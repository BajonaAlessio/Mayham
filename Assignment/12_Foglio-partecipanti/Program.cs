//dichiarazioni
Random dice = new Random();
string oggi = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
string path = @"partecipanti.txt", estrattiPath = @"estratti.txt";

SeNonEsisteCreaFile(estrattiPath);
string[] partecipanti = File.ReadAllLines(path);
string[] estratti = File.ReadAllLines(estrattiPath);
string[] disponibili = partecipanti.Except(estratti).ToArray();

//main

if (disponibili.Length == 0)
{
    Console.WriteLine("non ci sono partecipanti disponibili");
    return;
}

SeNonEsisteCreaFile(path);

//stampa
Console.Clear();
Console.WriteLine($"Timestamp corrente: {oggi}");
Console.WriteLine(new string('-', 40));

StampaPartecipanti(partecipanti);
Console.WriteLine("----------");
StampaPartecipanti(disponibili);

//sorteggio
int estratto = dice.Next(disponibili.Length);
Console.WriteLine($"ha vinto {disponibili[estratto]}");

//salvo sul file 
SeNonEsisteCreaFile(estrattiPath);
File.AppendAllText(estrattiPath, $"{disponibili[estratto]}\n");// {oggi.ToString()}\n");

//funzioni
void StampaPartecipanti(string[] partecipanti)
{
    foreach (string partecipante in partecipanti)
    {
        Console.WriteLine(partecipante);
    }
}

void SeNonEsisteCreaFile (string file)
{
    if (!File.Exists(file))
    {
        File.Create(file).Close();
    }
}