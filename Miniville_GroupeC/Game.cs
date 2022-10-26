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
        private bool expertMode;
        private bool reelMode;
        public Pile pile;
        public static bool hasCentreCommercial = false;

        #endregion

        #region Constructeur
        public Game(Dice playDice, int nbPieceVictory, List<string> namePlayers, bool expertMode = false, bool reelMode = false)
        {
            this.playDice = playDice;
            this.nbPieceVictory = nbPieceVictory;
            this.expertMode = expertMode;
            this.reelMode = reelMode;
            this.namePlayers = namePlayers;
            pile = new Pile();

            //On initialise chaque joueur avec une boulangerie et un champ de blé ainsi que 3 pièces
            foreach (string thatName in namePlayers)
            {
                MasterCard cardIniWheatField = new WheatFieldCard();
                MasterCard cardIniBakery = new BakeryCard();
                this.initialCards = new List<MasterCard>()
                {
                    cardIniWheatField,
                    cardIniBakery
                };
                Player thatPlayer = new Player(3, this.initialCards, this, thatName, this.pile);

                //On associe les cartes au joueur
                cardIniWheatField.SetPlayerOwner(thatPlayer);
                cardIniBakery.SetPlayerOwner(thatPlayer);
                players.Add(thatPlayer);
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
                    //Données du joueur et du dé
                    currentPlayer = players[i];
                    Console.Write("\n\nC'est au tour de " + currentPlayer.name + " qui a un total de ");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write(currentPlayer.nbPiece);
                    Console.ResetColor();
                    Console.WriteLine(" pièces !");

					int valueDice1 = this.playDice.activeValueOfDice;
                    int valueDice2 =0;
                    var GareCard = currentPlayer.playerCardList.Where(x => x is GareCard).ToList();
                    if (GareCard.Count >= 1)
                    {
                        valueDice2 = this.playDice.activeValueOfSecondDice;
                    }
                        
                    int valueTotal = valueDice1 + valueDice2;

                    Console.Write("Le(s) dé(s) affiche(nt) une valeur de ");
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    Console.Write(valueTotal);
                    Console.ResetColor();
                    Console.WriteLine();               

                    var TourRadioCard = currentPlayer.playerCardList.Where(x => x is TourRadioCard).ToList();
                    if(TourRadioCard.Count >= 1)
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
                    
                    //Activation de cartes et achats
                    Console.WriteLine("Nous regardons si les joueurs ont des cartes qui doivent être activées\n");
                    currentPlayer.CheckCardToActivate(valueTotal);
                    Console.WriteLine("Quel carte souhaitez-vous acheter ? \n");
                    currentPlayer.BuyCard();
                    hasCentreCommercial = false;
                    //Conditions de victoires
                    if (currentPlayer.nbPiece >= this.nbPieceVictory)
                    {
                        if (reelMode)
                        {
                            var amountTourRadioCard = currentPlayer.playerCardList.Where(x => x is TourRadioCard).ToList();
                            var amountGareCard = currentPlayer.playerCardList.Where(x => x is GareCard).ToList();
                            var amountParcAttractionsCard = currentPlayer.playerCardList.Where(x => x is ParcAttractionsCard).ToList();
                            var amountCentreCommercialCard = currentPlayer.playerCardList.Where(x => x is CentreCommercialCard).ToList();
                            if(amountCentreCommercialCard.Count * amountGareCard.Count * amountParcAttractionsCard.Count * amountTourRadioCard.Count > 0)
                            {
                                winningPlayer = currentPlayer.name;
                                isInLoop = false;
                                break;
                            }
                        }
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
                            {
                                winningPlayer = currentPlayer.name;
                                isInLoop = false;
                                break;

                            }
                        }
                        else
                        {
                            winningPlayer = currentPlayer.name;
                            isInLoop = false;
                            break;
                        }
                    }
                    var ParcAttractionsCard = currentPlayer.playerCardList.Where(x => x is ParcAttractionsCard).ToList(); 
                    if (ParcAttractionsCard.Count >= 1 && valueDice2 == valueDice1)
                    {
                        break;
                    }
                }
                Console.Clear();
            }

            //Affichage du gagnant
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


        }

        #endregion

    }
}
