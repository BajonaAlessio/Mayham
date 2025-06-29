# CATALOGO PRODOTT
programma che permette di gestire un catalogo di prodotti
## descrizione
il programma consente di gestire un catalogo di prodotti, permettendo di aggiungere, rimuovere e visualizzare i prodotti. I prodotti sono memorizzati in un dizionario, dove la chiave è un identificatore univoco del prodotto e il valore è un oggetto che rappresenta il prodotto stesso.
Il dizionario ha una chiave numerica ed una lista di prodotti come valore. Ogni prodotto ha un nome, un prezzo e una descrizione
## funzionalità
il programma deve chiedere all'utente di inserire un numero per scegliere una delle seguenti opzioni
- aggiungi un prodotto
- rimuovi un prodotto
- visualizza tutti i prodotti
- esci
il programma deve chiedere all'utente di inserire i dati del prodotto (nome, prezzo, descrizione) quando si sceglia di aggiungere un prodotto. il prezzo deve essere un numero decimale e la descrizione non può essere una stringa vuota.
## suggerimenti
- utilizza un dizionario per memorizzare i prodotti, dove la chiave è un identificatore univoco (ad esempio un numero intero) e il valore è un oggetto che rappresenta il prodotto
- utilizza i metodi 'add', 'remove' e 'TryGetValue' del dizionario per gestire i prodotti
- utilizza dei metodi di conversione per convertire le stringhe in numeri decimali e viceversa
- utilizza le condizioni per verificare se il prezzo è un numero decimale valido e se la descrizione non è vuota
## codice (solo commenti)
```csharp
//dichiaro un dizionario per memorizzare i prodotti
//dichiaro una variabile per tenere traccia dell'ID del prodotto
//ciclo per gestire le opzioni del menu
//chiedo all'utente di inserire un numero per scegliere un'opzione

//gestisco l'opzione 1: Aggiungi un prodotto
//chiedo all'utente di inserire il nome del prodotto
//chidedo all'utente di inserire il prezzo del prodotto
//verifico se il prezzo è un numero decimale valido
//chiedo all'utente di inserire la descrizione del prodotto
//verifico se la descrizione non è vuota
//creo un nuovo prodotto con i dati inseriti
//aggiungo il prodotto al dizionario con l'ID del prodotto

//gestisco l'opzione 2: Rimuovi un prodotto
//chiedo all'utente di inserire l'ID del prodotto da rimuovere
//verifico se l'ID esiste nel dizionario
//rimuovo il prodotto dal dizionario

//gestisco l'opzione 3: Visualizza tutti i prodotti
//ciclo per visualizzare tutti i prodotti nel dizionario

//gestisco l'opzione 4: esci
//esco dal ciclo