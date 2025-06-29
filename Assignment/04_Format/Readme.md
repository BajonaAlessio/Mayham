# Format
adattare il seguente metodo format per formattare le stringhe:
```csharp
string nome1 = "Nome";
int eta = 10;
string frase = string.Format("il partecipante si chiama {0} e ha {1} anni.", nome1, eta);
Console.WriteLine(frase);
```
ad una collezione di nomi ed età.
Otterrò più frasi ognuna riferita a un elemento della collezione
##suggerimenti

- esempio di collezione di nomi 
string[] nomi = {"nome1", "nome2", "nome3"};
- esempio di collezione di età 
int[] eta = {10, 20, 30};
- uso il ciclo foreach per iterare su ogni elemento della collezione
foreach (var nome in nomi)
{
    //....
}

# versione 2
in questa versione usiamo un dizionario invece di due collezioni separate