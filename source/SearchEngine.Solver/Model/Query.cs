using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SearchEngine.Solver.Stemmer;

namespace SearchEngine.Solver.Model
{
    public sealed class Query : TfidfBase
    {
        public Query(string query)
        {
            ProcessGivenText(query);
            OverallComputation();
            
        }

        private void ProcessGivenText(string text)
        {
            var stemmer = new PorterStemmer();
            ContentStemmed = stemmer.stemText(text);
        }
    }
}
