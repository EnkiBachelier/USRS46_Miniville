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
        public bool isItAnAI;
        public bool testCanBuy;
        #endregion

        #region Constructeur
        public Player(int piece, List<MasterCard> Mastercard, Game game, string name, Pile pile, bool isItAnAI)
        {
            this.nbPiece = piece;
            this.playerCardList = Mastercard;
            this.game = game;
            this.name = name;
            this.pile = pile;
            this.isItAnAI = isItAnAI;
        }
        #endregion

        #region Méthodes

        //Affiche les différentes cartes qu'on peut acheter et réalise l'achat si le joueur a assez d'argent
        public void BuyCard(bool isAILooping = false)
        {

            int choice = -1;
            #region Compteurs du nombre restant de chaque type de carte dans la pile
            //Retourne le nombre restant dans la pile de chaque type de carte (si <= 0, la carte n'est plus disponible) 
            var amountWheatFields = pile.mainPile.Where(x => x is WheatFieldCard).ToList();
            var amountFarms = pile.mainPile.Where(x => x is FarmCard).ToList();
            var amountBakeries = pile.mainPile.Where(x => x is BakeryCard).ToList();
            var amountCoffees = pile.mainPile.Where(x => x is CoffeeCard).ToList();
            var amountMiniMarkets = pile.mainPile.Where(x => x is MiniMarketCard).ToList();
            var amountForests = pile.mainPile.Where(x => x is ForestCard).ToList();
            var amountRestaurants = pile.mainPile.Where(x => x is RestaurantCard).ToList();
            var amountStadiums = pile.mainPile.Where(x => x is StadiumCard).ToList();
            var amountCheeseFactories = pile.mainPile.Where(x => x is CheeseFactoryCard).ToList();
            var amountFurnitureFactories = pile.mainPile.Where(x => x is FurnitureFactoryCard).ToList();
            var amountMines = pile.mainPile.Where(x => x is MineCard).ToList();
            var amountOrchards = pile.mainPile.Where(x => x is OrchardCard).ToList();
            var amountMarkets = pile.mainPile.Where(x => x is MarketCard).ToList();
            var amountCentreCommercial = pile.mainPile.Where(x => x is CentreCommercialCard).ToList();
            #endregion

            //Le joueur n'est pas une IA
            if (!isItAnAI)
            {
                #region Affichage Cartes de la pile selon leur disponibilité
                do
                {
                    //On affiche la ligne dans la couleur de la carte
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    //On affiche la description de la carte si elle est encore disponible
                    if (amountWheatFields.Count > 0)
                    {
                        Console.Write("1  - Un champ de blé (1$) ? Recevez 1 pièce lorsque le dé affiche 1 ");
                        //Si le joueur possède déjà cette carte, on affiche le nombre dans sa main
                        var amountPlayerWheatFields = playerCardList.Where(x => x is WheatFieldCard).ToList();
                        if (amountPlayerWheatFields.Count >= 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("(" + amountPlayerWheatFields.Count + " en main)\n");
                        }
                        else
                            Console.WriteLine();
                    }
                    Console.ResetColor();

                    //On affiche la ligne dans la couleur de la carte
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    //On affiche la description de la carte si elle est encore disponible
                    if (amountFarms.Count > 0)
                    {
                        Console.Write("2  - Une ferme (2$) ? Recevez 1 pièce lorsque le dé affiche 1 ");
                        //Si le joueur possède déjà cette carte, on affiche le nombre dans sa main
                        var amountPlayerFarms = playerCardList.Where(x => x is FarmCard).ToList();
                        if (amountPlayerFarms.Count >= 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("(" + amountPlayerFarms.Count + " en main)\n");
                        }
                        else
                            Console.WriteLine();
                    }
                    Console.ResetColor();

                    //On affiche la ligne dans la couleur de la carte
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    //On affiche la description de la carte si elle est encore disponible
                    if (amountBakeries.Count > 0)
                    {
                        Console.Write("3  - Une boulangerie (1$) ? Recevez 2 pièces lorsque le dé affiche 2 ");
                        //Si le joueur possède déjà cette carte, on affiche le nombre dans sa main
                        var amountPlayerBakeries = playerCardList.Where(x => x is BakeryCard).ToList();
                        if (amountPlayerBakeries.Count >= 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("(" + amountPlayerBakeries.Count + " en main)\n");
                        }
                        else
                            Console.WriteLine();
                    }
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    if (amountCoffees.Count > 0)
                    {
                        Console.Write("4  - Une café (2$) ? Recevez 1 pièce du joueur qui a lancé le dé et qui affiche 3 ");
                        var amountPlayerCoffees = playerCardList.Where(x => x is CoffeeCard).ToList();
                        if (amountPlayerCoffees.Count >= 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("(" + amountPlayerCoffees.Count + " en main)\n");
                        }
                        else
                            Console.WriteLine();
                    }
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    if (amountMiniMarkets.Count > 0)
                    {
                        Console.Write("5  - Une superette (2$) ? Recevez 3 pièces lorsque le dé affiche 4 ");
                        var amountPlayerMiniMarkets = playerCardList.Where(x => x is MiniMarketCard).ToList();
                        if (amountPlayerMiniMarkets.Count >= 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("(" + amountPlayerMiniMarkets.Count + " en main)\n");
                        }
                        else
                            Console.WriteLine();
                    }
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    if (amountForests.Count > 0)
                    {
                        Console.Write("6  - Une forêt (2$) ? Recevez 1 pièce lorsque le dé affiche 5 ");
                        var amountPlayerForests = playerCardList.Where(x => x is ForestCard).ToList();
                        if (amountPlayerForests.Count >= 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("(" + amountPlayerForests.Count + " en main)\n");
                        }
                        else
                            Console.WriteLine();
                    }
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    if (amountRestaurants.Count > 0)
                    {
                        Console.Write("7  - Un restaurant (4$) ? Recevez 2 pièces du joueur qui a lancé le dé et qui affiche 9 ou 10 ");
                        var amountPlayerRestaurants = playerCardList.Where(x => x is RestaurantCard).ToList();
                        if (amountPlayerRestaurants.Count >= 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("(" + amountPlayerRestaurants.Count + " en main)\n");
                        }
                        else
                            Console.WriteLine();
                    }
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    if (amountStadiums.Count > 0)
                    {
                        Console.Write("8  - Un stade (6$) ? Recevez 4 pièces lorsque le dé affiche 6 ");
                        var amountPlayerStadiums = playerCardList.Where(x => x is StadiumCard).ToList();
                        if (amountPlayerStadiums.Count >= 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("(" + amountPlayerStadiums.Count + " en main)\n");
                        }
                        else
                            Console.WriteLine();
                    }
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    if (amountCheeseFactories.Count > 0)
                    {
                        Console.Write("9  - Une fromagerie (5$) ? Recevez 3 pièces lorsque le dé affiche 7 ");
                        var amountPlayerCheeseFactories = playerCardList.Where(x => x is CheeseFactoryCard).ToList();
                        if (amountPlayerCheeseFactories.Count >= 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("(" + amountPlayerCheeseFactories.Count + " en main)\n");
                        }
                        else
                            Console.WriteLine();
                    }
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    if (amountFurnitureFactories.Count > 0)
                    {
                        Console.Write("10 - Une fabrique de meuble (3$) ? Recevez 3 pièces lorsque le dé affiche 8 ");
                        var amountPlayerFurnitureFactories = playerCardList.Where(x => x is FurnitureFactoryCard).ToList();
                        if (amountPlayerFurnitureFactories.Count >= 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("(" + amountPlayerFurnitureFactories.Count + " en main)\n");
                        }
                        else
                            Console.WriteLine();
                    }
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    if (amountMines.Count > 0)
                    {
                        Console.Write("11 - Une mine (6$) ? Recevez 5 pièces lorsque le dé affiche 9 ");
                        var amountPlayerMines = playerCardList.Where(x => x is MineCard).ToList();
                        if (amountPlayerMines.Count >= 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("(" + amountPlayerMines.Count + " en main)\n");
                        }
                        else
                            Console.WriteLine();
                    }
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    if (amountOrchards.Count > 0)
                    {
                        Console.Write("12 - Un verger (3$) ? Recevez 4 pièces lorsque le dé affiche 10 ");
                        var amountPlayerOrchards = playerCardList.Where(x => x is OrchardCard).ToList();
                        if (amountPlayerOrchards.Count >= 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("(" + amountPlayerOrchards.Count + " en main)\n");
                        }
                        else
                            Console.WriteLine();
                    }
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    if (amountMarkets.Count > 0)
                    {
                        Console.Write("13 - Un marché (2$) ? Recevez 2 pièces lorsque le dé affiche 11 ");
                        var amountPlayerMarkets = playerCardList.Where(x => x is MarketCard).ToList();
                        if (amountPlayerMarkets.Count >= 1)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("(" + amountPlayerMarkets.Count + " en main)\n");
                        }
                        else
                            Console.WriteLine();
                    }
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("14 - Passer votre tour");
                    Console.ResetColor();

                } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 14);
                #endregion
            }
            //Le joueur est une IA
            else  
            {
                int Cagnote = 0;
                foreach (Player perso in game.players)
                {
                    if (perso.nbPiece < game.nbPieceVictory / 2) { }
                    else { Cagnote++; }
                }

                int maxforet = 0;
                foreach (Player perso in game.players) //Parcour tout les joueurs
                {
                    int testforet = 0;

                    foreach (MasterCard carte in this.playerCardList) //parcour toute les cartes du joueurs
                    {
                        if (carte is ForestCard) { testforet += 1; } // si le joueur a une foret
                        testforet++;
                    }
                    if (testforet > maxforet) { maxforet = testforet; }

                }


                int myretaurant = 0;
                foreach (MasterCard carte in this.playerCardList) //parcour toute les cartes de ce joueur
                {
                    if (carte is ForestCard) { myretaurant++; }
                }


                int maxchamp = 0;
                foreach (Player perso in game.players) //Parcour tout les joueurs
                {
                    int testchamp = 0;

                    foreach (MasterCard carte in this.playerCardList) //parcour toute les cartes du joueurs
                    {
                        if (carte is WheatFieldCard) { testchamp += 1; } // si le joueur a une foret
                        testchamp++;
                    }
                    if (testchamp > maxchamp) { maxchamp = testchamp; }

                }

                int myferme = 0;
                foreach (MasterCard carte in this.playerCardList) //parcour toute les cartes de ce joueur
                {
                    if (carte is FarmCard) { myferme++; }
                }

                if (maxforet < myretaurant) //si un joueur enemy a plus de foret que son nombre de restau en prendre un
                {
                    if (nbPiece >= 4)
                    {
                        choice = 7;
                    }
                }
                else if (maxchamp < myferme) //si un joueur enemy a plus de champ que son nombre de ferme en prendre un sinon prendre boulangerie si pas asser
                {
                    if (nbPiece >= 2)
                    {
                        choice = 2;
                    }
                    else
                    {
                        if (nbPiece >= 1)
                        {
                            choice = 3;
                        }
                    }
                }
                else if (Cagnote == 0) //prendre un stade si la cagnote de tout les joueurs sont faible pour remonter la partie
                {
                    if (nbPiece >= 6)
                    {
                        choice = 8;
                    }
                }
                else //Sinon prendre une carte qui n'a pas encore était prise par le joueur
                {
                    bool CardChamp = false;
                    bool CardFerme = false;
                    bool CardBoulangerie = false;
                    bool CardCaffee = false;
                    bool CardSuperette = false;
                    bool CardForet = false;
                    bool CardRestaurant = false;
                    bool CardStade = false;
                    foreach (MasterCard carte in this.playerCardList) //on teste si les cartes appartiennent au joueur
                    {
                        if (carte is WheatFieldCard) { CardChamp = true; }
                        if (carte is FarmCard) { CardFerme = true; }
                        if (carte is BakeryCard) { CardBoulangerie = true; }
                        if (carte is CoffeeCard) { CardCaffee = true; }
                        if (carte is MiniMarketCard) { CardSuperette = true; }
                        if (carte is ForestCard) { CardForet = true; }
                        if (carte is RestaurantCard) { CardRestaurant = true; }
                        if (carte is StadiumCard) { CardStade = true; }
                    }

                    //si le joueur ne l'a pas on le la lui prend
                    if (CardChamp == false) { if (nbPiece >= 1) { choice = 1; } }
                    if (CardFerme == false) { if (nbPiece >= 2) { choice = 2; } }
                    if (CardBoulangerie == false) { if (nbPiece >= 1) { choice = 3; } }
                    if (CardCaffee == false) { if (nbPiece >= 2) { choice = 4; } }
                    if (CardSuperette == false) { if (nbPiece >= 2) { choice = 5; } }
                    if (CardForet == false) { if (nbPiece >= 2) { choice = 6; } }
                    if (CardRestaurant == false) { if (nbPiece >= 4) { choice = 7; } }
                    if (CardStade == false) { if (nbPiece >= 6) { choice = 8; } }

                     
                }
                if (choice == -1 || isAILooping)
                {
                    Random rdm = new Random();
                    choice = rdm.Next(1, 15);
                }
            }

            #region Effectue l'achat si c'est possible (carte disponible et assez d'argent)
            switch (choice)
            {
                case 1:
                    var wheatFieldCard = new WheatFieldCard();
                    //Si le joueur rentre quand même le numéro de la carte alors qu'il n'y en a plus, on le refait choisir une autre option
                    if (amountWheatFields.Count <= 0)
                    {
                        Console.WriteLine("Cette carte n'est plus disponible...");
                        if (this.isItAnAI)
                            BuyCard(true);
                        else
                            BuyCard();
                        break;
                    }
                    //On teste si le joueur peut acheter la carte avec son argent
                    CanBuyCard(wheatFieldCard);
                    Console.WriteLine("{0} a choisi d'acheter un champ de blé", this.name);
                    break;
                case 2:
                    var farm = new FarmCard();
                    //Si le joueur rentre quand même le numéro de la carte alors qu'il n'y en a plus, on le refait choisir une autre option
                    if (amountFarms.Count <= 0)
                    {
                        Console.WriteLine("Cette carte n'est plus disponible...");
                        if (this.isItAnAI)
                            BuyCard(true);
                        else
                            BuyCard();
                        break;
                    }
                    //On teste si le joueur peut acheter la carte avec son argent
                    CanBuyCard(farm);
                    Console.WriteLine("{0} a choisi d'acheter une ferme", this.name);
                    break;
                case 3:
                    var bakery = new BakeryCard();
                    //Si le joueur rentre quand même le numéro de la carte alors qu'il n'y en a plus, on le refait choisir une autre option
                    if (amountBakeries.Count <= 0)
                    {
                        Console.WriteLine("Cette carte n'est plus disponible...");
                        if (this.isItAnAI)
                            BuyCard(true);
                        else
                            BuyCard();
                        break;
                    }
                    //On teste si le joueur peut acheter la carte avec son argent
                    CanBuyCard(bakery);
                    Console.WriteLine("{0} a choisi d'acheter une boulangerie", this.name);
                    break;
                case 4:
                    var cafe = new CoffeeCard();
                    if (amountCoffees.Count <= 0)
                    {
                        Console.WriteLine("Cette carte n'est plus disponible...");
                        if (this.isItAnAI)
                            BuyCard(true);
                        else
                            BuyCard();
                        break;
                    }
                    CanBuyCard(cafe);
                    Console.WriteLine("{0} a choisi d'acheter un café", this.name);
                    break;
                case 5:
                    var minimarket = new MiniMarketCard();
                    if (amountMiniMarkets.Count <= 0)
                    {
                        Console.WriteLine("Cette carte n'est plus disponible...");
                        if (this.isItAnAI)
                            BuyCard(true);
                        else
                            BuyCard();
                        break;
                    }
                    CanBuyCard(minimarket);
                    Console.WriteLine("{0} a choisi d'acheter une superette", this.name);
                    break;
                case 6:
                    var forest = new ForestCard();
                    if (amountForests.Count <= 0)
                    {
                        Console.WriteLine("Cette carte n'est plus disponible...");
                        if (this.isItAnAI)
                            BuyCard(true);
                        else
                            BuyCard();
                        break;
                    }
                    CanBuyCard(forest);
                    Console.WriteLine("{0} a choisi d'acheter une forêt", this.name);
                    break;
                case 7:
                    var restau = new RestaurantCard();
                    if (amountRestaurants.Count <= 0)
                    {
                        Console.WriteLine("Cette carte n'est plus disponible...");
                        if (this.isItAnAI)
                            BuyCard(true);
                        else
                            BuyCard();
                        break;
                    }
                    CanBuyCard(restau);
                    Console.WriteLine("{0} a choisi d'acheter un restaurant", this.name);
                    break;
                case 8:
                    var stadium = new StadiumCard();
                    if (amountStadiums.Count <= 0)
                    {
                        Console.WriteLine("Cette carte n'est plus disponible...");
                        if (this.isItAnAI)
                            BuyCard(true);
                        else
                            BuyCard();
                        break;
                    }
                    CanBuyCard(stadium);
                    Console.WriteLine("{0} a choisi d'acheter un stade", this.name);
                    break;
                case 9:
                    var cheeseFacto = new CheeseFactoryCard();
                    if (amountCheeseFactories.Count <= 0)
                    {
                        Console.WriteLine("Cette carte n'est plus disponible...");
                        if (this.isItAnAI)
                            BuyCard(true);
                        else
                            BuyCard();
                        break;
                    }
                    CanBuyCard(cheeseFacto);
                    Console.WriteLine("{0} a choisi d'acheter une fromagerie", this.name);
                    break;
                case 10:
                    var furnitureFacto = new FurnitureFactoryCard();
                    if (amountFurnitureFactories.Count <= 0)
                    {
                        Console.WriteLine("Cette carte n'est plus disponible...");
                        if (this.isItAnAI)
                            BuyCard(true);
                        else
                            BuyCard();
                        break;
                    }
                    CanBuyCard(furnitureFacto);
                    Console.WriteLine("{0} a choisi d'acheter une fabrique de meuble", this.name);
                    break;
                case 11:
                    var mine = new StadiumCard();
                    if (amountMines.Count <= 0)
                    {
                        Console.WriteLine("Cette carte n'est plus disponible...");
                        if (this.isItAnAI)
                            BuyCard(true);
                        else
                            BuyCard();
                        break;
                    }
                    CanBuyCard(mine);
                    Console.WriteLine("{0} a choisi d'acheter une mine", this.name);
                    break;
                case 12:
                    var orchard = new OrchardCard();
                    if (amountOrchards.Count <= 0)
                    {
                        Console.WriteLine("Cette carte n'est plus disponible...");
                        if (this.isItAnAI)
                            BuyCard(true);
                        else
                            BuyCard();
                        break;
                    }
                    CanBuyCard(orchard);
                    Console.WriteLine("{0} a choisi d'acheter un verger", this.name);
                    break;
                case 13:
                    var market = new MarketCard();
                    if (amountMarkets.Count <= 0)
                    {
                        Console.WriteLine("Cette carte n'est plus disponible...");
                        if (this.isItAnAI)
                            BuyCard(true);
                        else
                            BuyCard();
                        break;
                    }
                    CanBuyCard(market);
                    Console.WriteLine("{0} a choisi d'acheter un marché", this.name);
                    break;
                case 14:
                    Console.WriteLine("{0} a passé son tour", this.name);
                    break;

                default:
                    Console.WriteLine("Default");
                    break;
            }
            #endregion
        }

        //Si le joueur a assez d'argent, achète la carte sinon relance BuyCard()
        private void CanBuyCard(MasterCard card)
        {
            //Le joueur a assez d'argent
            if (nbPiece >= card.costValue)
            {
                nbPiece -= card.costValue;
                playerCardList.Add(card);
                game.pile.RemoveCardFromPile(card);
                card.SetPlayerOwner(this);
            }
            //Le joueur n'a pas assez d'argent
            else
            {
                Console.WriteLine("{0} n'avez pas assez de pièces. Veuillez choisir une autre carte !\n", this.name);
                BuyCard(true);
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