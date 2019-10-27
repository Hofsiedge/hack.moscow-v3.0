from functools import reduce
import numpy as np
from sqlalchemy.sql import select
from flask import Flask, render_template, flash, request, jsonify, abort
from . import main 
from .. import db
from ..models import Student, Teacher, Class, Subject, Task, Theme, Work, CorrectAnswer, Answer

class Placeholder:
    text    = ''
    grade   = 0

@main.route('/test', methods=['GET', 'POST'])
def test():
    test_password = 'Test'
    print(request)
    content = request.json
    print(content)
    return jsonify({'teacher_id': 1}), 200 if content['password'] == test_password else 403

@main.route('/teacher/<int:teacher_id>')
def get_teacher(teacher_id):
    teacher = Teacher.query.get(teacher_id)
    return jsonify({
        'id':           teacher.id,
        'surname':      teacher.surname,
        'name':         teacher.name,
        'patronymic':   teacher.patronymic,
        'classes':      [{'letter': f'{class_.num}{class_.letter}', 'id': class_.id} 
                         for class_ in teacher.classes],
        'subjects':     [subject.id for subject in teacher.subjects]
    })

@main.route('/class/<int:class_id>')
def get_class(class_id):
    class_ = Class.query.get(class_id)
    return jsonify({
        'id':               class_.id,
        'name':             f'{class_.num}{class_.letter}',
        'teacher':          class_.teacher_id,
        'students':         [student.id for student in class_.students],
        'student_names':    [f'{student.surname} {student.name} {student.patronymic}' for student in class_.students]
    })

@main.route('/student/<int:student_id>')
def get_student(student_id):
    student = Student.query.get(student_id)
    return jsonify({
        'id':           student.id,
        'surname':      student.surname,
        'name':         student.name,
        'patronimyc':   student.patronymic,
        'class_':       student.class_.id
    })

@main.route('/subject/')
@main.route('/subject/<int:subject_id>')
def get_subject(subject_id=None):
    if subject_id is None:
        subjects = Subject.query.all()
        return jsonify({
            "subjects": [{
                'id':       subj.id,
                'teacher':  subj.teacher_id, 
                'name':     subj.name, 
                'themes':   [theme.id for theme in subj.themes]} for subj in subjects]
        })
    else:
        subject = Subject.query.get(subject_id)
        return jsonify({
            'id':       subject.id,
            'teacher':  subject.teacher_id,
            'name':     subject.name,
            'themes':   [theme.id for theme in subject.themes]
        })

@main.route('/theme/', methods=['GET'])
@main.route('/theme/<int:theme_id>', methods=['GET'])
def get_theme(theme_id=None):
    if theme_id is not None:
        theme = Theme.query.get(theme_id)
        return jsonify({
            "id":           theme.id,
            "name":         theme.name,
            "subject_id":   theme.subject_id,
            "tasks":        [task.id for task in theme.tasks]
        })
    return jsonify({
        "themes": [{'id': theme.id, 'name':theme.name} for theme in Theme.query.all()]
    })
    


@main.route('/task/', methods=['GET'])
@main.route('/task/<int:task_id>', methods=['GET'])
def get_task(task_id=None):
    if task_id is not None:
        task = Task.query.get(task_id)
        return jsonify({
            'id':           task.id,
            'name':         task.name,
            'difficulty':   task.difficulty,
            'text':         task.text,
            'answer_type':  task.answer_type,
            'themes':       [theme.id for theme in task.themes]
        })
    else:
        subject_id = request.args.get('subject_id', default=0, type=int)
        theme_id = request.args.get('theme_id', default=0, type=int)
        tasks = None
        if theme_id:
            tasks = Theme.query.get(theme_id).tasks
        elif subject_id:
            tasks = Subject.query.get(subject_id).tasks
        else:
            tasks = Task.query.all()
    return jsonify({
        "tasks": [{
            "id":           task.id,
            'name':         task.name,
            "difficulty":   task.difficulty,
            "text":         task.text,
            "answer_type":  task.answer_type,
            "themes":       [theme.id for theme in task.themes]
        } for task in tasks],
    })

