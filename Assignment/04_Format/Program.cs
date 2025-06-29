string[] nomi = {"nome1", "nome2", "nome3"};
int[] eta = {10, 20, 30};
string frase;
int indiceEta = 0;

Console.WriteLine("caso foreach:");
foreach (string nome in nomi)
{
    frase = string.Format("(foreach) il partecipante si chiama {0} e ha {1} anni.", nome, eta[indiceEta]);
    Console.WriteLine(frase);
    indiceEta++;
}

//oppure

Console.WriteLine("caso for:");
for (int i = 0; i < nomi.Length; i++)
{
    frase = string.Format("(for) il partecipante si chiama {0} e ha {1} anni.", nomi[i], eta[i]);
    Console.WriteLine(frase);
}

//converto i due array in un dizionario
Dictionary<string, int> dizionario = new Dictionary<string, int>();
for (int i = 0; i < nomi.Length; i++)
{
    dizionario.Add(nomi[i], eta[i]);
}
//stampo le variabili di dizionario
Console.WriteLine("caso dizionario(foreach):");
foreach (var d in dizionario)
{
    frase = string.Format("(dizionario) il partecipante si chiama {0} e ha {1} anni.", d.Key, d.Value);
    Console.WriteLine(frase);
}