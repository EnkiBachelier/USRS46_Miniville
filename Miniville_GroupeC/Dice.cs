using System;

namespace Miniville_GroupeC
{
    public class Dice
    {
        #region Déclaration des variables
        private Random rdmDiceValue = new Random();
        #endregion

        #region Propriétés
        //A chaque fois que l'utilisateur va chercher à lire la valeur d'un dé (le premier ou le second), on va lui renvoyer une valeur aléatoire entre 1 et 6
        public int activeValueOfDice { get { return rdmDiceValue.Next(1, 7); } }
        public int activeValueOfSecondDice { get { return rdmDiceValue.Next(1, 7); } }
        #endregion
    }
}
