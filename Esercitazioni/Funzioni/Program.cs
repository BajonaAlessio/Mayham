//  Funzioni
/* 
- una funzione è un blocco di codice che esegue un compito specifico
- il vantaggio di usare le funzioni è che il codice diventa più leggibile e modulare
ci sono 2 tipi principali di funzioni:
- Funzioni che elaborano i dati ma non restituiscono nessun valore (void)
- Funzioni che elaborano i dati e restituiscono un valore (return)  -> sono definite con un tipo di ritorno.
una funzione è definita da:
- un tipo di ritorno
- un nome
- una lista di parametri (opzionale)
- un corpo della funzione
- un istruzione di ritorno (opzionale)
- una funzione in csharp deve avere il nome scritto in PascalCase                                                   <---IMPORTANTE
- una funzione deve svolgere un compito specifico                                                                   <---IMPORTANTE
- una funzione può avere un solo return, ma può essere chiamato più volte                                           <---IMPORTANTE
- una variabile definita all'interno di una funzione è visibile solo all'interno di quella funzione (scope locale)  <---IMPORTANTE
*/

//esempio di funzione void (senza ritorno)
//funzione che stampa un messaggio
void StampaMessaggio()
{
    Console.WriteLine("funzione void");
}
//chiamata della funzione
StampaMessaggio();

//esempio di funzione void (senza ritorno e con parametri)
//funzione che stampa un messaggio con un parametro
void StampaMessaggioConParametro(string messaggio)
{
    Console.WriteLine(messaggio);
}
//chiamata della funzione con parametro
StampaMessaggioConParametro("funzione void con parametro");
//chiamata della funzione con un altro parametro
StampaMessaggioConParametro("funzione void con parametro 2");

//esempio di funzione void (senza ritorno con più parametri)
//funzioni che stampa un messaggio con due parametri
void StampaMessaggioConPiuParametri(string messaggio1, string messaggio2)
{
    Console.WriteLine($"{messaggio1} {messaggio2}");
}
StampaMessaggioConPiuParametri("funzione void con", "più parametri");

//funzione che stampa un messaggio con due parametri di tipo diverso
void StampaMessaggioConParametriDiversi(string messaggio, int numero)
{
    Console.WriteLine($"{messaggio} {numero}");
}
StampaMessaggioConParametriDiversi("funzione void con", 2);

//esempio di funzione void che manipola una lista
List<string> lista = new List<string> { "elemento 1", "elemento 2", "elemento 3" };
List<string> lista2 = new List<string> { "elemento 4", "elemento 5" };
void StampaLista(List<string> lista)
{
    foreach (var item in lista)
    {
        Console.WriteLine(item);
    }
}
StampaLista(lista);
StampaLista(lista2);

//esempio di una funzione che unisce due liste
List<string> UnisciListe(List<string> lista1, List<string> lista2)
{
    List<string> listaUnita = new List<string>();
    listaUnita.AddRange(lista1);
    listaUnita.AddRange(lista2);
    
    return listaUnita;
}
List<string> listaUnita = UnisciListe(lista, lista2);
StampaLista(listaUnita);

//esempio di una funzione che somma due valori e restituisce il risultato

int somma(int a, int b)
{
    return a + b;
}

Console.WriteLine($"la somma è {somma(2, 2)}");

//esempio di funzione che restituisce un booleano
//funzione che verifica se una parola ha un numero di lettere pari
bool ParolaPari(string parola)
{
    return parola.Length % 2 == 0;
}

Console.WriteLine($"La parola ha un numero di lettere pari: {ParolaPari("Cane")}");

//esempio di una funzione che restituisce una sringa
string FormattaMessaggio(string nome, int eta)
{
    return $"Ciao {nome}, hai {eta} anni.";
}

string messaggio = FormattaMessaggio("Utente 1", 25);
Console.WriteLine(messaggio);

//esempio di funzione con parametri di out
//funzione che divide due numeri e restituisce il risultato e il resto
void Divisione(int dividendo, int divisore, out int quoziente, out int resto)
{
    quoziente = dividendo / divisore;
    resto = dividendo % divisore;
}

int quoziente, resto;
Divisione(10, 3, out quoziente, out resto);
Console.WriteLine($"Quoziente: {quoziente} ,Resto: {resto}");

//esempio di una funzione che trasmette il valore ad un altra
int Doppio(int n)
{
    return n * 2;
}
int Quadruplo(int n)
{
    return Doppio(n) * 2;
}
int numero = 5;
int risultato = Quadruplo(numero);
Console.WriteLine($"Il quadruplo di {numero} è {risultato}");

//Esempio di una funzione che usa il parametro ref
//il ref passa il riferimento della variabile, quindi se la variabile viene modificata all'interno della funzione, la modifica viene riflessa anche all'esterno della funzione
int DoppioConRef(ref int n)
{
    n *= 2;
    return n;
}
int n = 5;
Console.WriteLine(n);
int doppioConRef = DoppioConRef(ref n);
Console.WriteLine(doppioConRef);
Console.WriteLine(n);
int provola = DoppioConRef(ref n);
Console.WriteLine(doppioConRef);
Console.WriteLine(n);