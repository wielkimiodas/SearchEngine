using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SearchEngine.Solver.Stemmer;

namespace SearchEngine.Solver.Model
{
    public sealed class Document : TfidfBase, IComparable<Document>
    {
        public string Title { get; set; }
        public double Similarity { get; set; }

        public Document(string paragraph) : base(paragraph)
        {
            Title = paragraph.Substring(0, paragraph.IndexOf('\n'));
        }

        public int CompareTo(Document that)
        {
            if (that == null) return -1;
            if (Similarity == that.Similarity) return 0;
            if (Similarity > that.Similarity) return -1;
            return 1;
        }

        
    }
}
