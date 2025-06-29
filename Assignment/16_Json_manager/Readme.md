# Json manager

il programma deve permettere di gestire una serie di files json dentro ad una folder specifica

## il programma deve permettere di:
- aggiungere un nuovo file json
- modificare i campi disponibile e quantità di un file specifico
- eliminare un file json specifico
- visualizzare un elenco dei files json presenti nella cartella
- visualizzare il contenuto di un file json specifico
- visualizzare i prodotti disponibili divisi per categoria e per magazzino

## requisiti:
- il programma deve chiedere all'utente di scegliere un azione tra quelle disponibili (quindi deve esserci un menu delle azioni disponibili)
- il programma deve essere organizzato in funzioni
- il programma deve deserializzare i dati in oggetti json
- gli oggetti devono essere rappresentati da classi con le proprietà accessibili tramite le keyword 'get' e 'set'
- il programma deve usare i metodi di files in modo da poter leggere e scrivere i files
- ogni files json deve avere come nome l'id univoco del prodotto
- una funzione deve essere dedicata alla generazione di un id univoco per i files json
- il programma deve essere in grado di gestire eventuali errori (ad esempio, se il file json non esiste, se il file json non è valido, ecc..)
- deve essere presente un file readme con la descrizione delle funzioni

## esempio di file json:
Prodotto_12345.json
```json
{
    "codice": "12345",
    "nome": "Prodotto 1",
    "disponibile": true,
    "quantità": 100,
    "categorie": ["Elettronica", "Computer"],
    "posizione": {
        "magazzino": "magazzino-1",
        "scaffale": 20
    }
}
```

# Spiegazione Funzioni

### Menu

Funzione:

```csharp
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
```

la funzione visualizza una lista del tipo:
```txt
 1) opzione 1
 2) opzione 2
 3) opzione 3
```
e chiede all'utente di inserire un numero adatto alle opzioni, quel numero viene restituito dalla funzione.
questo può essere utile da usare con gli switch, esempio:
```csharp
string[] opzioni = { "aggiungi", "modifica", "elimina"};
switch (Menu(opzioni))   //questo è un codice di esempio non presente nel programma.
{
    case 1://aggiungi
        aggiungi();
        break;
    case 2://modifica
        modifica();
        break;
    case 3://elimina
        elimina();
        break;
}
```


## LeggiFiles

Funzione: 

```csharp
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
```

- la funzione legge tutti i file presenti nella cartella (il nome della cartella è scritto in dir, tipo fileLetti = LeggiFiles("Nome_Cartella") dove Nome_Cartella è il nome proprio della cartella salvata).
- se la cartella non esiste viene creata.
- vengono letti tutti i file presenti nella catella e vengono salvati in un array come riga di testo unica.
- l'array di testi viene restituito dalla funzione ed ogni elemento è pronto per la deserializzazione.

## DeserializzaProdotti

Funzione: 

```csharp
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
```
la funzione chiede come input un array di testo per essere deserializzati in un array di Prodotto (classe).
è utile da usare insieme a LeggiFiles per avere l'array di tutti i prodotti deserializzati.

## VisualizzaTuttiProdotti

Funzione: 

```csharp
void VisualizzaTuttiProdotti(Prodotto[] prodotti)
{
    foreach (Prodotto prodotto in prodotti)
    {
        Console.WriteLine($"codice: {prodotto.codice}");
        Console.WriteLine($"nome: {prodotto.nome}");
        Console.Write("\n");
    }
}
```
stampa su console la lista di ogni prodotto con codice e nome separati da uno spazio

## VisualizzaDettagli

Funzione: 

```csharp
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
```
funzione che chiede all'utente un codice e visualizza tutti i dettagli del prodotto scelto.
qui c'è un controllo, se l'id non viene trovato InserisciCodice restituisce un Prodotto con nome: Errore e Codice: -1.

## DettagliProdotto

funzione:

```csharp
void DettagliProdotto (Prodotto oggettoCercato)
{
    Console.WriteLine($"nome: {oggettoCercato.nome}");
    Console.WriteLine($"disponibilità: {oggettoCercato.disponibile}");
    Console.WriteLine($"quantità: {oggettoCercato.quantita}");
    Console.WriteLine($"categorie: {string.Join(", ", oggettoCercato.categorie)}");
    Console.WriteLine($"posizione: magazzino: {oggettoCercato.posizione.magazzino} scaffale: {oggettoCercato.posizione.scaffale}");
}
```
funzione che stampa i componenti dell'oggetto che gli passiamo.

