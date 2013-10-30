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
            keywords = DataReader.LoadKeywords("keywords.txt");
            documents = DataReader.LoadDocuments("documents.txt");
        }

        public List<Document> Search(Query query)
        {
            ComputeIdf();
            DocumentValueEstimator.CompareDocumentsToQuery(documents, query);
            
            //top ten
            var list = new List<Document>();
            documents.Sort();
            for (int i = 0; i < 10; i++)
                list.Add(documents[i]);
            return list;
        }

        private void ComputeIdf()
        {
            InverseDocumentFrequency = new Dictionary<string, double>();
            var docAmount = documents.Count;
            foreach (var key in keywords)
            {
                int occ = 0;
                foreach (var doc in documents)
                {
                    if (doc.BagOfWords.ContainsKey(key.Value))
                    {
                        if (doc.BagOfWords[key.Value] > 0)
                            occ++;
                    }
                }
                double idf;
                if (occ == 0) idf = 0;
                else idf = Math.Log10(docAmount / occ);

                InverseDocumentFrequency.Add(key.Value, idf);
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
