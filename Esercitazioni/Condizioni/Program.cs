// Condizioni

/* le condizioni o istruzioni di controllo sono utilizzate per eseguire un blocco di codice solo se
   una certa condizione è vera. In C# le condizioni possono essere scritte in vari modi 
   ma i più comuni sono:
   - if
   - else
   - else if
   - switch
*/

int a = 10;
int b = 5;

//if
if(a > b)
{
    Console.WriteLine($"{a} è maggiore di {b}");
    //codice da eseguire se la condizione è vera
    int somma = a + b;
    if(somma > 10)
    {
        Console.WriteLine($"La somma di {a} e {b} è maggiore di 10");
    }
    else
    {
        Console.WriteLine($"La somma di {a} e {b} non è maggiore di 10");
    }
}
else if(a < b)  //altrimenti
{
    Console.WriteLine($"{a} è minore di {b}");
    //codice da eseguire se la condizione è false
}
else
{
    Console.WriteLine($"{a} è uguale a {b}");
}

//swich
switch(a)
{
    case 1:
        Console.WriteLine("il valore è 1");
        break;
    case 2:
        Console.WriteLine("il valore è 2");
        break;
    case 3:
        Console.WriteLine("il valore è 3");
        break;
    default:
        Console.WriteLine("il valore non è 1, 2 o 3");
        break;
}

//switch (string)
string parola = "pausa";
switch(parola)
{
    case "pausa":
        Console.WriteLine("il valore è pausa");
        break;
    case "pranzo":
        Console.WriteLine("il valore è pranzo");
        break;
    case "cena":
        Console.WriteLine("il valore è cena");
        break;
    default:
        Console.WriteLine("il valore non è pausa, pranzo o cena");
        break;
}

//switch (bool)
bool condizione = true;
switch (condizione)
{
    case true:
        Console.WriteLine("il valore è true");
        break;
    case false:
        Console.WriteLine("il valore è false");
        break;
}