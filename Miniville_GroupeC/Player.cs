using System;
using System.Collections.Generic;
using System.Linq;

namespace Miniville_GroupeC
{
    public class Player
    {
        #region Déclaration de variables
        public int nbPiece;
        public string name;
        public Game game;
        private Pile playPile;
        public List<MasterCard> playerCardList = new List<MasterCard>();
        public bool isItAnAI;
        public bool isChoiceNotPossible = false;
        #endregion

        #region Constructeur
        public Player(int piece, List<MasterCard> Mastercard, Game game, string name, Pile playPile, bool isItAnAI)
        {
            this.nbPiece = piece;
            this.playerCardList = Mastercard;
            this.game = game;
            this.name = name;
            this.playPile = playPile;
            this.isItAnAI = isItAnAI;
        }
        #endregion

        #region Méthodes

        //Affiche les différentes cartes qu'on peut acheter et réalise l'achat si le joueur a assez d'argent
        public void BuyCard(bool isAILooping = false)
        {
            #region Déclaration de variables
            int choice = -1;
            #endregion

            #region Compteurs du nombre restant de chaque type de carte dans la pile
            var amountWheatFields = playPile.mainPile.Where(x => x is WheatFieldCard).ToList();
            var amountFarms = playPile.mainPile.Where(x => x is FarmCard).ToList();
            var amountBakeries = playPile.mainPile.Where(x => x is BakeryCard).ToList();
            var amountCoffees = playPile.mainPile.Where(x => x is CoffeeCard).ToList();
            var amountMiniMarkets = playPile.mainPile.Where(x => x is MiniMarketCard).ToList();
            var amountForests = playPile.mainPile.Where(x => x is ForestCard).ToList();
            var amountRestaurants = playPile.mainPile.Where(x => x is RestaurantCard).ToList();
            var amountStadiums = playPile.mainPile.Where(x => x is StadiumCard).ToList();
            var amountCheeseFactories = playPile.mainPile.Where(x => x is CheeseFactoryCard).ToList();
            var amountFurnitureFactories = playPile.mainPile.Where(x => x is FurnitureFactoryCard).ToList();
            var amountMines = playPile.mainPile.Where(x => x is MineCard).ToList();
            var amountOrchards = playPile.mainPile.Where(x => x is OrchardCard).ToList();
            var amountMarkets = playPile.mainPile.Where(x => x is MarketCard).ToList();
            #endregion

            #region Compteurs du nombre de monuments dans la main du joueur
            var amountPlayerAmusementParcCard = this.playerCardList.Where(x => x is AmusementParcCard).ToList();
            var amountPlayerRadioTowerCard = this.playerCardList.Where(x => x is RadioTowerCard).ToList();
            var amountPlayerShoppingCentreCard = this.playerCardList.Where(x => x is ShoppingCentreCard).ToList();
            var amountPlayerTrainStationCard = this.playerCardList.Where(x => x is TrainStationCard).ToList();
            #endregion

            //Le joueur n'est pas une IA
            if (!isItAnAI)
            {
                #region Affichage Cartes de la pile selon leur disponibilité
                do
                {
                    #region Affichage Champs de Blé
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
                    #endregion

                    #region Affichage Ferme
                    //On affiche la ligne dans la couleur de la carte
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    //On affiche la description de la carte si elle est encore disponible
                    if (amountFarms.Count > 0)
                    {
                        Console.Write("2  - Une ferme (1$) ? Recevez 1 pièce lorsque le dé affiche 1 ");
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
                    #endregion

                    #region Affichage Boulangerie
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
                    #endregion

                    #region Affichage Café
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    if (amountCoffees.Count > 0)
                    {
                        Console.Write("4  - Un café (2$) ? Recevez 1 pièce du joueur qui a lancé le dé et qui affiche 3 ");
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
                    #endregion

                    #region Affichage Supérette
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
                    #endregion

                    #region Affichage Forêt
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    if (amountForests.Count > 0)
                    {
                        Console.Write("6  - Une forêt (3$) ? Recevez 1 pièce lorsque le dé affiche 5 ");
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
                    #endregion

                    #region Affichage Restaurant
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    if (amountRestaurants.Count > 0)
                    {
                        Console.Write("7  - Un restaurant (3$) ? Recevez 2 pièces du joueur qui a lancé le dé et qui affiche 9 ou 10 ");
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
                    #endregion

                    #region Affichage Stade
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
                    #endregion

                    #region Affichage Fromagerie
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
                    #endregion

                    #region Affichage Fabrique de meubles
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
                    #endregion

                    #region Affichage Mine
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
                    #endregion

                    #region Affichage Verger
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
                    #endregion

                    #region Affichage Marché
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
                    #endregion

                    #region Affichage Gare
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    if (amountPlayerTrainStationCard.Count == 0)
                        Console.WriteLine("14  - Une gare (4$) ? Vous pouvez lancer deux dés !");
                    else if (amountPlayerTrainStationCard.Count == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Vous possèdez déjà une gare ! Vous pouvez donc choisir de lancer deux dés au début du tour !");
                    }
                    Console.ResetColor();
                    #endregion

                    #region Affichage Parc d'attraction
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    if (amountPlayerAmusementParcCard.Count == 0)
                        Console.WriteLine("15  - Un parc d'attraction (16$) ? Si votre jet de dés est un double, rejouez directement");
                    else if (amountPlayerAmusementParcCard.Count == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Vous possèdez déjà un parc d'attractions ! Si jamais votre jet de dés est un double, vous pouvez rejouer directement !");
                    }
                    Console.ResetColor();
                    #endregion

                    #region Affichage Tour Radio
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    if (amountPlayerRadioTowerCard.Count == 0)
                        Console.WriteLine("16  - Une tour radio (22$) ? Une fois par tour, vous pouvez choisir de relancer vos dés !");
                    else if (amountPlayerRadioTowerCard.Count == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Vous possèdez déjà une tour Radio ! Vous pouvez donc choisir de relancer vos dés en début de tour !");
                    }
                    Console.ResetColor();
                    #endregion

                    #region Affichage Centre Commercial
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    if (amountPlayerShoppingCentreCard.Count == 0)
                        Console.WriteLine("17  - Un centre commercial (10$) ? Vos établissement de type café, restaurant, supérette et boulangerie rapporte une pièce de plus !");
                    else if (amountPlayerShoppingCentreCard.Count == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Vous possèdez déjà un centre commercial ! Vos cafés, restaurants, supérettes et boulangeries sont boostées d'une pièce !");
                    }
                    Console.ResetColor();
                    #endregion

                    #region Affichage Passer le tour
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("18 - Passer votre tour");
                    Console.ResetColor();
                    #endregion

                } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 18);
                #endregion
            }
            //Le joueur est une IA
            else
            {
                #region Récupération du nombre de joueurs ayant moins de la moitié de l'argent requis pour gagner
                int nbPlayersBelowHalfOfVictory = 0;
                foreach (Player perso in game.playersInGame)
                {
                    if (perso.nbPiece < game.nbPieceVictory / 2) { }
                    else { nbPlayersBelowHalfOfVictory++; }
                }
                #endregion

                #region Récupération du maximum de forêt & de champs dans les mains des autres joueurs
                int maxOfAllForest = 0;
                foreach (Player perso in game.playersInGame)
                {
                    int currentMaxForest = perso.playerCardList.Where(x => x is ForestCard).ToList().Count;
                    if (currentMaxForest > maxOfAllForest) { maxOfAllForest = currentMaxForest; }
                }

                int maxOfAllWheatField = 0;
                foreach (Player perso in game.playersInGame)
                {
                    int currentMaxWheatField = perso.playerCardList.Where(x => x is WheatFieldCard).ToList().Count;
                    if (currentMaxWheatField > maxOfAllWheatField) { maxOfAllWheatField = currentMaxWheatField; }

                }
                #endregion

                #region Récupération du nombre de restaurant & de fermes dans la main du joueur 
                int nbOfCurrentRestaurant = this.playerCardList.Where(x => x is RestaurantCard).ToList().Count;
                int nbOfCurrentFarm = this.playerCardList.Where(x => x is FarmCard).ToList().Count;
                #endregion

                #region Selon les données précédentes, faire un choix
                //On contre les Forêts par les Restaurants (Si les autres ont plus de Forêt que notre nombre de Restaurant, on achète un Restaurant)
                if (maxOfAllForest > nbOfCurrentRestaurant)
                {
                    if (nbPiece >= 4)
                        choice = 7;
                }
                //On contre les Champs de Blés par les Fermes ou les Boulangeries (Si les autres ont plus de Champs de Blés que notre nombre de Fermes, on achète une Ferme ou une Boulangerie)
                else if (maxOfAllWheatField > nbOfCurrentFarm)
                {
                    if (nbPiece >= 2)
                        choice = 2;
                    else if (nbPiece >= 1)
                        choice = 3;
                }
                //Si tout les joueurs sont presque à la victoire (au dessus de la moitié du montant exigé), on achète un stade
                else if (nbPlayersBelowHalfOfVictory == 0)
                {
                    if (nbPiece >= 6)
                        choice = 8;
                }
                #endregion

                #region Décision de l'IA basée sur ses types de cartes possédées
                else //Sinon prendre une carte qui n'a pas encore était prise par le joueur
                {
                    #region Déclaration des bools de chaque carte pour savoir si l'IA possède ce type
                    bool isWheatFieldInHand = false;
                    bool isFarmInHand = false;
                    bool isBakeryInHand = false;
                    bool isCoffeeInHand = false;
                    bool isMiniMarketInHand = false;
                    bool isForestInHand = false;
                    bool isRestaurantInHand = false;
                    bool isStadiumInHand = false;
                    bool isRadioTowerInHand = false;
                    bool isTrainStationInHand = false;
                    bool isShoppingCentreInHand = false;
                    bool isAttractionParcInHand = false;
                    #endregion

                    #region Mise à jour des précédents bools en parcourant les cartes de la main du joueur
                    foreach (MasterCard carte in this.playerCardList) //on teste si les cartes appartiennent au joueur
                    {
                        if (carte is WheatFieldCard) { isWheatFieldInHand = true; }
                        if (carte is FarmCard) { isFarmInHand = true; }
                        if (carte is BakeryCard) { isBakeryInHand = true; }
                        if (carte is CoffeeCard) { isCoffeeInHand = true; }
                        if (carte is MiniMarketCard) { isMiniMarketInHand = true; }
                        if (carte is ForestCard) { isForestInHand = true; }
                        if (carte is RestaurantCard) { isRestaurantInHand = true; }
                        if (carte is StadiumCard) { isStadiumInHand = true; }
                        if (carte is AmusementParcCard) { isAttractionParcInHand = true; }
                        if (carte is RadioTowerCard) { isRadioTowerInHand = true; }
                        if (carte is TrainStationCard) { isTrainStationInHand = true; }
                        if (carte is ShoppingCentreCard) { isShoppingCentreInHand = true; }
                    }
                    #endregion

                    #region Si le joueur ne possède pas un type de carte, on lui fait acheter
                    if (isWheatFieldInHand == false) { if (nbPiece >= 1) { choice = 1; } }
                    if (isFarmInHand == false) { if (nbPiece >= 2) { choice = 2; } }
                    if (isBakeryInHand == false) { if (nbPiece >= 1) { choice = 3; } }
                    if (isCoffeeInHand == false) { if (nbPiece >= 2) { choice = 4; } }
                    if (isMiniMarketInHand == false) { if (nbPiece >= 2) { choice = 5; } }
                    if (isForestInHand == false) { if (nbPiece >= 2) { choice = 6; } }
                    if (isRestaurantInHand == false) { if (nbPiece >= 4) { choice = 7; } }
                    if (isStadiumInHand == false) { if (nbPiece >= 6) { choice = 8; } }
                    if (isTrainStationInHand == false) { if (nbPiece >= 4) { choice = 14; } }
                    if (isShoppingCentreInHand == false) { if (nbPiece >= 10) { choice = 15; } }
                    if (isRadioTowerInHand == false) { if (nbPiece >= 22) { choice = 16; } }
                    if (isAttractionParcInHand == false) { if (nbPiece >= 15) { choice = 17; } }
                    #endregion
                }
                #endregion

                #region Décision aléatoire de l'IA
                //Si elle n'a pas sélectionné de choix avant ou pour éviter qu'elle fasse une boucle infini
                if (choice == -1 || isAILooping)
                {
                    Random rdm = new Random();
                    choice = rdm.Next(1, 19);
                }
                #endregion
            }

            #region Effectue l'achat si c'est possible (carte disponible et assez d'argent)
            switch (choice)
            {
                case 1:
                    #region Champ de blé
                    //Si le joueur rentre quand même le numéro de la carte alors qu'il n'y en a plus, on le refait choisir une autre option
                    if (amountWheatFields.Count <= 0)
                    {
                        if (!this.isItAnAI)
                            Console.WriteLine("Cette carte n'est plus disponible...");
                        isChoiceNotPossible = true;
                        break;
                    }
                    //On teste si le joueur peut acheter la carte avec son argent
                    CanBuyCard(new WheatFieldCard());
                    if (isChoiceNotPossible)
                        break;
                    Console.WriteLine("{0} a choisi d'acheter un champ de blé", this.name);
                    #endregion
                    break;
                case 2:
                    #region Ferme
                    //Si le joueur rentre quand même le numéro de la carte alors qu'il n'y en a plus, on le refait choisir une autre option
                    if (amountFarms.Count <= 0)
                    {
                        if (!this.isItAnAI)
                            Console.WriteLine("Cette carte n'est plus disponible...");
                        isChoiceNotPossible = true;
                        break;
                    }
                    //On teste si le joueur peut acheter la carte avec son argent
                    CanBuyCard(new FarmCard());
                    if (isChoiceNotPossible)
                        break;
                    Console.WriteLine("{0} a choisi d'acheter une ferme", this.name);
                    #endregion
                    break;
                case 3:
                    #region Boulangerie
                    //Si le joueur rentre quand même le numéro de la carte alors qu'il n'y en a plus, on le refait choisir une autre option
                    if (amountBakeries.Count <= 0)
                    {
                        if (!this.isItAnAI)
                            Console.WriteLine("Cette carte n'est plus disponible...");
                        isChoiceNotPossible = true;
                        break;
                    }
                    //On teste si le joueur peut acheter la carte avec son argent
                    CanBuyCard(new BakeryCard());
                    if (isChoiceNotPossible)
                        break;
                    Console.WriteLine("{0} a choisi d'acheter une boulangerie", this.name);
                    #endregion
                    break;
                case 4:
                    #region Café
                    if (amountCoffees.Count <= 0)
                    {
                        if (!this.isItAnAI)
                            Console.WriteLine("Cette carte n'est plus disponible...");
                        isChoiceNotPossible = true;
                        break;
                    }
                    CanBuyCard(new CoffeeCard());
                    if (isChoiceNotPossible)
                        break;
                    Console.WriteLine("{0} a choisi d'acheter un café", this.name);
                    #endregion
                    break;
                case 5:
                    #region Supérette
                    if (amountMiniMarkets.Count <= 0)
                    {
                        if (!this.isItAnAI)
                            Console.WriteLine("Cette carte n'est plus disponible...");
                        isChoiceNotPossible = true;
                        break;
                    }
                    CanBuyCard(new MiniMarketCard());
                    if (isChoiceNotPossible)
                        break;
                    Console.WriteLine("{0} a choisi d'acheter une superette", this.name);
                    #endregion
                    break;
                case 6:
                    #region Forêt
                    if (amountForests.Count <= 0)
                    {
                        if (!this.isItAnAI)
                            Console.WriteLine("Cette carte n'est plus disponible...");
                        isChoiceNotPossible = true;
                        break;
                    }
                    CanBuyCard(new ForestCard());
                    if (isChoiceNotPossible)
                        break;
                    Console.WriteLine("{0} a choisi d'acheter une forêt", this.name);
                    #endregion
                    break;
                case 7:
                    #region Restaurant
                    if (amountRestaurants.Count <= 0)
                    {
                        if (!this.isItAnAI)
                            Console.WriteLine("Cette carte n'est plus disponible...");
                        isChoiceNotPossible = true;
                        break;
                    }
                    CanBuyCard(new RestaurantCard());
                    if (isChoiceNotPossible)
                        break;
                    Console.WriteLine("{0} a choisi d'acheter un restaurant", this.name);
                    #endregion
                    break;
                case 8:
                    #region Stade
                    if (amountStadiums.Count <= 0)
                    {
                        if (!this.isItAnAI)
                            Console.WriteLine("Cette carte n'est plus disponible...");
                        isChoiceNotPossible = true;
                        break;
                    }
                    CanBuyCard(new StadiumCard());
                    if (isChoiceNotPossible)
                        break;
                    Console.WriteLine("{0} a choisi d'acheter un stade", this.name);
                    #endregion
                    break;
                case 9:
                    #region Fromagerie
                    if (amountCheeseFactories.Count <= 0)
                    {
                        if (!this.isItAnAI)
                            Console.WriteLine("Cette carte n'est plus disponible...");
                        isChoiceNotPossible = true;
                        break;
                    }
                    CanBuyCard(new CheeseFactoryCard());
                    if (isChoiceNotPossible)
                        break;
                    Console.WriteLine("{0} a choisi d'acheter une fromagerie", this.name);
                    #endregion
                    break;
                case 10:
                    #region Fabrique de Meubles
                    if (amountFurnitureFactories.Count <= 0)
                    {
                        if (!this.isItAnAI)
                            Console.WriteLine("Cette carte n'est plus disponible...");
                        isChoiceNotPossible = true;
                        break;
                    }
                    CanBuyCard(new FurnitureFactoryCard());
                    if (isChoiceNotPossible)
                        break;
                    Console.WriteLine("{0} a choisi d'acheter une fabrique de meuble", this.name);
                    #endregion
                    break;
                case 11:
                    #region Mine
                    if (amountMines.Count <= 0)
                    {
                        if (!this.isItAnAI)
                            Console.WriteLine("Cette carte n'est plus disponible...");
                        isChoiceNotPossible = true;
                        break;
                    }
                    CanBuyCard(new MineCard());
                    if (isChoiceNotPossible)
                        break;
                    Console.WriteLine("{0} a choisi d'acheter une mine", this.name);
                    #endregion
                    break;
                case 12:
                    #region Verger
                    if (amountOrchards.Count <= 0)
                    {
                        if (!this.isItAnAI)
                            Console.WriteLine("Cette carte n'est plus disponible...");
                        isChoiceNotPossible = true;
                        break;
                    }
                    CanBuyCard(new OrchardCard());
                    if (isChoiceNotPossible)
                        break;
                    Console.WriteLine("{0} a choisi d'acheter un verger", this.name);
                    #endregion
                    break;
                case 13:
                    #region Marché
                    if (amountMarkets.Count <= 0)
                    {
                        if (!this.isItAnAI)
                            Console.WriteLine("Cette carte n'est plus disponible...");
                        isChoiceNotPossible = true;
                        break;
                    }
                    CanBuyCard(new MarketCard());
                    if (isChoiceNotPossible)
                        break;
                    Console.WriteLine("{0} a choisi d'acheter un marché", this.name);
                    #endregion
                    break;
                case 14:
                    #region Gare
                    if (amountPlayerTrainStationCard.Count == 1)
                    {
                        if (!this.isItAnAI)
                            Console.WriteLine("Vous possèdez déjà ce monument...");
                        isChoiceNotPossible = true;
                        break;
                    }
                    CanBuyCard(new TrainStationCard());
                    if (isChoiceNotPossible)
                        break;
                    Console.WriteLine("{0} a choisi d'acheter une gare", this.name);
                    #endregion
                    break;
                case 15:
                    #region Parc d'Attractions
                    if (amountPlayerAmusementParcCard.Count == 1)
                    {
                        if (!this.isItAnAI)
                            Console.WriteLine("Vous possèdez déjà ce monument...");
                        isChoiceNotPossible = true;
                        break;
                    }
                    CanBuyCard(new AmusementParcCard());
                    if (isChoiceNotPossible)
                        break;
                    Console.WriteLine("{0} a choisi d'acheter un parc d'attractions", this.name);
                    #endregion
                    break;
                case 16:
                    #region Tour Radio
                    if (amountPlayerRadioTowerCard.Count == 1)
                    {
                        if (!this.isItAnAI)
                            Console.WriteLine("Vous possèdez déjà ce monument...");
                        isChoiceNotPossible = true;
                        break;
                    }
                    CanBuyCard(new RadioTowerCard());
                    if (isChoiceNotPossible)
                        break;
                    Console.WriteLine("{0} a choisi d'acheter une tour radio", this.name);
                    #endregion
                    break;
                case 17:
                    #region Centre Commercial
                    if (amountPlayerShoppingCentreCard.Count == 1)
                    {
                        if (!this.isItAnAI)
                            Console.WriteLine("Vous possèdez déjà ce monument...");
                        isChoiceNotPossible = true;
                        break;
                    }
                    CanBuyCard(new ShoppingCentreCard());
                    if (isChoiceNotPossible)
                        break;
                    Console.WriteLine("{0} a choisi d'acheter un centre commercial", this.name);
                    #endregion
                    break;

                case 18:
                    Console.WriteLine("{0} a passé son tour", this.name);
                    break;

                default:
                    Console.WriteLine("Default");
                    break;
            }
            #endregion

            #region Relancer la fonction si le choix n'a pas été possible
            if (isChoiceNotPossible)
            {
                isChoiceNotPossible = false;
                //Pour éviter que l'IA fasse une boucle infinie
                if (this.isItAnAI)
                    BuyCard(true);
                else
                    BuyCard();
            }
            #endregion
        }

        //Si le joueur a assez d'argent, achète la carte sinon relance BuyCard()
        private void CanBuyCard(MasterCard card)
        {
            //Le joueur a assez d'argent
            if (nbPiece >= card.costValue)
            {
                isChoiceNotPossible = false;
                nbPiece -= card.costValue;
                playerCardList.Add(card);
                game.playPile.RemoveCardFromPile(card);
                card.SetPlayerOwner(this);

            }
            //Le joueur n'a pas assez d'argent
            else
            {
                if (!this.isItAnAI)
                    Console.WriteLine("{0} n'a pas assez de pièces. Veuillez choisir une autre carte !\n", this.name);
                isChoiceNotPossible = true;
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