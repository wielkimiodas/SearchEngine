using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Windows.Forms;
using LAIR.Collections.Generic;
using LAIR.ResourceAPIs.WordNet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SearchEngine.Solver.UnitTest
{
    [TestClass]
    public class WordNetTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var a = Environment.CurrentDirectory;
            var b = a.Substring(0,a.IndexOf("source"));
            var c = Path.Combine(b, @"contrib\WordNet 3.0\dict");
            //Path.GetDirectoryName(Program  )
            var wordNetEngine = new WordNetEngine(c, false);
            var txt = "sex";
            var synSetsToShow = wordNetEngine.GetSynSets(txt, WordNetEngine.POS.Adjective);
            var synonyms = new List<string>();
            foreach (var synSet in synSetsToShow)
            {
                foreach (var word in synSet.Words)
                {
                    if (!synonyms.Contains(word))
                    {
                        synonyms.Add(word);
                    }
                }
            }
            string res = null;
            foreach (var synonym in synonyms)
            {
                res += synonym + " ";
            }
            MessageBox.Show("Synonyms: "+ res);
        }
    }
}
