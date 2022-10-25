using System;
using System.Collections.Generic;
using System.Text;

namespace Miniville_GroupeC
{
    class Program
    {
        static void Main(string[] args)
        {

            Dice playDice = new Dice();
            List<string> namePlayers = new List<string>();

            Console.WriteLine("Bienvenue dans Miniville !");
            int nbMayors = 0;
            int errorTryCatch = 0;
            do
            {
                try
                {
                    Console.Write("Avec combien de maires souhaitez-vous jouer ? ");
                    nbMayors = int.Parse(Console.ReadLine());
                    errorTryCatch = 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Veuillez entrer un numéro valide");
                    errorTryCatch = 1;
                }

            } while (errorTryCatch == 1);

            for (int i = 0; i < nbMayors; i++)
            {
                Console.Write("\nQuel est le nom du maire n°" + (i + 1) + "? ");
                string name = Console.ReadLine();
                namePlayers.Add(name);
            }

            Console.WriteLine("\nQuel est le niveau de difficulté avec lequel vous souhaitez jouer ?\n");
            Console.WriteLine("1 -- Partie rapide (10 pièces pour gagner)");
            Console.WriteLine("2 -- Partie standard (20 pièces pour gagner)");
            Console.WriteLine("3 -- Partie longue (30 pièces pour gagner)");
            Console.WriteLine("4 -- Partie experte (20 pièces et un exemplaire de chaque carte pour gagner)\n");

            string difficulty = Console.ReadLine();

            int nbPiecesToWin = 0;
            bool expertMode = false;
            switch (difficulty)
            {
                case "1":
                    nbPiecesToWin = 10;
                    break;
                case "2":
                    nbPiecesToWin = 20;
                    break;
                case "3":
                    nbPiecesToWin = 30;
                    break;
                case "4":
                    nbPiecesToWin = 20;
                    expertMode = true;
                    break;


            }

            Game theGame = new Game(playDice, nbPiecesToWin, namePlayers, expertMode);
            theGame.GameLoop();
        }
    }
}
