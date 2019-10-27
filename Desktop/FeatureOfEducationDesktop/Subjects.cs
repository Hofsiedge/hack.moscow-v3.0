using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace FeatureOfEducationDesktop
{
   class Subject
    {
        public int id;
        public string name;
        public int teacher;
        public List<int> themes = new List<int>();
    }

    class Subjects
    {
        public int id;
        public List<Subject> subjects = new List<Subject>();

        public void GetSubjects(string json)
        {
            var JSSerializer = new JavaScriptSerializer();
            Subjects subjects = JSSerializer.Deserialize<Subjects>(json);
            this.subjects = subjects.subjects;
        }

        public int GetStudentId(string name)
        {
            Console.WriteLine(name);
            for (int i = 0; i < this.subjects.Count; i++)
            {
                
                if (subjects[i].name.CompareTo(name) == 0) {
 
                    return subjects[i].id;
                }
            }
            return -1;
        }


        public string GetStudentName(int id)
        {
            for (int i = 0; i < this.subjects.Count; i++)
            {

                if (subjects[i].id == id)
                {

                    return subjects[i].name;
                }
            }
            return null;
        }
    }


}
