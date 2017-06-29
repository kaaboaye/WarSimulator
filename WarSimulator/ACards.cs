using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarSimulator
{
    public abstract class ACards
    {
        public List<Card> Cards { get; set; }

        public ACards()
        {
            Cards = new List<Card>();
        }

        public void Show()
        {
            Console.WriteLine("Deck:");

            foreach (Card card in Cards)
            {
                Console.WriteLine($"  {card.Rank} {card.Type}");
            }
        }
    }
}
