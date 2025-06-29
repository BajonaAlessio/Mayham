// cicli


// i cicli sono delle strutture di controllo che ci permettono di eseguire un blocc di codice più volte, a seconda di una condizione.
// in C# ci sono due principali tipi di cicli: "for" e "while"
// ci sono anche "foreach" ed il "do-while"

//ciclo for
for (int i = 0; i <= 10; i++)
{
    Console.WriteLine(i);
}

//ciclo while
int j = 0;
while (j < 5)
{
    Console.WriteLine(j);
    j++;
}

//esempio di while on true
int k = 4;
while (true)
{
    Console.WriteLine("Ciclo infinito");
    if (k == 5)
    {
        break;
    }
    k++;
}

//ciclo foreach
//il ciclo foreach vieneutilizzato per iterare su una collezione o una struttura di dati  (come un array o una lista).

string[] nomi = { "partecipante 1", "partecipante 2", "partecipante 3" };
foreach (string nome in nomi)
{
    Console.WriteLine(nome);
}

string[] nomi2 = { "partecipante 1", "partecipante 2", "partecipante 3" };
foreach (string nome2 in nomi2)
{
    if (nome2 == "partecipante 2")
    {
        Console.WriteLine("nome trovato");
        break;
    }
    else
    {
        Console.WriteLine("nome non trovato");
    }
}