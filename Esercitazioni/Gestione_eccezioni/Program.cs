// Gestione eccezioni

// sto tentando di accedere a un file che non esiste

/*
try
{
    //il file deve essere nella stessa cartella del programma
    string contenuto = File.ReadAllText("file.txt");
    Console.WriteLine(contenuto);
}
catch (Exception e)
{
    Console.WriteLine("Il file non esiste");
    Console.WriteLine($"ERRORE NON TRATTATO {e.Message}");
    Console.WriteLine($"CODICE ERRORE: {e.HResult}");
    return;
}


//sto cercando di divedere un numero per 0

try
{
    int zero = 0;
    int numero = 1 / zero;
}
catch (Exception e)
{
    Console.WriteLine("Divisione per zero");
    Console.WriteLine($"ERRORE NON TRATTATO {e.Message}");
    Console.WriteLine($"CODICE ERRORE: {e.HResult}");
    return;
}


//sto cercando di accedere a un elemento di un array che non esiste
int[] numeri = { 1, 2, 3 };

try
{
    Console.WriteLine(numeri[3]);
}
catch (Exception e)
{
    Console.WriteLine("accedo a un indice di un array che non esiste");
    Console.WriteLine($"ERRORE NON TRATTATO {e.Message}");
    Console.WriteLine($"CODICE ERRORE: {e.HResult}");
    return;
}


//sto cercando di accedere ad un oggetto che non esiste
string nome = null;
try
{
    Console.WriteLine(nome.Length);
}
catch (Exception e)
{
    Console.WriteLine("oggetto nullo");
    Console.WriteLine($"ERRORE NON TRATTATO {e.Message}");
    Console.WriteLine($"CODICE ERRORE: {e.HResult}");
    return;
}

//non c'è abbastanza memoria disponibile
try
{
    int[] numeri = new int[int.MaxValue];
}
catch (Exception e)
{
    Console.WriteLine("memoria");
    Console.WriteLine($"ERRORE NON TRATTATO {e.Message}");
    Console.WriteLine($"CODICE ERRORE: {e.HResult}");
    return;
}*/

//esempio di try catch finally
try
{
    using (StreamWriter writer = new StreamWriter("file,txt"))
    {
        writer.WriteLine("Hello world");
    }
}
catch (Exception e)
{
    Console.WriteLine("errore durante la scrittura del file");
    Console.WriteLine($"ERRORE NON TRATTATO {e.Message}");
    Console.WriteLine($"CODICE ERRORE: {e.HResult}");
}
finally
{
    Console.WriteLine("il file è stato chiuso");
}