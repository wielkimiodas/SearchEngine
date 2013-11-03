using System;
using System.Collections.Generic;
using System.IO;
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
            string a = Environment.CurrentDirectory;
            string b = a.Substring(0, a.IndexOf("source"));
            string c = Path.Combine(b, @"contrib\WordNet 3.0\dict");
            WordNetEngine wordNetEngine = new WordNetEngine(c, false);
            string txt = "availability";
            Set<SynSet> synSetsToShow = wordNetEngine.GetSynSets(txt, WordNetEngine.POS.Adjective);
            synSetsToShow.AddRange(wordNetEngine.GetSynSets(txt, WordNetEngine.POS.Adverb));
            synSetsToShow.AddRange(wordNetEngine.GetSynSets(txt, WordNetEngine.POS.Noun));
            synSetsToShow.AddRange(wordNetEngine.GetSynSets(txt, WordNetEngine.POS.Verb));

            List<string> synonyms = new List<string>();
            foreach (SynSet synSet in synSetsToShow)
            {
                foreach (string word in synSet.Words)
                {
                    if (!synonyms.Contains(word))
                    {
                        synonyms.Add(word);
                    }
                }
            }
            string res = null;
            foreach (string synonym in synonyms)
            {
                res += synonym + " ";
            }
            MessageBox.Show("Synonyms: " + res);
        }
    }
}