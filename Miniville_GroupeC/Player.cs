using System;
using System.Collections.Generic;
using System.Linq;

namespace Miniville_GroupeC
{
    public class Player
    {
        #region Déclaration de variables
        public List<MasterCard> playerCardList = new List<MasterCard>();
        public int nbPiece;
        public Game game;
        public string name;
        private Pile pile;
        #endregion

        #region Constructeur
        public Player(int piece, List<MasterCard> Mastercard, Game game, string name, Pile pile)
        {
            this.nbPiece = piece;
            this.playerCardList = Mastercard;
            this.game = game;
            this.name = name;
            this.pile = pile;
        }
        #endregion

        #region Méthodes

        //Affiche les différentes cartes qu'on peut acheter et réalise l'achat si le joueur a assez d'argent
        public void BuyCard()
        {
            int choice = -1;
            //Retourne le nombre restant dans la pile de chaque type de carte (si <= 0, la carte n'est plus disponible) 
            var amountWheatFields = pile.mainPile.Where(x => x is WheatFieldCard).ToList();
            var amountFarms = pile.mainPile.Where(x => x is FarmCard).ToList();
            var amountBakeries = pile.mainPile.Where(x => x is BakeryCard).ToList();
            var amountCoffees = pile.mainPile.Where(x => x is CoffeeCard).ToList();
            var amountMiniMarkets = pile.mainPile.Where(x => x is MiniMarketCard).ToList();
            var amountForests = pile.mainPile.Where(x => x is ForestCard).ToList();
            var amountRestaurants = pile.mainPile.Where(x => x is RestaurantCard).ToList();
            var amountStadiums = pile.mainPile.Where(x => x is StadiumCard).ToList();

            do
            {
                //Affichage des cartes de la pile selon la disponibilité dans la pile
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                if (amountWheatFields.Count > 0)
                    Console.WriteLine("1 - Un champ de blé (1$) ? Recevez 1 pièce lorsque le dé affiche 1");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                if (amountFarms.Count > 0)
                    Console.WriteLine("2 - Une ferme (2$) ? Recevez 1 pièce lorsque le dé affiche 1");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                if (amountBakeries.Count > 0)
                    Console.WriteLine("3 - Une boulangerie (1$) ? Recevez 2 pièces lorsque le dé affiche 2");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkRed;
                if (amountCoffees.Count > 0)
                    Console.WriteLine("4 - Une café (2$) ? Recevez 1 pièce du joueur qui a lancé le dé et qui affiche 3");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                if (amountMiniMarkets.Count > 0)
                    Console.WriteLine("5 - Une superette (2$) ? Recevez 3 pièces lorsque le dé affiche 4");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                if (amountForests.Count > 0)
                    Console.WriteLine("6 - Une forêt (2$) ? Recevez 1 pièce lorsque le dé affiche 5");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkRed;
                if (amountRestaurants.Count > 0)
                    Console.WriteLine("7 - Un restaurant (4$) ? Recevez 2 pièces du joueur qui a lancé le dé et qui affiche 5");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                if (amountStadiums.Count > 0)
                    Console.WriteLine("8 - Un stade (6$) ? Recevez 4 pièces lorsque le dé affiche 6");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("9 - Passer votre tour");
                Console.ResetColor();

            } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 9);

            switch (choice)
            {
                //Selon le choix du joueur et la disponibilité de la carte dans la pile, réalise l'achat via CanBuyCard()
                case 1:
                    var wheatFieldCard = new WheatFieldCard();
                    if (amountWheatFields.Count <= 0)
                    {
                        Console.WriteLine("Cette carte n'est plus disponible...");
                        BuyCard();
                        break;
                    }
                    CanBuyCard(wheatFieldCard);
                    Console.WriteLine("Vous avez choisi d'acheter un champ de blé\n");
                    break;
                case 2:
                    var farm = new FarmCard();
                    if (amountFarms.Count <= 0)
                    {
                        Console.WriteLine("Cette carte n'est plus disponible...");
                        BuyCard();
                        break;
                    }
                    CanBuyCard(farm);
                    Console.WriteLine("Vous avez choisi d'acheter une ferme\n");
                    break;
                case 3:
                    var bakery = new BakeryCard();
                    if (amountBakeries.Count <= 0)
                    {
                        Console.WriteLine("Cette carte n'est plus disponible...");
                        BuyCard();
                        break;
                    }
                    CanBuyCard(bakery);
                    Console.WriteLine("Vous avez choisi d'acheter une boulangerie\n");
                    break;
                case 4:
                    var cafe = new CoffeeCard();
                    if (amountCoffees.Count <= 0)
                    {
                        Console.WriteLine("Cette carte n'est plus disponible...");
                        BuyCard();
                        break;
                    }
                    CanBuyCard(cafe);
                    Console.WriteLine("Vous avez choisi d'acheter un café\n");
                    break;
                case 5:
                    var minimarket = new MiniMarketCard();
                    if (amountMiniMarkets.Count <= 0)
                    {
                        Console.WriteLine("Cette carte n'est plus disponible...");
                        BuyCard();
                        break;
                    }
                    CanBuyCard(minimarket);
                    Console.WriteLine("Vous avez choisi d'acheter une superette\n");
                    break;
                case 6:
                    var forest = new ForestCard();
                    if (amountForests.Count <= 0)
                    {
                        Console.WriteLine("Cette carte n'est plus disponible...");
                        BuyCard();
                        break;
                    }
                    CanBuyCard(forest);
                    Console.WriteLine("Vous avez choisi d'acheter une ferme\n");
                    break;
                case 7:
                    var restau = new RestaurantCard();
                    if (amountRestaurants.Count <= 0)
                    {
                        Console.WriteLine("Cette carte n'est plus disponible...");
                        BuyCard();
                        break;
                    }
                    CanBuyCard(restau);
                    Console.WriteLine("Vous avez choisi d'acheter un restaurant\n");
                    break;
                case 8:
                    var stadium = new StadiumCard();
                    if (amountStadiums.Count <= 0)
                    {
                        Console.WriteLine("Cette carte n'est plus disponible...");
                        BuyCard();
                        break;
                    }
                    CanBuyCard(stadium);
                    Console.WriteLine("Vous avez choisi d'acheter un stade\n");
                    break;
                case 9:
                    Console.WriteLine("Vous avez passé votre tour\n");
                    break;
            }
        }

        //Si le joueur a assez d'argent, achète la carte sinon relance BuyCard()
        private void CanBuyCard(MasterCard card)
        {
            if (nbPiece >= card.costValue)
            {
                nbPiece -= card.costValue;
                playerCardList.Add(card);
                game.pile.RemoveCardFromPile(card);
                card.SetPlayerOwner(this);
            }
            else
            {
                Console.WriteLine("Vous n'avez pas assez de pièces. Veuillez choisir une autre carte !\n");
                BuyCard();
            }
        }


        //Parcourt les cartes de chaque joueur afin de les activer selon la valeur du dé
        public void CheckCardToActivate(int diceValue)
        {
            foreach (var card in playerCardList)
                card.OnDiceResult(diceValue, game.currentPlayer);
        }
        #endregion
    }
}