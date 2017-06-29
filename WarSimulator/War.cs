using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WarSimulator.Cards;

namespace WarSimulator
{
    public class War
    {
        public List<Player> Players { get; set; }
        public Deck Deck { get; set; }

        private int turns;
        private bool endOfWar;

        public War(int players, int decks = 1)
        {
            Players = new List<Player>();
            Deck = new Deck(decks);
            Deck.Shuffle();

            // Add players
            for (int i = 0; i < players; i++)
            {
                Players.Add(new Player());
            }

            // Give cards
            for (int i = 0; i < Deck.Cards.Count; i++)
            {
                int player_id = i % Players.Count;

                Players[player_id].Cards.Add(Deck.Cards[i]);
            }

            // Clear starting deck
            Deck.Cards.Clear();
        }

        public void Begin()
        {
            endOfWar = false;
            turns = 0;

            while (!endOfWar)
            {
                var cards = new List<PlayerCard>();

                foreach (var player in Players)
                {
                    if (player.Cards.Count == 0)
                    {
                        EndOfWar();
                        break;
                    }

                    cards.Add(new PlayerCard()
                    {
                        Player = player,
                        Card = player.Cards.Last()
                    });

                    player.Cards.Remove(player.Cards.Last());
                }

                var winner = Fight(cards);

                Console.WriteLine($"Wygrała {winner.Card.Rank} {winner.Card.Type}");
                Console.ReadKey();

                turns++;
            }
        }

        private PlayerCard Fight(List<PlayerCard> playerCards)
        {
            PlayerCard best = new PlayerCard();

            foreach (var c in playerCards)
            {
                if (best.Player == null)
                {
                    best = c;
                }

                if (c.Card.Rank > best.Card.Rank)
                {
                    best = c;
                }
            }

            return best;
        }

        private void EndOfWar()
        {
            Console.WriteLine("End of war");
            endOfWar = true;
        }
    }
}
