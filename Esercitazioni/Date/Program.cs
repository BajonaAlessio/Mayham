//   ---date---

/*le date dipendono dalla localizzazione del sistema operativo,
quindi è importante considerare il fuso orario e le impostazioni locali quando si lavora con le date in C#*/

DateTime birthDate = new DateTime(1995, 12, 3);
//il costruttore di DateTime accetta tre parametri: anno, mese e giorno
Console.WriteLine($"Sei nato il {birthDate}");
//DateTime è una struttura che rappresenta un istante di tempo

//conversioni di date
DateTime oggi = DateTime.Today;
Console.WriteLine($"oggi è {oggi}"); //stampa la data odierna
Console.WriteLine($"oggi è {oggi.ToShortDateString()}"); //stampa la data odierna in formato breve
Console.WriteLine($"oggi è {oggi.ToLongDateString()}");  //stampa la data odierna in formato lungo

Console.WriteLine($"oggi è {oggi.ToString("dd/MM/yyyy")}"); //stampa la data odierna in formato personalizzato
//dd rappresenta il giorno come numero a due cifre, MM il mese a due cifre e yyyy l'anno a quattro cifre
//possiamo usare MM/dd/yyyy per il formato inglese, ma in italia si usa dd/MM/yyyy
Console.WriteLine($"oggi è {birthDate.ToString("ddd/MMM/yy")}");
//day of week restituisce il giorno della settimana inserita in inglese
Console.WriteLine($"Il giorno della settimana è: {birthDate.DayOfWeek}");
//se lo vogliamo in italiano dobbiamo fare una conversione
Console.WriteLine($"Il giorno della settimana è: {birthDate:dddd}");
//possiamo farci restituire l'indice numerico del giorno della settimana
Console.WriteLine($"Il giorno della settimana è: {(int)birthDate.DayOfWeek}");
//possiamo restituire il giorno dell'anno con il metodo Day of year
Console.WriteLine($"Il giorno dell'anno è: {birthDate.DayOfYear}");

//parse
//DateTime.Parse è un metodo che converte una stringa in un oggetto DateTime (ad esempio quando un utente inserisce una data)
string dateString = "2024-12-31"; //data in formato stringa
DateTime date = DateTime.Parse(dateString); // converte la stringa in un oggetto DateTime
Console.WriteLine($"la data convertita è: {date}");
//TryParse
DateTime parsedDate;//dichiarazione di una variabile DateTime per il risultato
if (DateTime.TryParse(dateString, out parsedDate))
{
    Console.WriteLine(parsedDate);
}
else
{
    Console.WriteLine("Errore");
}

//operazioni con le date
//possiamo sommare o sottrarre un intervallo di tempo a una data
DateTime domani = oggi.AddDays(1);
Console.WriteLine($"domani è {domani.ToShortDateString()}");
DateTime ieri = oggi.AddDays(-1);
Console.WriteLine($"ieri era {ieri.ToShortDateString()}");
Console.WriteLine($"ieri era {ieri:dddd}");
Console.WriteLine($"domani è {domani:dddd}");

//TimeSpam imdica un imtervallo di tempo
TimeSpan timeSpan = new TimeSpan(5, 3, 5, 10, 0, 0); //5 giorni, 3 ore, 5 minuti, 10 secondi, 0 millisecondi e 0 microsecondi
TimeSpan age = oggi - birthDate; //calcola l'età in giorni
Console.WriteLine($"La tua età in giorni è {age.Days}");
//possiamo calcolare l'età in anni
Console.WriteLine($"hai {age.Days / 365} anni"); //365,25
//age.hours, age.minutes, age.seconds, age milliseconds, age.ticks
//i ticks sono i decimi di microsecondi
Console.WriteLine($"La tua età in secondi è {age.Seconds}");

DateTime nextYear = new DateTime(oggi.Year + 1, 1, 1); //prossimo anno
Console.WriteLine($"Mancano {nextYear - oggi} giorni a capodanno");

DateTime nextMonth = oggi.AddMonths(1);
Console.WriteLine($"mancano {nextMonth - oggi} giorni al prossimo mese");

//compare
//confronto tra date
DateTime date1 = DateTime.Today;
DateTime date2 = new DateTime(2024, 12, 31); //scegli una data
int result = DateTime.Compare(date1, date2); //confronto tra data
//restituisce i giorni di differenza se minore, uguale o maggiore (-1, 0 , 1)
Console.WriteLine(result);
result = DateTime.Compare(date2, date1);
Console.WriteLine(result);



date1 = new DateTime(2026, 12, 31);
date2 = new DateTime(2025, 12, 31);
result = DateTime.Compare(date1, date2);
if (result == 0)
{
    Console.WriteLine("data uguale");
}
else if (result > 0)
{
    Console.WriteLine("data 1 maggiore");
}
else
{
    Console.WriteLine("data 1 minore");
}

