using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace FeatureOfEducationDesktop
{
    class Teacher
    {
       
        public string name, surname;
        public List<int> subjects = new List<int>();
        public string patronymic;
        public List<Class> classes = new List<Class>();
        public int id;

        public void GetClasses(string json)
        {
            var JSSerializer = new JavaScriptSerializer();
            Teacher classes = JSSerializer.Deserialize<Teacher>(json);
            this.name = classes.name;
            this.surname = classes.surname;
            this.subjects= classes.subjects;
            this.patronymic = classes.patronymic;
            this.classes = classes.classes;
        }

        public int GetClassId(string name)
        {
            for(int i = 0; i < classes.Count; i++)
            {
                if (classes[i].letter == name) return classes[i].id;
            }
            return -1;
        }
    }



    class Class
    {
        public string letter;
        public int id;
    }
}
