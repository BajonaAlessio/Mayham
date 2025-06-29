//    --- Metodi Array ---

/* i principali metodi per manipolare gli array sono:
- Lenght
- Copy
- Clear
- Reverse
- Sort
- IndexOf
*/

//definizione di un array di interi
int[] numeri = { 11, 12, 3, 41, 5 };

//accedere ad un elemento specifico dell'array
Console.WriteLine(numeri[2]);
//se provo ad accedere ad un elemento che non esiste, il programma darà un errore di runtime (un eccezione non gestita)

//lunghezza dell'array
Console.WriteLine(numeri.Length);

//creare una copia di un array
int[] numeri2 = new int[numeri.Length]; //devo dichiarare l'array di destinazione con la stessa lunghezza di quello di origine
Array.Copy(numeri, numeri2, numeri.Length);
//oppure
numeri.CopyTo(numeri2, 0); //copio in numeri 2 il contenuto di numeri partendo dall'elemento con indice 0
Console.WriteLine(string.Join(", ", numeri2)); //join unisce gli elementi di un array in una stringa separati da una virgola

//cancellare un array
Array.Clear(numeri2, 0, numeri2.Length); //resetta i valori dell'indice 0 fino alla lunghezza dell'array
Console.WriteLine(string.Join(", ", numeri2));
//oppure
numeri2 = new int[0]; //cancella l'array
Console.WriteLine(string.Join(", ", numeri2));

//ordinare un array
Array.Sort(numeri2); //sort ordina l'array in ordine crescente
Console.WriteLine(string.Join(", ", numeri2));

//invertire un array
Array.Reverse(numeri2);
Console.WriteLine(string.Join(", ", numeri2));

//IndexOf
//indexof restituisce l'indice di un elemento di un array
int index = Array.IndexOf(numeri2, 12);
Console.WriteLine(index); 
//se ci sono più elementi uguali restituisce l'indice del primo
//se non ci sono occorrenze dell'elemento cercato restituisce -1 