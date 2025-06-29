# Files Backup
- Programma che copia i files presenti dentro una cartella in una cartella di backup mantenendo la struttura delle sottocartelle
- la cartella di destinazione deve avere il nome della cartella d'origine, con l'aggiunta del timestamp nel formato yyyyMMdd_HHmmss alla fine del nome

## funzionalità del programma
- tutti i file dalla cartella sorgente
- Crea una nuova cartella di destinazione con un nome basato sul timestamp corrente (e le subfolders).
- Mantiene i nomi originali dei file durante la copia.
- se vogliamo possiamo usare le funzioni

## struttura originale
```csharp
Progetti
   Progetto1
      File1.txt
      File2.txt
    Progetto2
      File3.txt
      File4.txt
## struttura di backup
progetti_20231001_123456
   Progetto1
      File1.txt
      File2.txt
    Progetto2
      File3.txt
      File4.txt
