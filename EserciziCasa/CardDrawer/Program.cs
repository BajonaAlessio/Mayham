// libraries
using CardDrawer.Models;
using CardDrawer.Deck;
using Newtonsoft.Json;

//data structures
string[] mainMenu = { "Crea", "Carica", "Elimina", "Esci" };
CardDeck deckAttuale = new();

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
        scelta = int.TryParse(Console.ReadLine(), out scelta) ? scelta : -1;
    } while (!(scelta >= 1 && scelta < opzioni.Length + 1));

    return scelta;
}

void CreaDeck()
{
    string cartella = Inserisci("Nome del deck", false);
    if (CreaCartella(cartella))
        InserisciCarte(cartella, 1);
}

void InserisciCarte(string dir, int id)
{
    string[] opzioniCrea = { "inserisci mostro", "inserisci magia", "inserisci trappola", "indietro" };
    while (true)
    {
        switch (Menu(opzioniCrea))
        {
            case 1:
                MonsterCard newMonster = new MonsterCard(Inserisci("nome", true), Inserisci("testo", true), Inserisci("attributo", true), Inserisci("tipo", true), Inserisci("Atk", true), Inserisci("Def", true));
                newMonster.SalvaCarta(dir, id, "Mst");
                id++;
                break;
            case 2:
                SpellCard newSpell = new SpellCard(Inserisci("nome", true), Inserisci("testo", true), Inserisci("tipo di magia", true));
                newSpell.SalvaCarta(dir, id, "Spl");
                id++;
                break;
            case 3:
                TrapCard newTrap = new TrapCard(Inserisci("nome", true), Inserisci("testo", true), Inserisci("tipo di trappola", true));
                newTrap.SalvaCarta(dir, id, "Trp2");
                id++;
                break;
            case 4:
                return;
        }
    }
}

void CaricaDeck()
{
    string nomeDeck = Inserisci("nome del Deck", false);
    while (!Directory.Exists(nomeDeck))  //deve diventare funzione cercadeck per poter essere usata anche in EliminaDeck
    {
        Console.WriteLine("deck non trovato, inserisci un nome valido:  (o 'indietro' per tornare al menù principale)");
        nomeDeck = Inserisci("nome del Deck", false);
        if (nomeDeck == "indietro")
            return;
    }
    deckAttuale = new(nomeDeck);

    //debug test
    Console.WriteLine($"nome deck: {nomeDeck}");
    deckAttuale.LeggiDeck();
}

void EliminaDeck()
{

}

string Inserisci(string cosaInserisco, bool withSpaces)
{
    string? nome;

    while (true)
    {
        Console.Write($"{cosaInserisco}: ");
        nome = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(nome))
            Console.WriteLine("Inserisci un nome valido!");
        else
            break;
    }

    if (!withSpaces)
    {
        string nomeCorretto = nome.Replace(" ", "_");
        return nomeCorretto;
    }

    return nome;
}

bool CreaCartella(string dir)
{
    if (!Directory.Exists(dir))
    {
        Directory.CreateDirectory(dir);
        return true;
    }
    else
    {
        Console.WriteLine("Deck già esistente");
        return false;
    }
}