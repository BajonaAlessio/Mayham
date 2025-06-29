Random dice = new Random();
string numCarStr;
int numeroCaratteri;
do
{
    Console.WriteLine("Di quanti caratteri?");
    numCarStr = Console.ReadLine();
} while (!int.TryParse(numCarStr, out numeroCaratteri));
if (!(numeroCaratteri > 4 && numeroCaratteri < 9))
{
    Console.WriteLine("non valido");
    return;
}
bool esisteMaiusc, esisteMin, esisteNum, esisteCarSp;
string password;
string[] lettere = { "q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "a", "s", "d", "f", "g", "h", "j", "k", "l", "z", "x", "c", "v", "b", "n", "m" };
string[] CarSp = { "!", "£", "$", "%", "&", "/", "(", ")", "=", "?", "^", "'", "[", "]", "°", "-", "_", "#", "*", "+", ",", ";", ".", ":", "|" };

while(true)
{
    esisteMaiusc = false;
    esisteMin = false;
    esisteNum = false;
    esisteCarSp = false;
    password = "";

    for (int i = 0; i < numeroCaratteri; i++)
    {
        int tipoCarattere = dice.Next(0, 4);
        switch (tipoCarattere)
        {
            case 0: //maiuscola
                password += lettere[dice.Next(lettere.Length)].ToUpper();
                esisteMaiusc = true;
                break;
            case 1: //minuscola
                password += lettere[dice.Next(lettere.Length)];
                esisteMin = true;
                break;
            case 2: //numero
                password += dice.Next(10);
                esisteNum = true;
                break;
            case 3: //carattere speciale
                password += CarSp[dice.Next(CarSp.Length)];
                esisteCarSp = true;
                break;
            default: //non entra mai qui
                return;
        }
    }

    if (esisteMaiusc && esisteMin && esisteNum && esisteCarSp)
    {
        break;
    }

} 

Console.WriteLine(password);