## VisualizzaDisponibilità

Funzione: 

```csharp
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
```
funzione che chiede all'utente un codice e spampa su console se è disponibile o no.
qui c'è un controllo, se l'id non viene trovato InserisciCodice restituisce un Prodotto con nome: Errore e Codice: -1.

## VisualizzaPerMagazzino

Funzione:

```csharp
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
```
funzione che manda in stampa tutti i prodotti con i relativi dettagli in ordine di posizione (in base al magazzino e allo scaffale)

## ConfrontaPosizioni

Funzione

```csharp
bool ConfrontaPosizioni (Posizione a, Posizione b)
{
    return a.magazzino == b.magazzino && a.scaffale == b.scaffale;
}
```
funzione che confronta magazzino e scaffale di due posizioni


## VerificaGiaVisualizzato

Funzione

```csharp
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
```
funzione che data una lista di posizione vede se c'è almeno un elemento uguale a quello cercato

## CalcolaId

Funzione: 

```csharp
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
```
funzione che cicla l'array dei prodotti per confrontarne gli id e prendere il più alto ed aggiungere 1

## CercaId

Funzione: 

```csharp
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
```
funzione che cicla l'array dei prodotti per confrontarne gli id e se è uguale a quello richiamato dalla funzione restituisce il giusto oggetto.
in caso non venga trovato nessun id che corrisponde viene restituito un Prodotto con codice: -1 e nome: Errore.
in altre funzioni viene fatto questo controllo:
```csharp
if (int.Parse(oggettoCercato.codice) == -1 && oggettoCercato.nome == "Errore")
{
    Console.WriteLine("Codice non trovato");
    return;
}
```

## InserisciCodice

Funzione: 

```csharp
Prodotto InserisciCodice(Prodotto[] prodotti)
{
    int id = 0;

    Console.Write("codice: ");
    id = InputIntero();

    return CercaId(prodotti, id);
}
```
Funzione che chiede all'utente un numero intero per poi cercare l'oggetto con l'id corrispondente

## AggiungiProdotto

Funzione: 

```csharp
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
```
Funzione che chiede all'utente tutti i campi di un prodotto e lo salva su un file Json nella cartella.

## ModificaProdotto

Funzione: 

```csharp
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
```
funzione che apre un menù chiedendo all'utente l'operazione da eseguire per modificare un campo.
viene chiesto per prima cosa il codice e viene fatto il controllo se quel codice esiste, poi viene chiesta l'operazione tramite in menù, infine il file Json corrispondente all'oggetto scelto viene sovrascritto con le modifiche applicate.


## EliminaProdotto

Funzione: 

```csharp
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
```
funzione che elimina un prodotto (Json, poi devi rileggere dalla cartella con le altre funzioni per avere un array aggiornato).
viene chiesto per prima cosa il codice e viene fatto il controllo se quel codice esiste, dopo viene visualizzato il nome e viene richiesta conferma, se viene scento 'si' il file del prodotto viene cancellato.
è presente una verifica in caso i nomi dei file vengano cambiati che stampa errore.

## InputIntero

Funzione: 

```csharp
int InputIntero()
{
    int numero;

    while (!int.TryParse(Console.ReadLine(), out numero))
    {
        Console.WriteLine("Devi inserire un numero!");
    }

    return numero;
}
```
chiede all'utente l'inserimento di un numero, e viene controllato se è un numero, in caso contrario la funzione continua a chiedere finchè non viene fornito un numero (intero).

## InserisciNome

Funzione: 

```csharp
string InserisciNome()
{
    Console.Write("Nome: ");

    return Console.ReadLine();
}
```
chiede semplicemente l'inserimento di un nome.

## InserisciQuantità

Funzione: 

```csharp
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
```
viene chiesto di inserire un numero intero che rappresenta una quantità e viene eseguito un controllo, se non ci sono oggetti (o si è in debito persino) la funzione restituisce un booleano che rappresenta se è disponibile (true) o non lo è (false).

## InserisciCategorie

Funzione: 

```csharp
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
```
funzione che chiede all'utente di inserire le varie categorie, ad ogni categoria inserita il programma chiede se se ne vuole inserire un altra, se l'utente digita si (+invio) ne inserisce un altra, le categorie vengono restituite sottoforma di array.


## InserisciPosizione

Funzione: 

```csharp
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
```
funzione che chiede all'utente di inserire magazzino e scaffale e le restituisce come oggetto Posizione (che è una proprietà della classe Prodotto)