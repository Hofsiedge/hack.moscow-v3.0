using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace FeatureOfEducationDesktop
{

    class Tasks
    {
        public List<Task> tasks = new List<Task>();
        public int id;
        public void GetTasks(string json)
        {
            var JSSerializer = new JavaScriptSerializer();
            Tasks classes = JSSerializer.Deserialize<Tasks>(json);
            this.tasks = classes.tasks;
            Console.WriteLine(tasks[0].text);
            
        }

        public Task Search(string text)
        {
            for(int i = 0; i < tasks.Count; i++)
            {
                if (tasks[i].text.CompareTo(text) == 0) return tasks[i];
            }
            return null;
        }
    }

    class Task
    {
        public string text;
        public List<int> themes = new List<int>();
        public int answer_type;
        public int difficulty;
        public int id;
        //тема название, текст, сложность id
    }
}
