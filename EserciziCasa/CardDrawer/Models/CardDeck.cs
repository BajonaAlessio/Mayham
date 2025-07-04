using CardDrawer.Models;
namespace CardDrawer.Deck
{
    public class CardDeck
    {
        public List<MonsterCard> monsterCards = new();
        public List<SpellCard> spellCards = new();
        public List<TrapCard> trapCards = new();

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