//librerie
using Newtonsoft.Json;

//dichiarazioni
string[] mainMenu = { "Aggiungi", "modifica", "elimina", "visualizza tutti", "visualizza dettagli", "visualizza disponibilità", "visualizza per posizione", "esci" };
string cartella = "Prodotti";
string[] filesLetti = LeggiFiles(cartella);
Prodotto[] tuttiProdotti = DeserializzaProdotti(filesLetti);

//main
while (true)
{
    switch (Menu(mainMenu))
    {
        case 1://aggiungi
            AggiungiProdotto(tuttiProdotti, cartella);
            filesLetti = LeggiFiles(cartella);
            tuttiProdotti = DeserializzaProdotti(filesLetti);
            break;
        case 2://modifica
            ModificaProdotto(tuttiProdotti, cartella);
            filesLetti = LeggiFiles(cartella);
            tuttiProdotti = DeserializzaProdotti(filesLetti);
            break;
        case 3://elimina
            EliminaProdotto(tuttiProdotti, cartella);
            filesLetti = LeggiFiles(cartella);
            tuttiProdotti = DeserializzaProdotti(filesLetti);
            break;
        case 4://visualizza tutti
            VisualizzaTuttiProdotti(tuttiProdotti);
            break;
        case 5://visualizza dettagli
            VisualizzaDettagli(tuttiProdotti);
            break;
        case 6://visualizza disponibilità
            VisualizzaDisponibilita(tuttiProdotti);
            break;
        case 7://visualizza per posizione
            VisualizzaPerMagazzino(tuttiProdotti);
            break;
        case 8://esci
            return;
    }
}

//funzioni
int Menu(string[] opzioni)
{
    int scelta;

    do
    {
        Console.WriteLine("seleziona l'operazione");
        for (int i = 0; i < opzioni.Length; i++)
        {
            Console.WriteLine($"{i + 1}) {opzioni[i]}");
        }
        scelta = InputIntero();
    } while (!(scelta >= 1 && scelta < opzioni.Length + 1));

    return scelta;
}

string[] LeggiFiles(string dir)
{
    int i = 0;

    if (!Directory.Exists(dir))
    {
        Directory.CreateDirectory(dir);
    }
    string[] filesNames = Directory.GetFiles(dir);
    string[] files = new string[filesNames.Length];
    foreach (string fileName in filesNames)
    {
        files[i] = File.ReadAllText(fileName);
        i++;
    }

    return files;
}

Prodotto[] DeserializzaProdotti(string[] testoFiles)
{
    int i = 0;
    Prodotto[] output = new Prodotto[testoFiles.Length];

    foreach (string tf in testoFiles)
    {
        output[i] = JsonConvert.DeserializeObject<Prodotto>(tf);
        i++;
    }

    return output;
}

void VisualizzaTuttiProdotti(Prodotto[] prodotti)
{
    foreach (Prodotto prodotto in prodotti)
    {
        Console.WriteLine($"codice: {prodotto.codice}");
        Console.WriteLine($"nome: {prodotto.nome}");
        Console.Write("\n");
    }
}

void VisualizzaDettagli(Prodotto[] prodotti)
{
    Prodotto oggettoCercato = InserisciCodice(prodotti);

    if (int.Parse(oggettoCercato.codice) == -1 && oggettoCercato.nome == "Errore")
    {
        Console.WriteLine("Codice non trovato");
        return;
    }
    DettagliProdotto(oggettoCercato);
}

void DettagliProdotto (Prodotto oggettoCercato)
{
    Console.WriteLine($"nome: {oggettoCercato.nome}");
    Console.WriteLine($"disponibilità: {oggettoCercato.disponibile}");
    Console.WriteLine($"quantità: {oggettoCercato.quantita}");
    Console.WriteLine($"categorie: {string.Join(", ", oggettoCercato.categorie)}");
    Console.WriteLine($"posizione: magazzino: {oggettoCercato.posizione.magazzino} scaffale: {oggettoCercato.posizione.scaffale}");
}

void VisualizzaDisponibilita(Prodotto[] prodotti)
{
    Prodotto oggettoCercato = InserisciCodice(prodotti);

    if (int.Parse(oggettoCercato.codice) == -1 && oggettoCercato.nome == "Errore")
    {
        Console.WriteLine("Codice non trovato");
        return;
    }
    if (oggettoCercato.disponibile)
    {
        Console.WriteLine("Prodotto Disponibile");
    }
    else
    {
        Console.WriteLine("Prodotto Non Disponibile");
    }
}

void VisualizzaPerMagazzino (Prodotto[] prodotti)
{
    List<Posizione> prodottiGiaVisualizzati = new();

    foreach (Prodotto prodotto in prodotti)
    {
        if (!VerificaGiaVisualizzato(prodottiGiaVisualizzati, prodotto.posizione))
        {
            Console.WriteLine($"posizione: magazzino: {prodotto.posizione.magazzino} scaffale: {prodotto.posizione.scaffale} \n");
            foreach (Prodotto p in prodotti)
            {
                if (ConfrontaPosizioni(prodotto.posizione, p.posizione))
                {
                    DettagliProdotto(p);
                    Console.Write("\n");
                }
            }
        }
        prodottiGiaVisualizzati.Add(prodotto.posizione);
    }
}

bool ConfrontaPosizioni (Posizione a, Posizione b)
{
    return a.magazzino == b.magazzino && a.scaffale == b.scaffale;
}

