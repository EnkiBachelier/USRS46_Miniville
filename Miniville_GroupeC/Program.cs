using System;
using System.Collections.Generic;
using System.Text;

namespace Miniville_GroupeC
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Déclaration des variables
            Dice playDice = new Dice();
            List<string> namePlayers = new List<string>();
            int nbMayors = 0;
            int errorTryCatch = 0;
            bool expertMode = false;
            int nbPiecesToWin = 0;

            #endregion

            #region Textes de lancement
            Console.WriteLine("Bienvenue dans Miniville !");
            Console.Write("Dans ce jeu, vous serez amené à devenir le maire le plus ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("INCROYABLE");
            Console.ResetColor();
            Console.WriteLine(" que cette région ait connu");
            Console.WriteLine("\nMais bien évidemment, certains essayeront de vous mettre des bâtons dans les pattes...");
            Console.Write("Etonnez-les avec votre ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("MAGNIFICIENCE");
            Console.ResetColor();
            Console.WriteLine(" et réduisez-les à l'état d'agents municipaux !\n\n");
            #endregion

            #region Données des maires
            do
            {
                //Nombres de maires
                try
                {
                    Console.Write("Combien de maires souhaitent jouer ? ");
                    nbMayors = int.Parse(Console.ReadLine());
                    errorTryCatch = 0;
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
                Console.Write("\nQuel est le nom du maire n°" + (i + 1) + "? ");
                string name = Console.ReadLine();
                namePlayers.Add(name);
            }
            #endregion

            #region Niveau de difficultés des parties
            do
            {
                Console.WriteLine("\nQuel est le niveau de difficulté avec lequel vous souhaitez jouer ?\n");
                Console.WriteLine("1 -- Partie rapide (10 pièces pour gagner)");
                Console.WriteLine("2 -- Partie standard (20 pièces pour gagner)");
                Console.WriteLine("3 -- Partie longue (30 pièces pour gagner)");
                Console.WriteLine("4 -- Partie experte (20 pièces et un exemplaire de chaque carte pour gagner)\n");

                string difficulty = Console.ReadLine();

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
                        errorTryCatch = 0 ;
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
            } while(errorTryCatch == 1);
            #endregion

            #region Lancement du jeu
            Game theGame = new Game(playDice, nbPiecesToWin, namePlayers, expertMode);
            theGame.GameLoop();
            #endregion
        }
    }
}
