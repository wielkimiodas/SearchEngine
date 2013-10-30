using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchEngine.Solver.Stemmer;

namespace SearchEngine.Solver.Model
{
    public sealed class Document : TfidfBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public float Similarity { get; set; }

        public Document(string paragraph)
        {
            ProcessGivenText(paragraph);
            OverallComputation();
        }

        private void ProcessGivenText(string paragraph)
        {
            var docLines = paragraph.Split(new [] { Environment.NewLine }, StringSplitOptions.None);
            Title = docLines[0];

            var stemmer = new PorterStemmer();
            var stemmed = stemmer.stemText(paragraph);
            ContentStemmed = stemmed;

            for (var i = 1; i < docLines.Length; i++)
            {
                Content += docLines[i];
            }
        }
    }
}
