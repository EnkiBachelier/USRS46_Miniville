using System;
using System.Collections.Generic;
using System.Text;

namespace Miniville_GroupeC
{
    public class Dice
    {
        #region Déclaration des variables
        Random rdm = new Random();

        private int valueRandom => rdm.Next(1, 7);

        public int activeValueOfDice { get { return valueRandom; } }
        #endregion
    }
}
