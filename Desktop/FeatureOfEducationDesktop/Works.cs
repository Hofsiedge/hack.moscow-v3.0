using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace FeatureOfEducationDesktop
{

    class Works
    {
        public List<Work> works = new List<Work>();
        public int id;

        public void GetSubjects(string json)
        {
            var JSSerializer = new JavaScriptSerializer();
            Works works = JSSerializer.Deserialize<Works>(json);
            this.works = works.works;
            this.id = works.id;
        }

        public Work GetWorkByName(string name)
        {
            for (int i = 0; i < works.Count; i++)
            {
                if (works[i].name == name) return works[i];
            }
            return null;
        }
    }

    class Work
    {
        public List<task> tasks = new List<task>();
        public string name;
        public int id;
        public int subject_id;
       
        

        public int CorrectTasks()
        {
            int num = 0;
            for(int i = 0; i < tasks.Count; i++)
                for(int j = 0; j < tasks[i].answer_real.Count; j++)
                    if(tasks[i].answer_pupil.CompareTo(tasks[i].answer_real[j]) == 0)
                    {
                        num++;
                        break;
                    }
            return num;
        }

        public string outOfAll()
        {
            int sumgrade = 0;
            for (int i = 0; i < tasks.Count; i++)
                sumgrade += tasks[i].grade;
            return $"average score is {(double)sumgrade/tasks.Count:.02f}";
        }
    }

    class task
    {
        public string answer_pupil;
        public List<string> answer_real = new List<string>();
        public int id;
        public int grade;
    }
}
