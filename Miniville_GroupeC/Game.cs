using System;
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
        private bool isExpertModeOn;
        private bool isDoubleDeActive;
        public Pile pile;
        private bool isMultiplayerOn = false;
        public static bool hasCentreCommercial = false;
        private bool isReelModeOn;
        #endregion

        #region Constructeur
        public Game(Dice playDice, int nbPieceVictory, List<string> namePlayers, bool isExpertModeOn = false, bool isMultiplayerOn = false, bool isReelModeOn = false)
        {
            this.playDice = playDice;
            this.nbPieceVictory = nbPieceVictory;
            this.isExpertModeOn = isExpertModeOn;
            this.isReelModeOn = isReelModeOn;
            this.namePlayers = namePlayers;
            this.isMultiplayerOn = isMultiplayerOn;
            pile = new Pile(this.namePlayers.Count);

            for (int i = 0; i < namePlayers.Count; i++)
            {
                string thatName = namePlayers[i];
                bool isItAnAI = false;

                //Contre l'ordinateur
                if (!this.isMultiplayerOn)
                {
                    MasterCard cardCham = new WheatFieldCard();
                    MasterCard cardBak = new BakeryCard();
                    this.initialCards = new List<MasterCard>()
                    {
                        cardCham,
                        cardBak
                    };
                    //Si ce n'est pas le joueur
                    if (i != 0)
                        isItAnAI = true;

                    Player thatPlayer = new Player(3, this.initialCards, this, thatName, this.pile, isItAnAI);
                    cardCham.SetPlayerOwner(thatPlayer);
                    cardBak.SetPlayerOwner(thatPlayer);
                    players.Add(thatPlayer);
                }
                //Partie en multijoueur
                else
                {
                    isItAnAI = false;
                    MasterCard cardCham = new WheatFieldCard();
                    MasterCard cardBak = new BakeryCard();
                    this.initialCards = new List<MasterCard>()
                    {
                        cardCham,
                        cardBak
                    };
                    Player thatPlayer = new Player(3, this.initialCards, this, thatName, this.pile, isItAnAI);
                    cardCham.SetPlayerOwner(thatPlayer);
                    cardBak.SetPlayerOwner(thatPlayer);
                    players.Add(thatPlayer);
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
            bool needsToSkip = false;
            int playerWhoSkipped = 0;

            while (isInLoop)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    #region Données du joueur
                    if (needsToSkip)
                    {
                        i = playerWhoSkipped;
                        needsToSkip = false;
                    }
                    currentPlayer = players[i];
                    Console.WriteLine("\n\nC'est au tour de " + currentPlayer.name + " !");
                    #endregion

                    #region Données des dés
                    //Choix nombre de dés
                    if (currentPlayer.isItAnAI)
                    {
                        isDoubleDeActive = true;
                    }
                    else
                    {
                        var GareCard = currentPlayer.playerCardList.Where(x => x is GareCard).ToList();
                        if (GareCard.Count >= 1)
                        {
                            int errorTryCatch = 0;
                            do
                            {
                                Console.WriteLine("\nAvec combien de dé voulez vous jouer\n");
                                Console.WriteLine("1 -- Avec un dé !");
                                Console.WriteLine("2 -- Avec deux dés !");
                                string responseDoubleDe = Console.ReadLine();

                                switch (responseDoubleDe)
                                {
                                    case "1":
                                        isDoubleDeActive = false;
                                        errorTryCatch = 0;
                                        break;
                                    case "2":
                                        isDoubleDeActive = true;
                                        errorTryCatch = 0;
                                        break;
                                    default:
                                        Console.WriteLine("Veuillez choisir une valeur valide (1 ou 2)");
                                        errorTryCatch = 1;
                                        break;
                                }
                            } while (errorTryCatch == 1);
                        }
                    }

                    //Affichage valeur finale des dés
                    int valueDice1 = this.playDice.activeValueOfDice;
                    int valueDice2 = 0;
                    if (isDoubleDeActive)
                    {
                        valueDice2 = this.playDice.activeValueOfSecondDice;
                    }

                    int valueTotal = valueDice1 + valueDice2;

                    Console.Write("Le(s) dé(s) affiche(nt) une valeur de ");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(valueTotal);
                    Console.ResetColor();
                    Console.WriteLine();
                    #endregion

                    #region Activation et Achats
                    var TourRadioCard = currentPlayer.playerCardList.Where(x => x is TourRadioCard).ToList();
                    if (TourRadioCard.Count >= 1)
                    {
                        Console.WriteLine("Voulez-vous relancer les dés ?\n");
                        Console.WriteLine("o -- Oui");
                        Console.WriteLine("n -- Non");
                        string tourRadio = Console.ReadLine();
                        if (tourRadio == "o")
                        {
                            valueDice1 = this.playDice.activeValueOfDice;

                            valueDice2 = this.playDice.activeValueOfSecondDice;
                            valueTotal = valueDice1 + valueDice2;

                            Console.Write("Le(s) dé(s) affiche(nt) une valeur de ");
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.Write(valueTotal);
                            Console.ResetColor();
                            Console.WriteLine();

                        }
                    }
                    var CentreCommercialCard = currentPlayer.playerCardList.Where(x => x is CentreCommercialCard).ToList();
                    if (CentreCommercialCard.Count >= 1)
                    {
                        hasCentreCommercial = true;
                    }

                    Console.WriteLine("Nous regardons si les joueurs ont des cartes qui doivent être activées\n");
                    currentPlayer.CheckCardToActivate(valueTotal);
                    Console.Write("{0} possède ", currentPlayer.name);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(currentPlayer.nbPiece);
                    Console.ResetColor();
                    Console.WriteLine(" pièce(s) !");
                    if (!currentPlayer.isItAnAI)
                        Console.WriteLine("Quel carte souhaitez-vous acheter ? \n");
                    currentPlayer.BuyCard();
                    #endregion

                    #region Détermination du gagnant (s'il y en a un)
                    isInLoop = WhoWins(currentPlayer);
                    if (!isInLoop)
                        winningPlayer = currentPlayer.name;
                    #endregion

                    hasCentreCommercial = false;

                    var ParcAttractionsCard = currentPlayer.playerCardList.Where(x => x is ParcAttractionsCard).ToList();
                    if (ParcAttractionsCard.Count >= 1 && valueDice2 == valueDice1)
                    {
                        Console.WriteLine("{0} a fait un double et peut donc directement rejouer !\n", currentPlayer.name);
                        playerWhoSkipped = i;
                        needsToSkip = true;
                        break;
                    }
                }
                #region Nettoyer la console à chaque nouveau tour
                Console.Write("\n\n(Presser une touche pour continuer)");
                Console.ReadKey();
                Console.Clear();
                #endregion
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
                if (isExpertModeOn)
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
                else if (isReelModeOn)
                {
                    var amountTourRadioCard = currentPlayer.playerCardList.Where(x => x is TourRadioCard).ToList();
                    var amountGareCard = currentPlayer.playerCardList.Where(x => x is GareCard).ToList();
                    var amountParcAttractionsCard = currentPlayer.playerCardList.Where(x => x is ParcAttractionsCard).ToList();
                    var amountCentreCommercialCard = currentPlayer.playerCardList.Where(x => x is CentreCommercialCard).ToList();
                    if (amountCentreCommercialCard.Count * amountGareCard.Count * amountParcAttractionsCard.Count * amountTourRadioCard.Count > 0)
                    {
                        isInLoop = false;
                    }
                }
                else
                {
                    isInLoop = false;
                }

            }
            return isInLoop;
        }
        #endregion
    }
}
