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
    [Activity(Label = "FilterActivity")]
    public class FilterActivity : Activity
    {

        public class MyAdapter : ArrayAdapter<string>
        {
            List<string> mas;
            Context con;
            public MyAdapter(Context context, int a, List<string> list) : base(context, a, list)
            {
                mas = list;
                con = context;
            }

            public override View GetView(int position, View convertView, ViewGroup parent)
            {
                CheckBox a = new CheckBox(con);
                a.Checked = StaticStore.goodThemes[position];

                a.Click += delegate
                {
                    StaticStore.goodThemes[position] = a.Checked;
                };

                a.Text = mas[position];

                return a;
            }
        }


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Filter_layout);

            ListView listView = FindViewById<ListView>(Resource.Id.listView1);
            CheckBox type = FindViewById<CheckBox>(Resource.Id.checkBox1);
            SeekBar bar = FindViewById<SeekBar>(Resource.Id.seekBar1);
            bar.Max = 10;
            TextView textView = FindViewById<TextView>(Resource.Id.textView2);

            bar.ProgressChanged += delegate (object sender, SeekBar.ProgressChangedEventArgs e)
            {
                StaticStore.difficulty = bar.Progress;
                textView.Text = "Dyfficulty = " + e.Progress;
            };

            bar.Progress = StaticStore.difficulty;

            StaticStore.isFilted = true;

            type.Checked = StaticStore.isHomeWork;
            if (type.Checked)
                type.Text = "HomeWork";
            else
                type.Text = "SelfTraining";

            type.Click += delegate
            {
                StaticStore.isHomeWork = type.Checked;

                if (type.Checked)
                    type.Text = "HomeWork";
                else
                    type.Text = "SelfTraining";
            };

            List<string> array = new List<string>();

            for (int i = 0; i < StaticStore.themes.Count; i++)
                array.Add(i + ". " + StaticStore.themes[i].name);

            listView.Adapter = new MyAdapter(this, Android.Resource.Layout.SimpleListItem1, array);

            listView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs e)
            {
                Intent intent = new Intent(this, typeof(TaskActivity));
                intent.PutExtra("Film", array[e.Position]);
                StartActivity(intent);

                //Finish();
            };

        }


    }
}