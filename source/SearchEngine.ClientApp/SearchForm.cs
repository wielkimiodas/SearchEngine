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
        }

        private List<Document> documents;
        public List<Keyword> keywords;

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            var query = new Query(tbQuery.Text);
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

    }
}
