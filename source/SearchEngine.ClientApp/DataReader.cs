using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using SearchEngine.Solver.Model;

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
                for(var i=1; i<docLines.Length;i++)
                {
                    doc.Content += docLines[i];
                }
                documents.Add(doc);
            }
            
            return documents;
        }

        public static List<string> LoadKeywords(string path)
        {
            if (path == null) throw new ArgumentNullException("path");

            var allText = File.ReadAllText(path);
            var keywords = allText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            return new List<string>(keywords);
        }
    }
}
