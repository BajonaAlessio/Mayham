/* Console.WriteLine("inserisci il tuo nome: ");
string nome = Console.ReadLine(); // legge una riga di testo da tastiera e la assegna alla variabile nome
Console.WriteLine("ciao " + nome + "!"); // uso il metodo Writeline in modo da stampare il mio nome */

/* iterpolazione di stringa
Metodo più professionale e facile
 */

//Console.WriteLine($"Ciao {nome}!");

// dichiaro una variabile di tipo intero
//int eta = 0; //la inizializzo a 0
// provo a stampare la variabile eta così com'è senza convertirla
//Console.WriteLine(eta);

/* 
Esercizio 1 
scrivere un programma che chiede all'utente di inserire il proprio nome e cognome e poi stampa a video un saluto personalizzato
*/
Console.WriteLine("Inserisci il tuo nome: ");
string nome2 = Console.ReadLine();
Console.WriteLine("Inserisci il tuo cognome: ");
string cognome = Console.ReadLine();
Console.WriteLine($"Ciao {nome2} {cognome}!");
Console.WriteLine("quanti anni hai?");
int eta = 47; //Console.ReadLine();
string etaStr = eta.ToString(); //converto un int in string
Console.WriteLine($"hai {etaStr} anni");

Console.WriteLine("quanti anni hai?");
int etaStr2 = int.Parse(Console.ReadLine());
Console.WriteLine($"hai {etaStr2} anni");