using Models;
using Newtonsoft.Json;
string cartella = @"CartellaLibri";

string[] testoFiles = LeggiFiles(cartella);
Libro[] libri = DeserializzaLibri(testoFiles);


string[] LeggiFiles(string dir)
{
    int i = 0;

    if (!Directory.Exists(dir))
    {
        Directory.CreateDirectory(dir);
    }
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