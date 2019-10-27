using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace FeatureOfEducationDesktop
{
    public class ClassStudent
    {
        public string name;
        public int teacher;
        public List<int> students = new List<int>();
        public List<string> student_names = new List<string>();
        public int id;

        public void GetClassesStudent(string json)
        {
            var JSSerializer = new JavaScriptSerializer();
            ClassStudent classStudent = JSSerializer.Deserialize<ClassStudent>(json);
            this.name = classStudent.name;
            this.teacher = classStudent.teacher;
            this.students = classStudent.students;
            this.student_names = classStudent.student_names;
        }

        public int GetStudentId(string name)
        {
            Console.WriteLine(name);
            Console.WriteLine(students.Count);
            for (int i = 0; i < student_names.Count; i++)
            {
                if (student_names[i] == name) return students[i];
            }
            return -1;
        }

    }

    
}
