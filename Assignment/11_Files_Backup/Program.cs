//Controllo se esiste una cartella progetti
string path = @"progetti", newPath = "";

if (Directory.Exists(path))
{
    newPath = CreaCartellaBase(path);
    CopiaFile(path, path, newPath);
    CopiaCartelleConFile(path, path, newPath);
}
else
{
    Console.WriteLine("Directory principale non trovata");
}

void CopiaCartelleConFile(string cartella, string path, string newPath) //cartella in cui guardare, path originale del progetto, e nuovo percorso della copia
{
    string[] sottoCartelle = Directory.GetDirectories(cartella);
    foreach (string subdir in sottoCartelle)
    {
        string newSubdir = subdir.Replace(path, newPath);
        Directory.CreateDirectory(newSubdir);
        CopiaFile(subdir, path, newPath);
        CopiaCartelleConFile(subdir, path, newPath);   // <----- OPZIONE PIU SEMPLICE    (ma si può fare senza?)
    }
}

void CopiaFile(string cartella, string path, string newPath) //cartella in cui guardare, path originale del progetto, e nuovo percorso della copia
{
    string[] files = Directory.GetFiles(cartella);
    foreach (string file in files)
    {
        string newFile = file.Replace(path, newPath);
        File.Copy(file, newFile, true);
    }
}

string CreaCartellaBase(string path)
{
    DateTime oggi = DateTime.Today;
    string dir = $"{path}_{oggi.ToString("yyyyMMdd_HHmmss")}";
    Directory.CreateDirectory(dir);

    return dir;
}