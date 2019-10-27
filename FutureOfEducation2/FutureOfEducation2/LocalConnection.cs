using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace FutureOfEducation2
{
    public static class LocalConnection
    {
        public static string Message { get; private set; }
        static string Url = "http://192.168.43.32:5050";



        public async static Task<bool> Test()
        {
            string a = await getJsonLine("/subject/");
            return a != null && a != "";
        }

        public async static Task<string> getJsonLine(string add)
        {
            string jsonString = "";
            HttpResponseMessage response = null;
            HttpClient httpClient = new HttpClient();
            List<Subject> list1 = new List<Subject>();

                try
                {
                    response = await httpClient.GetAsync(Url + add);
                    jsonString = await response.Content.ReadAsStringAsync();
                }
                catch { }

            if (response != null && response.IsSuccessStatusCode)
            {
                Message = "";
            }
            else
            {
                Message = "error";
            }
            return jsonString;
        }

    }



}