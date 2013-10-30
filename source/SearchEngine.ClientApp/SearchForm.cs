using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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
        private List<Keyword> keywords;

        private void Test()
        {
            //var doc1 = new Document()
            //{
            //    Content = "To jest treść",
            //    ContentStemmed = new List<string> { "wystemowana treść" },
            //    Similarity = 0.7f,
            //    Title = "Mój super artykuł!"
            //};

            //var doc2 = new Document()
            //{
            //    Content = "To jest treść2",
            //    ContentStemmed = new List<string> { "wystemowana treść2" },
            //    Similarity = 0.12f,
            //    Title = "A to inny artykuł!"
            //};

            //var doc3 = new Document()
            //{
            //    Content = "To jest treść3",
            //    ContentStemmed = new List<string>{"wystemowana treść3"},
            //    Similarity = 0.12f,
            //    Title = "A to trzeci artykuł!"
            //};

            //var res1 = new ResultControl(doc1);
            ////res1.Dock = DockStyle.Top;
            ////res1.Anchor = (AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Top);
            //var res2 = new ResultControl(doc2);
            //var res3 = new ResultControl(doc3);

            
            //resultsLayoutPanel.Controls.Add(res1,0,0);
            //resultsLayoutPanel.Controls.Add(res2,0,1);
            //resultsLayoutPanel.Controls.Add(res3,0,2);

            //resultsLayoutPanel.Refresh();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            var query = new Query(tbQuery.Text);
        }

        private void loadDocumentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStripMain.Text = "Loading documents...";
            try
            {
                documents = DataReader.LoadDocuments(GetFilePathToOpen());
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
                keywords = DataReader.LoadKeywords(GetFilePathToOpen());
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

    }
}
