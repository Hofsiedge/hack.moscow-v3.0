using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System.Net.Http;
using System;
using System.Net;
using Android.Content;
using System.Text;

namespace FutureOfEducation2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Login);

            Button btn = FindViewById<Button>(Resource.Id.button1);


            btn.Click += async delegate
            {
                TextView loginView = FindViewById<TextView>(Resource.Id.editText1);
                TextView passwordView = FindViewById<TextView>(Resource.Id.editText2);
                

                if (await LocalConnection.Test())//LocalConnection.Connect(loginView.Text, passwordView.Text))
                {
                    Intent intent = new Intent(this, typeof(SubjectListActivity));
                    StartActivity(intent);
                    Finish();
                }
                
            };
        }
    }
}