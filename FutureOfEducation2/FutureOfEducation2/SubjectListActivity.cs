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
    [Activity(Label = "SubjectListActivity")]
    public class SubjectListActivity : Activity
    {


        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Subject_list_activity);

            ListView listView = FindViewById<ListView>(Resource.Id.listView1);
            TextView textView = FindViewById<TextView>(Resource.Id.textView1);

            //GetStringFromServer
            


            string json = await LocalConnection.getJsonLine("/subject/");
            //Deserialize
            var list1 = Subjects.GetSubjects(json);
            StaticStore.subjects.subjects = list1;


            if (json == null || json == "" || list1 == null || list1.Count == 0)
            {
                var a = Toast.MakeText(this, "Connection Faild", ToastLength.Short);
                a.Show();
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
                Finish();
            }


            List<string> list = new List<string>();
            for (int i = 0; i < list1.Count; i++)
                list.Add(list1[i].name);

            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, list);


            if(list.Count != 0)
                listView.Adapter = adapter;
            else
            {
                Intent intent = new Intent(this, typeof(MainActivity));
                StartActivity(intent);
            }

            listView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs e) 
            {
                StaticStore.isFilted = false;
                Intent intent = new Intent(this, typeof(TaskListActivity));
                intent.PutExtra("Subject", e.Position);                                   
                StartActivity(intent);
                //Finish();
            };

            
        }
    }
}