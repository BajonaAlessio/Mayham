//    ---ARRAY---
/*  //esercizio 1
int[] numeri = { 6, 4, 72, 12, 2 };
int somma = 0;

for (int i = 0; i < numeri.Length; i++)
{
    somma += numeri[i];
}
Console.WriteLine(somma);
*/

//esercizio 2
//stampa i numeri pari di un array
/*
int[] numeri = { 5, 4, 71, 12, 2 };
List<int> numeriPari = new List<int>();

//aggiungo i numeri pari alla lista
for (int i = 0; i < numeri.Length; i++)
{
    if (numeri[i] % 2 == 0)
    {
        numeriPari.Add(numeri[i]);
    }
}
*/
//stampo i componenti della lista
/*
foreach (int num in numeriPari)
{
    Console.WriteLine(num);
}
*/
//Console.WriteLine($"i numeri pari sono: {string.Join(", ", numeriPari)}");

//esercizio 2 variante senza list
/*
int[] numeri = { 5, 4, 71, 12, 2, 21, 30};

int contatorePari = 0;
foreach (int n in numeri) //conto i numeri pari
{
    if (n % 2 == 0)
    {
        contatorePari++;
    }
}
int[] numeriPari = new int[contatorePari];
int indice = 0;
foreach (int n in numeri)
{
    if (n % 2 == 0)
    {
        numeriPari[indice] = n;
        indice++;
    }
}
Console.WriteLine($"i numeri pari sono: {string.Join(", ", numeriPari)}");
*/

//esercizio 3
/*
int[] numeri = { 5, 12, 71, 12, 2 };
int posizione = -1, cerca = 12;
List<int> posizioniDiCerca = new List<int>();

//posizione = Array.IndexOf(numeri, cerca);
for (int i = 0; i < numeri.Length; i++)
{
    if (numeri[i] == cerca)
    {
        posizione = i;
        posizioniDiCerca.Add(i);
    }
}

if (posizione != -1)
{
    foreach (int p in posizioniDiCerca)
    {
        Console.WriteLine(p);
    }
}
else
{
    Console.WriteLine("Elemento non trovato");
}
*/

//esercizio 4
/*
int[] numeri = { 5, 12, 71, 12, 2 };

int[] numeriInvertito = new int[numeri.Length];
Array.Copy(numeri, numeriInvertito, numeri.Length);
Array.Reverse(numeriInvertito);

Console.WriteLine(string.Join(", ", numeriInvertito));
*/

//esercizio completo

Console.WriteLine("quanti elementi vuoi inserire?");  //input numero di elementi
int numeroElementi = int.Parse(Console.ReadLine());

int[] numeri = new int[numeroElementi];  // input di ciascun elemento
for (int i = 0; i < numeroElementi; i++)
{
    Console.Write($"inserisci elemento numero {i}: ");
    numeri[i] = int.Parse(Console.ReadLine());
}

Console.Write("inserisci il numero da cercare in questa collezione: "); //input numero da cercare
int numeroDaCercare = int.Parse(Console.ReadLine());

int posizione = Array.IndexOf(numeri, numeroDaCercare);  //ricerca

if (posizione != -1)  //stampa
{
    Console.WriteLine($"il numero {numeroDaCercare} si trova in posizione {posizione}");
}
else
{
    Console.WriteLine("Elemento non trovato");
}

/* 
possibili cose da fare per migliorare il programma:
- dichiarare le variabili all'inizio del programma in modo da averne un resoconto e che non vengano inizializzate all'interno di cicli se il programma viene modificato
- chiedere se si vuole cercare un altro elemento
- cercare ogni istanza del numero da cercare invece che solo la prima
*/

//test con chatgpt
/*
Console.Write("Quanti elementi vuoi inserire? ");
if (!int.TryParse(Console.ReadLine(), out int numeroElementi) || numeroElementi <= 0)
{
    Console.WriteLine("Inserisci un numero intero positivo valido.");
    return;
}

int[] numeri = new int[numeroElementi];

for (int i = 0; i < numeroElementi; i++)
{
    Console.Write($"Inserisci l'elemento numero {i + 1}: ");
    while (!int.TryParse(Console.ReadLine(), out numeri[i]))
    {
        Console.Write("Valore non valido. Riprova: ");
    }
}

Console.Write("Inserisci il numero da cercare nella collezione: ");
if (!int.TryParse(Console.ReadLine(), out int numeroDaCercare))
{
    Console.WriteLine("Numero non valido.");
    return;
}

int posizione = Array.IndexOf(numeri, numeroDaCercare);

if (posizione != -1)
{
    Console.WriteLine($"Il numero {numeroDaCercare} si trova in posizione {posizione} (indice 0-based).");
}
else
{
    Console.WriteLine("Elemento non trovato.");
}
*/