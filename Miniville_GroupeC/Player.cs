using System;
using System.Collections.Generic;
using System.Linq;

namespace Miniville_GroupeC
{
    public class Player : Game
    {
<<<<<<< Updated upstream

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

=======
        #region Déclaration de variables
        public List<MasterCard> playerCardList = new List<MasterCard>();
        public int nbPiece;
<<<<<<< Updated upstream
        public Game game;
        public string name;
<<<<<<< HEAD
        public bool ordi;
        public bool testCanBuy;


        public Player(int piece, List<MasterCard> Mastercard, Game game, string name, bool ordi)
=======
        private Pile pile;
=======
        public Game game; //on appelle la fonction game pour tester ce qu'il y a dedans 
        public string name;//nom du joueur
        private Pile pile;//pile des cartes pour pouvoir tester 
        public bool isItAnAI; //si le joueur est une IA ou non 
        public bool testCanBuy; //tester si on peut acheter la carte
        private bool stopBuying = false; //on demande d'arreter d'acheter pour eviter les boucles
>>>>>>> Stashed changes
        #endregion

        #region Constructeur
        public Player(int piece, List<MasterCard> Mastercard, Game game, string name, Pile pile)
>>>>>>> d4242d8a9ae8bdd291db9d872e14168785ae6dd8
        {
            this.nbPiece = piece;
            this.playerCardList = Mastercard;
            this.game = game;
            this.name = name;
<<<<<<< HEAD
            this.ordi = ordi;
=======
            this.pile = pile;
>>>>>>> d4242d8a9ae8bdd291db9d872e14168785ae6dd8
>>>>>>> Stashed changes
        }
        #endregion

<<<<<<< Updated upstream
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
=======
        #region Méthodes
        //Affiche les différentes cartes qu'on peut acheter et réalise l'achat si le joueur a assez d'argent
        public void BuyCard()
        {
            
            int choice = -1;

<<<<<<< HEAD
            if (ordi == false) //Le player est un joueur
            {
                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("1 - Des champs de blé (1$) ? Recevez 1 pièce lorsque le dé affiche 1");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("2 - Une ferme (2$) ? Recevez 1 pièce lorsque le dé affiche 1");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("3 - Une boulangerie (1$) ? Recevez 2 pièces lorsque le dé affiche 2");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("4 - Une café (2$) ? Recevez 1 pièce du joueur qui a lancé le dé et qui affiche 3");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("5 - Une superette (2$) ? Recevez 3 pièces lorsque le dé affiche 4");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("6 - Une forêt (2$) ? Recevez 1 pièce lorsque le dé affiche 5");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("7 - Un restaurant (4$) ? Recevez 2 pièces du joueur qui a lancé le dé et qui affiche 5");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("8 - Un stade (6$) ? Recevez 4 pièces lorsque le dé affiche 6");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("9 - Passer votre tour");
                    Console.ResetColor();

                } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 9);
            }
            else //Le player est un ordi 
            {
                int Cagnote = 0;
                foreach (Player perso in game.players)
                {
                    if (perso.nbPiece < game.nbPieceVictory / 2) { }//si le perso a un nombre de piéce inferieur a la moitier de condition de victoire
                    else { Cagnote++; }
                }

                int maxforet = 0;
                foreach (Player perso in game.players) //Parcour tout les joueurs
                {
                    int testforet = 0;
                    
                    foreach (MasterCard carte in playercard) //parcour toute les cartes du joueurs
                    {
                        if (carte is ForestCard) { testforet += 1; } // si le joueur a une foret
                        testforet++;
                    }
                    if(testforet > maxforet) { maxforet = testforet; }

                }


                int myretaurant = 0;
                foreach (MasterCard carte in playercard) //parcour toute les cartes de ce joueur
                {
                    if (carte is ForestCard) { myretaurant++; } 
                }


                int maxchamp = 0;
                foreach (Player perso in game.players) //Parcour tout les joueurs
                {
                    int testchamp = 0;

                    foreach (MasterCard carte in playercard) //parcour toute les cartes du joueurs
                    {
                        if (carte is WheatFieldCard) { testchamp += 1; } // si le joueur a une foret
                        testchamp++;
                    }
                    if (testchamp > maxchamp) { maxchamp = testchamp; }

                }


                int myferme = 0;
                foreach (MasterCard carte in playercard) //parcour toute les cartes de ce joueur
                {
                    if (carte is FarmCard) { myferme++; }
                }




                if (maxforet < myretaurant) //si un joueur enemy a plus de foret que son nombre de restau en prendre un
                {
                    if(nbPiece >= 4)
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
                    foreach (MasterCard carte in playercard) //on teste si les cartes appartiennent au joueur
                    {
                        if (carte is WheatFieldCard) { CardChamp = true; }
                        if (carte is WheatFieldCard) { CardChamp = true; }
                        if (carte is WheatFieldCard) { CardChamp = true; }
                        if (carte is WheatFieldCard) { CardChamp = true; }
                        if (carte is WheatFieldCard) { CardChamp = true; }
                        if (carte is WheatFieldCard) { CardChamp = true; }
                        if (carte is WheatFieldCard) { CardChamp = true; }
                        if (carte is WheatFieldCard) { CardChamp = true; }
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
                    else 
                    {
                        Random rdm = new Random(); //Si le joueur  ne peut faire aucune des actions précédente alors elle fait un choix aléatoire
                        choice = rdm.Next(1, 10);
                    }
                }
                

            }
            
=======
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
            #endregion

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
>>>>>>> d4242d8a9ae8bdd291db9d872e14168785ae6dd8

            #region Effectue l'achat si c'est possible (carte disponible et assez d'argent)
            switch (choice)
            {
                case 1:
                    var wheatFieldCard = new WheatFieldCard();
                    //Si le joueur rentre quand même le numéro de la carte alors qu'il n'y en a plus, on le refait choisir une autre option
                    if (amountWheatFields.Count <= 0)
                    {
                        Console.WriteLine("Cette carte n'est plus disponible...");
                        BuyCard();
                        break;
                    }
                    //On teste si le joueur peut acheter la carte avec son argent
                    CanBuyCard(wheatFieldCard);
                    if (ordi == false) { Console.WriteLine("Vous avez choisi d'acheter un champ de blé"); }
                    else { Console.WriteLine("{0} a choisi d'acheter un champ de blé", name); }
                    break;
                case 2:
                    var farm = new FarmCard();
                    //Si le joueur rentre quand même le numéro de la carte alors qu'il n'y en a plus, on le refait choisir une autre option
                    if (amountFarms.Count <= 0)
                    {
                        Console.WriteLine("Cette carte n'est plus disponible...");
                        BuyCard();
                        break;
                    }
                    //On teste si le joueur peut acheter la carte avec son argent
                    CanBuyCard(farm);
                    if (ordi == false) { Console.WriteLine("Vous avez choisi d'acheter une ferme"); }
                    else { Console.WriteLine("{0} a choisi d'acheter une ferme", name); }
                    break;
                case 3:
                    var bakery = new BakeryCard();
                    //Si le joueur rentre quand même le numéro de la carte alors qu'il n'y en a plus, on le refait choisir une autre option
                    if (amountBakeries.Count <= 0)
                    {
                        Console.WriteLine("Cette carte n'est plus disponible...");
                        BuyCard();
                        break;
                    }
                    //On teste si le joueur peut acheter la carte avec son argent
                    CanBuyCard(bakery);
                    if (ordi == false) { Console.WriteLine("Vous avez choisi d'acheter une boulangerie"); }
                    else { Console.WriteLine("{0} a choisi d'acheter une boulangerie", name); }
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
                    if (ordi == false) { Console.WriteLine("Vous avez choisi d'acheter un café"); }
                    else { Console.WriteLine("{0} a choisi d'acheter un café", name); }
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
                    if (ordi == false) { Console.WriteLine("Vous avez choisi d'acheter une superette"); }
                    else { Console.WriteLine("{0} a choisi d'acheter une superette", name); }
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
                    if (ordi == false) { Console.WriteLine("Vous avez choisi d'acheter une foret"); }
                    else { Console.WriteLine("{0} a choisi d'acheter une foret", name); }
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
                    if (ordi == false) { Console.WriteLine("Vous avez choisi d'acheter un restaurant"); }
                    else { Console.WriteLine("{0} a choisi d'acheter un restaurant", name); }
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
                    if (ordi == false) { Console.WriteLine("Vous avez choisi d'acheter un stade\n"); }
                    
                     else { Console.WriteLine("{0} a choisi d'acheter un stade", name); }
                    break;
                case 9:
<<<<<<< HEAD
                    if (ordi == false) { Console.WriteLine("Vous avez passé votre tour\n"); }
                    else { Console.WriteLine("{0} a passé son tour", name); }
=======
                    var cheeseFacto = new CheeseFactoryCard();
                    if (amountCheeseFactories.Count <= 0)
                    {
                        Console.WriteLine("Cette carte n'est plus disponible...");
                        BuyCard();
                        break;
                    }
                    CanBuyCard(cheeseFacto);
                    Console.WriteLine("Vous avez choisi d'acheter une fabrique de fromage\n");
                    break;
                case 10:
                    var furnitureFacto = new FurnitureFactoryCard();
                    if (amountFurnitureFactories.Count <= 0)
                    {
                        Console.WriteLine("Cette carte n'est plus disponible...");
                        BuyCard();
                        break;
                    }
                    CanBuyCard(furnitureFacto);
                    Console.WriteLine("Vous avez choisi d'acheter une fabrique de meubles\n");
                    break;
                case 11:
                    var mine = new StadiumCard();
                    if (amountMines.Count <= 0)
                    {
                        Console.WriteLine("Cette carte n'est plus disponible...");
                        BuyCard();
                        break;
                    }
                    CanBuyCard(mine);
                    Console.WriteLine("Vous avez choisi d'acheter une mine\n");
                    break;
                case 12:
                    var orchard = new OrchardCard();
                    if (amountOrchards.Count <= 0)
                    {
                        Console.WriteLine("Cette carte n'est plus disponible...");
                        BuyCard();
                        break;
                    }
                    CanBuyCard(orchard);
                    Console.WriteLine("Vous avez choisi d'acheter un verger\n");
                    break;
                case 13:
                    var market = new MarketCard();
                    if (amountMarkets.Count <= 0)
                    {
                        Console.WriteLine("Cette carte n'est plus disponible...");
                        BuyCard();
                        break;
                    }
                    CanBuyCard(market);
                    Console.WriteLine("Vous avez choisi d'acheter un marché\n");
                    break;
                case 14:
                    Console.WriteLine("Vous avez passé votre tour\n");
>>>>>>> d4242d8a9ae8bdd291db9d872e14168785ae6dd8
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
                testCanBuy = true;
                nbPiece -= card.costValue;
                playerCardList.Add(card);
                game.pile.RemoveCardFromPile(card);
                card.SetPlayerOwner(this);
                
            }
            //Le joueur n'a pas assez d'argent
            else
            {
                testCanBuy = false;
                if (ordi == false) { Console.WriteLine("Vous n'avez pas assez de pièces. Veuillez choisir une autre carte !\n"); }
                BuyCard();
            }
        }


        //Parcourt les cartes de chaque joueur afin de les activer selon la valeur du dé
        public void CheckCardToActivate(int diceValue)
        {
            foreach (var card in playerCardList)
                card.OnDiceResult(diceValue, game.currentPlayer);
>>>>>>> Stashed changes
        }
        #endregion
    }
}
