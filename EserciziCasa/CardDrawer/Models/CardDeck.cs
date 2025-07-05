using CardDrawer.Models;
using Newtonsoft.Json;

namespace CardDrawer.Deck
{
    public class CardDeck
    {
        public List<MonsterCard> monsterCards = new();
        public List<SpellCard> spellCards = new();
        public List<TrapCard> trapCards = new();

        public CardDeck()
        {
            monsterCards = new List<MonsterCard>();
            spellCards = new List<SpellCard>();
            trapCards = new List<TrapCard>();
        }

        public CardDeck(string dir)
        {
            string[] filesNames = Directory.GetFiles(dir);
            string[] files = new string[filesNames.Length];
            string fileNameCorrect;
            MonsterCard monster = new();
            SpellCard spell = new();
            TrapCard trap = new();
            for (int i = 0; i < filesNames.Length; i++)
            {
                files[i] = File.ReadAllText(filesNames[i]);
                fileNameCorrect = filesNames[i].Replace($@"{dir}\", "");
                if (fileNameCorrect.StartsWith("Mst"))
                {
                    monster = JsonConvert.DeserializeObject<MonsterCard>(files[i]);
                    monsterCards.Add(monster);
                }
                else if (fileNameCorrect.StartsWith("Spl"))
                {
                    spell = JsonConvert.DeserializeObject<SpellCard>(files[i]);
                    spellCards.Add(spell);
                }
                else if (fileNameCorrect.StartsWith("Trp"))
                {
                    trap = JsonConvert.DeserializeObject<TrapCard>(files[i]);
                    trapCards.Add(trap);
                }
            }
        }

        public void LeggiDeck()
        {
            Console.WriteLine($"Numero carte mostro: {monsterCards.Count}");
            foreach (MonsterCard mc in monsterCards)
            {
                mc.VisualizzaCarta();
            }
            Console.WriteLine($"Numero carte magia: {spellCards.Count}");
            foreach (SpellCard sc in spellCards)
            {
                sc.VisualizzaCarta();
            }
            Console.WriteLine($"Numero carte trappola: {trapCards.Count}");
            foreach (TrapCard tc in trapCards)
            {
                tc.VisualizzaCarta();
            }
        }


    }
}