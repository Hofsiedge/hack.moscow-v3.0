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

namespace FutureOfEducation2
{
    [Activity(Label = "TaskListActivity")]
    public class TaskListActivity : Activity
    {
        /*
        protected async override void OnResume()
        {
            base.OnResume();

            Intent intent = new Intent(this, typeof(TaskListActivity));
            StartActivity(intent);
            Finish();
        }
        */

        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Task_List_Activity);

            ListView listView = FindViewById<ListView>(Resource.Id.listView1);
            Button filter = FindViewById<Button>(Resource.Id.button1);



            int pos = Intent.GetIntExtra("Subject", 42);


            List<Theme> list = new List<Theme>();
            List<Task> tasks = new List<Task>();

            if (!StaticStore.isFilted)
            {
                Theme tem; string jsonstr;
                foreach (int a in StaticStore.subjects.subjects[pos].themes)
                {
                    try
                    {
                        jsonstr = await LocalConnection.getJsonLine("/theme/" + a);
                        tem = FutureOfEducation2.Theme.GetTheme(jsonstr);
                        list.Add(tem);
                    }
                    catch
                    {
                        jsonstr = await LocalConnection.getJsonLine("/theme/" + a);
                        tem = FutureOfEducation2.Theme.GetTheme(jsonstr);
                        list.Add(tem);
                    }

                    foreach (var ex in tem.tasks)
                    {
                        try
                        {
                            jsonstr = await LocalConnection.getJsonLine("/task/" + ex);
                            tasks.Add(Task.GetTheme(jsonstr));
                        }
                        catch
                        {
                            jsonstr = await LocalConnection.getJsonLine("/task/" + ex);
                            tasks.Add(Task.GetTheme(jsonstr));
                        }
                    }
                }

                StaticStore.themes = list;
                StaticStore.tasks = tasks;

                if (tasks == null || tasks.Count == 0)
                {
                    Toast.MakeText(this, "All tasks are done or error", ToastLength.Short).Show();
                    Finish();
                }
            }
            else
            {
                list = StaticStore.themes;
                tasks = StaticStore.tasks;
            }





            List<string> array = new List<string>();
            StaticStore.Filtertasks = new List<Task>();

            if (StaticStore.isFilted)
                foreach (var item in StaticStore.tasks)
                {
                    bool flag = false;
                    foreach (var theme in item.themes)
                    {
                        for (int i = 0; i < StaticStore.themes.Count; i++)
                        {
                            if (theme == StaticStore.themes[i].id)
                            {
                                flag = flag || StaticStore.goodThemes[i];
                                break;
                            }
                        }
                    }
                    if (flag && Math.Abs(item.difficulty - StaticStore.difficulty) <= 1)
                    {
                        array.Add(item.name);
                        StaticStore.Filtertasks.Add(item);
                    }
                }
            else
            {
                for (int i = 0; i < tasks.Count; i++)
                    if (tasks[i].name != null)
                        array.Add(tasks[i].name);
                    else
                        array.Add("No name task №" + tasks[i].id);
                StaticStore.Filtertasks = StaticStore.tasks;
            }


            listView.Adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, array);

            listView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs e)
            {
                Intent intent = new Intent(this, typeof(TaskActivity));
                intent.PutExtra("Task", e.Position);
                StartActivity(intent);

                //Finish();
            };

            filter.Click += delegate
            {
                Intent intent = new Intent(this, typeof(FilterActivity));
                StartActivity(intent);
            };

            StaticStore.goodThemes = new bool[StaticStore.themes.Count];
            Array.Fill(StaticStore.goodThemes, true);
        }
    }
}