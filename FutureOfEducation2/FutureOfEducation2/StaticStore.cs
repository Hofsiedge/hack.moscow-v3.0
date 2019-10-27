using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace FutureOfEducation2
{
    public static class StaticStore
    {
        public static Subjects subjects = new Subjects();
        public static List<Theme> themes = new List<Theme>();
        public static List<Task> tasks = new List<Task>();
        public static List<Task> Filtertasks = new List<Task>();
        public static bool[] goodThemes;
        public static bool isHomeWork = true;
        public static int difficulty = 0;
        public static bool isFilted = false;
    }

    public class Task
    {
        public string name;
        public int answer_type;
        public int difficulty;
        public int id;
        public string text;
        public List<int> themes = new List<int>();

        public static Task GetTheme(string json)
        {
            return JsonConvert.DeserializeObject<Task>(json);
        }
    }

    public class Theme
    {
        public int id;
        public string name;
        public int subject_id;
        public List<int> tasks = new List<int>();

        public static Theme GetTheme(string json)
        {
            return JsonConvert.DeserializeObject<Theme>(json);
        }
    }


    public class Subject
    {
        public int id;
        public string name;
        public int teacher;
        public List<int> themes = new List<int>();

    }

    public class Subjects
    {
        public List<Subject> subjects = new List<Subject>();

        public static List<Subject> GetSubjects(string json)
        {
            return JsonConvert.DeserializeObject<Subjects>(json).subjects;
        }
    }
}