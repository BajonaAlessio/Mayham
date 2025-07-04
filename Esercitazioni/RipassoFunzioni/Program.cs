//app con menù e funzioni di base
//le funzioni sono dei principali tipi (void, int, con dati complessi di ritorno)

//ci sono due tipi di metodi dei quali uno è statico
//il metodo statico è un metodo che può essere invocato senza creare un'istanza della classe
//Random random = new Random(); <---ESEMPIO CONTRARIO (non static)
//i metodi statici sono invocati direttamente dalla classe quindi direttamente accessibili senza bisogno di creare un istanza della classe
//static readonly -> valore condiviso da tutte le istanze, ma immutabile dopo l'inizializzazione
//public static readonly -> valore condiviso da tutte le istanze, ma immutabile dopo inizializzazione ed accessibile ovunque

//public -> Accessibilità -> chi può vedere/chiamare il membro
//static -> Legame alla classe -> membro condiviso, invocabile senza istanza
//readonly -> Immutabilità dopo inizializzazione -> Campo assegnabile solo in dichiarazione o costruttore

//creo un menù di opzioni per scegliere quale funzione invocare
while (true)
{
    Console.Clear();
    Console.WriteLine("1. esempio di funzione void");
    Console.WriteLine("2. esempio di funzione con azione");
    Console.WriteLine("3. esempio di funzione con dati complessi");
    Console.WriteLine("0. esci");
    Console.Write("scegli un opzione: ");
    string scelta = Console.ReadLine();
    switch (scelta)
    {
        case "1":
            EsempioVoid();
            break;
        case "2":
            EsempioConAzione();
            break;
        case "3":
            EsempioDatiComplessi();
            break;
        case "0":
            Console.WriteLine("Uscita dal programma");
            return;
        default:
            Console.WriteLine("opzione non valida");
            Console.ReadKey();
            break;
    }
}

//una funzione void che non restituisce nulla
static void EsempioVoid()
{
    //pulisco la console
    Console.Clear();
    Console.WriteLine("--funzione void--");
    //stampa un messaggio di saluto
    StampaSaluto();
    Console.WriteLine("Premi un tasto per tornare al menu..");
    Console.ReadKey();
}

static void StampaSaluto()
{
    Console.WriteLine("Ciao!");
}



//funzione void: non restituisce nulla ma esegua un azione
static void EsempioConAzione()
{
    Console.Clear();
    Console.WriteLine("---Funzione con Azione---");
    //chiedo i dati all'utente
    Console.Write("Inserisci il primo numero: ");
    int a = int.Parse(Console.ReadLine() ?? "0");
    Console.Write("Inserisci il secondo numero: ");
    int b = int.Parse(Console.ReadLine() ?? "0");
    int somma = Somma(a, b);
    Console.WriteLine("Premi un tasto per tornare al menu..");
    Console.ReadKey();
}

//funzione con tipo di ritorno: restituisce un valore
static int Somma(int x, int y)
{
    return x + y;
}


//funzione che gestisce dati complessi: elenco di libri
static void EsempioDatiComplessi()
{
    Console.Clear();
    Console.WriteLine("---Funzione con dati complessi---");

    //creo elenco di libri
    var libri = new List<Libro>
    {
        new Libro("Il nome della rosa", 1980, "Storico", true),
        new Libro("1984", 1949, "distopico", false),
        new Libro("Il signore degli anelli", 1954, "Storico", true)
    };

    //filtro i libri letti usando la funzione FiltraLibriLetti
    var libriLetti = FiltraLibriLetti(libri);

    //stampo i libri letti
    Console.WriteLine("Libri già letti:");
    foreach (var libro in libriLetti)
    {
        Console.WriteLine($"- {libro.Titolo} ({libro.Anno}) - {libro.Genere}");
    }
    Console.WriteLine("Premi un tasto per tornare al menu..");
    Console.ReadKey();
}

static List<Libro> FiltraLibriLetti(List<Libro> libri)
{
    List<Libro> libriLetti = new();
    foreach (var libro in libri)
    {
        if (libro.Letto)
        {
            libriLetti.Add(libro);
        }
    }
    return libriLetti;
}


public class Libro
{
    // proprieta
    public string Titolo { get; set; } // proprieta pubbliche accessibili tramite i metodi get e set
    public int Anno { get; set; }
    public string Genere { get; set; }
    public bool Letto { get; set; }

    // costruttore di default (senza parametri)
    public Libro()
    {
        // inizializza i valori di default
        Titolo = "Sconosciuto";
        Anno = 2000;
        Genere = "N/A";
        Letto = false;
    }

    // costruttore
    // si chiama come la classe pero senza il tipo di ritorno
    public Libro(string titolo, int anno, string genere, bool letto)
    {
        // Qui inizializzo le proprietà con i valori passati
        Titolo = titolo;
        Anno = anno;
        Genere = genere;
        Letto = letto;
    }
}