@main.route('/task', methods=['POST'])
def create_task():
    data = request.json
    if data is None:
        return '', 400

    difficulty  = data.get('difficulty', None)
    text        = data.get('text', None)
    name        = data.get('name', None)
    subject_id  = data.get('subject_id', None)
    themes      = data.get('themes', None)

    task = Task(
        difficulty=int(difficulty), 
        text=text,
        name=name,
        answer_type=0,
        subject=Subject.query.get(subject_id))
    task.themes.extend([Theme.query.get(theme_id) for theme_id in themes])

    correct_answers = data.get('correct_answer', None)


    db.session.add(task)
    db.session.commit()

    return jsonify({
        'task_id':   task.id
    })

# ? student_id=None, task_amount=10, subject_id=None, 
@main.route('/practice/')
def get_practice_tasks():
    tasks = Task.query.all()
    subj_id = request.args.get('subject_id', default=0, type=int)
    if subj_id:
        tasks = Task.query.filter(Task.subject_id == subj_id)
    
    filtered = Answer.query.filter(Answer.student_id == request.args['student_id']).order_by(Answer.id.asc()).all()
    EMA = reduce(lambda a, b: 0.75 * a + 0.25 * b, map(lambda x: x.grade, filtered), 5)
    value_func = lambda x: np.exp(-np.power(x - EMA, 2.) / 2)

    # mapped = map(value_func, Task.difficulty)
    # listed = list(mapped)
    listed = [value_func(x.difficulty) for x in Task.query]
    sorted_by_value = np.argsort(listed)
    indices = np.array([x.id for x in Task.query])[sorted_by_value].tolist()

    ## result = db.session.query(Task).order_by(*indices) .limit(request.args.get('task_amount', 10, int))
    pairs   = list(zip(sorted_by_value, indices))
    indices = [x[1] for x in sorted(pairs)][:request.args.get('task_amount', 10, int)]


    return jsonify({
        "tasks": [id for id in indices]
        # "tasks": [task.id for task in result]
    })

@main.route('/assign_task/', methods=['POST', 'GET'])
def assign_task():
    data = request.json
    if data is None:
        return '', 400
    task_ids = data.get('task_id', None)
    if task_ids is not None:
        student_id = request.args.get('student_id', 0, int)

        db.session.add_all([Assignment(task=Task.query.get(task_id), student=Student.get(student_id)) 
                    for task_id in task_ids])
        db.session.commit()

        return '', 200
    else:
        abort(400)

@main.route('/work/', methods=['GET'])
@main.route('/work/<int:work_id>', methods=['GET'])
def get_work(work_id=None):
    if work_id is not None:
        work = Work.query.get(work_id)
        return jsonify({
            'id':       work.id,
            'name':     work.name,
            'tasks':    [
                {
                    'id':           task.id,
                    'answer_pupil': \
                    (Answer.query.filter((Answer.assignment == task) & (Student.id == work.student_id)).first() or Placeholder).text,
                    'answer_real':  [ans.text for ans in task.correct_answers]
                } for task in work.tasks 
            ]
        })
    works = Work.query.all()
    return jsonify({
        'works':    [{
            'id':       work.id,
            'name':     work.name,
            'tasks':    [
                {
                    'id':           task.id,
                    'answer_pupil': \
                    (Answer.query.filter((Answer.assignment == task) & (Student.id == work.student_id)).first() or Placeholder).text,
                    'answer_real':  [ans.text for ans in task.correct_answers]
                } for task in work.t
            ]
        } for work in works]
    })

@main.route('/work/student/<int:student_id>')
def get_student_works(student_id):
    student = Student.query.get(student_id)
    return jsonify({
        "works": [{'id': work.id,
                   'name': work.name,
                   'tasks': [
                       {
                           'id': task.id,
                           'answer_pupil': \
                           (Answer.query.filter((Answer.assignment == task) & (Student.id == work.student_id)).first() or Placeholder).text,
                           'answer_real':  [ans.text for ans in task.correct_answers],
                    'grade': \
                    (Answer.query.filter((Answer.assignment == task) & (Student.id == work.student_id)).first() or Placeholder).grade
                       } for task in work.tasks ]
                  } for work in student.works
                 ]
    })

@main.route('/auth/login')
def login():
    return '', 200
