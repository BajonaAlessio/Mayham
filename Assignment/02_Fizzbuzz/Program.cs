//   ----------FIZZBUZZ---------
/*
for (int i = 1; i <= 100; i++)
{
    if (i % 3 == 0 && i % 5 == 0)
    {
        Console.WriteLine("FIZZBUZZ");
    }
    else if (i % 3 == 0)
    {
        Console.WriteLine("FIZZ");
    }
    else  if (i % 5 == 0)
    {
        Console.WriteLine("BUZZ");
    }
    else
    {
        Console.WriteLine(i);
    }
}
*/

/*
for (int i = 1; i <= 100; i++)
{
    if (i % 3 == 0)
    {
        Console.Write("FIZZ");
    }
    if (i % 5 == 0)
    {
        Console.Write("BUZZ");
    }
    if (i % 3 != 0 && i % 5 != 0)
    {
        Console.Write(i);
    }
    Console.Write("\n");
}
*/

/*
string num = "";
for (int i = 1; i <= 100; i++)
{
    num = "";
    if (i % 3 == 0)
    {
        num = "FIZZ";
    }
    if (i % 5 == 0)
    {
        num += "BUZZ";
    }
    if (num == "")
    {
        num = i.ToString();
    }
    Console.WriteLine(num);
}
*/

// ---ver 2---
string numero = "", output = ""; //numero è l'input utente in formato stringa che viene conservato, mentre output è una variabile su cui l'algoritmo costruisce l'output
int numeroIntero = 0; //numeroIntero è l'input in formato intero per poter fare le comparazioni
while (true) //loop infinito
{
    Console.WriteLine("Inserisci un numero (o scrivi esci per uscire): ");
    numero = Console.ReadLine(); //<-- aquisisco l'input
    if (numero == "esci") //<-- controllo se l'input è "esci"
    {
        break;
    }
    numeroIntero = int.Parse(numero); //converto in intero
    output = ""; //resetto output nel caso non sia il primo loop
    if (numeroIntero % 3 == 0) // controllo 1
    {
        output = "FIZZ";   // "" oppure FIZZ
    }
    if (numeroIntero % 5 == 0) // controllo 2
    {
        output += "BUZZ";  // ("" oppure FIZZ) + BUZZ
    }
    if (output == "") // controllo 3
    {
        output = numero;  // se siamo ancora a "" allora stampo il numero
    }
    Console.WriteLine(output); // stampa
}