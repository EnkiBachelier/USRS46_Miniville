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

            do{
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("1 - Des champs de blé ? (1$)");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("2 - Une ferme ? (2$)");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("3 - Une boulangerie ? (1$)");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("4 - Une café ? (2$)");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("5 - Une superette ? (2$)");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("6 - Une forêt ? (2$)");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("7 - Un restaurant ? (4$)");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("8 - Un stade ? (6$)");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("9 - Passer votre tour");
                Console.ResetColor();

            } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 ||choice > 9);

            switch(choice)
            {
                case 1:
                    var wheatFieldCard = new WheatFieldCard();
                    CanBuyCard(wheatFieldCard);
                    Console.WriteLine("Vous avez choisi d'acheter un champ de blé\n");
                    break;
                case 2:
                    var farm = new FarmCard();
                    CanBuyCard(farm);
                    Console.WriteLine("Vous avez choisi d'acheter une ferme\n");
                    break;
                case 3:
                    var bakery = new BakeryCard();
                    CanBuyCard(bakery);
                    Console.WriteLine("Vous avez choisi d'acheter une boulangerie\n");
                    break;
                case 4:
                    var cafe = new CafeCard();
                    CanBuyCard(cafe);
                    Console.WriteLine("Vous avez choisi d'acheter un café\n");
                    break;
                case 5:
                    var minimarket = new MiniMarketCard();
                    CanBuyCard(minimarket);
                    Console.WriteLine("Vous avez choisi d'acheter une superette\n");
                    break;
                case 6:
                    var forest = new ForestCard();
                    CanBuyCard(forest);
                    Console.WriteLine("Vous avez choisi d'acheter une ferme\n");
                    break;
                case 7:
                    var restau = new RestaurantCard();
                    CanBuyCard(restau);
                    Console.WriteLine("Vous avez choisi d'acheter un restaurant\n");
                    break;
                case 8:
                    var stadium = new StadiumCard();
                    CanBuyCard(stadium);
                    Console.WriteLine("Vous avez choisi d'acheter un stade\n");
                    break;
                case 9:
                    Console.WriteLine("Vous avez passé votre tour\n");
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
                card.SetPlayerOwner(this);
            }
            else
            {
                Console.WriteLine("Vous n'avez pas assez de pièces. Veuillez choisir une autre carte !\n");
                BuyCard();
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