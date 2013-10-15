using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.Solver.Stemmer
{
    interface StemmerInterface
    {
        string stemTerm(string s);
    }
}
