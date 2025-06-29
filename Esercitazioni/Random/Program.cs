//    --- Random ---

/* 
la classe random di csharp si occupa di generare numeri casuali.
genera numeri in un intervallo semiaperto cioè se voglio generare i numeri tra 1 e 100 dovrò scrivere 1 e 101.
*/
/*
Random numeroRandom = new Random(); // creo un oggetto random
int numero = numeroRandom.Next(1, 101); // genero un numero casuale tra 1 e 100
Console.WriteLine(numero); // stampo il numero

// se specifico un solo argomento, il numero generato sarà compreso tra 0 e il numero specificato.

int numero2 = numeroRandom.Next(100); // genero un numero casuale tra 0 e 99
Console.WriteLine(numero2); // stampo il numero

//se vogliamo generare un numero casuale compreso tra 0 e 1 (escluso) posso usare il metodo NextDouble
double numero3 = numeroRandom.NextDouble();
Console.WriteLine(numero3); // stampo il numero
*/

/* ESERCIZIO 1
scrivere un programma che genera 10 numeri casuali compresi tra 1 e 100
e stampa a video solo i numeri divisibili per 3 e 5


Random d100 = new Random();
int[] numeri = new int[10];
for (int i = 0; i < 10; i++)
{
    numeri[i] = d100.Next(1, 101);
    if (numeri[i] % 3 == 0 || numeri[i] % 5 == 0)
    {
        Console.WriteLine(numeri[i]);
    }
}
Console.WriteLine(string.Join(", ", numeri)); //tutti i numeri generati
*/


/* ESERCIZIO 2
scrivere un programma che genera 10 numeri casuali compresi tra 1 e 100 e memorizza in una lista solo i numeri paro, Dopo stampa la lista

List<int> numeriPari = new List<int>();
Random d100 = new Random();
int[] numeri = new int[10];
for (int i = 0; i < 10; i++)
{
    numeri[i] = d100.Next(1, 101);
    if (numeri[i] % 2 == 0 )
    {
        numeriPari.Add(numeri[i]);
    }
}
Console.WriteLine(string.Join(", ", numeri)); //tutti i numeri generati
foreach (int np in numeriPari)
{
    Console.Write($"{np}, ");
}
Console.Write("\n");
*/

/* ESERCIZIO 3
scrivere un programma che simuli il lancio di 2 dadi e calcoli la somma
*/

Random d6 = new Random();
int Dado1 = d6.Next(1, 7);
int Dado2 = d6.Next(1, 7);
int Totale = Dado1 + Dado2;
if (Dado1 == 6 && Dado2 == 6)
{
    Console.WriteLine("CRITICO!!");
}
Console.WriteLine($"{Dado1}, {Dado2} \nTotale:{Totale}");
