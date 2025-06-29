//   --- Metodi Liste ---

/*
i metodi disponibili per manipolare le liste sono:
- Count           -->con gli array non esiste perchè è lenght
- Add             -->con gli array non esiste si usa solo l'operatore += 
- AddRange
- Clear
- Contains
- IndexOf
- Remove
- RemoveAt
- Sort
- ToArray
- TrimExcess
*/


List<int> numeri = new List<int>(); // creazione di una lista di interi vuota
//aggiunta di 20 numeri alla lista
for (int i = 0; i < 10; i++)
{
    numeri.Add(i);
}
//creazione di una lista già piena
List<int> numeri2 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

//Count
//il metodo count restituisce il numero di elementi presenti nella lista
Console.WriteLine(numeri.Count);

//addrange
//il metodo addrange permette di aggiungere più elementi alla lista in un colpo solo
numeri.AddRange(new int[] { 11, 12, 13, 14, 15 });
Console.WriteLine(numeri.Count); //15
//permette di aggiungere anche un'altra lista:
numeri.AddRange(numeri2);
Console.WriteLine(numeri.Count);//25

//contains
//il metodo contains pemette di verificare se un elemento è presente nella lista (restituisce un booleano)
Console.WriteLine(numeri.Contains(5));
Console.WriteLine(numeri.Contains(20));

//indexof
//il metodo indexof permette di trovare l'indice di un elemento nella lista (se trova il valore restituisce l'indice, altrimenti -1)
Console.WriteLine(numeri.IndexOf(5));
Console.WriteLine(numeri.IndexOf(-1));

//sort
//il metodo sort permette di ordinare gli elementi della lista in ordine crescente
numeri.Sort();
Console.WriteLine(numeri[0]);
Console.WriteLine(numeri[numeri.Count - 1]);

//remove
//il metodo Remove permette di rimuovere un elemento dalla lista (restituisce un booleano)
Console.WriteLine(numeri.Remove(5));
Console.WriteLine(numeri.Remove(30));
Console.WriteLine(numeri.Count);

//removeat
//il metodo removeat permette di rimuovere un elemento della lista in base all'indice
Console.WriteLine(numeri[0]);
numeri.RemoveAt(0);
Console.WriteLine(numeri[0]);
Console.WriteLine(numeri.Count);

//trimexcess
//il metodo TrimExcess permette di ridurre la capacità della lista alla dimensione attuale
Console.WriteLine(numeri.Capacity); 
numeri.TrimExcess();
Console.WriteLine(numeri.Capacity);

//toarray
//il metodo to array permette di convertire la lista in un array
int[] arrayNumeri = numeri.ToArray();
Console.WriteLine(arrayNumeri.Length);

//clear
//il metodo clear permette di rimuovere tutti gli elementi della lista
numeri.Clear();
Console.WriteLine(numeri.Count); //0 