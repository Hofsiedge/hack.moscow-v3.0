using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;

namespace FeatureOfEducationDesktop
{
    public partial class Form3 : Form
    {
        private static readonly HttpClient httpClient = new HttpClient();

        private static readonly string detectorURL = "http://192.168.43.32:5050/auth/login";

        public Form3()
        {
            InitializeComponent();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                radioButton1.Checked = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                radioButton2.Checked = false;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            HttpResponseMessage response = null;
            try
            {
                ClassToRegister classToRegister = new ClassToRegister();
                classToRegister.hashpassword = textBox3.Text.GetHashCode();
                classToRegister.sequrity_key = textBox1.Text.GetHashCode();
                classToRegister.login = textBox2.Text;
                classToRegister.person_type = radioButton1.Checked ? 'p' : 't';
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                string jsonStr = javaScriptSerializer.Serialize(classToRegister);

                response = await httpClient.PostAsync(detectorURL, new StringContent(jsonStr, Encoding.UTF8, "application/json"));
                var jsonString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Success");
                    this.Hide();
                    Form a = new Login();
                    a.Location = this.Location;

                    a.Size = this.Size;
                    a.Activate();
                    a.SetDesktopLocation(DesktopLocation.X, DesktopLocation.Y);
                }
                else
                {
                    MessageBox.Show("Fail");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var a = new Login();
            this.Hide();
            a.Location = this.Location;

            a.Size = this.Size;
            a.Show();
            a.Activate();
            a.SetDesktopLocation(DesktopLocation.X, DesktopLocation.Y);
        }
    }
}
