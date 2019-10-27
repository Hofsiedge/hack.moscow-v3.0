using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;

namespace FeatureOfEducationDesktop
{
    public partial class Login : Form
    {
        private static readonly HttpClient httpClient = new HttpClient();

        private static readonly string detectorURL = "http://192.168.43.32:5050/test";

        public Login()
        {
            InitializeComponent();
            this.MinimumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width / 2,Screen.PrimaryScreen.WorkingArea.Height / 2);


        }

        private async void button1_Click(object sender, EventArgs e)
        {
            HttpResponseMessage response = null;
            try
            {
                response = await httpClient.PostAsync(detectorURL, new StringContent($"{{\"login\": \"{loginText.Text}\", \"password\": \"{passwordText.Text}\"}}", Encoding.UTF8, "application/json"));
                var jsonString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    teacher.id = GetID(jsonString.Substring(18, jsonString.Length - 20));
                    
                    this.Hide();
                    Form a = new Form2();
                    a.Location = this.Location;

                    a.Size = this.Size;
                    a.Show();
                    a.SetDesktopLocation(DesktopLocation.X, DesktopLocation.Y);
                }
                else
                {
                    isCorret.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        int GetID(string inp)
        {
            
            return int.Parse(inp);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form a = new Form3();
            a.Location = this.Location;
            a.Size = this.Size;
            a.Show();
            a.SetDesktopLocation(DesktopLocation.X, DesktopLocation.Y);
        }
    }
}
