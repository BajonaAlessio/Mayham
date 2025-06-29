//ASSEGNAZIONI
Dictionary<string, DateTime> partecipanti = RaccogliPartecipanti(); //dizionario globale con i partecipanti (nome e data di nascita)
List<string> idonei = FiltraIdonei(partecipanti); //lista globale per i partecipanti idonei
//MAIN
SorteggiaPartecipante(idonei); //chiamata alla funzione che sorteggia un partecipante idoneo
//FUNZIONI
Dictionary<string, DateTime> RaccogliPartecipanti() //funzione che raccoglie i partecipanti senza nessun parametro
{
    Dictionary<string, DateTime> partecipanti = new Dictionary<string, DateTime>();

    while (true)
    {
        //gestione del nome
        Console.Write("inserisci nome (o fine per uscire): ");
        string nome = Console.ReadLine();
        //se l'utente inserisce fine usciamo dal ciclo
        if (nome.ToLower() == "fine")
        {
            break; //esce dal ciclo se l'utente inserisce fine
        }
        //gestione della data di nascita
        Console.Write("inserisci data di nascita: ");
        string inputData = Console.ReadLine();
        //parse della data inserita in modo che da string diventi datetime
        DateTime data; //variabile per memorizzare la data di nascita
        if (!DateTime.TryParse(inputData, out data))
        {
            Console.WriteLine("Data non valida. riprova.");
            continue;
        }
        //aggiunta del partecipante al dizionario
        partecipanti[nome] = data;

    }
    return partecipanti;  //restituisce il dizionario dei partecipanti
}

List<string> FiltraIdonei(Dictionary<string, DateTime> partecipanti) //funzione che filtra i partecipanti idonei con parametro dizionario partecipanti da filtrare in una lista
{
    //lista partecipanti idonei
    List<string> idonei = new();
    //gestire la data odierna
    DateTime oggi = DateTime.Today;
    //ciclo per filtrare i partecipanti idonei
    foreach (var p in partecipanti)
    {
        //calcolo l'età del partecipante
        int eta = oggi.Year - p.Value.Year;
        //se l'età è maggiore o uguale a 21 aggiungo il partecipante alla lista degli idonei
        if (eta >= 21)
        {
            //aggiunta del partecipante alla lista
            idonei.Add(p.Key);
        }
    }

    return idonei;  //restituisce la lista dei partecipanti idonei
}

void SorteggiaPartecipante(List<string> idonei) //funzione che sorteggia un partecipante idoneo con parametro lista di idonei e nessun return dato che deve solo stampare
{
    //gestire il caso in cui non ci sono partecipanti idonei
    if (idonei.Count > 0)
    {
        //generare un numero casuale per sorteggiare un partecipante idoneo
        Random rnd = new();
        //sorteggio il partecipante idoneo
        string scelto = idonei[rnd.Next(idonei.Count)];
        //stampare il nome del partecipante sorteggiato
        Console.WriteLine("Partecipante scelto: " + scelto);
    }
    else
    {
        Console.WriteLine("nessun partecipante trovato");
    }        
}