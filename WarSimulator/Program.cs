using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            int players;
            int decks;
            War war;

            Console.Write("Players ammount: ");
            do
            {
                input = Console.ReadLine();
            }
            while (!Int32.TryParse(input, out players));

            Console.Write("Card decks ammount: ");
            do
            {
                input = Console.ReadLine();
            }
            while (!Int32.TryParse(input, out decks));

            war = new War(players, decks);
            war.Begin();

            Console.ReadKey();
        }
    }
}
