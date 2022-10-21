using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BackupSystem
{

    public partial class FormBackup : Form
    {
        public static int StreamsFree = 5; // Количество свободных подпотоков.
                                           // Это ещё один поток. Он может сразу же, как в основном потоке заполнится биржа,
                                           //взять из биржи что-то и начать копировать - не дожидаясь, пока чекер пройдется
                                           // по другим файлам (их может быть много)
        
        public static int TimeWatchDog = 5000;


        public FormBackup()
        {
            InitializeComponent();
            JSONDatabase.JSONUnload();
            Copying.WorkingStart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Where.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                WhereTo.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Where.Text.Length == 0)
            {
                MessageBox.Show($"Выберите директорию, откуда копировать!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (WhereTo.Text.Length == 0)
            {
                MessageBox.Show($"Выберите директорию, куда копировать!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CoupleName.Text.Length == 0)
            {
                MessageBox.Show($"Назовите как-нибудь пару!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Directory.Exists(Where.Text))
            {
                MessageBox.Show($"Папки {Where.Text} не существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Directory.Exists(WhereTo.Text))
            {
                Directory.CreateDirectory(WhereTo.Text);
            }

            JSONDatabase.CopyFolder t = JSONDatabase.ListCopying.Find(x => x.Name == CoupleName.Text);
            
            if (t.Name == CoupleName.Text)
            {
                MessageBox.Show($"Пара {CoupleName.Text} уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Where.Text[Where.TextLength - 1] != '\\')
            { 
                Where.Text += '\\'; 
            }
            if (WhereTo.Text[WhereTo.TextLength - 1] != '\\')
            {
                WhereTo.Text += '\\';
            }
            JSONDatabase.InitNewPair(CoupleName.Text, Where.Text, WhereTo.Text);
            comboBoxFolders.Items.Add(CoupleName.Text);
            MessageBox.Show($"Пара '{CoupleName.Text}' создана.");
            Where.Text = WhereTo.Text = CoupleName.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int Number = comboBoxFolders.SelectedIndex;
                JSONDatabase.RemoveDependencies(Number);
                comboBoxFolders.Items.RemoveAt(Number);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Number = comboBoxFolders.SelectedIndex;
            labelFor.Text = Number == -1 ? "..." : JSONDatabase.ListCopying[Number].DirectoryStart;
            labelTo.Text = Number == -1 ? "..." : JSONDatabase.ListCopying[Number].DirectoryFinish;
            buttonDelete.Enabled = Number > -1;
        }

        private void textBoxStreams_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(textBoxStreams.Text) > 0)
                {
                    StreamsFree = int.Parse(textBoxStreams.Text);
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex);
            }
            
        }

        private void textBoxFrequency_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(textBoxFrequency.Text) > 0)
                {
                    TimeWatchDog = int.Parse(textBoxFrequency.Text);
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

}
