using Backend.Models; //Importa il namespace Backend.Models per accedere ai modelli definiti in esso
namespace Backend.Services
{
    public class ProductService
    {
        //inizializzo una lista di prodotti in memoria
        private readonly List<Product> _products = new() //inizializza una lista di prodotti in memoria
        //definisco privata la _list di prodotti perché voglio che sia accessibile solo all'interno di questa classe
        //in pratica voglio che l'elenco dei prodotti sia accessibile sono all'interno di questa classe
        {
            // elenco dei prodotti iniziali
            new Product { Id = 1, Name = "Penna", Price = 1.20M, Quantita = 10 },
            new Product { Id = 2, Name = "Quaderno", Price = 2.50M, Quantita = 5 }
        };

        // restituisco tutti i prodotti, dato che erano privati _products li rendo pubblici
        //public List<Product> GetAll() => _products; //lambda expression per restituira la lista dei prodotti
        //ciclo in modo esplicito per restituire tutti i prodotti

        //metodo per otteneree tutti i prodotti sotto forma di lista
        public List<Product> GetAll()
        //public -> è il modificatore d'accesso che indica che il metodo è accessibile da qualsiasi parte del programma
        //List<Product> -> indica che il metodo restituisce una lista di oggetti di tipo Product
        //GetAll() -> è il nome del metodo che restituisce tutti i prodotti
        {
            List<Product> result = new List<Product>(); //creo una nuova lista di prodotti per restituire i risultati
            foreach (var product in _products)
            {
                result.Add(product);//aggiungo ogni prodotto alla lista dei risultati
            }

            return result;
        }
        // metodo che restituisce un prodotto per ID, o null se non trovato
        //public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id); //lambda expression per trovare il primo prodotto con l'id specifico
        public Product? GetById(int id) //metodo per ottenere un prodotto specifico in base all'ID
        {
            foreach (var product in _products)
            {
                if (product.Id == id)
                {
                    return product;
                }
            }
            return null;//restituisce null se non trovato
        }

        //metodo per aggiungere un prodotto alla lista
        public Product Add(Product newProduct)
        {
            int id = 0;
            foreach (var product in _products)
            {
                if (id <= product.Id)
                    id = product.Id + 1;
            }
            newProduct.Id = id;

            _products.Add(newProduct);
            return newProduct;
        }

        //metodo per eliminare un prodotto specifico in base all'ID
        public void DeleteProduct(int id)//<---
        {
            _products.RemoveAt(id);
        }

        //metodo per modificare un prodotto specifico in base all'ID
        public void ModificaProdotto(Product product, int id)//<---
        {
            _products.RemoveAt(id);
            product.Id = id;
            _products.Add(product);
        }

        public bool Update(int id, Product updatedProduct)
        {
            Product? existing = null;
            foreach (var p in _products)
            {
                if (p.Id == id)
                {
                    existing = p;
                    break;
                }
            }
            if (existing == null)
            {
                return false;
            }
            existing.Name = updatedProduct.Name;
            existing.Price = updatedProduct.Price;
            return true;
        }
    }
}