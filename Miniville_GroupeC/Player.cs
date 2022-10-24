using System;
using System.Collections.Generic;
using System.Text;

namespace Miniville_GroupeC
{
    public class Player
    {
		
		List<Card> Cards = new List<Card> ();
        int Piece;
        Game = Game();
        string Name;
        Pile = Pile();
		
		public Player(int piece,cards[],Game() game,string name, Pile() pile)
		{
			this.Piece = piece;
			this.Cards = cards;
			this.Game = game;
			this.Name = name;
			this.Pile = pile
		}
		
        public void BuyCard(Card, cards)
        {
            //ici rediriger vers la carte en question
		
			cards += Card
        }

        public void CheckCardToActivate(int diceValue)
        {
			foreach(Card C in cards)
			{
				if (diceValue in Costvalue) {return true}
				else () {return false}
			}
        }
    }
}
