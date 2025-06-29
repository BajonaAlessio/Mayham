// ------------Elenco partecipanti--------------

/*
List<string> partecipanti = new List<string>();
string nome = "zero";
Console.WriteLine("Inserisci i partecipanti e scrivi 'fine' quando hai finito:");
int numeroPartecipanti = 0;
while (true)
{
    Console.WriteLine($"Inserisci partecipante n°{numeroPartecipanti + 1}");
    nome = Console.ReadLine();
    if (nome != "fine")
    {
        numeroPartecipanti++;
        partecipanti.Add(nome);
    }
    else
    {
        break;
    }
}
Console.WriteLine($"i {numeroPartecipanti} partecipanti sono:");
foreach (string partecipante in partecipanti)
{
    Console.WriteLine(partecipante);
}
*/

//  ---ver 2---
/*
List<string> squadraUno = new List<string>();
List<string> squadraDue = new List<string>();
string nome = "", nomeSquadraUno = "", nomeSquadraDue = "";
Console.WriteLine("Inserisci i nomi delle squadre che si sfideranno: \nSquadra 1:");
nomeSquadraUno = Console.ReadLine();
Console.WriteLine("Squadra 2:");
nomeSquadraDue = Console.ReadLine();
Console.WriteLine("Inserisci i partecipanti e scrivi 'fine' quando hai finito:");
int numeroPartecipanti = 0, qualeSquadra = 0;
while (true)
{
    Console.WriteLine($"Inserisci partecipante n°{numeroPartecipanti + 1}");
    nome = Console.ReadLine();
    if (nome != "fine")
    {
        numeroPartecipanti++;
        Console.WriteLine($"di quale squadra fa parte? 1:{nomeSquadraUno} 2:{nomeSquadraDue}: ");
        qualeSquadra = int.Parse(Console.ReadLine());
        if (qualeSquadra == 1)
        {
            squadraUno.Add(nome);
        }
        else if (qualeSquadra == 2)
        {
            squadraDue.Add(nome);
        }
        else
        {
            Console.WriteLine("squadra non valida, riprova");
            numeroPartecipanti--;
        }
    }
    else
    {
        break;
    }
}
Console.WriteLine($"i {numeroPartecipanti} partecipanti sono:");
Console.WriteLine($" -- {nomeSquadraUno} -- ");
foreach (string partecipante1 in squadraUno)
{
    Console.WriteLine(partecipante1);
}
Console.WriteLine($"       VS       \n -- {nomeSquadraDue} -- ");
foreach (string partecipante2 in squadraDue)
{
    Console.WriteLine(partecipante2);
}
*/

//  --- ver 3 ---
List<string> squadraUno = new List<string>();
List<string> squadraDue = new List<string>();
string nome = "", nomeSquadraUno = "", nomeSquadraDue = "";

Console.WriteLine("Inserisci i nomi delle squadre che si sfideranno: \nSquadra 1:");
nomeSquadraUno = Console.ReadLine().Trim();
if (nomeSquadraUno.ToLower().Trim() != "fine")
{
    Console.WriteLine("Squadra 2:");
    nomeSquadraDue = Console.ReadLine().Trim();
}

Console.WriteLine("Inserisci i partecipanti e scrivi 'fine' quando hai finito:");
int numeroPartecipanti = 0, qualeSquadra = 0;

while (true)
{
    if (nomeSquadraUno.ToLower().Trim() == "fine" || nomeSquadraDue.ToLower().Trim() == "fine")
    {
        break;
    }
    Console.WriteLine($"Inserisci partecipante n°{numeroPartecipanti + 1}");
    nome = Console.ReadLine();
    if (nome.ToLower().Trim() != "fine")
    {
        if (!string.IsNullOrWhiteSpace(nome))
        {
            numeroPartecipanti++;
            Console.WriteLine($"di quale squadra fa parte? 1:{nomeSquadraUno} 2:{nomeSquadraDue}: ");
            qualeSquadra = int.Parse(Console.ReadLine());
            if (qualeSquadra == 1)
            {
                squadraUno.Add(nome.Trim());
            }
            else if (qualeSquadra == 2)
            {
                squadraDue.Add(nome.Trim());
            }
            else
            {
                Console.WriteLine("squadra non valida, riprova");
                numeroPartecipanti--;
            }
        }
        else
        {
            Console.WriteLine("nome non valido, riprova");
        }

    }
    else
    {
        break;
    }
}

Console.WriteLine($"i {numeroPartecipanti} partecipanti sono:");

Console.WriteLine($" -- {nomeSquadraUno} -- ");
foreach (string partecipante1 in squadraUno)
{
    Console.WriteLine($"{partecipante1} scritto con {partecipante1.Length} lettere");
}

Console.WriteLine($"       VS       \n -- {nomeSquadraDue} -- ");
foreach (string partecipante2 in squadraDue)
{
    Console.WriteLine($"{partecipante2} scritto con {partecipante2.Length} lettere");
}