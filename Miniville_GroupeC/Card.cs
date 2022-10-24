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

    public abstract class MasterCard
    {
        public string name;
        public int activationValue;
        public int costValue;
        public CardColor cardColor;
        public Player playerOwner;
        public MasterCard(int activationValue, CardColor cardColor, string name, int costValue)
        {
            this.name = name;
            this.activationValue = activationValue;
            this.costValue = costValue;
            this.cardColor = cardColor;
        }

        public abstract void OnDiceResult(int diceResult, Player playerWhosPlaying);

        public void SetPlayerOwner(Player owner)
        {
            playerOwner = owner;
        }
    }


    public class WheatFieldCard : MasterCard
    {
        public WheatFieldCard() : base(1, CardColor.BLUE, "Champs de blé", 1)
        {

        }

        public override void OnDiceResult(int diceResult, Player playerWhosPlaying)
        {
            if(diceResult == activationValue)
            {
                //currentPlayer.nbPiece ++;
            }
        }

    }

    public class FarmCard : MasterCard
    {
        public FarmCard() : base(1, CardColor.BLUE, "Ferme", 2)
        {

        }

        public override void OnDiceResult(int diceResult, Player playerWhosPlaying)
        {
            if(diceResult == activationValue)
            {
                //currentPlayer.nbPiece ++;
            }
        }
    }

    public class BakeryCard : MasterCard
    {
        public BakeryCard() : base (2,CardColor.GREEN,"Boulangerie", 1)
        {

        }

        public override void OnDiceResult(int diceResult, Player playerWhosPlaying)
        {
            if(playerOwner == playerWhosPlaying && diceResult == activationValue)
            {
                //currentPlayer.nbPlayer+=1;
            }
        }
    }

    public class MiniMarketCard : MasterCard
    {
        public MiniMarketCard() : base (4,CardColor.GREEN, "Superette",2)
        {

        }

        public override void OnDiceResult(int diceResult, Player playerWhosPlaying)
        {
            if(playerOwner == playerWhosPlaying && diceResult == activationValue)
            {
                //currentPlayer.nbPiece+=3;
            }
        }
    }

    public class Forest : MasterCard
    {
        public Forest() : base(5, CardColor.BLUE, "Forêt", 2)
        {

        }

        public override void OnDiceResult(int diceResult, Player playerWhosPlaying)
        {
            if(diceResult == activationValue)
            {
                //playerOwner.nbPiece++
            }
        }
    }

    public class Restaurant : MasterCard
    {

        public Restaurant() : base(5, CardColor.RED, "Restaurant", 4)
        {

        }
        public override void OnDiceResult(int diceResult, Player playerWhosPlaying)
        {
            if(diceResult == activationValue && playerOwner != playerWhosPlaying)
            {
                //playerWhosPlaying -= 2;
                //playerOwner.nbPiece+= 2;
            }
        }

        public class Stadium : MasterCard
        {
            public Stadium() : base(6, CardColor.BLUE, "Stade", 6)
            {

            }

            public override void OnDiceResult(int diceResult, Player playerWhosPlaying)
            {
                if(diceResult == activationValue)
                {
                    //playerOwner += 4
                }
            }
        }
    }

}
