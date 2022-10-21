using System;
using System.Collections.Generic;
using System.Text;

namespace Miniville_GroupeC
{
    public class Game
    {
        public List<Player> players;
        public Player currentPlayers;
        public Dice playDice;
        public int nbPieceVictory;
        public List<string> namePlayers;
        private List<Card> initialCards;

        public Game(Dice playDice, int nbPieceVictory, List<string> namePlayers)
        {
            this.playDice = playDice;
            this.nbPieceVictory = nbPieceVictory;

            this.initialCards = new List<Card>()
            {
                new Card(),                             //name, activation value, costvalue, CardColor. Action
            };

            foreach (string thatName in namePlayers)
            {
                players.Add(new Player());              //(
            }
        }

        


    }
}
