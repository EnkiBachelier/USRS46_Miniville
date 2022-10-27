using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Reflection;
using System.IO;
using System.Text.RegularExpressions;

namespace Miniville_GroupeC
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Déclaration des variables
            Dice playDice = new Dice();
            List<string> namePlayers = new List<string>();
            bool isMultiplayerOn = false;
            int errorMulti = 0;
            int nbMayors = 0;
            int errorTryCatch = 0;
            bool isExpertModeOn = false;
            bool isReelModeOn = false;
            int nbPiecesToWin = 0;
            Random rnd = new Random();
            string[] malePetNames = { "Rufus", "Bear", "Dakota", "Fido", "Vanya", "Samuel", "Koani", "Volodya", "Prince", "Yiska", "chicos", "chipie", "chiquita", "chouquette", "choupette", "azimut", "zazou", "zanzibar", "zebulon", "zephyr", "zigou", "zoupette", "volt", "dynamite", "mélo",
                                        "mélopée", "michette", "mistik", "moustakoamande", "caramel", "chocolat", "noisette", "pistache", "pralinébibi", "bidou", "biloute", "barjès", "batilou", "bernik", "cachou", "cambo", "capoune", "capri", "clown", "dino", "doli", "flip", "indi", "djimi", "litz", "loutz", "pat", "patouille", "pipette", "pirouette", "pitikok", "poulette", "slim"};
            #endregion

            #region Textes de lancement
            Console.WriteLine("                                         Bienvenue à MINIVILLE !!!");
            Wait(0.4f);
            Console.Write("\nDans ce jeu, vous serez amené à devenir le maire le plus ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            AffichageCharParChar("INCROYABLE", 0.2f);
            Console.ResetColor();
            Console.WriteLine(" que cette région ait connu.");
            Wait(0.4f);
            Console.WriteLine("Si vous arrivez à suffisamment séduire le vieux maire de Miniville, il vous laissera sa place (en échange d'une retraite payée par vos soins).");
            Console.WriteLine("En effet, le vieux maire ne contrôle plus Miniville, où désormais les jeunes font la loi et tapent les petits vieux.");
            Wait(0.4f);
            Console.WriteLine("\nMais bien évidemment, certains essayeront de vous mettre des bâtons dans les pattes...");
            Wait(0.4f);
            Console.Write("Etonnez-les avec votre ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            AffichageCharParChar("MAGNIFICIENCE", 0.25f);
            Console.ResetColor();
            Console.Write(" et réduisez-les à l'état d'");
            Console.ForegroundColor = ConsoleColor.Red;
            AffichageCharParChar("agents municipaux !", 0.25f);
            Console.ResetColor();
            Console.WriteLine("\n");
            #endregion

            #region Mode de jeu Multijoueur vs IA
            do
            {
                Console.WriteLine("Veuillez choisir un mode de jeu");
                Console.WriteLine("1 - Multijoueur");
                Console.WriteLine("2 - Contre l'Ordinateur\n");
                string modePlay = Console.ReadLine();

                if (modePlay == "1")
                {
                    errorMulti = 1;
                    isMultiplayerOn = true;
                    Console.WriteLine("Vous avez sélectionné le mode multijoueur !\n");
                }
                else if (modePlay == "2")
                {
                    errorMulti = 1;
                    isMultiplayerOn = false;
                    Console.WriteLine("Vous avez sélectionné le mode contre l'ordinateur !\n");
                }
                else
                {
                    errorMulti = 0;
                    Console.WriteLine("Veuillez choisir une entrée valide...\n");
                }
            } while (errorMulti == 0);
            #endregion

            #region Données des maires
            do
            {
                //Nombres de maires
                try
                {
                    if (!isMultiplayerOn)
                    {
                        Console.Write("Avec combien d'ordinateurs maires souhaitez-vous jouer ? ");
                        nbMayors = int.Parse(Console.ReadLine()) + 1;                                   //+1 car on doit compter le joueur en plus
                        errorTryCatch = 0;
                    }
                    else
                    {
                        Console.Write("Combien de maires souhaitent jouer ? ");
                        nbMayors = int.Parse(Console.ReadLine());
                        errorTryCatch = 0;
                    }
                }
                catch
                {
                    Console.WriteLine("Veuillez entrer un numéro valide !");
                    errorTryCatch = 1;
                }
            } while (errorTryCatch == 1);

            //Noms des maires
            for (int i = 0; i < nbMayors; i++)
            {
                if (!isMultiplayerOn)
                {
                    //Le nom du joueur
                    if (i == 0)
                    {
                        Console.Write("\nQuel est votre nom ? ");
                        string name = Console.ReadLine();
                        namePlayers.Add(name);
                    }
                    //Les noms des ordinateurs
                    else
                    {
                        int mIndex = rnd.Next(malePetNames.Length);
                        string name = malePetNames[mIndex];
                        namePlayers.Add(name);
                        Console.Write("\nLe nom du maire ordinateur n°" + (i + 1)+" est {0}",name);
                    }
                }
                //Les noms de chaque joueur
                else
                {
                    Console.Write("\nQuel est le nom du maire n°" + (i + 1) + "? ");
                    string name = Console.ReadLine();
                    namePlayers.Add(name);
                }
            }
            #endregion

            #region Niveau de difficultés des parties
            do
            {
                errorTryCatch = 0;
                //Affichage des difficultés
                Console.WriteLine("\nQuel est le niveau de difficulté avec lequel vous souhaitez jouer ?\n");
                Console.WriteLine("1 -- Partie rapide (10 pièces pour gagner)");
                Console.WriteLine("2 -- Partie standard (20 pièces pour gagner)");
                Console.WriteLine("3 -- Partie longue (30 pièces pour gagner)");
                Console.WriteLine("4 -- Partie experte (20 pièces et un exemplaire de chaque carte pour gagner)");
                Console.WriteLine("5 -- Partie se rapprochant du vrai jeu\n");
                string difficulty = Console.ReadLine();

                //Calibre les conditions de victoire selon la difficulté
                switch (difficulty)
                {
                    case "1":
                        nbPiecesToWin = 10;
                        errorTryCatch = 0;
                        break;
                    case "2":
                        nbPiecesToWin = 20;
                        errorTryCatch = 0;
                        break;
                    case "3":
                        nbPiecesToWin = 30;
                        errorTryCatch = 0;
                        break;
                    case "4":
                        nbPiecesToWin = 20;
                        isExpertModeOn = true;
                        errorTryCatch = 0;
                        break;
                    case "5":
                        isReelModeOn = true;
                        errorTryCatch=0;
                        break;
                    default:
                        Console.WriteLine("Veuillez entrer un numéro valide");
                        errorTryCatch = 1;
                        break;
                }
            } while (errorTryCatch == 1);
            #endregion

            #region Lancement du jeu
            Game theGame = new Game(playDice, nbPiecesToWin, namePlayers, isExpertModeOn, isMultiplayerOn, isReelModeOn);
            theGame.GameLoop();
            #endregion
        }
        #region Méthodes
        //Marque une pause de n-secondes
        public static void Wait(float second)
        {
            Task Delay = Task.Delay(TimeSpan.FromSeconds(second));
            Delay.Wait();
        }

        //Affiche des char un par un avec un délai de n-secondes entre chaque
        public static void AffichageCharParChar(string message, float second)
        {
            foreach (char thatChar in message)
            {
                Console.Write(thatChar);
                Wait(0);
            }
        }
        #endregion
    }
}
