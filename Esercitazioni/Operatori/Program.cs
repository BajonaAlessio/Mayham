// OPERATORI

/* i tipi di operatori principali sono:
 -aritmetici
 -di confronto
 -logici
 -di assegnazione
 -di incremento e decremento
 -di concatenazione
*/

 //operatori aritmetici
 int a = 10;
 int b = 5;
 int somma = a + b; // somma
 //stampo il risultato
 Console.WriteLine($"La somma di {a} e {b} è: {somma}");
 int differenza = a - b;
 Console.WriteLine($"La differenza di {a} e {b} è: {differenza}");
 int prodotto = a * b;
 Console.WriteLine($"Il prodotto di {a} e {b} è: {prodotto}");
 int quoziente = a / b;
 Console.WriteLine($"il quoziente di {a} e {b} è: {quoziente}");
 int resto = a % b; //modulo
 Console.WriteLine($"il resto di {a} e {b} è: {resto}");

 //operatori di confronto (restituiscono un booleano)
 bool uguale = a == b;
 Console.WriteLine($"Il valore di {a} è uguale a {b}: {uguale}");
 bool diverso = a != b;
 Console.WriteLine($"Il valore di {a} è diverso a {b}: {diverso}");
 bool maggiore = a > b;
 Console.WriteLine($"Il valore di {a} è maggiore a {b}: {maggiore}");
 bool minore = a < b;
 Console.WriteLine($"Il valore di {a} è minore a {b}: {minore}");
 bool maggioreuguale = a >= b;
 Console.WriteLine($"Il valore di {a} è maggioreuguale a {b}: {maggioreuguale}");
 bool minoreuguale = a <= b;
 Console.WriteLine($"Il valore di {a} è minoreuguale a {b}: {minoreuguale}");

 //operatori logici
 bool condizione1 = true;
 bool condizione2 = false;

 bool and = condizione1 && condizione2; //and (&&) significa che entrambe le condizioni devono essere vere
 Console.WriteLine($"la condizione {condizione1} e {condizione2} è {and}");
 bool or = condizione1 || condizione2;  //or (||) significa che almeno una delle condizioni deve essere vera
 Console.WriteLine($"la condizione {condizione1} e {condizione2} è {or}");
 bool not = !condizione1; //not(!) significa che la condizione deve essere falsa (restituisce il contrario dello stato della variabile)
 Console.WriteLine($"la condizione {condizione1} è {not}");

 //operatori di assegnazione
 int c = 10;
 c += 5; //somma e assegna (se d = 8 diventa 16)
 Console.WriteLine($"il valore di c è {c}");
 c -= 5;
 Console.WriteLine($"il valore di c è {c}");
 c *= 5;
 Console.WriteLine($"il valore di c è {c}");
 c /= 5;
 Console.WriteLine($"il valore di c è {c}");

 //operatori di incremento e decremento
 c++; //incremento di 1
 Console.WriteLine($"il valore di c è: {c}");
 c--;
 Console.WriteLine($"il valore di c è: {c}");

//operatore di concatenazione
string nome = "nome persona";
string cognome = "cognome persona";
string nomecognome = "il nome completo è " + nome + " " + cognome + "!";
//oppure
string nomecognome2 = $"il nome completo è {nome} {cognome}!";
Console.WriteLine(nomecognome);
Console.WriteLine(nomecognome2);