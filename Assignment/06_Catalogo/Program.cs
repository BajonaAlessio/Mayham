Dictionary<int, List<string>> catalogo = new Dictionary<int, List<string>>();
string[] menu = { "Aggiungi un prodotto", "rimuovi un prodotto", "visualizza tutti i prodotti", "esci" };
int azioneEseguita, Id = 0;
string nome, prezzo, descrizione;
float prezzoFloat;
while (true)
{
    //-----gestione menù-----
    do
    {
        Console.WriteLine("seleziona l'azione che vuoi eseguire:");
        for (int i = 0; i < menu.Length; i++)
        {
            Console.WriteLine($"{i}: {menu[i]}");
        }
        nome = Console.ReadLine();
    } while (!int.TryParse(nome, out azioneEseguita));
    if (azioneEseguita < 4 && azioneEseguita >= 0)
    {
        Console.WriteLine($"hai selezionato {menu[azioneEseguita]}");
    }
    //-----------------------
        switch (azioneEseguita)
        {
            case 0: //aggiungi
                Console.WriteLine("inserisici il nome del prodotto:");
                do
                {
                    nome = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(nome));
                do
                {
                    Console.WriteLine("inserisci il prezzo:");
                    prezzo = Console.ReadLine();
                } while (!float.TryParse(prezzo, out prezzoFloat));
                do
                {
                    Console.WriteLine("inserisci una descrizione:");
                    descrizione = Console.ReadLine();
                } while (string.IsNullOrWhiteSpace(descrizione));
                catalogo.Add(Id, new List<string> { nome.Trim(), prezzo.Trim(), descrizione.Trim() });
                Id++;
                break;
            case 1: //rimuovi
                int deleteId;
                do
                {
                    Console.WriteLine("fornisci un ID valido:");
                    nome = Console.ReadLine();
                } while (!int.TryParse(nome, out deleteId));
                if (catalogo.TryGetValue(deleteId, out var art))
                {
                    Console.WriteLine($"vuoi cancellare l'elemento: {string.Join(", ", art)} ? ('si' per confermare)");
                    nome = Console.ReadLine();
                    if (nome.Trim().ToLower() == "si")
                    {
                        catalogo.Remove(deleteId);
                    }
                }
                else
                {
                    Console.WriteLine("ID non trovato");
                }
                break;
            case 2: //visualizza
                foreach (var articolo in catalogo)
                {
                    Console.WriteLine($"(ID: {articolo.Key}) {string.Join(", ", articolo.Value)}");
                }
                break;
            case 3: //esci
                return;
            default:
                Console.WriteLine("opzione non valida");
                break;
        }
}