from . import db 
from werkzeug.security import generate_password_hash, check_password_hash
from flask import current_app


class Class(db.Model):
    __tablename__   = 'class'
    id              = db.Column(db.Integer, primary_key=True)
    num             = db.Column(db.Integer)
    letter          = db.Column(db.String(1))
    teacher_id      = db.Column(db.Integer, db.ForeignKey('teacher.id'), nullable=False)
    teacher         = db.relationship('Teacher',
                                      backref=db.backref('classes', lazy=True))

    def __repr__(self):
        return f'<Class {self.num}{self.letter}>'
    

class Student(db.Model):
    __tablename__   = 'student'
    id              = db.Column(db.Integer, primary_key=True)
    surname         = db.Column(db.String(64))
    name            = db.Column(db.String(64))
    patronymic      = db.Column(db.String(64))
    class_id        = db.Column(db.Integer, db.ForeignKey('class.id'), nullable=False)
    class_          = db.relationship('Class',
                                      backref=db.backref('students', lazy=True))

    def __repr__(self):
        return f'<Student {self.name } {self.surname} {self.patronymic}: {self.class_}>'


class Teacher(db.Model):
    __tablename__   = 'teacher'
    id              = db.Column(db.Integer, primary_key=True)
    surname         = db.Column(db.String(64))
    name            = db.Column(db.String(64))
    patronymic      = db.Column(db.String(64))
    # classes


task_asc_table = db.Table( # Task to Theme m2m
    'task_asc_table',
    db.Column('theme',  db.Integer, db.ForeignKey('theme.id'),  primary_key=True),
    db.Column('task',   db.Integer, db.ForeignKey('task.id'),   primary_key=True)
)

work_asc_table = db.Table( # Work to Theme m2m
    'work_asc_table',
    db.Column('work',   db.Integer, db.ForeignKey('work.id'),   primary_key=True),
    db.Column('task',   db.Integer, db.ForeignKey('task.id'),   primary_key=True)
)


class Task(db.Model):
    __tablename__   = 'task'
    id              = db.Column(db.Integer, primary_key=True)
    difficulty      = db.Column(db.Integer)
    text            = db.Column(db.String(1024))
    answer_type     = db.Column(db.Integer)

    subject_id      = db.Column(db.Integer, db.ForeignKey('subject.id'), nullable=False)
    subject         = db.relationship('Subject', backref=db.backref('tasks', lazy=True))

    name            = db.Column(db.String(128))

    themes          = db.relationship(
        'Theme',
        secondary=task_asc_table,
        back_populates='tasks')

    works           = db.relationship(
        'Work',
        secondary=work_asc_table,
        back_populates='tasks')


    def __repr__(self):
        return f'<Task: {self.difficulty} {self.themes}>'



class Subject(db.Model):
    __tablename__   = 'subject'
    id              = db.Column(db.Integer, primary_key=True)
    name            = db.Column(db.String(128))
    teacher_id      = db.Column(db.Integer, db.ForeignKey('teacher.id'), nullable=False)
    teacher         = db.relationship('Teacher',
                                      backref=db.backref('subjects', lazy=True))

    def __repr__(self):
        return f"<Subject {self.name}>"


class Theme(db.Model):
    __tablename__   = 'theme'
    id              = db.Column(db.Integer, primary_key=True)
    name            = db.Column(db.String(128))
    subject_id      = db.Column(db.Integer, db.ForeignKey('subject.id'), nullable=False)
    subject         = db.relationship('Subject',
                                      backref=db.backref('themes', lazy=True))
    tasks         = db.relationship(
        'Task',
        secondary=task_asc_table,
        back_populates='themes')

    def __repr__(self):
        return f"<Theme {self.name}: {self.subject}>"


class Answer(db.Model):
    __tablename__   = 'answer'
    id              = db.Column(db.Integer, primary_key=True)
    student_id      = db.Column(db.Integer, db.ForeignKey('student.id'))
    student         = db.relationship('Student', backref=db.backref('answers', lazy=True))
    answer_type     = db.Column(db.Integer)
    text            = db.Column(db.String(128))
    grade           = db.Column(db.Integer)
    assignment_id   = db.Column(db.Integer, db.ForeignKey('task.id'))# , nullable=False)
    assignment      = db.relationship('Task', 
                                      backref=db.backref('answers', lazy=True))

class CorrectAnswer(db.Model):
    __tablename__   = 'correct_answer'
    id              = db.Column(db.Integer, primary_key=True)
    answer_type     = db.Column(db.Integer)
    text            = db.Column(db.String(128))
    task_id         = db.Column(db.Integer, db.ForeignKey('task.id'))# , nullable=False)
    task            = db.relationship('Task', 
                                      backref=db.backref('correct_answers', lazy=True))


class Work(db.Model):
    __tablename__   = 'work'
    id              = db.Column(db.Integer, primary_key=True)
    task_id         = db.Column(db.Integer, db.ForeignKey('task.id'))
    tasks           = db.relationship(
        'Task',
        secondary=work_asc_table,
        back_populates='works')
    
    name            = db.Column(db.String(128))

    student_id      = db.Column(db.Integer, db.ForeignKey('student.id'), nullable=False)
    student         = db.relationship('Student',
                                      backref=db.backref('works', lazy=True))

    def __repr__(self):
        return f'<Work {self.tasks}>'

    # tasks
    # deadline
    # students
    # 
