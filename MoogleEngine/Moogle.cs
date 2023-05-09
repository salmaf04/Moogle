using System.Text.RegularExpressions;
namespace MoogleEngine;


public static class Moogle
{
    public static SearchResult Query(string query) {
        

        SearchItem[] items = Search(query);

        return new SearchResult(items, query);
    }
    public static SearchItem[] Search (string x){
        List<string> query = Regex.Split(x.ToLower(), @"[^\wáéíóúÁÉÍÓÚ]+").ToList();
        List<SearchItem> result = new List<SearchItem>();
        foreach(Vector doc in Matrix.files){
            double maxTFIDF = 0;
            string maxword = "";
            double score = 0;
            foreach(string word in query){
                if (doc.TF_IDF.ContainsKey (word) && Matrix.idf [word] > 0.5){
                    double tfidf = doc.TF_IDF[word] * Matrix.idf[word];
                    score += tfidf * (Matrix.idf[word] * (double) query.Count(x => x == word) / query.Count);
                    if(tfidf > maxTFIDF){
                        maxTFIDF = tfidf;
                        maxword = word;
                    }
                }
            }
            if (score > 0){
                result.Add(new SearchItem(doc.Getname(),Snippet(doc.path, maxword), (float) score));
            }
        }
        return result.OrderByDescending(x => x.Score).ToArray();
    }
    static string Snippet (string path, string word){
        string text = File.ReadAllText(path);
        if (text.Length < 150){
           text =  text.Substring(0);
        }
        else{
         text = text.Substring(0, 149);
        }
        return text;
    }
}
