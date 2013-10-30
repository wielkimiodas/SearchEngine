using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SearchEngine.Solver.Model;

namespace SearchEngine.Solver
{
    public class SearchPerformer
    {
        public List<Keyword> keywords;
        private Dictionary<string, double> InverseDocumentFrequency;
        public List<Document> documents;

        public SearchPerformer()
        {
            keywords = DataReader.LoadKeywords(@"input\keywords.txt");
            documents = DataReader.LoadDocuments(@"input\documents.txt");
        }

        public List<Document> Search(Query query)
        {
            ComputeIdf();
            foreach (var document in documents)
            {
                document.ApplyIdfComputation(InverseDocumentFrequency);
            }
            query.ApplyIdfComputation(InverseDocumentFrequency);

            DocumentValueEstimator.CompareDocumentsToQuery(documents, query);

            //top ten
            var list = new List<Document>();
            documents.Sort();
            var docAmount = 10;
            docAmount = Math.Min(docAmount, documents.Count);
            for (int i = 0; i < docAmount; i++)
                list.Add(documents[i]);
            return list;
        }

        private void ComputeIdf()
        {
            InverseDocumentFrequency = new Dictionary<string, double>();

            var docAmount = documents.Count;
            var keysStemmed = new List<string>();
            foreach (var key in keywords)
            {
                if (!keysStemmed.Contains(key.ValueStemmed))
                    keysStemmed.Add(key.ValueStemmed);
            }

            foreach (var key in keysStemmed)
            {
                var occ = 0;
                foreach (var doc in documents)
                {
                    if (doc.BagOfWords.ContainsKey(key))
                    {
                        if (doc.BagOfWords[key] > 0)
                            occ++;
                    }
                }
                var idf = occ == 0 ? 0 : Math.Log10(docAmount / (double)occ);
                InverseDocumentFrequency.Add(key, idf);
            }
        }

        public void SetNewKeywords(string path)
        {
            if (path != null)
                keywords = DataReader.LoadKeywords(path);
        }

        public void SetNewDocuments(string path)
        {
            if (path != null)
                documents = DataReader.LoadDocuments(path);
        }

    }
}
