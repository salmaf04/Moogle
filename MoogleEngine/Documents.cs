using System.Text.RegularExpressions;

public static class Documents{
static List <string> Vocabulary = new List<string>();
public static void GetDocuments(){
    //Recibir direccion de los documentos
string filePath = @"../Content/";
string[] docs = Directory.GetFiles(filePath, "*.txt");
//Obtener el texto de todos los documentos
string  alldocs = "";
foreach (string doc in docs){

    string document = File.ReadAllText(doc).ToLower();
    alldocs += document;
    List <string> wordsOfDocs = Regex.Split(document, @"[^\wáéíóúÁÉÍÓÚ]+").ToList();
    Vector v = new Vector(wordsOfDocs, doc);
}
foreach (Vector v in Matrix.files){
    Matrix.CalculateTFIDF(v);
}
foreach (string key in Matrix.idf.Keys){
    Matrix.idf [key] = Math.Log(Matrix.files.Count/Matrix.idf [key]);
}

}


}

  
