Dictionary<string, DateTime> elencoPartecipantiMaggiorenni = new Dictionary<string, DateTime>();
Dictionary<string, DateTime> elencoPartecipantiMinorenni = new Dictionary<string, DateTime>();
Random dice = new Random();
DateTime dataCorretta;
int anni, vincitore;
string nome, data; //variabili di appoggio
int opzione; //opzione scelta dall'utente

while (true)
{
    // Menu--
    Console.Write("Quale opzione vuoi eseguire? \n 1)Inserisci partecipante \n 2)Sorteggia partecipante \n 3)Esci \n");
    while (!int.TryParse(Console.ReadLine(), out opzione)) //controllo se è un numero
    {
        Console.WriteLine("opzione non valida, riprova:");
    }
    if (!(opzione > 0 && opzione < 4))  //controllo se è nel range del menù
    {
        Console.WriteLine("non nel menù, riprova:");
        continue;
    }
    // Gestisco l'opzione--
    switch (opzione)
    {
        case 1: //Inserisci partecipante
            do
            {
                Console.WriteLine("Inserisci il nome:");
                nome = Console.ReadLine()!.Trim();
            } while (string.IsNullOrEmpty(nome) ||  elencoPartecipantiMaggiorenni.ContainsKey(nome) || elencoPartecipantiMinorenni.ContainsKey(nome));
            do
            {
                do
                {
                    Console.WriteLine("Inserisci data di nascita:");
                    data = Console.ReadLine()!.Trim();
                } while (string.IsNullOrEmpty(data));
                if (DateTime.TryParse(data, out dataCorretta))
                {
                    anni = DateTime.Today.Year - dataCorretta.Year;
                    if (anni >= 18)
                    {
                        elencoPartecipantiMaggiorenni.Add(nome, dataCorretta);
                    }
                    else
                    {
                        elencoPartecipantiMinorenni.Add(nome, dataCorretta);
                    }
                }
                else
                {
                    Console.WriteLine("Formato Data non valido");
                }
            } while (!DateTime.TryParse(data, out dataCorretta));
            break;
        case 2: //Sorteggio
            if (elencoPartecipantiMaggiorenni.Count != 0)
            {
                vincitore = dice.Next(elencoPartecipantiMaggiorenni.Count);
                Console.WriteLine($"Vince: {elencoPartecipantiMaggiorenni.Keys.ElementAt(vincitore)}, nato il: {elencoPartecipantiMaggiorenni.Values.ElementAt(vincitore).ToShortDateString()}");
            }
            else
            {
                Console.WriteLine("Non ci sono partecipanti maggiorenni");
            }
            break;
        case 3: //esci
            return;
    }    
}