/*
Console.WriteLine("Ciao! inserisci il primo valore: ");
int a = int.Parse(Console.ReadLine());
Console.WriteLine("inserisci il secondo valore: ");
int b = int.Parse(Console.ReadLine());
Console.WriteLine("scrivi che tipo di operazione vuoi fare (+, -, *, /): ");
string operazione = Console.ReadLine();
//sto dichiarando le variabili invece di stamparle del tipo Console.WriteLine( a + b );
switch(operazione)
{
    case "+":
        int somma = a + b;
        Console.WriteLine(somma);
        break;
    case "-":
        int sottrazione = a - b;
        Console.WriteLine(sottrazione);
        break;
    case "*":
        int prodotto = a * b;
        Console.WriteLine(prodotto);
        break;
    case "/":
        if( b == 0 )
        {
            Console.WriteLine("ERRORE: non puoi dividere per 0!");
        }
        else
        {
            int divisione = a / b;
            Console.WriteLine(divisione);
        }
        break;
    default:
        Console.WriteLine("Tipo di operazione non valida");
        break;
}
*/

//  -- Ver 2 --
string ripeti = "si", operazione;
int a, b;
Console.Write("Ciao! ");
do
{
    if (ripeti == "si")
    {
        Console.WriteLine("inserisci il primo valore: ");
        a = int.Parse(Console.ReadLine());
        Console.WriteLine("inserisci il secondo valore: ");
        b = int.Parse(Console.ReadLine());
        Console.WriteLine("scrivi che tipo di operazione vuoi fare (+, -, *, /): ");
        operazione = Console.ReadLine();
        //sto dichiarando le variabili invece di stamparle del tipo Console.WriteLine( a + b );
        switch (operazione)
        {
            case "+":
                int somma = a + b;
                Console.WriteLine(somma);
                break;
            case "-":
                int sottrazione = a - b;
                Console.WriteLine(sottrazione);
                break;
            case "*":
                int prodotto = a * b;
                Console.WriteLine(prodotto);
                break;
            case "/":
                if (b == 0)
                {
                    Console.WriteLine("ERRORE: non puoi dividere per 0!");
                }
                else
                {
                    int divisione = a / b;
                    Console.WriteLine(divisione);
                }
                break;
            default:
                Console.WriteLine("Tipo di operazione non valida");
                break;
        }
    }
    Console.WriteLine("Vuoi ripetere l'operazione: (si/no):");
    ripeti = Console.ReadLine();
} while (ripeti != "no");   // si, potevo fare: if(ripeti =="si"){..}else if(ripeti =="no"){break;}else{errore} ma mi è uscito così