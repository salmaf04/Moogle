
using System;

class Vector{
   public string path;
  
public Dictionary<string, double> TF_IDF = new Dictionary<string, double>();
public int cantidadPalabras;
public List<string> Vectorwords;
    public Vector(List<string> words, string path){
        this.Vectorwords = words;
        this.path = path;
        this.cantidadPalabras = words.Count();
        Matrix.files.Add(this);
    }
    public string Getname (){
    return path.Substring(path.LastIndexOf('/') + 1, path.IndexOf(".txt") - path.LastIndexOf('/') - 1);
}
    
}



