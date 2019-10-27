from random import choice, randint
import os
from app import create_app, db
from app.models import *

from flask_script import Shell, Manager
import random, string

def randomword(length):
    letters = string.ascii_lowercase
    return ''.join(random.choice(letters) for i in range(length))

application = create_app(os.getenv('FLASK_CONFIG') or 'default')
manager = Manager(application)

def make_shell_context():
    return dict(application=application, db=db)

manager.add_command('shell', Shell(make_context=make_shell_context))

@manager.command
def run():
    application.run(host='0.0.0.0', port='5050')

@manager.command
def create_DB():
    db.create_all()
    db.session.commit()

@manager.command
def fill_DB():

    names       = 'Vasily Maria Katerin Daniil Alexander Anna Vitaly'.split()
    surnames    = [f'Surname{i}' for i in range(1, 7)]
    patronymics = [f'Patronymic{i}' for i in range(1, 7)]

    numbers     = [i for i in range(1, 5)]
    letters     = ['A', 'B', 'C', 'D', 'E', 'F']

    words = [f'Theme{i}' for i in range(1, 21)]

    teacher1    = Teacher(name='TeacherName1', surname='TSurname1', patronymic='TPatronymic1')
    teacher2    = Teacher(name='TeacherName2', surname='TSurname2', patronymic='TPatronymic2')

    classes = [Class(num=1, letter='A', teacher=teacher1),
               Class(num=2, letter='B', teacher=teacher1),
               Class(num=3, letter='C', teacher=teacher1),
               Class(num=1, letter='A', teacher=teacher2),
               Class(num=4, letter='F', teacher=teacher2),
               Class(num=1, letter='C', teacher=teacher2)]

    print(choice(names), choice(surnames), choice(patronymics), choice(classes), choice(letters))

    students = [Student(name=choice(names), 
                        surname=choice(surnames), 
                        patronymic=choice(patronymics),
                        class_=choice(classes)) for i in range(120)]

    subjects = [Subject(name='Math', teacher=teacher1), Subject(name='Programming', teacher=teacher2)]

    themes  = [Theme(name=words[i], subject=choice(subjects)) for i in range(len(words))]

    tasks = [Task(difficulty=randint(0, 10), text=f'Task{i}', answer_type=0, subject=choice(subjects)) for i in range(len(themes))]

    works = [Work(name=f'Work{i}', student=choice(students)) for i in range(100)]
    for work in works:
        work.tasks.extend(random.sample(tasks, k=randint(5, 15)))

    answers = [Answer(student=choice(students), answer_type=0, text=randomword(10), grade=randint(0, 10), assignment=choice(tasks)) for i in range(500)]


    db.session.add_all([*students, *subjects, *themes, *works, *tasks, *classes, teacher1, teacher2, *answers, *themes])
    
    db.session.commit()

    for task in tasks:
        current_themes = random.sample(themes, k=randint(0, 7))
        for theme in current_themes:
            task.themes.append(theme)
        db.session.add(task)
        db.session.commit()

@manager.command
def drop_DB():
    db.drop_all()

@manager.command
def deploy():
    """ Drop, preset and run """
    db.drop_all()
    create_DB()
    app.run()

if __name__ == "__main__":
    manager.run()

# application.run(host='0.0.0.0', port=5050)

