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
    [Activity(Label = "TaskActivity")]
    public class TaskActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TaskActivity);
            Window.SetSoftInputMode(SoftInput.AdjustPan);

            int pos = Intent.GetIntExtra("Task", 42);
            var thisTask = StaticStore.tasks[pos];


            TextView nameView = FindViewById<TextView>(Resource.Id.textView1);
            TextView textView = FindViewById<TextView>(Resource.Id.textView2);

            if (thisTask.name != null)
                nameView.Text = thisTask.name;
            else
                nameView.Text = "No name task №" + thisTask.id;

            string text = "";

            if (thisTask.text == null)
            {
                for (int i = 0; i < 20; i++)
                    text += "\n" + i + ". Sample Text";
            }
            else
                text = thisTask.text;

            textView.Text = text;

            Button tags = FindViewById<Button>(Resource.Id.button1);
            Button submit = FindViewById<Button>(Resource.Id.button2);

            tags.Click += delegate
            {
                AlertDialog.Builder a = new AlertDialog.Builder(this);
                a.SetMessage(text);
                a.SetTitle("Tags");
                a.SetPositiveButton("Ok", (senderAlert, args) => { });
                a.SetCancelable(true);
                a.Create().Show();
            };

            submit.Click += delegate
            {
                Finish();
            };
        }
    }
}