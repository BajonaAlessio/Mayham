using Backend.Services; //importa in namespace Backend.Services per accedere ai servizi definiti da esso
using Microsoft.AspNetCore.Builder; //importa il namespace Microsoft.AspNetCore.Builder per configurare l'applicazione ASP.NET Core
using Microsoft.Extensions.DependencyInjection; //importa il namespace Microsoft.Extensions.DependencyInjection i servizi dell'applicazione
using Microsoft.Extensions.Hosting; //importa il namespace Microsoft.Extensions.Hosting per configurare l'hosting dell'applicazione

// CREAZIONE APPLICAZIONE

var builder = WebApplication.CreateBuilder(args);// crea un nuovo builder per l'applicazione ASP.NET Core

//1. Aggiungi i controller
//i controller sono responsabili della gestione delle richieste HTTP e della restituzione delle risposte
builder.Services.AddControllers();

//2. Registra il servizio in-memory per i prodotti
//in pratica vado a simulare un archivio di dati. Dato che non posso farlo nel program principale lo faccio in una folders servizi
builder.Services.AddSingleton<ProductService>();

//3. Configura CORS per permettere tutte le origini (sviluppo locale)
// CORS (Cross-Origin Resource Sharing) è una politica di sicurezza che permette o blocca le richieste tra domini diversi
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(Policy =>
    {
        Policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build(); // Costruisce l'applicazione ASP.NET Core

//CONFIGURAZIONE

// parte riguardante la configurazione dell'applicazione con l'uso di middleware
// il middleware è un componente che gestisce una funzionalità specifica dell'applicazione

//4. Middlewarw HTTPS e CORS
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage(); //Mostra errori dettagliati in sviluppo
}

app.UseHttpsRedirection(); // Reindirizza le richieste HTTP e HTTPS verso HTTPS

app.UseCors(); //Applica le politiche CORS definite in precedenza

//5. Mappa i controller API
//in pratica mappa le rotte dei controller API per gestire le richieste HTTP
//mappare le rotte significa associare le richieste a specifici metodi nei controller
app.MapControllers();

app.Run();// Avvia l'applicazione e inizia ad ascoltare le richieste HTTP