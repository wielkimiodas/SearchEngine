using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using SearchEngine.Solver.Model;
using SearchEngine.Solver.Stemmer;

namespace SearchEngine.Solver
{
    internal class DataReader
    {
        public static List<Document> LoadDocuments(string path)
        {
            if (path == null) throw new ArgumentNullException("path");

            var allText = File.ReadAllText(path);
            //splitting by double new line
            var stringDocs = Regex.Split(allText, @"(?:\r\n){2,}");

            var documents = new List<Document>();

            foreach (var stringDoc in stringDocs)
            {
                var doc = new Document(stringDoc);
                documents.Add(doc);
            }

            return documents;
        }

        public static List<Keyword> LoadKeywords(string path)
        {
            if (path == null) throw new ArgumentNullException("path");

            var allText = File.ReadAllText(path);
            var keywordsArray = allText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            var keywords = new List<Keyword>();

            var stemmer = new PorterStemmer();

            foreach (var keywordElem in keywordsArray)
            {
                var stemmed = stemmer.stemTerm(keywordElem);
                var keyword = new Keyword { Value = keywordElem, ValueStemmed = stemmed };
                keywords.Add(keyword);
            }

            return keywords;
        }
    }
}