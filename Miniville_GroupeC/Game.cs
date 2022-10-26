﻿using System;
using System.Collections.Generic;
using System.Linq;


namespace Miniville_GroupeC
{
    public class Game
    {
        #region Déclaration des variables
        public List<Player> players = new List<Player>();
        public Player currentPlayer;
        public Dice playDice;
        public int nbPieceVictory;
        public List<string> namePlayers = new List<string>();
        private List<MasterCard> initialCards = new List<MasterCard>();
        private bool expertMode;
        private bool doubleDe;
        public Pile pile;
        public bool multiplayer = false;
		#endregion
		
        #region Constructeur
        public Game(Dice playDice, int nbPieceVictory, List<string> namePlayers, bool expertMode = false,bool multiplayer = false)
        {
            this.playDice = playDice;
            this.nbPieceVictory = nbPieceVictory;
            this.expertMode = expertMode;
            this.namePlayers = namePlayers;
            this.multiplayer = multiplayer;
            pile = new Pile();
            
            for (int i = 0; i < namePlayers.Count; i++)
            {
                Console.WriteLine("lol");
                string thatName = namePlayers[i];
                bool ordi = true;

                if(this.multiplayer == false) //Partie contre ordinateur
                {
                    MasterCard cardCham = new WheatFieldCard();
                    MasterCard cardBak = new BakeryCard();
                    this.initialCards = new List<MasterCard>()
                    {
                        cardCham,
                        cardBak
                    };
                    if (i == 0) // Si c'est le joueur 
                    {
                        ordi = false;  
                    }
                    else // Si c'est un ordinateur
                    {
                        ordi = true;
                    }
                    Player thatPlayer = new Player(3, this.initialCards, this, thatName, ordi);
                    cardCham.SetPlayerOwner(thatPlayer);
                    cardBak.SetPlayerOwner(thatPlayer);
                    players.Add(thatPlayer);
                }
                else //Partie en multijoueur
                {
                    foreach (string thatName2 in namePlayers)
                    {
                        MasterCard cardCham = new WheatFieldCard();
                        MasterCard cardBak = new BakeryCard();
                        this.initialCards = new List<MasterCard>()
                        {
                            cardCham,
                            cardBak
                        };
                        Player thatPlayer = new Player(3, this.initialCards, this, thatName, ordi);
                        cardCham.SetPlayerOwner(thatPlayer);
                        cardBak.SetPlayerOwner(thatPlayer);
                        players.Add(thatPlayer);
                    }
                }
            }
            
        }
        #endregion

