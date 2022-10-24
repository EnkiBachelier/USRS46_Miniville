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

            foreach (string thatName in namePlayers)
            {
                MasterCard cardCham = new WheatFieldCard();
                MasterCard cardBak = new BakeryCard();
                this.initialCards = new List<MasterCard>()
                {
                    cardCham,
                    cardBak
                };
                Player thatPlayer = new Player(3, this.initialCards, this, thatName);
                cardCham.SetPlayerOwner(thatPlayer);
                cardBak.SetPlayerOwner(thatPlayer);
                players.Add(thatPlayer);
            }
        }

        private int CheckWinner(List<int> piecesPlayers)
        {
            int gagnant = -1;
            for (int i = 0; i < namePlayers.Count; i++)
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

            while (CheckWinner(piecesPlayers) == -1)
            {
                Console.WriteLine("LOOP");
                for (int i = 0; i < players.Count; i++)
                {

                    currentPlayers = players[i];
                    int valueDice = this.playDice.De;
                    Console.WriteLine("\n\nC'est au tour de " + currentPlayers.name + " qui a un total de " + currentPlayers.nbPiece + " pièces !");
                    Console.WriteLine("Le dé affiche une valeur de " + valueDice + "\n");
                    Console.WriteLine("Nous regardons si les joueurs ont des cartes qui doivent être activées\n");
                    currentPlayers.CheckCardToActivate(valueDice);
                    Console.Write("Quel carte souhaitez-vous acheter ? ");
                    currentPlayers.BuyCard();

                    piecesPlayers[i] = currentPlayers.nbPiece;
                    
                }
            }
            Console.WriteLine("Terminé");
            Console.WriteLine("Bravo au joueur " + namePlayers[CheckWinner(piecesPlayers)] + " qui a gagné !!");
        }


    }
}
