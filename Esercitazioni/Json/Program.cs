// Json

/*
i file json sono file di testo che contengono dati strutturati in un formato leggibile dall'uomo
JSON st per Javascript Object Notation è un formato di scambio molto comune
*/

//in c# per leggere un file json, è possibile utilizzare la libreria Newtonsoft.Json
//i files json hanno bisogno di essere serializzati e deserializzati per poter essere utilizzati in csharp

//installazione della libreria Newtonsoft.Json ---> dotnet add package Newtonsoft.Json


//esempio di Deserializzazione (lettura)
using Newtonsoft.Json;

//percorso del file json
string path = @"Persona.json"; //in questo caso il file è nella stessa cartella del programma

//deserializzo il file json on un oggetto
string json = File.ReadAllText(path);
Partecipante partecipante = JsonConvert.DeserializeObject<Partecipante>(json);//deserializzazione tramite Jsonconvert

//Partecipante partecipante = JsonSerializer.Deserialize<Partecipante>(json); //deserializzazione tramite Newtonsoft.Json

//una volta deserializzato, posso accedere ai campi dell'oggetto
//nome
Console.WriteLine($"Nome: {partecipante.nome}");
//età
Console.WriteLine($"età: {partecipante.eta}");
//presente
Console.WriteLine($"Presente: {partecipante.presente}");
//interessi
Console.WriteLine("Interessi: ");
foreach (var interesse in partecipante.interessi)
{
    Console.WriteLine($"- {interesse}");
}
Console.WriteLine($"Interessi di nuovo ma col Join: \n - {string.Join("\n - ", partecipante.interessi)}");

//deserializzo un nodo specifico in questo caso un indirizzo che è formato da più campi tipo via vittà cap
Console.WriteLine($"Indirizzo {partecipante.indirizzo.via}, {partecipante.indirizzo.citta}, {partecipante.indirizzo.cap}");

//esempio di serializzazione (scrittura)
Partecipante nuovoPartecipante = new Partecipante//crea un nuovo oggetto partecipante tramite il costruttore
//lo serializzo con i valori desiderati
{
    nome = "nuovo partecipante",
    eta = 25,
    presente = true,
    interessi = new List<string> { "arte", "viaggi", "cucina" },
    indirizzo = new Indirizzo
    {
        via = "Via Milano",
        citta = "Roma",
        cap = "00100"
    }
};
//serializzo l'oggetto in un file json
string newJson = JsonConvert.SerializeObject(nuovoPartecipante, Formatting.Indented);
string outputPath = @"output.Json";
File.WriteAllText(outputPath, newJson);
Console.WriteLine("JSON serializzato");
Console.WriteLine(newJson);

//esempio di modifica del valore di un campo
partecipante.nome = "Partecipante 2";
string jsonModificato = JsonConvert.SerializeObject(partecipante, Formatting.Indented);
File.WriteAllText(path, jsonModificato);

//esempio di cancellazione di un file json
//cancello il file json
/*if (File.Exist(path))
{
    File.Delete(path);
    Console.WriteLine($"File {path} cancellato");
}
else
{
    Console.WriteLine($"il file {path} non esiste");
}*/

//creare la classe partecipante
public class Partecipante
{
    public string nome { get; set; }
    public int eta { get; set; }
    public bool presente { get; set; }
    public List<string> interessi { get; set; }
    public Indirizzo indirizzo { get; set; } //campo oggetto di tipo indirizzo
}
public class Indirizzo
{
    public string via { get; set; }
    public string citta { get; set; }
    public string cap { get; set; }
}