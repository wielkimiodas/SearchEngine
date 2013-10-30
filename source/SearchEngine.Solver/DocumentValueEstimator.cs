using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SearchEngine.Solver.Model;

namespace SearchEngine.Solver
{
    public class DocumentValueEstimator
    {
        static void CompareDocumentToQuery(Document document, Query query)
        {
            double res = 0;
            var queryFreq = query.TermFrequency;
            foreach (var term in document.TermFrequency)
            {
                if (queryFreq.ContainsKey(term.Key))
                res += term.Value*queryFreq[term.Key];
            }

            res /= query.VectorLength*document.VectorLength;
            document.Similarity = res;
        }

        public static void CompareDocumentsToQuery(List<Document> documents, Query query)
        {
            foreach (var doc in documents)
            {
                CompareDocumentToQuery(doc,query);
            }
        }

        
    }
}
