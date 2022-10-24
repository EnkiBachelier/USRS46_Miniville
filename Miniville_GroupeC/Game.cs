using System;
using System.Collections.Generic;
using System.Text;

namespace Miniville_GroupeC
{
    public class Game
    {
        public List<Player> players = new List<Player>();
        public Player currentPlayers;
        public Dice playDice;
        public int nbPieceVictory;
        public List<string> namePlayers = new List<string>();
        private List<MasterCard> initialCards = new List<MasterCard>();
        private bool expertMode;
        public Pile pile;

        public Game(Dice playDice, int nbPieceVictory, List<string> namePlayers, bool expertMode = false)
        {
            this.playDice = playDice;
            this.nbPieceVictory = nbPieceVictory;
            this.expertMode = expertMode;
            pile = new Pile();

            this.initialCards = new List<MasterCard>()
            {
                new WheatFieldCard(),
                new BakeryCard()
            };

            foreach (string thatName in namePlayers)
            {
                Player thatPlayer = new Player(3, this.initialCards, this, thatName);
                players.Add(thatPlayer);
            }
        }

        private int CheckWinner(List<int> piecesPlayers)
        {
            int gagnant = 0;
            for (int i = 0; i < piecesPlayers.Count; i++)
            {
                if (piecesPlayers[i] == this.nbPieceVictory)
                    gagnant = i;
            }
            return gagnant;
        }

        public void GameLoop()
        {
            List<int> piecesPlayers = new List<int>();

            foreach (Player thatPlayer in players)
            {
                piecesPlayers.Add(thatPlayer.nbPiece);
            }

            while (CheckWinner(piecesPlayers) == 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    currentPlayers = players[i];
                    int valueDice = this.playDice.De;
                    Console.WriteLine(valueDice);
                    Console.WriteLine("Nous regardons si les joueurs ont des cartes qui doivent être activées");
                    currentPlayers.CheckCardToActivate(valueDice);
                    Console.WriteLine("Quel carte souhaitez-vous acheter ?");
                    currentPlayers.BuyCard();


                    piecesPlayers[i] = currentPlayers.nbPiece;
                }
            }
        }


    }
}
