using System;
using System.Text.RegularExpressions;

static class Matrix{
public static List <Vector> files = new List<Vector>();
public static Dictionary<string, double> idf = new Dictionary<string, double>();


    public static void CalculateTFIDF (Vector v){
        foreach (string word in v.Vectorwords){
            if (!v.TF_IDF.ContainsKey(word)){
                v.TF_IDF.Add(word, 1);
                }
                else{
                    v.TF_IDF[word] ++;
                }      
            }
            foreach (string key in v.TF_IDF.Keys){
                if (! idf.ContainsKey(key)){
                    idf.Add(key, 1);
                }
                else{
                    idf [key] ++;
                }
                v.TF_IDF[key] /= v.cantidadPalabras;
            }
        }
       
    }

    

    





















































