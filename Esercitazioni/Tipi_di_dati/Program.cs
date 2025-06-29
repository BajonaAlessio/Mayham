//Tipi di dati
//i tipi di dati possono essere dati semplici o complessi(strutture di dati)

//dati semplici
int eta2; //dichiarazione
eta2 = 20; //inizializzazione di una variabile di tipo intero

int eta = 10; //dichiarazione e inizializzazione di una variabile di tipo intero

//variabile di tipo stringa (devo specificare il valore tra gli apici doppi)
string numero = "5"; //dichiarazione e inizializzazione di una variabile di tipo stringa

//variabile di  tipo char
char lettera = 'a'; //dichiarazione e inizializzazione di una variabile di tipo char

//variabili di tipo float (devo separare gli interi dai decimali con il punto)
float pi = 3.14f; //dichiarazione e inizializzazione di una variabile di tipo float
double pi2 = 3.14; //dichiarazione e inizializzazione di una variabile di tipo double
//la differenza fra float e double è la precisione (float 7 cifre decimale, double 15 cifre decimali)

//variabili di tipo booleano (2 stati)
bool maggiorenne = true; //dichiarazione e inizializzazione di una variabile di tipo bool

//variabile di tipo var
//var è una variabile che permette di dichiarare senza specificare il tipo
//il tipo viedne dedotto dal valore assegnato
var eta3 = 20; //dichiarazione e inizializzazione di una variabile di intero
var nome = "Alessio"; //dichiarazione e inizializzazione di una variabile di stringa con var
//non posso dichiararla senza inizializzarla:
//var et4 //<--errore
//var necessita di essere inizializzata al momento della dichiarazione

//variabili di tipo data
DateTime dataNascita = new DateTime(2000, 1, 1); //dichiarazione e inizializzazione di una variabile di tipo data
//new è una parola che permette di creare un oggetto (costruttore)

//esempio di utilizzo di una variabile attraverso i metodi di console
Console.WriteLine($"La variabile maggiorenne vale: {maggiorenne}");//stampa il valore della variabile maggiorenne
Console.WriteLine($"La variabile nome vale: {nome}");//stampa il valore della variabile nome

//tipi di dati complessi (strutture di dati)
//un insieme di dati dello stesso tipo

//array (ha la caratteristica di avere una lunghezza fissa e predeterminata)
int[] numeri = new int[5]; //dichiarazione di un array di interi di lunghezza 5
numeri[0] = 1;   //inizializzazione del primo elemento dell'array, [0] è l'indice dell'array e parte da 0
numeri[1] = 6;   
numeri[2] = 35;
numeri[3] = 40;
numeri[4] = 5;
//oppure posso dichiarare l'array in un'unica riga
int[] numeri2 = new int[] {1, 6, 35, 40, 5};

//array di stringhe
string[] nomi = new string [5];
nomi[0] = "partecipante 1";
nomi[1] = "partecipante 2";
nomi[2] = "partecipante 3";
nomi[3] = "partecipante 4";
nomi[4] = "partecipante 5";

string[] nomi2 = new string [5] {"partecipante 1", "partecipante 2", "partecipante 3", "partecipante 4", "partecipante 5"};

//list
//una lista è una collezione di oggetti dello stesso tipo
//la lista ha la caratteristica di avere una lunghezza variabaile
List<int> numeri3 = new List<int>(); //dichiarazione di una lista di interi
numeri3.Add(1); //aggiunta di un elemento alla lista
numeri3.Add(6);
numeri3.Add(35);
numeri3.Add(40);
numeri3.Add(5);

List<int> numeri4 = new List<int>() {1, 6, 35, 40, 5};

//lista di stringhe
List<string> nomi3 = new List<string>(); //dichiarazione di una lista di interi
nomi3.Add("partecipante 1"); //aggiunta di un elemento alla lista
nomi3.Add("partecipante 2");
nomi3.Add("partecipante 3");
nomi3.Add("partecipante 4");
nomi3.Add("partecipante 5");

List<string> nomi4 = new List<string>() {"partcipante 1", "partecipante 2", "partecipanti 3", "partecipante 4", "partecipante 5"};

//dizionario
//una lista è una collezione di oggetti dello stesso tipo
Dictionary<string, int> dizionario = new Dictionary<string, int>();
dizionario.Add("Partecipante 1", 1);
dizionario.Add("Partecipante 2", 6);
dizionario.Add("Partecipante 3", 45);
dizionario.Add("Partecipante 4", 40);
dizionario.Add("Partecipante 5", 5);

Dictionary<string, int> dizionario2 = new Dictionary<string, int>() {{"partecipante 1", 1}, {"Partecipante 2", 6}, {"Partecipante 3", 45}, {"Partecipante 4", 40}, {"Partecipante 5", 5}};

//dizionario int bool
Dictionary<int, bool> dizionario3 = new Dictionary<int, bool>();
dizionario3.Add(1, true);
dizionario3.Add(6, false);
dizionario3.Add(35, true);
dizionario3.Add(40, false);
dizionario3.Add(5, true);

Dictionary<int, bool> dizionario4 = new Dictionary<int, bool>()
{
    {1, true},
    {6, false},
    {35, true},
    {40, false},
    {5, true}
};