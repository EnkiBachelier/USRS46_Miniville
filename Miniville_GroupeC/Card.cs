﻿using System;
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

    public abstract class MasterCard
    {
        public string name;
        public int activationValue;
        public int costValue;
        public CardColor cardColor;

        public MasterCard(int activationValue, CardColor cardColor, string name, int costValue)
        {
            this.name = name;
            this.activationValue = activationValue;
            this.costValue = costValue;
            this.cardColor = cardColor;
        }

        public abstract void OnDiceResult(int diceResult, Player currentPlayer, Player playerWhosPlaying);
    }


    public class FarmCard : MasterCard
    {
        public FarmCard() : base(1, CardColor.BLUE, "Champs de blé", 1)
        {

        }

        public override void OnDiceResult(int diceResult, Player currentPlayer, Player playerWhosPlaying)
        {
            if(diceResult == activationValue)
            {
                //currentPlayer.nbPiece ++;
            }
        }

    }

}
