// libraries
using CardDrawer.Models;
using CardDrawer.Deck;
using Newtonsoft.Json;

//data structures
string[] mainMenu = { "Crea", "Carica", "Elimina", "Esci" };

//main program
while (true)
{
    Console.WriteLine("Gestisci Decks:");
    switch (Menu(mainMenu))
    {
        case 1:
            CreaDeck();
            break;
        case 2:
            CaricaDeck();
            break;
        case 3:
            EliminaDeck();
            break;
        case 4:
            return;
    }
}

//functions
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

void CreaDeck()
{
    EsisteCartella(InserisciNome());
    //resto del programma...
}

void CaricaDeck()
{
    string nomeDeck = InserisciNome();
    while (!Directory.Exists(nomeDeck))
    {
        Console.WriteLine("deck non trovato, inserisci un nome valido:");
        nomeDeck = InserisciNome();
        Console.WriteLine($"debug test: {nomeDeck}");
    }
    //resto della funzione
}

void EliminaDeck()
{

}

string InserisciNome()
{
    string? nome;

    while (true)
    {
        Console.Write("Nome: ");
        nome = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(nome))
            Console.WriteLine("Inserisci un nome valido!");
        else
            break;
    }
    string nomeCorretto = nome.Replace(" ", "_");

    return nomeCorretto;
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

void EsisteCartella(string dir)
{
    if (!Directory.Exists(dir))
    {
        Directory.CreateDirectory(dir);
    }
}