        #region Méthodes
        //Effectue la boucle de jeu en affichant les données du joueur et du dé, en vérifiant si des cartes doivent être activées et en demandant si le joueur souhaite acheter une carte
        //Vérifie également la condition de fin et affiche le gagnant
        public void GameLoop()
        {
            bool isInLoop = true;
            string winningPlayer = "";
            while (isInLoop)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    currentPlayers = players[i];
                    int valueDice = this.playDice.De;

                    if (this.multiplayer == false) //une partie contre l'ordinateur
                    {
						
                    #region Données du joueur
                    currentPlayer = players[i];
                    Console.Write("\n\nC'est au tour de " + currentPlayer.name + " qui a un total de ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(currentPlayer.nbPiece);
                    Console.ResetColor();
                    Console.WriteLine(" pièces !");
                    #endregion

                    #region Données des dés
                    //Choix nombre de dés
                    int errorTryCatch = 0;
                    do
                    {
                        Console.WriteLine("\nAvec combien de dé voulez vous jouer\n");
                        Console.WriteLine("1 -- Avec un dé !");
                        Console.WriteLine("2 -- Avec deux dés !");
                        string DoubleDe = Console.ReadLine();

                        switch (DoubleDe)
                        {
                            case "1":
                                doubleDe = false;
                                errorTryCatch = 0;
                                break;
                            case "2":
                                doubleDe = true;
                                errorTryCatch = 0;
                                break;
                            default:
                                Console.WriteLine("Veuillez choisir une valeur valide (1 ou 2)");
                                errorTryCatch = 1;
                                break;
                        }
                    } while (errorTryCatch == 1);

                    //Valeur totale des dés lancés
                    int valueTotal = this.playDice.activeValueOfDice;
                    if(doubleDe)
						valueTotal += this.playDice.activeValueOfSecondDice;

                    //Affichage valeur finale des dés
                    Console.Write("Le(s) dé(s) affiche(nt) une valeur de ");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(valueTotal);
                    Console.ResetColor();
                    Console.WriteLine();
                    #endregion

                        if (i == 0) //Si tour du Joueur
                        {
                            Console.WriteLine("Nous regardons si les joueurs ont des cartes qui doivent être activées\n");
                            currentPlayers.CheckCardToActivate(valueDice);
                            Console.WriteLine("Quel carte souhaitez-vous acheter ? \n");
                            currentPlayers.BuyCard();
                        }
                        else //Si tour de(s) l'ordinateur(s)
                        {
                            Console.WriteLine("L'Ordinateur a joué");
                            currentPlayers.CheckCardToActivate(valueDice);
                            currentPlayers.BuyCard();
                        }

                        #region Détermination du gagnant (s'il y en a un)
                    isInLoop = WhoWins(currentPlayer);
                    if (!isInLoop)
                        winningPlayer = currentPlayer.name;
                    #endregion
                    }
                    else //Une partie multijoueur
                    {
                        #region Données du joueur
                    currentPlayer = players[i];
                    Console.Write("\n\nC'est au tour de " + currentPlayer.name + " qui a un total de ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(currentPlayer.nbPiece);
                    Console.ResetColor();
                    Console.WriteLine(" pièces !");
                    #endregion

                    #region Données des dés
                    //Choix nombre de dés
                    int errorTryCatch = 0;
                    do
                    {
                        Console.WriteLine("\nAvec combien de dé voulez vous jouer\n");
                        Console.WriteLine("1 -- Avec un dé !");
                        Console.WriteLine("2 -- Avec deux dés !");
                        string DoubleDe = Console.ReadLine();

                        switch (DoubleDe)
                        {
                            case "1":
                                doubleDe = false;
                                errorTryCatch = 0;
                                break;
                            case "2":
                                doubleDe = true;
                                errorTryCatch = 0;
                                break;
                            default:
                                Console.WriteLine("Veuillez choisir une valeur valide (1 ou 2)");
                                errorTryCatch = 1;
                                break;
                        }
                    } while (errorTryCatch == 1);

                    //Valeur totale des dés lancés
                    int valueTotal = this.playDice.activeValueOfDice;
                    if(doubleDe)
						valueTotal += this.playDice.activeValueOfSecondDice;

                    //Affichage valeur finale des dés
                    Console.Write("Le(s) dé(s) affiche(nt) une valeur de ");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(valueTotal);
                    Console.ResetColor();
                    Console.WriteLine();
                    #endregion

                        Console.WriteLine("Nous regardons si les joueurs ont des cartes qui doivent être activées\n");
                        currentPlayers.CheckCardToActivate(valueDice);
                        Console.WriteLine("Quel carte souhaitez-vous acheter ? \n");
                        currentPlayers.BuyCard();

                        #region Détermination du gagnant (s'il y en a un)
                    isInLoop = WhoWins(currentPlayer);
                    if (!isInLoop)
                        winningPlayer = currentPlayer.name;
                    #endregion
                    }
                }
                

                    
                Console.Clear();

            }

            #region Affichage du gagnant
            Console.Write("Bravo au grand maire ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Program.AffichageCharParChar(winningPlayer, 0.25f);
            Console.ResetColor();
            Console.WriteLine();
            Program.Wait(0.5f);
            Console.WriteLine("Suite à l'étalage de sa puissance, le vieux maire de Miniville lui a laissé sa place.");
            Program.Wait(0.3f);
            Console.WriteLine("Le nouveau maire " + winningPlayer + " a décidé de renommer la ville : ");
            string nameNewTown = Console.ReadLine();
            Console.WriteLine("Bienvenue à " + nameNewTown + ", ville créée par le grand " + winningPlayer);
            Program.Wait(0.3f);
            Console.WriteLine("Depuis que le nouveau maire a renommé la ville, le taux de criminalité a fortement baissé, les petits vieux ne se sentent plus menacés.");
            Console.WriteLine("A vrai dire, c'est devenu le parfait opposé de l'ancienne ville, les petits vieux se mettent à attaquer les jeunes et à les humilier publiquement");
            #endregion

        }

        //Retourne vrai si le currentPlayer a gagné la partie (selon les conditions de victoire déterminées par la difficulté
        private bool WhoWins(Player currentPlayer)
        {
            bool isInLoop = true;
            if (currentPlayer.nbPiece >= this.nbPieceVictory)
            {
                if (expertMode)
                {
                    //Retourne le nombre restant dans la main du joueur de chaque type de carte (si elles y sont toutes, le joueur gagne le mode expert) 
                    var amountWheatFields = currentPlayer.playerCardList.Where(x => x is WheatFieldCard).ToList();
                    var amountFarms = currentPlayer.playerCardList.Where(x => x is FarmCard).ToList();
                    var amountBakeries = currentPlayer.playerCardList.Where(x => x is BakeryCard).ToList();
                    var amountCoffees = currentPlayer.playerCardList.Where(x => x is CoffeeCard).ToList();
                    var amountMiniMarkets = currentPlayer.playerCardList.Where(x => x is MiniMarketCard).ToList();
                    var amountForests = currentPlayer.playerCardList.Where(x => x is ForestCard).ToList();
                    var amountRestaurants = currentPlayer.playerCardList.Where(x => x is RestaurantCard).ToList();
                    var amountStadiums = currentPlayer.playerCardList.Where(x => x is StadiumCard).ToList();
                    var amountCheeseFactories = currentPlayer.playerCardList.Where(x => x is CheeseFactoryCard).ToList();
                    var amountFurnitureFactories = currentPlayer.playerCardList.Where(x => x is FurnitureFactoryCard).ToList();
                    var amountMines = currentPlayer.playerCardList.Where(x => x is MineCard).ToList();
                    var amountOrchards = currentPlayer.playerCardList.Where(x => x is OrchardCard).ToList();
                    var amountMarkets = currentPlayer.playerCardList.Where(x => x is MarketCard).ToList();

                    if (amountWheatFields.Count * amountFarms.Count * amountBakeries.Count * amountCoffees.Count * amountMiniMarkets.Count *
                        amountForests.Count * amountRestaurants.Count * amountStadiums.Count * amountCheeseFactories.Count *
                        amountFurnitureFactories.Count * amountMines.Count * amountOrchards.Count * amountMarkets.Count > 0)
                        isInLoop = false;

                }
                else
                    isInLoop = false;
            }
            return isInLoop;
        }
        #endregion

    }
}
