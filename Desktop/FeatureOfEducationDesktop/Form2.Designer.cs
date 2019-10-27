namespace FeatureOfEducationDesktop
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Classes = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taskMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.students = new System.Windows.Forms.FlowLayoutPanel();
            this.doing = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dificulty = new System.Windows.Forms.TrackBar();
            this.themes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.submit = new System.Windows.Forms.Button();
            this.tags = new System.Windows.Forms.CheckedListBox();
            this.createTask = new System.Windows.Forms.Button();
            this.homeworks = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.doing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dificulty)).BeginInit();
            this.SuspendLayout();
            // 
            // Classes
            // 
            this.Classes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.Classes.AutoScroll = true;
            this.Classes.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.Classes.Location = new System.Drawing.Point(12, 31);
            this.Classes.Name = "Classes";
            this.Classes.Size = new System.Drawing.Size(200, 387);
            this.Classes.TabIndex = 0;
            this.Classes.WrapContents = false;
            this.Classes.Paint += new System.Windows.Forms.PaintEventHandler(this.Classes_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.taskMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(950, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(62, 24);
            this.homeToolStripMenuItem.Text = "Home";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // taskMenu
            // 
            this.taskMenu.Name = "taskMenu";
            this.taskMenu.Size = new System.Drawing.Size(72, 24);
            this.taskMenu.Text = "Set task";
            this.taskMenu.Click += new System.EventHandler(this.taskMenu_Click);
            // 
            // students
            // 
            this.students.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.students.AutoScroll = true;
            this.students.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.students.Location = new System.Drawing.Point(235, 31);
            this.students.Name = "students";
            this.students.Size = new System.Drawing.Size(213, 387);
            this.students.TabIndex = 1;
            this.students.WrapContents = false;
            // 
            // doing
            // 
            this.doing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.doing.AutoScroll = true;
            this.doing.Controls.Add(this.button1);
            this.doing.Controls.Add(this.button2);
            this.doing.Controls.Add(this.button3);
            this.doing.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.doing.Location = new System.Drawing.Point(470, 31);
            this.doing.Name = "doing";
            this.doing.Size = new System.Drawing.Size(217, 387);
            this.doing.TabIndex = 2;
            this.doing.Visible = false;
            this.doing.WrapContents = false;
            this.doing.Paint += new System.Windows.Forms.PaintEventHandler(this.doing_Paint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(205, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Generate individual task";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(205, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Create task";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 61);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(205, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Look results of tasks";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dificulty
            // 
            this.dificulty.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dificulty.LargeChange = 1;
            this.dificulty.Location = new System.Drawing.Point(708, 34);
            this.dificulty.Minimum = 1;
            this.dificulty.Name = "dificulty";
            this.dificulty.Size = new System.Drawing.Size(230, 56);
            this.dificulty.TabIndex = 3;
            this.dificulty.Value = 1;
            this.dificulty.Visible = false;
            // 
            // themes
            // 
            this.themes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.themes.FormattingEnabled = true;
            this.themes.Location = new System.Drawing.Point(709, 97);
            this.themes.Name = "themes";
            this.themes.Size = new System.Drawing.Size(229, 24);
            this.themes.TabIndex = 4;
            this.themes.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(737, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "1";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(914, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "10";
            this.label2.Visible = false;
            // 
            // submit
            // 
            this.submit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.submit.Location = new System.Drawing.Point(708, 127);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(230, 38);
            this.submit.TabIndex = 7;
            this.submit.Text = "Submit";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Visible = false;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // tags
            // 
            this.tags.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tags.FormattingEnabled = true;
            this.tags.Location = new System.Drawing.Point(711, 97);
            this.tags.Name = "tags";
            this.tags.Size = new System.Drawing.Size(230, 106);
            this.tags.TabIndex = 8;
            this.tags.Visible = false;
            // 
            // createTask
            // 
            this.createTask.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.createTask.Location = new System.Drawing.Point(711, 210);
            this.createTask.Name = "createTask";
            this.createTask.Size = new System.Drawing.Size(230, 28);
            this.createTask.TabIndex = 9;
            this.createTask.Text = "Create";
            this.createTask.UseVisualStyleBackColor = true;
            this.createTask.Visible = false;
            this.createTask.Click += new System.EventHandler(this.createTask_Click);
            // 
            // homeworks
            // 
            this.homeworks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.homeworks.AutoScroll = true;
            this.homeworks.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.homeworks.Location = new System.Drawing.Point(709, 34);
            this.homeworks.Name = "homeworks";
            this.homeworks.Size = new System.Drawing.Size(229, 387);
            this.homeworks.TabIndex = 10;
            this.homeworks.Visible = false;
            this.homeworks.WrapContents = false;
            this.homeworks.Paint += new System.Windows.Forms.PaintEventHandler(this.homeworks_Paint);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 450);
            this.Controls.Add(this.homeworks);
            this.Controls.Add(this.createTask);
            this.Controls.Add(this.tags);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.themes);
            this.Controls.Add(this.dificulty);
            this.Controls.Add(this.doing);
            this.Controls.Add(this.students);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.Classes);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.doing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dificulty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel Classes;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taskMenu;
        private System.Windows.Forms.FlowLayoutPanel students;
        private System.Windows.Forms.FlowLayoutPanel doing;
        private System.Windows.Forms.TrackBar dificulty;
        private System.Windows.Forms.ComboBox themes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.CheckedListBox tags;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button createTask;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.FlowLayoutPanel homeworks;
    }
}