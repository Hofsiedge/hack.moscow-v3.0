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
using System.Web.Script.Serialization;

namespace FeatureOfEducationDesktop
{
    public partial class Form1 : Form, FormsInterface
    {

        private static readonly string subjectsURL = "http://192.168.43.32:5050/subject/";
        private static readonly string detectorURL = "http://192.168.43.32:5050/task";
        private static readonly string themeURL = "http://192.168.43.32:5050/theme/";

        private static readonly HttpClient httpClient = new HttpClient();
        public static Form[] forms = new Form[5];
        Subjects subjects = new Subjects();
        Themes theme = new Themes();

        public Form1()
        {
            InitializeComponent();
            this.MinimumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2);
            tmp();
           
        }

        public async void tmp()
        {
            subjects = await GetThemes();
            for (int i = 0; i < subjects.subjects.Count; i++)
                subj.Items.Add(subjects.subjects[i].name);

            theme = await GetTheme();
        }

        private async Task<Themes> GetTheme()
        {
            HttpResponseMessage response = null;
            try
            {
                response = await httpClient.GetAsync(themeURL);
                var jsonString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    theme.GetThemes(jsonString);
                    return theme;
                }
                else
                {
                    MessageBox.Show(jsonString);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private async Task<Subjects> GetThemes()
        {
            HttpResponseMessage response = null;
            try
            {
                response = await httpClient.GetAsync(subjectsURL);
                var jsonString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    subjects.GetSubjects(jsonString);
                    return subjects;
                }
                else
                {
                    MessageBox.Show(jsonString);
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }


        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var a = forms[0];
            this.Hide();
            a.Location = this.Location;
            
            a.Size = this.Size;
            a.Show();
            a.SetDesktopLocation(DesktopLocation.X, DesktopLocation.Y);
        }

        private void teacherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var a = forms[0];
            this.Hide();
            a.Location = this.Location;

            a.Size = this.Size;
            a.Show();
            a.SetDesktopLocation(DesktopLocation.X, DesktopLocation.Y);
        }

        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void taskMenu_Click(object sender, EventArgs e)
        {
            var a = new Form2();
            this.Hide(); 
            a.Location = this.Location;

            a.Size = this.Size;
            a.Show();
            a.Activate();
            a.SetDesktopLocation(DesktopLocation.X, DesktopLocation.Y);
        }

        private void subj_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Control> listControls = tags.Controls.Cast<Control>().ToList();
            tags.Items.Clear(); ;
             

            for (int i = 0; i < subjects.subjects[subj.SelectedIndex].themes.Count; i++)
                tags.Items.Add(theme.GetName(subjects.subjects[subj.SelectedIndex].themes[i]));
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            ToIlya toIlya = new ToIlya();
            toIlya.answer.Add(answerText.Text);
            toIlya.difficulty = dificulty.Value;
            toIlya.answer_type = 0;
            toIlya.text = taskText.Text;
            toIlya.subject_id = subjects.GetStudentId(subj.SelectedItem.ToString());
            for (int i = 0; i < tags.CheckedItems.Count; i++)
            {
               
               toIlya.themes.Add(theme.GetId(tags.CheckedItems[i].ToString()));
            }
            var JSSerializer = new JavaScriptSerializer();
            string jsonStr = JSSerializer.Serialize(toIlya);
            HttpResponseMessage response = null;
            try
            {
                response = await httpClient.PostAsync(detectorURL, new StringContent(jsonStr, Encoding.UTF8, "application/json"));
                var jsonString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Success");
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

        class Themes
        {
            public List<themes> themes = new List<themes>();

            public void GetThemes(string json)
            {
                var JSSerializer = new JavaScriptSerializer();
                Themes works = JSSerializer.Deserialize<Themes>(json);
                this.themes = works.themes;
            }

            public string GetName(int id)
            {
                for (int i = 0; i < themes.Count; i++)
                {
                    if (themes[i].id == id) return themes[i].name;
                }
                return null;
            }

            public int GetId(string name)
            {
                for (int i = 0; i < themes.Count; i++)
                {
                    if (themes[i].name == name) return themes[i].id;
                }
                return -1;
            }
        }

        class themes
        {
            public int id;
            public string name;
        }


        class ToIlya
        {
            public int subject_id;
            public int answer_type;
            public int difficulty;
            public string text;
            public List<int> themes = new List<int>();
            public List<string> answer = new List<string>();
        }

    }
}
