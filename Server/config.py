import os

BASEDIR = os.path.abspath(os.path.dirname(__file__))

print('BASEDIR: ', BASEDIR)

class Config:
    CSRF_ENABLED 	= True
    SECRET_KEY 		= os.environ.get('SECRET_KEY')
    # SQLALCHEMY_DATABASE_URI = 'sqlite:///' + os.path.join(BASEDIR, '/hack.db') 
    SQLALCHEMY_DATABASE_URI = 'sqlite:////media/hofsiedge/A86057C760579AC0/Projects/Hackathons/Hack.Moscow 3.0/hack.db'
    
    SQLALCHEMY_TRACK_MODIFICATIONS = False
    
    @staticmethod
    def init_app(app):
        pass


class DevelopmentConfig(Config):
    DEBUG = True
    SQLALCHEMY_DATABASE_URI = 'sqlite:////media/hofsiedge/A86057C760579AC0/Projects/Hackathons/Hack.Moscow 3.0/hack.db'


class TestingConfig(Config):
    DEBUG = True


class ProductionConfig(Config):
    DEBUG = False

config = {
    'development': 	DevelopmentConfig,
    'testing': 		TestingConfig,
    'production': 	ProductionConfig,
    'default': 		DevelopmentConfig
}
