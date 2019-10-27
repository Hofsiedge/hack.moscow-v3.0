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
    public partial class Form2 : Form
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly string detectorURL = "http://192.168.43.32:5050/teacher/";
        private static readonly string detectURL = "http://192.168.43.32:5050/class/";
        private static readonly string subjectsURL = "http://192.168.43.32:5050/subject/";
        private static readonly string generateURL = "http://192.168.43.32:5050/practice/";
        private static readonly string tasksURL = "http://192.168.43.32:5050/task/"; 
        private static readonly string assigtasksURL = "http://192.168.43.32:5050/assign_task/"; 
        private static readonly string worksURL = "http://192.168.43.32:5050/work/student/"; 


        Teacher teache = new Teacher();
        ClassStudent classStudent = new ClassStudent();
        Subjects subjects = new Subjects();
        Tasks tasks = new Tasks();
        Works works = new Works();
        static int idStudent;

        public Form2()
        {
            InitializeComponent();
            this.MinimumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width / 2, Screen.PrimaryScreen.WorkingArea.Height / 2);
            temp();
            
        }
        
        public async void temp()
        {
            subjects = await GetThemes();
            for (int i = 0; i < subjects.subjects.Count; i++)
                themes.Items.Add(subjects.subjects[i].name);

            tasks = await GetTasks();
            for (int i = 0; i < tasks.tasks.Count; i++)
            {
                tags.Items.Add(tasks.tasks[i].text);
            }

            teache = await getClasses();
            for (int i = 0; i < teache.classes.Count; i++)
            {
                Button button = new Button();
                button.Text = teache.classes[i].letter;
                button.Width = (int)(Classes.Width*0.8);
                button.Height = button.Height * 2;
                button.Left = (int)(Classes.Width * 0.02);
                button.Click += new System.EventHandler(but_click);
                Classes.Controls.Add(button);
            }
            
        }

        private void but_click(object sender, EventArgs e)
        {
            
            Button bt = (Button)sender;
            int idClass = teache.GetClassId(bt.Text);
            List<Control> listControls = students.Controls.Cast<Control>().ToList();

            foreach (Control control in listControls)
            {
                students.Controls.Remove(control);
                control.Dispose();
            }
            button3.Visible = false;
            temp2(idClass);
            doing.Visible = false;
            dificulty.Visible = false;
            tags.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            themes.Visible = false;
            submit.Visible = false;
            label1.Visible = false;
            label2.Visible = false;

        }

        public async void temp2(int idClass)
        {
            await HttpToClass(idClass);
            
            for (int i = 0; i < classStudent.students.Count; i++)
            {
                Button button = new Button();
                button.Text = classStudent.student_names[i];
                button.Width = (int)(students.Width * 0.8);
                button.Height = button.Height * 2;
                button.Left = (int)(students.Width * 0.02);
                
                button.Click += new System.EventHandler(but2_click);
                students.Controls.Add(button);
            }
            doing.Visible = true;
        }

        private void but2_click(object sender, EventArgs e)
        {

           idStudent = classStudent.GetStudentId(((Button)sender).Text);

            button1.Visible = true;
            createTask.Visible = false;
            homeworks.Visible = false;
            button2.Visible = true;
            button3.Visible = true;
            dificulty.Visible = false;
            tags.Visible = false;
            themes.Visible = false;
            submit.Visible = false;
            label1.Visible = false;
            label2.Visible = false;

        }

      
        public async Task<ClassStudent> HttpToClass(int id)
        {
            HttpResponseMessage response = null;
            try
            {
                response = await httpClient.GetAsync(detectURL + id);
                var jsonString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    classStudent.GetClassesStudent(jsonString);
                    return classStudent;
                }
                else
                {
                    MessageBox.Show("Fail");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }


        private async Task<Teacher> getClasses()
        {
            HttpResponseMessage response = null;
            try
            {
                response = await httpClient.GetAsync(detectorURL + teacher.id);
                var jsonString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                   
                    teache.GetClasses(jsonString);
                    return teache;
                }
                else
                {
                    MessageBox.Show("Fail");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
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
                    MessageBox.Show("Fail");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private async Task<Tasks> GetTasks()
        {
            HttpResponseMessage response = null;
            try
            {
                response = await httpClient.GetAsync(tasksURL);
                var jsonString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    tasks.GetTasks(jsonString);
                    return tasks;
                }
                else
                {
                    MessageBox.Show("Fail");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }


        private async void submit_Click(object sender, EventArgs e)       //<int:student_id>/<int:task_amount>/<int:subject_id>";
        {
            HttpResponseMessage response = null;
            try
            {
               response = await httpClient.GetAsync(generateURL +"?student_id="+ idStudent + "?task_amount=" + dificulty.Value + "?subject_id=" + subjects.GetStudentId(themes.Text));
                var jsonString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Success");
                    return;
                }
                else
                {
                    MessageBox.Show("Fail");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createTask.Visible = false;
            homeworks.Visible = false;
            dificulty.Visible = true;
            themes.Visible = true;
            submit.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            tags.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            createTask.Visible = true;
            homeworks.Visible = false;
            dificulty.Visible = true;
            themes.Visible = false;
            submit.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            tags.Visible = true;
        }

        private async void createTask_Click(object sender, EventArgs e)
        {
            List<Task> L = new List<Task>();
            for (int i = 0; i < tags.CheckedItems.Count; i++)
            {
                L.Add(tasks.Search(tags.CheckedItems[i].ToString()));
            }
            TaskPush taskPush = new TaskPush();
            taskPush.Create(L);

            HttpResponseMessage response = null;
            try
            {
                string ToPush = "{\"task_id\": [\"";
                ToPush += String.Join<int>("\", \"", taskPush.id) + "\"]}";
                response = await httpClient.PostAsync(assigtasksURL + $"?student_id={idStudent}", new StringContent(ToPush, Encoding.UTF8, "application/json"));
                var jsonString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Success");
                }
                else
                {
                    MessageBox.Show("Failed");
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var a = new Form1();
            this.Hide();
            a.Location = this.Location;

            a.Size = this.Size;
            a.Show();
            a.Activate();
            a.SetDesktopLocation(DesktopLocation.X, DesktopLocation.Y);
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            HttpResponseMessage response = null;
            try
            {
                dificulty.Visible = false;
                themes.Visible = false;
                submit.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                tags.Visible = false;
                createTask.Visible = false;
              
                homeworks.Visible = true;
                response = await httpClient.GetAsync(worksURL+idStudent);
                var jsonString = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    homeworks.Controls.Clear();
                    works.GetSubjects(jsonString);
                    for(int i = 0; i < works.works.Count; i++)
                    {
                        Button button = new Button();
                        button.Text = works.works[i].name;
                        button.Width = (int)(homeworks.Width * 0.8);
                        button.Height = button.Height * 2;
                        button.Left = (int)(homeworks.Width * 0.02);
                        button.Click += new System.EventHandler(hometask_click);
                        homeworks.Controls.Add(button);
                    }
                }
                else
                {
                    MessageBox.Show("Fail");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return ;
            }
        }

        private void hometask_click(object sender, EventArgs e)
        {
            Work curwork = works.GetWorkByName(((Button)sender).Text);
            MessageBox.Show(subjects.GetStudentName(curwork.subject_id) + "\n" + curwork.outOfAll());
        }

        private void doing_Paint(object sender, PaintEventArgs e)
        {

        }

        private void homeworks_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Classes_Paint(object sender, PaintEventArgs e)
        {

        }
    }


    class TaskPush
    {
        public List<int> id = new List<int>();

        public void Create(List<Task> tasks)
        {
            List<int> id = new List<int>();
            for (int i = 0; i < tasks.Count; i++)
                id.Add(tasks[i].id);
            this.id = id;
        }
    }
}
