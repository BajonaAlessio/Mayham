namespace CardDrawer.Models
{
    public abstract class Card
    {
        public string Nome { get; set; }
        public string Testo { get; set; }

        public Card()
        {
            Nome = "Dark Magician";
            Testo = "The ultimate wizard in terms of attack and defense.";
        }
    }

    public class MonsterCard : Card
    {
        public string Attributo { get; set; }
        public string Tipo { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }

        public MonsterCard()
        {
            Nome = "Dark Magician";
            Testo = "The ultimate wizard in terms of attack and defense.";
            Attributo = "Dark";
            Tipo = "Spellcaster";
            Atk = 2500;
            Def = 2100;
        }

        public MonsterCard(string nome, string testo, string attributo, string tipo, string atk, string def)
        {
            Nome = string.IsNullOrWhiteSpace(nome) ? "Dark Magician" : nome;
            Testo = string.IsNullOrWhiteSpace(testo) ? "The ultimate wizard in terms of attack and defense." : testo;
            Attributo = string.IsNullOrWhiteSpace(attributo) ? "Dark" : attributo;
            Tipo = string.IsNullOrWhiteSpace(tipo) ? "Spellcaster" : tipo;
            int attacco, difesa;
            Atk = int.TryParse(atk, out attacco) ? 2500 : attacco;
            Def = int.TryParse(def, out difesa) ? 2100 : difesa;
        }

        public void VisualizzaCarta()
        {
            Console.Write("\n");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Attributo: {Attributo}");
            Console.WriteLine($"Tipo: {Tipo}");
            Console.WriteLine($"Testo: {Testo}");
            Console.WriteLine($"ATK: {Atk} DEF: {Def}");
        }
    }

    public class SpellCard : Card
    {
        public string SpellType { get; set; }

        public SpellCard()
        {
            Nome = "Soul Servant";
            Testo = "Place 1 card on top of the Deck from your hand, Deck, or GY, that is 'Dark Magician' or mentions 'Dark Magician' or 'Dark Magician Girl', except 'Soul Servant'. During your Main Phase: You can banish this card from your GY; draw cards equal to the number of 'Palladium' monsters, 'Dark Magician', and/or 'Dark Magician Girl', with different names, on the field and in the GYs. You can only use this effect of 'Soul Servant' once per turn.";
            SpellType = "Quick-Play Spell";
        }

        public SpellCard(string nome, string testo, string spellType)
        {
            Nome = string.IsNullOrWhiteSpace(nome) ? "Soul Servant" : nome;
            Testo = string.IsNullOrWhiteSpace(testo) ? "Place 1 card on top of the Deck from your hand, Deck, or GY, that is 'Dark Magician' or mentions 'Dark Magician' or 'Dark Magician Girl', except 'Soul Servant'. During your Main Phase: You can banish this card from your GY; draw cards equal to the number of 'Palladium' monsters, 'Dark Magician', and/or 'Dark Magician Girl', with different names, on the field and in the GYs. You can only use this effect of 'Soul Servant' once per turn." : testo;
            SpellType = string.IsNullOrWhiteSpace(spellType) ? "Quick-Play Spell" : spellType;
        }

        public void VisualizzaCarta()
        {
            Console.Write("\n");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Tipo: {SpellType}");
            Console.WriteLine($"Testo: {Testo}");
        }
    }

    public class TrapCard : Card
    {
        public string TrapType { get; set; }

        public TrapCard()
        {
            Nome = "Eternal Soul";
            Testo = "Every 'Dark Magician' in your Monster Zone is unaffected by your opponent's card effects. If this face-up card leaves the field: Destroy all monsters you control. You can only use the following effect of 'Eternal Soul' once per turn. You can activate 1 of these effects;Special Summon 1 'Dark Magician' from your hand or GY.Add 1 'Dark Magic Attack' or 'Thousand Knives' from your Deck to your hand.";
            TrapType = "Continuous Trap";
        }

        public TrapCard(string nome, string testo, string trapType)
        {
            Nome = string.IsNullOrWhiteSpace(nome) ? "Eternal Soul" : nome;
            Testo = string.IsNullOrWhiteSpace(Testo) ? "Every 'Dark Magician' in your Monster Zone is unaffected by your opponent's card effects. If this face-up card leaves the field: Destroy all monsters you control. You can only use the following effect of 'Eternal Soul' once per turn. You can activate 1 of these effects;Special Summon 1 'Dark Magician' from your hand or GY.Add 1 'Dark Magic Attack' or 'Thousand Knives' from your Deck to your hand." : testo;
            TrapType = string.IsNullOrWhiteSpace(trapType) ? "Continuous Trap" : trapType;
        }

        public void VisualizzaCarta()
        {
            Console.Write("\n");
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Tipo: {TrapType}");
            Console.WriteLine($"Testo: {Testo}");
        }
    }
}