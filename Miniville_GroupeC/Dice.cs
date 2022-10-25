using System;
using System.Collections.Generic;
using System.Text;

namespace Miniville_GroupeC
{
    public class Dice
    {
        Random rdm = new Random();
        private int Dices => rdm.Next(1, 7);
        private int Dices2 => rdm.Next(1, 7);

        public int De { get { return Dices; } }
        public int De2 { get { return Dices2; } }
    }
}
