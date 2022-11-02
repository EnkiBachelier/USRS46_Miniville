using System;
using System.Collections.Generic;
using System.Linq;


namespace Miniville_GroupeC
{
    public class Game
    {
        #region Déclaration des variables
        public int nbPieceVictory;
        public Player currentPlayer;
        public Dice playDice;
        public Pile playPile;
        public List<string> namePlayers = new List<string>();
        public List<Player> playersInGame = new List<Player>();
        public static bool hasShoppingCentre = false;
        private bool isExpertModeOn = false;
        private bool isDoubleDeActive = false;
        private bool isMultiplayerOn = false;
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
            this.playPile = new Pile(this.namePlayers.Count);

            for (int i = 0; i < namePlayers.Count; i++)
            {
                //Cartes de départ des joueurs
                WheatFieldCard initialWheatFieldCard = new WheatFieldCard();
                BakeryCard initialBakeryCard = new BakeryCard();
                List<MasterCard> initialCards = new List<MasterCard>()
                {
                    initialWheatFieldCard,
                    initialBakeryCard
                };
                string thatName = namePlayers[i];
                bool isItAnAI = false;

                //Partie en multijoueur (Pas d'IA)
                if (this.isMultiplayerOn)
                {
                    isItAnAI = false;
                    Player thatPlayer = new Player(3, initialCards, this, thatName, this.playPile, isItAnAI);
                    initialWheatFieldCard.SetPlayerOwner(thatPlayer);
                    initialBakeryCard.SetPlayerOwner(thatPlayer);
                    playersInGame.Add(thatPlayer);
                }
                //Partie contre les IA
                else
                {
                    //Si ce n'est pas le joueur humain
                    if (i != 0)
                        isItAnAI = true;
                    Player thatPlayer = new Player(3, initialCards, this, thatName, this.playPile, isItAnAI);
                    initialWheatFieldCard.SetPlayerOwner(thatPlayer);
                    initialBakeryCard.SetPlayerOwner(thatPlayer);
                    playersInGame.Add(thatPlayer);
                }
            }
        }
        #endregion

