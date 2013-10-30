using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SearchEngine.Solver.Model
{
    public abstract class TfidfBase
    {
        public virtual Dictionary<string, int> BagOfWords { get; set; }
        public virtual List<string> ContentStemmed { get; set; }
        public virtual Dictionary<string, double> TermFrequency { get; set; }
        public virtual double VectorLength { get; set; }

        protected virtual void CountOccurances()
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

        protected virtual void OverallComputation()
        {
            CountOccurances();
            ComputeTermFreq();            
            ComputeVectorLength();
        }

        protected virtual void ComputeTermFreq()
        {
            double max = BagOfWords.Values.Max();
            TermFrequency = new Dictionary<string, double>();
            foreach (var word in BagOfWords)
            {
                TermFrequency.Add(word.Key, word.Value / max);
            }
        }

        protected virtual void ComputeVectorLength()
        {
            double res = 0;
            foreach (var term in TermFrequency)
            {
                res += Math.Pow(term.Value, 2);
            }
            VectorLength = Math.Sqrt(res);
        }

    }
}
