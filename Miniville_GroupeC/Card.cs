using System;
using System.Collections.Generic;
using System.Text;

namespace Miniville_GroupeC
{
    public enum CardColor
    {
        RED,
        GREEN,
        BLUE
    }

    public class Card
    {
        public string name;
        public int activationValue;
        public int costValue;
        public CardColor cardColor;
        public Action action;
    }


}
