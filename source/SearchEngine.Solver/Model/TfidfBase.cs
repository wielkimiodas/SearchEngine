using System;
using System.Collections.Generic;
using System.Linq;
using SearchEngine.Solver.Stemmer;

namespace SearchEngine.Solver.Model
{
    public abstract class TfidfBase
    {
        public List<string> ContentStemmed { get; set; }
        public string OriginalContent { get; set; }

        public virtual Dictionary<string, int> BagOfWords { get; set; }
        public virtual Dictionary<string, double> TermFrequency { get; set; }
        public virtual double VectorLength { get; set; }
        public virtual Dictionary<string, double> IdfResult { get; set; }

        protected TfidfBase(string text)
        {
            OriginalContent = text;
            var stemmer = new PorterStemmer();
            ContentStemmed = stemmer.stemText(text);
            CountOccurances();
            ComputeTermFreq();
        }

        private void CountOccurances()
        {
            BagOfWords = new Dictionary<string, int>();
            foreach (var word in ContentStemmed)
            {
                if (BagOfWords.ContainsKey(word))
                {
                    BagOfWords[word]++;
                }
                else
                {
                    BagOfWords.Add(word, 1);
                }
            }
        }

        protected void ComputeTermFreq()
        {
            double max = BagOfWords.Values.Max();
            TermFrequency = new Dictionary<string, double>();
            foreach (var word in BagOfWords)
            {
                TermFrequency.Add(word.Key, word.Value/max);
            }
        }

        public virtual void ComputeVectorLength()
        {
            double res = 0;
            foreach (var idfRes in IdfResult)
            {
                res += Math.Pow(idfRes.Value, 2);
            }
            VectorLength = Math.Sqrt(res);
        }

        public void ApplyIdfComputation(Dictionary<string, double> idf)
        {
            IdfResult = new Dictionary<string, double>();
            foreach (var record in TermFrequency)
            {
                if (idf.ContainsKey(record.Key))
                    IdfResult.Add(record.Key, record.Value*idf[record.Key]);
            }
            ComputeVectorLength();
        }
    }
}