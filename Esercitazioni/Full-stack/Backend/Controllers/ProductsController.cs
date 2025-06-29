using Backend.Models;
using Backend.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc; // importa per utilizzare le funzionalità dei controller ASP.NET Core

//il controller si occupa di gestire le richieste HTTP e restituire le risposte
//questo modo specifico di inserire delle direttive tra parentesi quadre sono un attributo che in questo caso permette di definire òa classe come controller api 
[ApiController] //attributo che indica che questa classe è un controller API
[Route("api/[controller]")]// indica il percorso base per le richieste a questo controller

public class ProductsController : ControllerBase //estendiamo la classe base controller con un controller personalizzato (ProductController estende ControllerBase)
//quindi la classe derivata erediterà le proprietà e i comportamenti della classe base
{
    //inizializzo l'oggetto _service nel costruttore della classe
    //cioè quello che scrivo nel costruttore viene eseguito quando creo un istanza dela classe
    private readonly ProductService _service;
    //private è il modificatore di accesso
    //readonly indica che il campo può essere assegnato solo nel costruttore in pratica è di sola lettura
    //ProductService è il tipo del campo che rappresenta il servizio per la gestione dei prodotto
    //_service è il nome del campo, che segue la convenzione di denominazione per o campi privati

    //public ProductsController() => _service = service;
    public ProductsController(ProductService service) //l'argomento del costruttore è il srvizio che gestisce i prodotti in questo caso ProductService
    {
        //il throw serve a lanciare un'eccezione se il servizio è null
        //l'operatore di coalescenza restituisce il valore a sinistra se non è null, altrimenti restituisce il valore a destra
        _service = service ?? throw new ArgumentNullException(nameof(service)); //?? è l'operatore di coalescenza
    }

    //metodo per ottenere tutti i prodotti
    [HttpGet] //indica che questo metodo risponde alle richieste HTTP GET
              //ci possono essere vari tipi di richieste http come GET, POST, PUT, DELETE
              //GET indica che il metodo recupera dati dal server passandoli come risposta in formato JSON
              //POST indica che i dati vengono passati in chiaro cioè attraverso il corpo della richiesta del campo url del browser
              //public ActionResult<List<Product>> Get() => _service.GetAll();
    /*public List<Product> Get() //Metodo accessibile dal programma che restituisce la lista di Product che prendiamo dal metodo GetAll di ProductService
    {
        return _service.GetAll();
    }*/
    public ActionResult<List<Product>> Get()
    //ActionResult<List<Product>> indica che il metodo restituisce un'azione  HTTP con una lista di prodotti
    {
        List<Product> products = _service.GetAll();
        return Ok(products); //restituisce i prodotti con lo stato HTTP 200 OK
                             //è una convenzione di ASP.NET in modo da restituire un risultato di tipo ActionResult cioè una risposta 200 ok
    }

    [HttpGet("{id}")]
    public ActionResult<Product> Get(int id)
    {
        var p = _service.GetById(id);
        if (p is null) return NotFound();
        return p;
    }

}