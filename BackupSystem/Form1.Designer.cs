namespace BackupSystem
{
    partial class FormBackup
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.CoupleName = new System.Windows.Forms.TextBox();
            this.buttonAdditions = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonChoiceTo = new System.Windows.Forms.Button();
            this.WhereTo = new System.Windows.Forms.TextBox();
            this.buttonChoiceFor = new System.Windows.Forms.Button();
            this.Where = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelTo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelFor = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxFolders = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Choice = new System.Windows.Forms.TabControl();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.textBoxStreams = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxFrequency = new System.Windows.Forms.TextBox();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.Choice.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.textBoxFrequency);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.textBoxStreams);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(592, 340);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Настройки";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(592, 340);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Список пар";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(2, 2);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(588, 336);
            this.splitContainer1.SplitterDistance = 112;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.CoupleName);
            this.panel1.Controls.Add(this.buttonAdditions);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.buttonChoiceTo);
            this.panel1.Controls.Add(this.WhereTo);
            this.panel1.Controls.Add(this.buttonChoiceFor);
            this.panel1.Controls.Add(this.Where);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(588, 112);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Имя пары:";
            // 
            // CoupleName
            // 
            this.CoupleName.Location = new System.Drawing.Point(72, 10);
            this.CoupleName.Margin = new System.Windows.Forms.Padding(2);
            this.CoupleName.Name = "CoupleName";
            this.CoupleName.Size = new System.Drawing.Size(104, 20);
            this.CoupleName.TabIndex = 7;
            // 
            // buttonAdditions
            // 
            this.buttonAdditions.Location = new System.Drawing.Point(6, 79);
            this.buttonAdditions.Margin = new System.Windows.Forms.Padding(2);
            this.buttonAdditions.Name = "buttonAdditions";
            this.buttonAdditions.Size = new System.Drawing.Size(75, 31);
            this.buttonAdditions.TabIndex = 6;
            this.buttonAdditions.Text = "Добавить";
            this.buttonAdditions.UseVisualStyleBackColor = true;
            this.buttonAdditions.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Куда:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Откуда:";
            // 
            // buttonChoiceTo
            // 
            this.buttonChoiceTo.Location = new System.Drawing.Point(413, 55);
            this.buttonChoiceTo.Margin = new System.Windows.Forms.Padding(2);
            this.buttonChoiceTo.Name = "buttonChoiceTo";
            this.buttonChoiceTo.Size = new System.Drawing.Size(68, 21);
            this.buttonChoiceTo.TabIndex = 3;
            this.buttonChoiceTo.Text = "Выбрать";
            this.buttonChoiceTo.UseVisualStyleBackColor = true;
            this.buttonChoiceTo.Click += new System.EventHandler(this.button2_Click);
            // 
            // WhereTo
            // 
            this.WhereTo.Location = new System.Drawing.Point(52, 56);
            this.WhereTo.Margin = new System.Windows.Forms.Padding(2);
            this.WhereTo.Name = "WhereTo";
            this.WhereTo.Size = new System.Drawing.Size(358, 20);
            this.WhereTo.TabIndex = 2;
            // 
            // buttonChoiceFor
            // 
            this.buttonChoiceFor.Location = new System.Drawing.Point(413, 32);
            this.buttonChoiceFor.Margin = new System.Windows.Forms.Padding(2);
            this.buttonChoiceFor.Name = "buttonChoiceFor";
            this.buttonChoiceFor.Size = new System.Drawing.Size(68, 19);
            this.buttonChoiceFor.TabIndex = 1;
            this.buttonChoiceFor.Text = "Выбрать";
            this.buttonChoiceFor.UseVisualStyleBackColor = true;
            this.buttonChoiceFor.Click += new System.EventHandler(this.button1_Click);
            // 
            // Where
            // 
            this.Where.Location = new System.Drawing.Point(52, 32);
            this.Where.Margin = new System.Windows.Forms.Padding(2);
            this.Where.Name = "Where";
            this.Where.Size = new System.Drawing.Size(358, 20);
            this.Where.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.buttonDelete);
            this.panel2.Controls.Add(this.labelTo);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.labelFor);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.comboBoxFolders);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(588, 221);
            this.panel2.TabIndex = 0;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Location = new System.Drawing.Point(9, 136);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 25);
            this.buttonDelete.TabIndex = 9;
            this.buttonDelete.Text = "Удалить её";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.button4_Click);
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(6, 104);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(16, 13);
            this.labelTo.TabIndex = 14;
            this.labelTo.Text = "...";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 81);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Куда копируется:";
            // 
            // labelFor
            // 
            this.labelFor.AutoSize = true;
            this.labelFor.Location = new System.Drawing.Point(6, 59);
            this.labelFor.Name = "labelFor";
            this.labelFor.Size = new System.Drawing.Size(16, 13);
            this.labelFor.TabIndex = 12;
            this.labelFor.Text = "...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Откуда копируется:";
            // 
            // comboBoxFolders
            // 
            this.comboBoxFolders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFolders.FormattingEnabled = true;
            this.comboBoxFolders.Location = new System.Drawing.Point(96, 6);
            this.comboBoxFolders.Name = "comboBoxFolders";
            this.comboBoxFolders.Size = new System.Drawing.Size(134, 21);
            this.comboBoxFolders.TabIndex = 10;
            this.comboBoxFolders.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Выберите пару:";
            // 
            // Choice
            // 
            this.Choice.Controls.Add(this.tabPage1);
            this.Choice.Controls.Add(this.tabPage2);
            this.Choice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Choice.Location = new System.Drawing.Point(0, 0);
            this.Choice.Margin = new System.Windows.Forms.Padding(2);
            this.Choice.Name = "Choice";
            this.Choice.SelectedIndex = 0;
            this.Choice.Size = new System.Drawing.Size(600, 366);
            this.Choice.TabIndex = 0;
            // 
            // textBoxStreams
            // 
            this.textBoxStreams.Location = new System.Drawing.Point(58, 12);
            this.textBoxStreams.Name = "textBoxStreams";
            this.textBoxStreams.Size = new System.Drawing.Size(100, 20);
            this.textBoxStreams.TabIndex = 0;
            this.textBoxStreams.Text = "5";
            this.textBoxStreams.TextChanged += new System.EventHandler(this.textBoxStreams_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Потоки";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Частота";
            // 
            // textBoxFrequency
            // 
            this.textBoxFrequency.Location = new System.Drawing.Point(58, 38);
            this.textBoxFrequency.Name = "textBoxFrequency";
            this.textBoxFrequency.Size = new System.Drawing.Size(100, 20);
            this.textBoxFrequency.TabIndex = 2;
            this.textBoxFrequency.Text = "5000";
            this.textBoxFrequency.TextChanged += new System.EventHandler(this.textBoxFrequency_TextChanged);
            // 
            // FormBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.Choice);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBackup";
            this.Text = "VersionsBackup";
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.Choice.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl Choice;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonChoiceTo;
        private System.Windows.Forms.TextBox WhereTo;
        private System.Windows.Forms.Button buttonChoiceFor;
        private System.Windows.Forms.TextBox Where;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAdditions;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CoupleName;

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelFor;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox comboBoxFolders;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxFrequency;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxStreams;
    }
}

