using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Cards;

namespace WarSimulator
{
    public class Card
    {
        public Rank Rank { get; set; }
        public CType Type { get; set; }

        public Card(Rank rank, CType type)
        {
            Rank = rank;
            Type = type;
        }
    }
}
