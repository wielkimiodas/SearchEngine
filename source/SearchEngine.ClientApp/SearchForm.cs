using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            Test();
        }

        private void Test()
        {
            var doc1 = new Document()
            {
                Content = "To jest treść",
                ContentStemmed = "wystemowana treść",
                Similarity = 0.7f,
                Title = "Mój super artykuł!"
            };

            var doc2 = new Document()
            {
                Content = "To jest treść2",
                ContentStemmed = "wystemowana treść2",
                Similarity = 0.12f,
                Title = "A to inny artykuł!"
            };

            var doc3 = new Document()
            {
                Content = "To jest treść3",
                ContentStemmed = "wystemowana treść3",
                Similarity = 0.12f,
                Title = "A to trzeci artykuł!"
            };

            var res1 = new ResultControl(doc1);
            //res1.Dock = DockStyle.Bottom;
            var res2 = new ResultControl(doc2);
            var res3 = new ResultControl(doc3);
            resultsLayoutPanel.Controls.Add(res1);
            resultsLayoutPanel.Controls.Add(res2);
            resultsLayoutPanel.Controls.Add(res3);
            //resultsLayoutPanel.Refresh();
            
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }        

    }
}
