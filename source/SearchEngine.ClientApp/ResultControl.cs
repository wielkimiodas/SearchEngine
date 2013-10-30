using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using SearchEngine.Solver.Model;

namespace SearchEngine.ClientApp
{
    public sealed partial class ResultControl : UserControl
    {
        private Document _document;

        public ResultControl(Document document)
        {
            InitializeComponent();
            _document = document;
            AutoSize = true;

            //Anchor = (AnchorStyles.Right | AnchorStyles.Left);
            //Dock = DockStyle.Fill;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //Width = Parent.Width;
            if (_document != null)
            {
                lblTitle.Text = _document.Title;
                lblSimValue.Text = _document.Similarity.ToString();
            }
        }

        private void btShowOrigin_Click(object sender, EventArgs e)
        {
            MessageBox.Show(_document.Content);
        }

        private void btStemmed_Click(object sender, EventArgs e)
        {
            string res = null;
            foreach (var record in _document.ContentStemmed)
            {
                res += record + " ";
            }
            if (res != null)
                MessageBox.Show(res);
        }
    }
}
