using System;
using System.Collections.Generic;
using System.Text;

namespace Miniville_GroupeC
{
    public class Player
    {

        public List<MasterCard> playerCards = new List<MasterCard>();
        public int nbPiece;
        public Game game;
        public string name;


        public Player(int piece, List<MasterCard> MasterCards, Game game, string name)
        {
            this.nbPiece = piece;
            this.playerCards = MasterCards;
            this.game = game;
            this.name = name;

        }

        public void BuyCard(MasterCard cards)
        {
            
            if (nbPiece >= cards.costValue)
            {
                nbPiece -= cards.costValue;
                playerCards.Add(cards);
                //game.pile.removeCards(cards)
            }
            else
            {
                //Le joueur n'a pas assez de thune pour acheter la carte
            }
        }

        public void CheckCardToActivate(int diceValue)
        {

            foreach (var card in playerCards)
            {
                card.OnDiceResult(diceValue, game.currentPlayers);
            }

        }
    }
}