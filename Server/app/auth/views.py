from flask import redirect, request, url_for, #, g
from flask_login import login_user, login_required, logout_user, current_user
from . import auth

@auth.route('/login')
def login():
    return ''
