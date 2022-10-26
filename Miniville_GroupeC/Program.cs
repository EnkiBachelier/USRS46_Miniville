using System;
<<<<<<< Updated upstream
=======
using System.Collections.Generic;
<<<<<<< HEAD
using System.Security.Cryptography.X509Certificates;
using System.Text;
=======
using System.Threading.Tasks;
>>>>>>> d4242d8a9ae8bdd291db9d872e14168785ae6dd8
>>>>>>> Stashed changes

namespace Miniville_GroupeC
{
    class Program
    {
        static void Main(string[] args)
        {
<<<<<<< Updated upstream
            Console.WriteLine("Hello World!");
=======
            #region Déclaration des variables
            Dice playDice = new Dice();
            List<string> namePlayers = new List<string>();
<<<<<<< HEAD

            Console.WriteLine("Bienvenue dans Miniville !");

            bool Multiplayer = false;
            int errorMulti = 0;
            string ModePlay = "";
            
            do
            {
                Console.WriteLine("Veiller choisir un mode de jeu");
                Console.WriteLine("1 - MultiJoueur");
                Console.WriteLine("2 - Contre l'Ordinateur\n");

                ModePlay = Console.ReadLine();

                if(ModePlay == "1")
                {
                    errorMulti = 1;
                    Multiplayer = true;
                    Console.WriteLine("Vous avez selectionner le mode multijoueur !\n");
                }
                else if (ModePlay == "2")
                {
                    errorMulti = 1;
                    Multiplayer = false;
                    Console.WriteLine("Vous avez selectionner le mode contre l'ordinateur !\n");
                }
                else 
                {
                    errorMulti = 0;
                    Console.WriteLine("Veiller noter une entrée valide...\n");
                }
                    
            
            } while(errorMulti == 0);




=======
>>>>>>> d4242d8a9ae8bdd291db9d872e14168785ae6dd8
            int nbMayors = 0;
            int errorTryCatch = 0;
            bool expertMode = false;
            int nbPiecesToWin = 0;
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

            #region Données des maires
            do
            {
                //Nombres de maires
                try
                {
<<<<<<< HEAD
                    if(Multiplayer == false) // Mode contre l'ordi
                    {
                        Console.Write("Avec combien d'ordinateur souhaitez-vous jouer ? ");
                        nbMayors = int.Parse(Console.ReadLine()) + 1; //on rajoute 1 car on ne compte pas ici le joueur mais seulement les IAs
                        errorTryCatch = 0;
                    }
                    else // mode multijoueur
                    {
                        Console.Write("Combien de personne souhaite jouer ? ");
                        nbMayors = int.Parse(Console.ReadLine());
                        errorTryCatch = 0;
                    }

=======
                    Console.Write("Combien de maires souhaitent jouer ? ");
                    nbMayors = int.Parse(Console.ReadLine());
                    errorTryCatch = 0;
>>>>>>> d4242d8a9ae8bdd291db9d872e14168785ae6dd8
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
                if(Multiplayer == false) //Si mode de jeu contre l'ordi
                {
                    if(i == 0)
                    {
                        Console.Write("\nQuel est votre nom ?");
                        string name = Console.ReadLine();
                        namePlayers.Add(name);
                    }
                    else
                    {
                        Console.Write("\nQuel est le nom du l'ordinateur n°" + (i + 1) + "? ");
                        string name = Console.ReadLine();
                        namePlayers.Add(name);
                    }
                }
                else // si mode de jeu multijoueur
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
                Console.WriteLine("4 -- Partie experte (20 pièces et un exemplaire de chaque carte pour gagner)\n");
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
                        expertMode = true;
                        errorTryCatch = 0;
                        break;
                    default:
                        Console.WriteLine("Veuillez entrer un numéro valide");
                        errorTryCatch = 1;
                        break;
                }
            } while (errorTryCatch == 1);
            #endregion

<<<<<<< HEAD
            Game theGame = new Game(playDice, nbPiecesToWin, namePlayers, expertMode,Multiplayer);
=======
            #region Lancement du jeu
            Game theGame = new Game(playDice, nbPiecesToWin, namePlayers, expertMode);
>>>>>>> d4242d8a9ae8bdd291db9d872e14168785ae6dd8
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
>>>>>>> Stashed changes
        }
        #endregion
    }
}