        #region Méthodes
        //Effectue la boucle de jeu en affichant les données du joueur et du dé, en vérifiant si des cartes doivent être activées et en demandant si le joueur souhaite acheter une carte
        //Vérifie également la condition de fin et affiche le gagnant
        public void GameLoop()
        {
            bool hasNotAWinner = true;
            string winningPlayer = "";
            bool needsToSkip = false;
            int playerWhoSkipped = 0;

            while (hasNotAWinner)
            {
                //On fait une boucle en parcourant chaque joueur du jeu
                for (int i = 0; i < playersInGame.Count; i++)
                {
                    #region Données du joueur
                    //Si le joueur a un AmusementParcCard et fait un double, on recommence la boucle mais en partant de lui cette fois-ci : cela mine l'effet de rejouer 
                    if (needsToSkip)
                    {
                        i = playerWhoSkipped;
                        needsToSkip = false;
                    }
                    currentPlayer = playersInGame[i];
                    Console.WriteLine("\n\nC'est au tour de " + currentPlayer.name + " !");
                    #endregion

                    #region Données des dés (& effet de la Gare)
                    //Choix nombre de dés
                    if (currentPlayer.isItAnAI)
                    {
                        isDoubleDeActive = true;
                    }
                    else
                    {
                        var TrainStationCard = currentPlayer.playerCardList.Where(x => x is TrainStationCard).ToList();
                        if (TrainStationCard.Count >= 1)
                        {
                            int errorTryCatch = 0;
                            do
                            {
                                Console.WriteLine("\nAvec combien de dé voulez-vous jouer\n");
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
                        valueDice2 = this.playDice.activeValueOfSecondDice;
                    
                    int valueTotal = valueDice1 + valueDice2;

                    Console.Write("Le(s) dé(s) affiche(nt) une valeur de ");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(valueTotal);
                    Console.ResetColor();
                    Console.WriteLine();
                    #endregion

                    #region Effets de la Tour Radio & et du Centre Commercial 
                    var RadioTowerCard = currentPlayer.playerCardList.Where(x => x is RadioTowerCard).ToList();
                    if (RadioTowerCard.Count >= 1)
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
                    var ShoppingCentreCard = currentPlayer.playerCardList.Where(x => x is ShoppingCentreCard).ToList();
                    if (ShoppingCentreCard.Count >= 1)
                    {
                        hasShoppingCentre = true;
                    }
                    #endregion

                    #region Activation des cartes, affichage des pièces & et achat des pièces
                    //Activation
                    Console.WriteLine("Nous regardons si les joueurs ont des cartes qui doivent être activées\n");
                    currentPlayer.CheckCardToActivate(valueTotal);

                    //Affichage des pièces du joueur
                    Console.Write("{0} possède ", currentPlayer.name);
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(currentPlayer.nbPiece);
                    Console.ResetColor();
                    Console.WriteLine(" pièce(s) !");

                    //Achat des cartes
                    if (!currentPlayer.isItAnAI)
                        Console.WriteLine("Quel carte souhaitez-vous acheter ? \n");
                    currentPlayer.BuyCard();
                    #endregion

                    #region Détermination du gagnant
                    hasNotAWinner = isThereAWinner(currentPlayer);
                    if (!hasNotAWinner)
                        winningPlayer = currentPlayer.name;
                    #endregion

                    #region Effets du Parc d'Attractions
                    var AmusementParcCard = currentPlayer.playerCardList.Where(x => x is AmusementParcCard).ToList();
                    if (AmusementParcCard.Count >= 1 && valueDice2 == valueDice1)
                    {
                        Console.WriteLine("{0} a fait un double et peut donc directement rejouer !\n", currentPlayer.name);
                        playerWhoSkipped = i;
                        needsToSkip = true;
                        break;
                    }
                    #endregion

                    #region Réinitialisation des variables
                    hasShoppingCentre = false;
                    #endregion
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

        //Retourne vrai si le currentPlayer a gagné la partie (selon les conditions de victoire déterminées par la difficulté)
        private bool isThereAWinner(Player currentPlayer)
        {
            bool hasNotAWinner = true;
            if (currentPlayer.nbPiece >= this.nbPieceVictory)
            {
                //Le mode expert se termine si un joueur possède 20 pièces et toutes les cartes (sauf monuments)
                if (isExpertModeOn)
                {
                    #region Nombre de chaque type de carte dans la main du joueur
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
                    #endregion

                    //Si le joueur a au moins une carte de chaque type
                    if (amountWheatFields.Count * amountFarms.Count * amountBakeries.Count * amountCoffees.Count * amountMiniMarkets.Count *
                        amountForests.Count * amountRestaurants.Count * amountStadiums.Count * amountCheeseFactories.Count *
                        amountFurnitureFactories.Count * amountMines.Count * amountOrchards.Count * amountMarkets.Count > 0)
                    {
                        hasNotAWinner = false;
                    }
                }
                //Le mode réel se termine si un joueur possède tous les monuments
                else if (isReelModeOn)
                {
                    #region Nombre de chaque type de monument dans la main du joueur
                    var amountRadioTowerCard = currentPlayer.playerCardList.Where(x => x is RadioTowerCard).ToList();
                    var amountTrainStationCard = currentPlayer.playerCardList.Where(x => x is TrainStationCard).ToList();
                    var amountAmusementParcCard = currentPlayer.playerCardList.Where(x => x is AmusementParcCard).ToList();
                    var amountShoppingCentreCard = currentPlayer.playerCardList.Where(x => x is ShoppingCentreCard).ToList();
                    #endregion

                    if (amountShoppingCentreCard.Count * amountTrainStationCard.Count * amountAmusementParcCard.Count * amountRadioTowerCard.Count > 0)
                        hasNotAWinner = false;
                }
                //Dans les autres modes de jeu, seuls le nombre de pièces détermine le gagnant
                else
                    hasNotAWinner = false;
            }
            return hasNotAWinner;
        }
        #endregion
    }
}
