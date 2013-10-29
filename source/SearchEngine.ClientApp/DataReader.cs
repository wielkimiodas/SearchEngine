using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using SearchEngine.Solver.Model;
using SearchEngine.Solver.Stemmer;

namespace SearchEngine.ClientApp
{
    class DataReader
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
                var docLines = stringDoc.Split(new string[] {Environment.NewLine}, StringSplitOptions.None);
                var doc = new Document {Title = docLines[0]};

                var stemmer = new PorterStemmer();
                var stemmed = stemmer.stemText(stringDoc);
                doc.ContentStemmed = stemmed;

                for(var i=1; i<docLines.Length;i++)
                {
                    doc.Content += docLines[i];
                }
                documents.Add(doc);
            }
            
            return documents;
        }

        public static List<Keyword> LoadKeywords(string path)
        {
            if (path == null) throw new ArgumentNullException("path");

            var allText = File.ReadAllText(path);
            var keywordsArray = allText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            var keywords = new List<Keyword>();

            var stemmer = new PorterStemmer();

            foreach (var keywordElem in keywordsArray)
            {
                var stemmed = stemmer.stemTerm(keywordElem);
                var keyword = new Keyword {Value = keywordElem, ValueStemmed = stemmed};
                keywords.Add(keyword);
            }

            return keywords;
        }
    }
}
