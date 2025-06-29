/*Random dice = new Random();
int numeroCaratteri = dice.Next(5, 9);
bool esisteMaiusc = false, esisteMin = false, esisteNum = false, esisteCarSp = false;
string password = "";
string[] lettere = { "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "a", "s", "d", "f", "g", "h", "j", "k", "l", "z", "x", "c", "v", "b", "n", "m" };
string[] CarSp = { "!", "£", "$", "%", "&", "/", "(", ")", "=", "?", "^", "'", "[", "]", "°", "-", "_", "#", "*", "+", ",", ";", ".", ":","|" };
for (int i = 0; i < numeroCaratteri; i++)
{
    int tipoCarattere = dice.Next(0, 4);
    if (esisteMaiusc && esisteMin && esisteNum && esisteCarSp)
    {
        esisteMaiusc = false;
        esisteMin = false;
        esisteNum = false;
        esisteCarSp = false;
    }
    switch (tipoCarattere)
    {
        case 0: //maiuscola
            if (!esisteMaiusc)
            {
                password += lettere[dice.Next(lettere.Length)].ToUpper();
                esisteMaiusc = true;
            }
            else
            {
                i--;
            }
            break;
        case 1: //minuscola
            if (!esisteMin)
            {
                password += lettere[dice.Next(lettere.Length)].ToLower();
                esisteMin = true;
            }
            else
            {
                i--;
            }
            break;
        case 2: //numero
            if (!esisteNum)
            {
                password += dice.Next(10);
                esisteNum = true;
            }
            else
            {
                i--;
            }
            break;
        case 3: //carattere speciale
            if (!esisteCarSp)
            {
                password += CarSp[dice.Next(CarSp.Length)];
                esisteCarSp = true;
            }
            else
            {
                i--;
            }
            break;
        default: //non entra mai qui
            return;
    }
}
Console.WriteLine(password); */

Console.Write("Inserisci la lunghezza della password (tra 5 e 8): ");
if (!int.TryParse(Console.ReadLine(), out int lunghezza) || lunghezza < 5 || lunghezza > 8)
{
    Console.WriteLine("Lunghezza non valida."); // Se l'input non è valido, esce dal programma
    return;
}

string caratteri = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789@#*!$%&";

Random random = new Random();

char[] password = new char[lunghezza]; // Inizializzo un array di caratteri della lunghezza specificata
password[0] = caratteri[random.Next(26)]; // Aggiungi una lettera maiuscola alla password
password[1] = caratteri[random.Next(26, 52)]; // Aggiungi una lettera minuscola alla password
password[2] = caratteri[random.Next(52, 62)]; // Aggiungi un numero alla password
password[3] = caratteri[random.Next(62, caratteri.Length)]; // Aggiungi un carattere speciale alla password

for (int i = 4; i < lunghezza; i++) // Riempi il resto della password
{
    password[i] = caratteri[random.Next(caratteri.Length)]; // Aggiungi caratteri casuali alla password fino a raggiungere la lunghezza richiesta
}

// OPZIONALE: Mischia i caratteri
// Mischia i caratteri
for (int i = password.Length - 1; i > 0; i--)  // faccio -- perchè voglio partire dall'ultimo carattere pero potrei partire anche dal primo
{
    (password[i], password[random.Next(i + 1)]) = (password[random.Next(i + 1)], password[i]); // Mischia i caratteri della password
}

Console.WriteLine($"La tua password generata è: {new string(password)}");