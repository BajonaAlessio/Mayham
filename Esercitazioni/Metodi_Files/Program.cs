// --- metodi files e folders ---
//creare un file

string pathTest = @"text.txt";
File.Create(pathTest).Close(); //chiudere il file dopo la creazione permette di poterci scrivere dentro


//creare un file con il timestamp come nome
string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
string path = $"test_{timestamp}.txt";
File.Create(path).Close();

//scrivere su un file
File.WriteAllText(path, "test di scrittura su un file"); //Scrive il testo nel file, sovrascrivendo il contenuto esistente

//scrivere una collezione di stringhe su un file
List<string> lines = new List<string> { "linea 1", "linea 2", "linea 3" };
File.WriteAllLines(path, lines); //scrive ogni stringa della lista su una nuova riga del file

//aggiungere testo ad un file
File.AppendAllText(path, "test di append\n"); // aggiunge il testo alla fine del file senza sovrascrivere il contenuto

//aggiungere una lista di stringhe ad un file
File.AppendAllLines(path, lines);// aggiunge ogni stringa della lista alla fine del fine, una per riga

//Leggere da un file
string content = File.ReadAllText(path);//legge tutto il contenuto del file in una stringa
//stampa il contenuto del file
Console.WriteLine(content);

//leggere riga per riga da un file
string[] linee = File.ReadAllLines(path);
foreach (string line in linee)
{
    Console.WriteLine(line);
}
for (int i = 0; i < linee.Length; i++)
{
    Console.WriteLine($"Riga {i + 1}: {linee[i]}");
}

//ottenere informazioni su un file
FileInfo info = new FileInfo(path);
Console.WriteLine(info.Length);
Console.WriteLine(info.CreationTime);
Console.WriteLine(info.LastWriteTime);
Console.WriteLine(info.Extension);
Console.WriteLine(info.Name);
Console.WriteLine(info.DirectoryName);

//eliminare un file
if (File.Exists(path))
{
    File.Delete(path);
}
else
{
    Console.WriteLine("il file non esiste");
}

if (File.Exists(pathTest))
{
    File.Delete(pathTest);
}
else
{
    Console.WriteLine("il file non esiste");
}

//copiare un file
string sourcePath = @"source.txt";
string destinationPath = @"destination.txt";
if (File.Exists(sourcePath))
{
    File.Copy(sourcePath, destinationPath, true);//copia il file, sovrascrivendo se esiste già
    //il parametro true che indica di sovrascrivere il file di destinazione se esiste già
}
else
{
    Console.WriteLine("Il File di origine non esiste.");
}

//rinominare un file
string oldFileName = @"oldName.txt";
string newFileName = @"newName.txt";
if (File.Exists(oldFileName))
{
    File.Move(oldFileName, newFileName);
}
else
{
    Console.WriteLine("Il file da rinominare non esiste");
}

//Folders

//creare una directory
string dir = @"test";
Directory.CreateDirectory(dir);

//verificare se una directory esiste
if (Directory.Exists(dir))
{
    Console.WriteLine("Directory exists");
}

//ottenere informazioni su una directory
DirectoryInfo dirInfo = new DirectoryInfo(dir);
Console.WriteLine(dirInfo.CreationTime);
Console.WriteLine(dirInfo.LastWriteTime);
Console.WriteLine(dirInfo.Name);

//eliminare una directory
Directory.Delete(dir);