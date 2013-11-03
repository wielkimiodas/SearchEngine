using System;
using System.Windows.Forms;
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
            MessageBox.Show(_document.OriginalContent);
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