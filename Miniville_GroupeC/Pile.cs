using System;
using System.Collections.Generic;
using System.Text;

namespace Miniville_GroupeC
{
    public class Pile
    {
        public List<Card> mainpile = new List<Card>();

        public Pile()
        {
            int nbDone = 0;
            for (int i = 0; i < 6 * 8; i++)
            {
                if (i % 6 == 0)
                    nbDone++;

                switch (nbDone)
                {
                    case 1:
                        mainpile.Add(new Card("Champs de blé", 1, 1, CardColor.BLUE, (diceValue, thisPlayer, playerTurn) =>
                        {
                            if (diceValue == 1)
                            {
                                //actualPlayer.nbPice += 1
                                Console.WriteLine("Done");
                            }
                        }));
                        break;
                    case 2:
                        mainpile.Add(new Card("Ferme", 1, 2, CardColor.BLUE, (diceValue, thisPlayer, currentPlayerTurn) =>
                        {
                            if (diceValue == 1)
                            {
                                //actualPlayer.nbPice += 1
                            }
                        }));
                        break;
                    case 3:
                        mainpile.Add(new Card("Foret", 5, 2, CardColor.BLUE, (diceValue, thisPlayer, currentPlayerTurn) =>
                        {
                            if (diceValue == 5)
                            {
                                //actualPlayer.nbPice += 1
                            }
                        }));
                        break;
                    case 4:
                        mainpile.Add(new Card("Stade", 6, 6, CardColor.BLUE, (diceValue, thisPlayer, currentPlayerTurn) =>
                        {
                            if (diceValue == 6)
                            {
                                //actualPlayer.nbPice += 4
                            }
                        }));
                        break;
                    case 5:
                        mainpile.Add(new Card("Boulangerie", 2, 1, CardColor.GREEN, (diceValue, thisPlayer, currentPlayerTurn) =>
                        {
                            if (diceValue == 2 && thisPlayer == currentPlayerTurn)
                            {
                                //actualPlayer.nbPice += 2
                            }
                        }));
                        break;
                    case 6:
                        mainpile.Add(new Card("Superette", 4, 2, CardColor.GREEN, (diceValue, thisPlayer, currentPlayerTurn) =>
                        {
                            if (diceValue == 4 && thisPlayer == currentPlayerTurn)
                            {
                                //actualPlayer.nbPice += 3
                            }
                        }));
                        break;
                    case 7:
                        mainpile.Add(new Card("Café", 3, 2, CardColor.RED, (diceValue, thisPlayer, currentPlayerTurn) =>
                        {
                            if (diceValue == 3 && thisPlayer != currentPlayerTurn)
                            {
                                //actualPlayer.nbPice += 1
                                //playerTurn-=1
                            }
                        }));
                        break;
                    case 8:
                        mainpile.Add(new Card("Restaurant", 5, 4, CardColor.RED, (diceValue, thisPlayer, currentPlayerTurn) =>
                        {
                            if (diceValue == 5 && thisPlayer != currentPlayerTurn)
                            {
                                //currentPlayerTurn.nbPiece -= 2;
                                //actualPlayer.nbPice += 2
                            }
                        }));
                        break;
                }
            }
        }
    }
}
