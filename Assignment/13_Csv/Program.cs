using System.Globalization;
CultureInfo.CurrentCulture = new CultureInfo("it-IT");
string percorso = "prodotti.csv"; //percorso del file CSV
List<string[]> prodotti = LeggiProdotti(percorso); 
string[] opzioniMenuBase = { "aggiungi prodotto", "visualizza prodotti", "modifica prodotto", "elimina prodotto", "esci" };

while (true)
{
    switch (menu(opzioniMenuBase))
    {
        case 0://aggiungi
            AggiungiESalva();
            break;
        case 1://visualizza
            MostraProdotti(prodotti); 
            break;
        case 2://modifica
            ModificaProdotto(prodotti);
            break;
        case 3://elimina
            EliminaProdotto(prodotti);
            break;
        case 4://esci
            return;
    }
}

//funzioni
void AggiungiESalva()
{
    string continua = "si";
    while (true)
    {
        AggiungiProdotto(prodotti);

        Console.WriteLine("Vuoi inserire un altro prodotto?");
        string[] siONo = { "si", "no" };
        if (menu(siONo) == 0)
        {
            ScriviProdotti(percorso, prodotti);//scrivi i prodotti su CSV
            continue;
        }
        else
        {
            break;
        }
    }
}

List<string[]> LeggiProdotti(string file)
{
    //creo una lista di stringhe per ottenere i prodotti
    List<string[]> lista = new();
    //verifico se ci sia il file
    if (File.Exists(file))
    {
        string[] righe = File.ReadAllLines(file);//leggo file riga per riga
        for (int i = 1; i < righe.Length; i++)
        {
            //separo i valori della riga (dove c'è la virgola) usando il metodo split
            string[] campi = righe[i].Split(',');
            //aggiungo i campi alla lista
            lista.Add(campi);
        }
    }
    return lista;
}

void MostraProdotti(List<string[]> prodotti)
{
    //se non ci sono prodotti stampiamo un messaggio
    if (prodotti.Count == 0)
    {
        Console.WriteLine("Nessun prodotto disponibile.");
        return;
    }
    //altrimenti stampiamo i prodotti
    foreach (var prodotto in prodotti)
    {
        Console.WriteLine($"Id: {prodotto[0]}, Nome: {prodotto[1]}, Prezzo: {prodotto[2]}");
    }
}

void AggiungiProdotto (List<string[]> prodotti)
{
    Console.WriteLine("inserisci prodotto: ");
    string nome = Console.ReadLine();
    Console.WriteLine("inserisci prezzo: ");
    string prezzoInput = Console.ReadLine();
    double prezzo;
    while (!double.TryParse(prezzoInput, out prezzo))
    {
        Console.Write("Prezzo non valido. riprova: ");
        prezzoInput = Console.ReadLine();
    }
    int nuovoId = CalcolaNuovoId(prodotti, 0);
    //creiamo un array di stringhe per il nuovo prodotto
    //Console.WriteLine(prezzo);//debug test
    string[] nuovoProdotto = new string[] { nuovoId.ToString(), nome, prezzo.ToString("F2") }; //F2 serve per formattare il prezzo con 2 decimali
    nuovoProdotto[2] = nuovoProdotto[2].Replace(',', '.');
    prodotti.Add(nuovoProdotto);
}

void ModificaProdotto(List<string[]> prodotti)
{
    int posizione = TraduciId(prodotti);
    if (posizione != -1)
    {
        string[] cosaModificare = new string[] { "nome", "prezzo" };
        int scelta = menu(cosaModificare) + 1;
        Console.WriteLine($"inserisci il nuovo {cosaModificare[scelta - 1]}");
        string nuovoNome = Console.ReadLine();
        prodotti[posizione][scelta] = nuovoNome;
        ScriviProdotti(percorso, prodotti);
    }
}

void EliminaProdotto(List<string[]> prodotti)
{
    int posizione = TraduciId(prodotti);
    if (posizione != -1)
    {
        prodotti.RemoveAt(posizione);
        ScriviProdotti(percorso, prodotti);
    }
}

bool VerificaProdotto(List<string[]> prodotti, out int IdItem) 
{
    while (true)
    {
        IdItem = 0;
        Console.Write("Inserisci l'Id del prodotto: ");
        while (!int.TryParse(Console.ReadLine(), out IdItem))
        {
            Console.WriteLine("inserisci un numero");
        }

        string[] arrayVuoto = { "array vuoto" };
        if (arrayVuoto.SequenceEqual(CercaId(prodotti, IdItem)))
        {
            Console.WriteLine("ID non trovato");
            continue;
        }
        Console.Write("Vuoi selezionare: ");
        
        Console.Write($"{string.Join(", ", CercaId(prodotti, IdItem))} ");
        Console.WriteLine("\n");

        string[] opzioniContinua = new string[] { "si", "no", "indietro" };
        switch (menu(opzioniContinua))
        {
            case 0:
                return true;
            case 1:
                continue;
            case 2:
                return false;
            default:
                return false;
        }
    }
}

int CalcolaNuovoId(List<string[]> prodotti, int idCorrente)
{
    return int.Parse(prodotti[prodotti.Count - 1][0]) + 1;
}

void ScriviProdotti(string file, List<string[]> prodotti)
{
    //scrivo l'intestazione del file CSV
    List<string> righe = new() { "Id,Nome,Prezzo" };
    //ciclo i prodotti e li aggiungo
    foreach (var prodotto in prodotti)
    {
        //creo la riga del prodotto usando il metodo join per unire i campi con la virgola
        string riga = string.Join(",", prodotto);
        righe.Add(riga);
    }
    //scrivo il contenuto sul file csv
    File.WriteAllLines(file, righe);
}

int menu(string[] opzioni)
{
    int scelta;
    do
    {
        Console.WriteLine("seleziona l'operazione");
        for (int i = 0; i < opzioni.Length; i++)
        {
            Console.WriteLine($"{i}) {opzioni[i]}");
        }
        while (!int.TryParse(Console.ReadLine(), out scelta))
        {
            Console.WriteLine("inserisci un numero");
        }
    } while (!(scelta >= 0 && scelta < opzioni.Length));

    return scelta;
}

string[] CercaId(List<string[]> prodotti, int id)
{
    foreach (string[] prodotto in prodotti)
    {
        if (int.Parse(prodotto[0]) == id)
        {
            return prodotto;
        }
    }
    string[] arrayVuoto = { "array vuoto" };
    return arrayVuoto;
}

int TraduciId(List<string[]> prodotti)
{
    int id;
    if (VerificaProdotto(prodotti, out id))
    {
        int posizioneOggetto = prodotti.IndexOf(CercaId(prodotti, id));
        return posizioneOggetto;
    }
    return -1;
}