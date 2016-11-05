using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TextClustering.Lib;

namespace TextClustering
{
    public partial class TextClusteringGUI : Form
    {
        private DocumentCollection docCollection;
        string[] filenames;
        public TextClusteringGUI()
        {
            InitializeComponent();
            docCollection = new DocumentCollection() { DocumentList = new List<string>() };

        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            /*
            if (!string.IsNullOrEmpty(txtDoc1.Text))
                docCollection.DocumentList.Add(txtDoc1.Text);
            if (!string.IsNullOrEmpty(txtDoc2.Text))
                docCollection.DocumentList.Add(txtDoc2.Text);
            if (!string.IsNullOrEmpty(txtDoc3.Text))
                docCollection.DocumentList.Add(txtDoc3.Text);
            if (!string.IsNullOrEmpty(txtDoc4.Text))
                docCollection.DocumentList.Add(txtDoc4.Text);


            int totalDoc = 0;
            if (int.TryParse(docCollection.DocumentList.Count.ToString(), out totalDoc))
            {
                lblTotalDoc.Text = totalDoc.ToString();
            }

            txtDoc1.Clear();
            txtDoc2.Clear();
            txtDoc3.Clear();
            txtDoc4.Clear();
            */
            int totalDoc = 0;
            System.IO.StreamReader objReader;
            foreach(var file_name in filenames)
            {
            objReader = new System.IO.StreamReader(file_name);
            totalDoc++;
            docCollection.DocumentList.Add(objReader.ReadToEnd());
            objReader.Close();
            }
            label8.Text = totalDoc.ToString();
            }


        private void btnStartClustering_Click(object sender, EventArgs e)
        {
            List<DocumentVector> vSpace = VectorSpaceModel.ProcessDocumentCollection(docCollection);
            int totalIteration = 0;
            List<Centroid> resultSet = DocumnetClustering.PrepareDocumentCluster(int.Parse(txtClusterNo.Text), vSpace, ref  totalIteration);
            string msg = string.Empty;
            int count = 1;
            string k=string.Empty;
            string max = string.Empty;
            List<string> topic=new List<string>();
            foreach (Centroid c in resultSet)
            {
                msg += String.Format("------------------------------[ CLUSTER {0} ]-----------------------------{1}", count, System.Environment.NewLine);
                k += String.Format("[ CLUSTER {0} ]", count, System.Environment.NewLine);
                max=string.Empty;
                foreach (DocumentVector document in c.GroupedDocument)
                {

                    for (int i = 0; i < document.keys.Length; i++)
                    {
                        float m = document.VectorSpace[0];
                        if (document.VectorSpace[i] > 0.005 && document.keys[i] != ".")
                        {
                            k += document.keys[i] + ",";
                            

                        }
                        msg += document.Content + System.Environment.NewLine;
                        if (c.GroupedDocument.Count > 1)
                        {
                            msg += String.Format("{0}-------------------------------------------------------------------------------{0}", System.Environment.NewLine);
                        }
                    }

                    msg += "-------------------------------------------------------------------------------" + System.Environment.NewLine;
                    k += System.Environment.NewLine;
                    topic.Add(max);
                    count++;
                }
            }

            richTextBox2.Text = k;
            richTextBox1.Text = msg;
            label10.Text = totalIteration.ToString();
        }
        private void btnStopProcess_Click(object sender, EventArgs e)
        {
            docCollection = new DocumentCollection();
            this.ClearField();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            this.ClearField();
            docCollection = new DocumentCollection();
        }


        private void ClearField()
        {
            txtClusterNo.Clear();
            docCollection = null;
            lblTotalDoc.Text = "";
            lblError.Text = "";
            lblTotalCluster.Text = "";
            lblTotalIteration.Text = "";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearField();
        }

        private void txtClusterNo_TextChanged(object sender, EventArgs e)
        {
            int totalDoc = 0;
            if (int.TryParse(txtClusterNo.Text, out totalDoc))
            {
                lblError.Text = "";
                label9.Text = txtClusterNo.Text;
            }
            else
            {
                lblError.Text = "Enter a valid integer";
                label9.Text = " ";
            }


        }

        private void TextClusteringGUI_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                // Insert code to read the stream here.
                filenames = openFileDialog1.FileNames;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}

