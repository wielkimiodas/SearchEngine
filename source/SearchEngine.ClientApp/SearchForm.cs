using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SearchEngine.Solver;
using SearchEngine.Solver.Model;

namespace SearchEngine.ClientApp
{
    public partial class SearchForm : Form
    {
        private SearchPerformer searcher;
        private List<Document> topTenDocuments;
        private Stopwatch stopwatch = new Stopwatch();

        public SearchForm()
        {
            InitializeComponent();
            searcher = new SearchPerformer();
            tbQuery.KeyDown += tbQuery_KeyDown;
            cbSuggestions.Checked = true;
            toolStripStatusLabel.Text = "";
        }

        private void tbQuery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btSearch.PerformClick();
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            Search(tbQuery.Text);
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

        private static string GetFilePathToOpen()
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
                if (doc.Similarity == 0 && i == 0)
                {
                    resultsLayoutPanel.Controls.Add(
                        new Label() {Text = "No documents have been found", AutoSize = true, Margin = new Padding(10)});
                    toolStripStatusLabel.Text =
                        "There is no document in database which has positive similarity to given query.";
                }
                if (doc.Similarity > 0)
                {
                    resultsLayoutPanel.Controls.Add(new ResultControl(doc));
                    toolStripStatusLabel.Text = "Founded: " + topTenDocuments.Count + " documents in " +
                                                stopwatch.ElapsedMilliseconds + " miliseconds.";
                }
            }
        }

        private void Query_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var link = (LinkLabel) sender;
            Search(link.Text);
            tbQuery.Text = link.Text;
        }

        private void Search(string originalQuery)
        {
            if (!string.IsNullOrWhiteSpace(originalQuery))
            {
                stopwatch.Restart();
                var query = new Query(originalQuery);
                topTenDocuments = searcher.Search(query);
                ReloadDocsView();
                ApplyQuerySuggestions(query.OriginalContent);
                stopwatch.Stop();
            }
        }

        private void ApplyQuerySuggestions(string originalQuery)
        {
            var props = searcher.ProposeSimilarQueries(originalQuery).Take(5).ToList();
            flowLayoutPanelProposes.Controls.Clear();

            if (cbSuggestions.Checked)
            {
                if (props.Count < 1)
                {
                    flowLayoutPanelProposes.Controls.Add(new Label() {Text = "No suggestions proposed"});
                }
                else
                {
                    foreach (var prop in props)
                    {
                        var linkLabel = new LinkLabel() {Text = prop};
                        linkLabel.LinkClicked += Query_LinkClicked;
                        linkLabel.MinimumSize = TextRenderer.MeasureText(prop, linkLabel.Font);
                        flowLayoutPanelProposes.Controls.Add(linkLabel);
                    }
                }
            }
        }
    }
}