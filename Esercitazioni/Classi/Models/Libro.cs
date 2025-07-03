namespace Models
{
    public class Libro
    {
        // proprieta
        public string Titolo { get; set; } // proprieta pubbliche accessibili tramite i metodi get e set
        public int AnnoPubblicazione { get; set; }
        public string Genere { get; set; }
        public bool Letto { get; set; }

        // costruttore di default (senza parametri)
        public Libro()
        {
            // inizializza i valori di default
            Titolo = "Sconosciuto";
            AnnoPubblicazione = 2000;
            Genere = "N/A";
            Letto = false;
        }

        // costruttore
        // si chiama come la classe pero senza il tipo di ritorno
        public Libro(string titolo, int annoPubblicazione, string genere, bool letto)
        {
            // Qui inizializzo le proprietà con i valori passati
            Titolo = titolo;
            AnnoPubblicazione = annoPubblicazione;
            Genere = genere;
            Letto = letto;
        }

        public void StampaLibro()
        {
            Console.WriteLine($"Titolo : {Titolo}");
            Console.WriteLine($"Anno di pubblicazione: {AnnoPubblicazione}");
            Console.WriteLine($"Genere: {Genere}");
            Console.WriteLine($"Letto  : {(Letto ? "Letto" : "Non letto")}");
        }
    }
}