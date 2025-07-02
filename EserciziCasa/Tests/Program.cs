/*string[] numero = { "pari", "dispari" };
int a;
while (true)
{
    Console.Write("inserisci un numero: ");
    a = int.Parse(Console.ReadLine());
    Console.WriteLine(numero[a % 2]);
}  //cosa fa questo programma?
*/
/* assegnazioni
 a = funzioneOQuelloCheVuoi();

 quello che restituisce la funzione viene salvato su a
*/
bool[] a = {false,true,false,true};
while (true)
{
    a = Inverti(a);
    Stampa();
}

bool[] Inverti (bool[] a)
{
    bool[] newArray = new bool[a.Length];
    int i = 0;
    foreach (var b in a)
    {
        newArray[i] = !b;
        i++;
    }
    return newArray;
}

void Stampa()
{
    foreach (var b in a)
    {
        Console.Write(b);
    }
    Console.Write("\n");
}
/*
//Main
Numero();

//Funzioni
void Numero()
{
    string[] numero = { "pari", "dispari" };
    while (true)
    {
        Menu();
        int a = Calcolo(InputUtente());
        Console.WriteLine(numero[a]);
    }
}

void Menu()
{
    Console.Write("inserisci un numero: ");
}

int InputUtente()
{
    return int.Parse(Console.ReadLine());
}

int Calcolo(int inputUtente)
{
    return inputUtente % 2;
}
*/
