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
        public Action onDiceResults;

        public Card(string name, int activationValue, int costValue, CardColor cardColor, Action onDiceResult)
        {
            this.name = name;
            this.activationValue = activationValue;
            this.costValue = costValue;
            this.cardColor = cardColor;
            this.onDiceResults = onDiceResult;
        }

    }


}
