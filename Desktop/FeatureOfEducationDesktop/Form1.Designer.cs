namespace FeatureOfEducationDesktop
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taskMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.taskText = new System.Windows.Forms.RichTextBox();
            this.tags = new System.Windows.Forms.CheckedListBox();
            this.answerText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dificulty = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.subj = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dificulty)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.taskMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(920, 28);
            this.menuStrip1.TabIndex = 0;
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
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(350, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Write the task:";
            // 
            // taskText
            // 
            this.taskText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.taskText.Location = new System.Drawing.Point(53, 72);
            this.taskText.Name = "taskText";
            this.taskText.Size = new System.Drawing.Size(817, 174);
            this.taskText.TabIndex = 3;
            this.taskText.Text = "";
            // 
            // tags
            // 
            this.tags.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tags.FormattingEnabled = true;
            this.tags.Location = new System.Drawing.Point(53, 301);
            this.tags.MultiColumn = true;
            this.tags.Name = "tags";
            this.tags.Size = new System.Drawing.Size(311, 123);
            this.tags.TabIndex = 4;
            // 
            // answerText
            // 
            this.answerText.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.answerText.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.answerText.Location = new System.Drawing.Point(602, 301);
            this.answerText.Name = "answerText";
            this.answerText.Size = new System.Drawing.Size(268, 38);
            this.answerText.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(675, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "Answer:";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(602, 378);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(268, 37);
            this.button1.TabIndex = 7;
            this.button1.Text = "Add answer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dificulty
            // 
            this.dificulty.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dificulty.LargeChange = 1;
            this.dificulty.Location = new System.Drawing.Point(381, 301);
            this.dificulty.Minimum = 1;
            this.dificulty.Name = "dificulty";
            this.dificulty.Size = new System.Drawing.Size(197, 56);
            this.dificulty.TabIndex = 8;
            this.dificulty.Value = 1;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(420, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 32);
            this.label3.TabIndex = 9;
            this.label3.Text = "Dificulty:";
            // 
            // subj
            // 
            this.subj.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.subj.FormattingEnabled = true;
            this.subj.Location = new System.Drawing.Point(97, 252);
            this.subj.Name = "subj";
            this.subj.Size = new System.Drawing.Size(221, 24);
            this.subj.TabIndex = 10;
            this.subj.SelectedIndexChanged += new System.EventHandler(this.subj_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 459);
            this.Controls.Add(this.subj);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dificulty);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.answerText);
            this.Controls.Add(this.tags);
            this.Controls.Add(this.taskText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing_1);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dificulty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taskMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox taskText;
        private System.Windows.Forms.CheckedListBox tags;
        private System.Windows.Forms.TextBox answerText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar dificulty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox subj;
    }
}

