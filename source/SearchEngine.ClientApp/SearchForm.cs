using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SearchEngine.Solver;
using SearchEngine.Solver.Model;

namespace SearchEngine.ClientApp
{
    public partial class SearchForm : Form
    {
        public SearchForm()
        {
            InitializeComponent();
            keywords = DataReader.LoadKeywords("keywords.txt");
            documents = DataReader.LoadDocuments("documents.txt");
        }

        private List<Document> documents;
        public List<Keyword> keywords;
        private Dictionary<string, double> InverseDocumentFrequency; 

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            var query = new Query(tbQuery.Text);
            ComputeIdf();
            DocumentValueEstimator.CompareDocumentsToQuery(documents, query);
            ReloadDocsView();

        }

        private void loadDocumentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStripMain.Text = "Loading documents...";
            try
            {
                var path = GetFilePathToOpen();
                if (path != null)
                    documents = DataReader.LoadDocuments(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured: \n" + ex.Message + "\n\n" + ex.InnerException);
                statusStripMain.Text = "Error during loading documents...";
            }
            statusStripMain.Text = "Documents successfully loaded";
        }

        private void loadKeywordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var path = GetFilePathToOpen();
                if (path != null)
                    keywords = DataReader.LoadKeywords(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception occured: \n" + ex.Message + "\n\n" + ex.InnerException);
            }
        }

        private string GetFilePathToOpen()
        {
            string path = null;
            var dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(dlg.FileName))
                {
                    path = dlg.FileName;
                }
            }
            return path;
        }

        private void ReloadDocsView()
        {
            resultsLayoutPanel.Controls.Clear();
            documents.Sort();
            for(int i=0;i<10;i++)
                resultsLayoutPanel.Controls.Add(new ResultControl(documents[i]));
        }


        private void ComputeIdf()
        {
            InverseDocumentFrequency = new Dictionary<string, double>();
            var docAmount = documents.Count;
            foreach (var key in keywords)
            {
                int occ = 0;
                foreach (var doc in documents)
                {
                    if (doc.BagOfWords.ContainsKey(key.Value))
                    {
                        if (doc.BagOfWords[key.Value] > 0)
                            occ++;
                    }
                }
                double idf;
                if (occ == 0) idf = 0;
                else idf = Math.Log10(docAmount/occ);
                
                InverseDocumentFrequency.Add(key.Value,idf);
            }


        }
    }
}
