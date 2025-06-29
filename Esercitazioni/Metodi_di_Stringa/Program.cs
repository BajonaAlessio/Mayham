//metodi di stringa

// i tipi di dato stringa hanno dei metodi che permettono di eseguire operazioni su di essi (manipolazioni) o di ottenere informazioni.

//lenght
//prende la lunghezza di una stringa
string nome = "Nome1";
int lunghezza = nome.Length;
Console.WriteLine(lunghezza);  // 5

//isnullorwhitespace
//verifica se una stringa è nulla o vuota o contiene spazi
Console.WriteLine(string.IsNullOrWhiteSpace(nome)); //output false

//isnullorempty
//verifica se una stringa è nulla o vuota
Console.WriteLine(string.IsNullOrEmpty(nome)); //output false

//tolower
//converte una stringa in minuscolo
Console.WriteLine(nome.ToLower());

//toupper
//converte una stringa in maiuscolo
Console.WriteLine(nome.ToUpper());

//trim
//rimuove gli spazi bianchi all'inizio e alla fine di una stringa
Console.WriteLine(nome.Trim());

//split
//divide una stringa in base a un separatore
string nomi = "Nome1, nome2, nome3, nome4, nome5";
string[] nomiArray = nomi.Split(", ");
foreach (string n in nomiArray) // n è un alias
{
    Console.WriteLine(n);
}

//join
//unisce gli elementi di un array in una stringa usando un separatore
string nomiUniti = string.Join(", ", nomiArray);// nomi o nomiArray?
Console.WriteLine(nomiUniti);

//replace
//sostituisce una parte di testo con un altra parte di testo
string sostituzione = nome.Replace("Nome", "Cognome");
Console.WriteLine(sostituzione);
//oppure
Console.WriteLine(nome.Replace("Nome1", "Nome2"));

//substring
//restituisce una sottostringa a partire da un indice e una lunghezza
Console.WriteLine(nome.Substring(0, 2));

//contains
//verifica se contiene una sottostringa
Console.WriteLine(nome.Contains("Nom"));

//startwith
//verifica se una sringa inizia con una sottostringa
Console.WriteLine(nome.StartsWith("Nom"));

//endswith
//verifica se una stringa finisce con una sottostringa
Console.WriteLine(nome.EndsWith("me1"));

//tostring
//converte un tipo di dato in una stringa
int numero = 10;
string numeroStringa = numero.ToString();
Console.WriteLine(numeroStringa);

//parse
//converte una stringa in un tipo di dato
string numeroDaConvertire = "10";
int numeroConvertito = int.Parse(numeroDaConvertire);
Console.WriteLine(numeroConvertito);

//tryparse
//converte una stringa in un tipo di dato e restituisce un booleano che indica se la conversione è andata a buon fine
string numeroDaConvertireTryParse = "10";
int numeroConvertitoTryParse;
bool conversione = int.TryParse(numeroDaConvertireTryParse, out numeroConvertitoTryParse);
Console.WriteLine(conversione);
Console.WriteLine(numeroConvertitoTryParse);

//convert
//converte un tipo di dato in un altro dato
int numeroDaConvertire1 = 10;
string numeroConvertito1 = Convert.ToString(numeroDaConvertire1);
Console.WriteLine(numeroConvertito1);

//oppure
string numeroDaConvertire2 = "10";
int numeroConvertito2 = Convert.ToInt32(numeroDaConvertire2);
Console.WriteLine(numeroConvertito1);

//format
//formatta una stringa usando dei segnaposto con degli indici
string nome1 = "Nome";
int eta = 10;
string frase = string.Format("il partecipante si chiama {0} e ha {1} anni.", nome1, eta);
Console.WriteLine(frase);