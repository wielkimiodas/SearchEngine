using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchEngine.Solver.Stemmer;

namespace SearchEngine.Solver.UnitTest
{
    [TestClass]
    public class StemmerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var stemmer = new PorterStemmer();
            var res = stemmer.stemTerm("Available");
            var res2 = stemmer.stemTermToLowerAndClean("available, But ... yoU know what is available");
            Debug.WriteLine("Res2: " + res2);
            var arr = res2.Split(' ');
        }
    }
}
