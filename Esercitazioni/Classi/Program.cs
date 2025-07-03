using Models;
using Newtonsoft.Json;

string cartella = @"CartellaLibri";
string[] testoFiles = LeggiFiles(cartella);
Libro[] libri = DeserializzaLibri(testoFiles);
string path;

Console.WriteLine(libri.Length);
foreach (Libro l in libri)
{
    Console.WriteLine($"{l.Titolo}, ");
}

Console.WriteLine("in questo esempio aggiungiamo due libri: \nuno standard e uno a scelta dell'utente,\npoi stampiamo la lista di libri");
Libro nuovoLibro1 = new();
SalvaJson(cartella, nuovoLibro1);
Libro nuovoLibro2 = InserisciLibro();
SalvaJson(cartella, nuovoLibro2);
VisualizzaTuttiILibri(libri);

string[] LeggiFiles(string dir)
{
    int i = 0;

    EsisteCartella(dir);
    string[] filesNames = Directory.GetFiles(dir);
    string[] files = new string[filesNames.Length];
    foreach (string fileName in filesNames)
    {
        files[i] = File.ReadAllText(fileName);
        i++;
    }

    return files;
}

Libro[] DeserializzaLibri(string[] testoFiles)
{
    int i = 0;
    Libro[] output = new Libro[testoFiles.Length];

    foreach (string tf in testoFiles)
    {
        output[i] = JsonConvert.DeserializeObject<Libro>(tf);
        i++;
    }

    return output;
}

void SalvaJson(string cartella, Libro nuovoLibro)
{
    path = @$"{cartella}\{CalcolaId(cartella)}.Json";
    File.Create(path).Close();
    File.WriteAllText(path, JsonConvert.SerializeObject(nuovoLibro, Formatting.Indented));

    testoFiles = LeggiFiles(cartella);
    libri = DeserializzaLibri(testoFiles);
}

Libro InserisciLibro()
{
    Console.Write("Titolo: ");
    string newTitolo = Console.ReadLine();
    Console.Write("Anno Pubblicazione: ");
    int newAnnoPubblicazione = int.Parse(Console.ReadLine());//da fare il controllo nella bella copia
    Console.Write("Genere: ");
    string newGenere = Console.ReadLine();
    Console.Write("Letto? (si/no) ");
    string newLetto = Console.ReadLine();
    bool newLettoBool;
    if (newLetto == "si")
    {
        newLettoBool = true;
    }
    else //per semplicità in questo esempio lo faccio solo con 2 possibilità, più avanti magari lo correggo
    {
        newLettoBool = false;
    }

    Libro newLibro = new Libro(
    titolo: newTitolo,
    annoPubblicazione: newAnnoPubblicazione,
    genere: newGenere,
    letto: newLettoBool
);
    return newLibro;
}

void VisualizzaTuttiILibri(Libro[] Libri)
{
    Console.WriteLine(Libri.Length);//debug test
    foreach (Libro l in Libri)
    {
        Console.Write("\n");
        l.StampaLibro();
    }
}

string CalcolaId(string cartella)
{
    EsisteCartella(cartella);
    string[] filesNames = Directory.GetFiles(cartella);
    string newF;
    int newId = 0;
    //test
    foreach (string f in filesNames)
    {
        newF = f.Replace(@"CartellaLibri\", "");
        newF = newF.Replace(@".Json", "");
        if (int.Parse(newF) >= newId)
        {
            newId = int.Parse(newF) + 1;
        }
    }

    return newId.ToString();
}

void EsisteCartella(string dir)
{
    if (!Directory.Exists(dir))
    {
        Directory.CreateDirectory(dir);
    }
}