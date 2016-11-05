using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;
using System.IO;
namespace TextClustering
{
    public partial class Form1 : Form
    {
        string OldName;
        string NewName;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Old = null;
            string Nw = null;
            Old = textBox1.Text + @"\";
            Nw = textBox2.Text.ToString() + @"\";
            DirectoryInfo dinfo = new DirectoryInfo(textBox1.Text);
            FileInfo[] Files = dinfo.GetFiles("*.*");
foreach( FileInfo file in Files )
{
    OldName = Old +  file.Name.ToString();
    NewName = Nw +  file.Name.ToString() + ".txt";
    Directory.Move(OldName, NewName);
    
}
          
            MessageBox.Show("Document Convesion as been successfully processed");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
           
            TextClusteringGUI nw = new TextClusteringGUI();
            this.Opacity = 0.0f;
            this.ShowInTaskbar = false;
            nw.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderbrowserdialog = folderBrowserDialog1;
            folderBrowserDialog1.ShowDialog();
            textBox2.Text = folderBrowserDialog1.SelectedPath;

          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void folderBrowserDialog2_HelpRequest(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void btnselect_Click(object sender, EventArgs e)
        {

           
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            // Insert code to read the stream here.
                            textBox1.Text = openFileDialog1.FileName;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            
            if (result == DialogResult.OK)
            {
                //
                // The user selected a folder and pressed the OK button.
                // We print the number of files found.
                //
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                //string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                //MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                //
                // The user selected a folder and pressed the OK button.
                // We print the number of files found.
                //
                textBox2.Text = folderBrowserDialog1.SelectedPath;
                //string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                //MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
            }
        }
        //private void File_Formate_Load(System.Object sender, System.EventArgs e)
        //{
        //}
	
    //public File_Formate()
    //{
    //    Load += File_Formate_Load;
    //}

    }

   
}
