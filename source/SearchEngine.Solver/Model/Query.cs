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
            : base(query)
        {
        }
    }
}
