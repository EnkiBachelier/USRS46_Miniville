using System;

namespace Miniville_GroupeC
{
    public class Dice
    {
<<<<<<< Updated upstream
=======
        #region Déclaration des variables et propriétés
<<<<<<< Updated upstream
        Random rdm = new Random();
		
=======
        Random rdm = new Random(); //Pour le choix random du dé

>>>>>>> Stashed changes
        //A chaque fois que l'utilisateur va chercher à lire la valeur d'un dé (le premier ou le second), on va lui renvoyer une valeur aléatoire entre 1 et 6
        public int activeValueOfDice { get { return rdm.Next(1,7); } }
		public int activeValueOfSecondDice { get { return rdm.Next(1,7); } }
        #endregion
>>>>>>> Stashed changes
    }
}
