using System;
using System.Collections.Generic;
using System.Text;

namespace Miniville_GroupeC
{
    public class Player : Game
    {

        List<Card> Cards = new List<Card>();
        int Piece;
        Game game = new Game();
        string Name;
        Pile pile = new Pile();

        public Player(int piece, List<Card> cards, Game game, string name, Pile pile)
        {
            this.Piece = piece;
            this.Cards = cards;
            this.game = game;
            this.Name = name;
            this.pile = pile;

        }

        public void BuyCard(Card, cards)
        {
            if(activationValue == True)
            {
                Cards += Card;
                SupprCarte
            }

            
        }

        public CheckCardToActivate(int diceValue)
        {
            foreach (Card C in Cards)
            {
                if (diceValue == CostValue) { return true};
                else {return false};
            }
        }
    }
}
