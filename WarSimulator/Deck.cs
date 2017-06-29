using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Cards;

namespace WarSimulator
{
    public class Deck: ACards
    {
        //public List<Card> Cards { get; set; }

        public Deck(int size = 1)
        {
            for (byte i = 0; i < size; i++)
            {
                AddCards();
            }
        }

        public void AddCards()
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                foreach (CType type in Enum.GetValues(typeof(CType)))
                {
                    if (rank == Rank.Jocker)
                    {
                        if (type == CType.Diamond || type == CType.Spade)
                        {
                            continue;
                        }
                    }

                    Cards.Add(new Card(rank, type));
                }
            }
        }

        public void Shuffle()
        {
            var randomizedCards = new List<Card>();
            Random rnd = new Random();
            while (Cards.Count > 0)
            {
                int index = rnd.Next(0, Cards.Count);
                randomizedCards.Add(Cards[index]);
                Cards.RemoveAt(index);
            }

            Cards = randomizedCards;
        }
    }
}
