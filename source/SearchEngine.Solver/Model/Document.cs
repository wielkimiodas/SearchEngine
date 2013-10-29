using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Solver.Model
{
    public class Document
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public HashSet<string> ContentStemmed { get; set; }
        public float Similarity { get; set; }
    }
}
