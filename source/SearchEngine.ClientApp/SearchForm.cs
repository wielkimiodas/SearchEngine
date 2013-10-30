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
        private SearchPerformer searcher;
        private List<Document> topTenDocuments;

        public SearchForm()
        {
            InitializeComponent();
            searcher = new SearchPerformer();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbQuery.Text))
            {
                var query = new Query(tbQuery.Text);
                topTenDocuments = searcher.Search(query);
                ReloadDocsView();
            }
        }

        private void loadDocumentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStripMain.Text = "Loading documents...";
            try
            {
                var path = GetFilePathToOpen();
                if (path != null)
                    searcher.SetNewDocuments(path);
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
                searcher.SetNewKeywords(path);
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
            for (int i = 0; i < topTenDocuments.Count; i++)
            {
                var doc = topTenDocuments[i];
                if (doc.Similarity == 0 && i == 0) MessageBox.Show("No documents have been found");
                if (doc.Similarity > 0)
                    resultsLayoutPanel.Controls.Add(new ResultControl(doc));
            }
        }
    }
}
