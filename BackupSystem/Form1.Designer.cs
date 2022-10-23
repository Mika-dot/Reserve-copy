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
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxFrequency = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxStreams = new System.Windows.Forms.TextBox();
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
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxFilesList = new System.Windows.Forms.ComboBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelTo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelFor = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxFolders = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Choice = new System.Windows.Forms.TabControl();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.deleteFileFromDB = new System.Windows.Forms.Button();
            this.AutostartOn = new System.Windows.Forms.Button();
            this.AutostartOff = new System.Windows.Forms.Button();
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
            this.tabPage2.Controls.Add(this.AutostartOff);
            this.tabPage2.Controls.Add(this.AutostartOn);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.textBoxFrequency);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.textBoxStreams);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage2.Size = new System.Drawing.Size(792, 421);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Настройки";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 50);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 16);
            this.label7.TabIndex = 3;
            this.label7.Text = "Частота";
            // 
            // textBoxFrequency
            // 
            this.textBoxFrequency.Location = new System.Drawing.Point(77, 47);
            this.textBoxFrequency.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxFrequency.Name = "textBoxFrequency";
            this.textBoxFrequency.Size = new System.Drawing.Size(132, 22);
            this.textBoxFrequency.TabIndex = 2;
            this.textBoxFrequency.Text = "5000";
            this.textBoxFrequency.TextChanged += new System.EventHandler(this.textBoxFrequency_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 18);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Потоки";
            // 
            // textBoxStreams
            // 
            this.textBoxStreams.Location = new System.Drawing.Point(77, 15);
            this.textBoxStreams.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxStreams.Name = "textBoxStreams";
            this.textBoxStreams.Size = new System.Drawing.Size(132, 22);
            this.textBoxStreams.TabIndex = 0;
            this.textBoxStreams.Text = "5";
            this.textBoxStreams.TextChanged += new System.EventHandler(this.textBoxStreams_TextChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(792, 421);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Список пар";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 2);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
            this.splitContainer1.Size = new System.Drawing.Size(786, 417);
            this.splitContainer1.SplitterDistance = 139;
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
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 139);
            this.panel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Имя пары:";
            // 
            // CoupleName
            // 
            this.CoupleName.Location = new System.Drawing.Point(96, 12);
            this.CoupleName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CoupleName.Name = "CoupleName";
            this.CoupleName.Size = new System.Drawing.Size(137, 22);
            this.CoupleName.TabIndex = 7;
            // 
            // buttonAdditions
            // 
            this.buttonAdditions.Location = new System.Drawing.Point(8, 97);
            this.buttonAdditions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonAdditions.Name = "buttonAdditions";
            this.buttonAdditions.Size = new System.Drawing.Size(100, 38);
            this.buttonAdditions.TabIndex = 6;
            this.buttonAdditions.Text = "Добавить";
            this.buttonAdditions.UseVisualStyleBackColor = true;
            this.buttonAdditions.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Куда:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Откуда:";
            // 
            // buttonChoiceTo
            // 
            this.buttonChoiceTo.Location = new System.Drawing.Point(551, 68);
            this.buttonChoiceTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonChoiceTo.Name = "buttonChoiceTo";
            this.buttonChoiceTo.Size = new System.Drawing.Size(91, 26);
            this.buttonChoiceTo.TabIndex = 3;
            this.buttonChoiceTo.Text = "Выбрать";
            this.buttonChoiceTo.UseVisualStyleBackColor = true;
            this.buttonChoiceTo.Click += new System.EventHandler(this.button2_Click);
            // 
            // WhereTo
            // 
            this.WhereTo.Location = new System.Drawing.Point(69, 69);
            this.WhereTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.WhereTo.Name = "WhereTo";
            this.WhereTo.Size = new System.Drawing.Size(476, 22);
            this.WhereTo.TabIndex = 2;
            // 
            // buttonChoiceFor
            // 
            this.buttonChoiceFor.Location = new System.Drawing.Point(551, 39);
            this.buttonChoiceFor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonChoiceFor.Name = "buttonChoiceFor";
            this.buttonChoiceFor.Size = new System.Drawing.Size(91, 23);
            this.buttonChoiceFor.TabIndex = 1;
            this.buttonChoiceFor.Text = "Выбрать";
            this.buttonChoiceFor.UseVisualStyleBackColor = true;
            this.buttonChoiceFor.Click += new System.EventHandler(this.button1_Click);
            // 
            // Where
            // 
            this.Where.Location = new System.Drawing.Point(69, 39);
            this.Where.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Where.Name = "Where";
            this.Where.Size = new System.Drawing.Size(476, 22);
            this.Where.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gainsboro;
            this.panel2.Controls.Add(this.deleteFileFromDB);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.comboBoxFilesList);
            this.panel2.Controls.Add(this.buttonDelete);
            this.panel2.Controls.Add(this.labelTo);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.labelFor);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.comboBoxFolders);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(786, 274);
            this.panel2.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(328, 11);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 16);
            this.label9.TabIndex = 16;
            this.label9.Text = "Выберите файл:";
            // 
            // comboBoxFilesList
            // 
            this.comboBoxFilesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFilesList.FormattingEnabled = true;
            this.comboBoxFilesList.Location = new System.Drawing.Point(448, 8);
            this.comboBoxFilesList.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxFilesList.Name = "comboBoxFilesList";
            this.comboBoxFilesList.Size = new System.Drawing.Size(332, 24);
            this.comboBoxFilesList.TabIndex = 15;
            this.comboBoxFilesList.SelectedIndexChanged += new System.EventHandler(this.comboBoxFilesList_SelectedIndexChanged);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Location = new System.Drawing.Point(12, 167);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(100, 31);
            this.buttonDelete.TabIndex = 9;
            this.buttonDelete.Text = "Удалить её";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.button4_Click);
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(8, 128);
            this.labelTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(16, 16);
            this.labelTo.TabIndex = 14;
            this.labelTo.Text = "...";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 100);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 16);
            this.label8.TabIndex = 13;
            this.label8.Text = "Куда копируется:";
            // 
            // labelFor
            // 
            this.labelFor.AutoSize = true;
            this.labelFor.Location = new System.Drawing.Point(8, 73);
            this.labelFor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFor.Name = "labelFor";
            this.labelFor.Size = new System.Drawing.Size(16, 16);
            this.labelFor.TabIndex = 12;
            this.labelFor.Text = "...";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 44);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Откуда копируется:";
            // 
            // comboBoxFolders
            // 
            this.comboBoxFolders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFolders.FormattingEnabled = true;
            this.comboBoxFolders.Location = new System.Drawing.Point(128, 7);
            this.comboBoxFolders.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxFolders.Name = "comboBoxFolders";
            this.comboBoxFolders.Size = new System.Drawing.Size(177, 24);
            this.comboBoxFolders.TabIndex = 10;
            this.comboBoxFolders.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Выберите пару:";
            // 
            // Choice
            // 
            this.Choice.Controls.Add(this.tabPage1);
            this.Choice.Controls.Add(this.tabPage2);
            this.Choice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Choice.Location = new System.Drawing.Point(0, 0);
            this.Choice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Choice.Name = "Choice";
            this.Choice.SelectedIndex = 0;
            this.Choice.Size = new System.Drawing.Size(800, 450);
            this.Choice.TabIndex = 0;
            // 
            // deleteFileFromDB
            // 
            this.deleteFileFromDB.Enabled = false;
            this.deleteFileFromDB.Location = new System.Drawing.Point(551, 38);
            this.deleteFileFromDB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deleteFileFromDB.Name = "deleteFileFromDB";
            this.deleteFileFromDB.Size = new System.Drawing.Size(229, 31);
            this.deleteFileFromDB.TabIndex = 17;
            this.deleteFileFromDB.Text = "Удалить файл из базы данных";
            this.deleteFileFromDB.UseVisualStyleBackColor = true;
            this.deleteFileFromDB.Click += new System.EventHandler(this.deleteFileFromDB_Click);
            // 
            // AutostartOn
            // 
            this.AutostartOn.Location = new System.Drawing.Point(14, 88);
            this.AutostartOn.Name = "AutostartOn";
            this.AutostartOn.Size = new System.Drawing.Size(195, 23);
            this.AutostartOn.TabIndex = 4;
            this.AutostartOn.Text = "Добавить в автозапуск";
            this.AutostartOn.UseVisualStyleBackColor = true;
            this.AutostartOn.Click += new System.EventHandler(this.AutostartOn_Click);
            // 
            // AutostartOff
            // 
            this.AutostartOff.Location = new System.Drawing.Point(14, 117);
            this.AutostartOff.Name = "AutostartOff";
            this.AutostartOff.Size = new System.Drawing.Size(195, 23);
            this.AutostartOff.TabIndex = 5;
            this.AutostartOff.Text = "Удалить из автозапуска";
            this.AutostartOff.UseVisualStyleBackColor = true;
            this.AutostartOff.Click += new System.EventHandler(this.AutostartOff_Click);
            // 
            // FormBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Choice);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormBackup";
            this.Text = "VersionsBackup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBackup_FormClosing);
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxFrequency;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxStreams;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.ComboBox comboBoxFilesList;
        public System.Windows.Forms.ComboBox comboBoxFolders;
        private System.Windows.Forms.Button deleteFileFromDB;
        private System.Windows.Forms.Button AutostartOff;
        private System.Windows.Forms.Button AutostartOn;
    }
}

