using System;
using System.Collections.Generic;
using System.Text;

namespace Miniville_GroupeC
{
    public class Player
    {

        public List<MasterCard> playercard = new List<MasterCard>();
        public int nbPiece;
        public Game game;
        public string name;


        public Player(int piece, List<MasterCard> Mastercard, Game game, string name)
        {
            this.nbPiece = piece;
            this.playercard = Mastercard;
            this.game = game;
            this.name = name;

        }

        public void BuyCard()
        {
            int choice = -1;

            do
            {
                Console.WriteLine("Que voulez-vous acheter ?");
                Console.WriteLine("1 - Des champs de blé ? (1$)");
                Console.WriteLine("2 - Une ferme ? (2$)");
                Console.WriteLine("3 - Une boulangerie ? (1$)");
                Console.WriteLine("4 - Une café ? (2$)");
                Console.WriteLine("5 - Une superette ? (2$)");
                Console.WriteLine("6 - Une forêt ? (2$)");
                Console.WriteLine("7 - Un restaurant ? (4$)");
                Console.WriteLine("8 - Un stade ? (6$)");

            } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 ||choice > 8);

            switch(choice)
            {
                case 1:
                    var wheatFieldCard = new WheatFieldCard();
                    CanBuyCard(wheatFieldCard);
                    break;
                case 2:
                    var farm = new FarmCard();
                    CanBuyCard(farm);
                    break;
                case 3:
                    var bakery = new BakeryCard();
                    CanBuyCard(bakery);
                    break;
                case 4:
                    var cafe = new CafeCard();
                    CanBuyCard(cafe);
                    break;
                case 5:
                    var minimarket = new MiniMarketCard();
                    CanBuyCard(minimarket);
                    break;
                case 6:
                    var forest = new ForestCard();
                    CanBuyCard(forest);
                    break;
                case 7:
                    var restau = new RestaurantCard();
                    CanBuyCard(restau);
                    break;
                case 8:
                    var stadium = new StadiumCard();
                    CanBuyCard(stadium);
                    break;
            }

        }

        private void CanBuyCard(MasterCard card)
        {
            if (nbPiece >= card.costValue)
            {
                nbPiece -= card.costValue;
                playercard.Add(card);
                game.pile.RemoveCardFromPile(card);
            }
            else
            {
                //Le joueur n'a pas assez de thune pour acheter la carte
                Console.WriteLine("Vous n'avez pas assez de pièces.");
            }
        }

        public void CheckCardToActivate(int diceValue)
        {

            foreach (var card in playercard)
            {
                card.OnDiceResult(diceValue, game.currentPlayers);
            }

        }
    }
}