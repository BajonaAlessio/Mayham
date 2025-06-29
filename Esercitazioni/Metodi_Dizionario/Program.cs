//    ---metodi dizionario---

/* i metodi disponibili per manipolare i dizionari sono:
- Add
- Clear
- ContainsKey
- ContainsValue
- Remove
- TryGetValue

in un dizionario le chiavi sono uniche e non possono essere duplicate. I valori possono essere duplicati
*/

//Add
//aggiunge un elemento al dizionario. Se la chiave esiste già il valore viene aggiornato.
//dichiaro un dizionario int string
Dictionary<int, string> Dizionario = new Dictionary<int, string>()
{
    {1, "uno"},
    {2, "due"},
    {3, "tre"}
};
//aggiungo un elemento al dizionario
Dizionario.Add(4, "Quattro");
//Se la chiave esiste già il valore viene aggiornato.
//Dizionario.Add(1, "uno aggiornato");

//ContainsKey
//verifica se una chiave esiste nel dizionario
bool esisteChiave = Dizionario.ContainsKey(1);

//ContainsValue
//verifica se un valore esiste nel dizionario
bool esisteValore = Dizionario.ContainsValue("uno aggiornato");

//remove
//remove un elemento dal dizionario in base alla chiave. Se la chiave non esiste, non viene fatto nulla
Dizionario.Remove(2);
Dizionario.Remove(5);

//try get value
//prova a ottenere il valore associato a una chiave. se la chiave esiste, restituisce true e il valore; altrimenti restituisce false e un valore predefinito
if (Dizionario.TryGetValue(1, out string valore1))
{
    Console.WriteLine($"Valore associato alla chiave 1: {valore1}");
}
else
{
    Console.WriteLine($"Chiave 1 non trovata");
}

//clear
//rimuovi tutti gli elementi dal dizionario
Dizionario.Clear();

//Dizionario di liste
//un dizionario può contenere come valori anche altre strutture dati, come ad esempio una lista
Dictionary<int, List<string>> dizionarioListe = new Dictionary<int, List<string>>()
{
    {1, new List<string> {"nome", "prezzo"} },
    {2, new List<string> {"nome"} },
    {3, new List<string> {"nome", "prezzo", "quantita"} }
};
//aggiungo un elemento all lista associato alla chiave 1
dizionarioListe[1].Add("quantita");
dizionarioListe.Add(4, new List<string> { "nome", "prezzo", "quantita" });
// stampo il dizionario
foreach (var kvp in dizionarioListe)
{
    Console.WriteLine($"Chiave: {kvp.Key}, Valori: {string.Join(", ", kvp.Value)}");
}
//posso stampare un elemento specifico della lista associata a una chiave
Console.WriteLine(dizionarioListe[1][0]);
//posso stampare una chiave specifica ad esempio la chiave della seconda coppia chiamandolo con l'indice come in un array
Console.WriteLine(dizionarioListe.Keys.ElementAt(1)); //prende la key all'indice 1
Console.WriteLine(string.Join(", ", dizionarioListe.Values.ElementAt(2))); //prende il value all'indice 2