bool VerificaGiaVisualizzato (List<Posizione> posizione, Posizione posizioneDaVerificare)
{
    foreach (Posizione p in posizione)
    {
        if (ConfrontaPosizioni(p, posizioneDaVerificare))
        {
            return true;
        }
    }

    return false;
}

int CalcolaId(Prodotto[] prodotti)
{
    int id = 0;

    foreach (Prodotto prodotto in prodotti)
    {
        if (id <= int.Parse(prodotto.codice))
        {
            id = int.Parse(prodotto.codice) + 1;
        }
    }

    return id;
}

Prodotto CercaId(Prodotto[] prodotti, int id)
{
    foreach (Prodotto prodotto in prodotti)
    {
        if (id == int.Parse(prodotto.codice))
        {
            return prodotto;
        }
        
    }
    Prodotto ErroreProdotto = new();
    ErroreProdotto.codice = "-1";
    ErroreProdotto.nome = "Errore";

    return ErroreProdotto;
}

Prodotto InserisciCodice(Prodotto[] prodotti)
{
    int id = 0;

    Console.Write("codice: ");
    id = InputIntero();

    return CercaId(prodotti, id);
}

void AggiungiProdotto(Prodotto[] prodotti, string cartella)
{
    int quantitaProdotto = 0;
    int id = CalcolaId(prodotti);
    Prodotto newProdotto = new();

    newProdotto.codice = Convert.ToString(id);
    newProdotto.nome = InserisciNome();
    newProdotto.disponibile = InserisciQuantita(out quantitaProdotto);
    newProdotto.quantita = quantitaProdotto;
    newProdotto.categorie = InserisciCategorie();
    newProdotto.posizione = InserisciPosizione();
    string path = @$"{cartella}\Prodotto_{id}.Json";
    File.Create(path).Close();
    File.WriteAllText(path, JsonConvert.SerializeObject(newProdotto, Formatting.Indented));
}

void ModificaProdotto(Prodotto[] prodotti, string cartella)
{
    int quantitaProdotto = 0;
    string[] menuModifica = new string[] { "nome", "quantità", "categorie", "posizione", "torna indietro" };
    Prodotto oggettoCercato = InserisciCodice(prodotti);

    if (int.Parse(oggettoCercato.codice) == -1 && oggettoCercato.nome == "Errore")
    {
        Console.WriteLine("Codice non trovato");
        return;
    }
    switch (Menu(menuModifica))
    {
        case 1://nome
            oggettoCercato.nome = InserisciNome();
            break;
        case 2://quantità
            oggettoCercato.disponibile = InserisciQuantita(out quantitaProdotto);
            oggettoCercato.quantita = quantitaProdotto;
            break;
        case 3://categorie
            oggettoCercato.categorie = InserisciCategorie();
            break;
        case 4://posizione
            oggettoCercato.posizione = InserisciPosizione();
            break;
        case 5://torna indietro
            return;
    }
    string path = @$"{cartella}\Prodotto_{oggettoCercato.codice}.Json";
    File.WriteAllText(path, JsonConvert.SerializeObject(oggettoCercato, Formatting.Indented));
}

void EliminaProdotto(Prodotto[] prodotti, string cartella)
{
    string[] sicuroCancella = { "si", "no" };
    Prodotto oggettoCercato = InserisciCodice(prodotti);

    if (int.Parse(oggettoCercato.codice) == -1 && oggettoCercato.nome == "Errore")
    {
        Console.WriteLine("Codice non trovato");
        return;
    }
    Console.WriteLine("vuoi cancellare questo elemento?");
    Console.WriteLine($"nome: {oggettoCercato.nome} codice: {oggettoCercato.codice}");
    if (Menu(sicuroCancella) == 1)
    {
        string path = @$"{cartella}\Prodotto_{oggettoCercato.codice}.Json";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        else
        {
            Console.WriteLine("Errore: il nome del file non è stato trovato");
        }
    }
}

int InputIntero()
{
    int numero;

    while (!int.TryParse(Console.ReadLine(), out numero))
    {
        Console.WriteLine("Devi inserire un numero!");
    }

    return numero;
}

string InserisciNome()
{
    Console.Write("Nome: ");

    return Console.ReadLine();
}

bool InserisciQuantita(out int numero)
{
    numero = 0;

    Console.Write("Quantità: ");
    numero = InputIntero();
    if (numero > 0)
    {
        return true;
    }
    else
    {
        return false;
    }
}

string[] InserisciCategorie()
{
    List<string> categorie = new();
    string again;

    do
    {
        Console.Write("inserisci categoria: ");
        categorie.Add(Console.ReadLine());
        Console.WriteLine("Vuoi inserire un altra categoria? ('si' per inserirne un altra)");
        again = Console.ReadLine();
    } while (again == "si");
    string[] categorieArray = categorie.ToArray();

    return categorieArray;
}

Posizione InserisciPosizione()
{
    Posizione newPosizione = new();

    Console.WriteLine("inserisci posizione");
    Console.Write("magazzino: ");
    newPosizione.magazzino = Console.ReadLine();
    Console.Write("scaffale: ");
    newPosizione.scaffale = InputIntero();

    return newPosizione;
}

//classi
public class Prodotto
{
    public string codice { get; set; }
    public string nome { get; set; }
    public bool disponibile { get; set; }
    public int quantita { get; set; }
    public string[] categorie { get; set; }
    public Posizione posizione { get; set; }
}

public class Posizione
{
    public string magazzino { get; set; }
    public int scaffale { get; set; }
}