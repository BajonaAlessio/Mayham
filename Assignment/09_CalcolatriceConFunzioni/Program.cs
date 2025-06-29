//DICHIARAZIONI-----
int a, b, risultato = 0, resto = 0;
bool divisoPerZero = false;

//MAIN--------------
Console.Write("Ciao! ");
do
{
    a = ChiediInputInt("inserisci il primo valore: ");
    b = ChiediInputInt("inserisci il secondo valore: ");

    switch (ChiediInputInt("inserisci il tipo di operazione: \n1) somma \n2) Differenza \n3) Prodotto \n4) Divisione"))
    {
        case 1:
            risultato = Somma(a, b);
            break;
        case 2:
            risultato = Differenza(a, b);
            break;
        case 3:
            risultato = Prodotto(a, b);
            break;
        case 4:
            risultato = Divisione(a, b, out divisoPerZero, out resto);
            break;
        default:
            Console.WriteLine("Tipo di operazione non valida");
            break;
    }

    if (!divisoPerZero)
    {
        Console.Write($"il risultato è : {risultato}");
        if (resto != 0)
        {
            Console.WriteLine($" con resto {resto}");
        }
        Console.Write("\n");
    }

    resto = 0;
    divisoPerZero = false;

} while (ChiediInputInt("Vuoi ripetere l'operazione: 1)ripeti: ") == 1);

//FUNZIONI------------
int Somma(int a, int b)
{
    return a + b;
}

int Differenza(int a, int b)
{
    return a - b;
}

int Prodotto(int a, int b)
{
    return a * b;
}

int Divisione(int a, int b, out bool DivisoZero, out int resto)
{
    DivisoZero = false;
    if (b != 0)
    {
        resto = a % b;
        return a / b;
    }
    else
    {
        Console.WriteLine("Non è possibile dividere per 0");
        DivisoZero = true;
        resto = 0;
        return 0;
    }
}

int ChiediInputInt(string domanda)
{
    int n;
    Console.WriteLine(domanda);
    while (!int.TryParse(Console.ReadLine(), out n))
    {
        Console.WriteLine("non è un numero, riprova:");
    }
    return n;
}