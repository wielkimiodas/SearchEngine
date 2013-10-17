﻿using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SearchEngine.Solver.Stemmer;

namespace SearchEngine.Solver.UnitTest
{
    [TestClass]
    public class StemmerTest
    {
        [TestMethod]
        public void StemmingMethodTest()
        {
            var stemmer = new PorterStemmer();
            var res2 = stemmer.stemText("Such an analysis can reveal features that are not easily visible " +
                                        "from the variations in the individual genes and can lead to a picture of " +
                                        "expression that is more biologically transparent and accessible to interpretation.");
        }
    }
}
