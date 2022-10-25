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
            if (diceResult == activationValue)
            {
                playerOwner.nbPiece++;
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
            if (diceResult == activationValue)
            {
                playerOwner.nbPiece++;
            }
        }
    }

    public class BakeryCard : MasterCard
    {
        public BakeryCard() : base(2, CardColor.GREEN, "Boulangerie", 1)
        {

        }

        public override void OnDiceResult(int diceResult, Player playerWhosPlaying)
        {
            if (playerOwner == playerWhosPlaying && diceResult == activationValue)
            {
                playerOwner.nbPiece += 2;
            }
        }
    }

    public class CafeCard : MasterCard
    {
        public CafeCard() : base(3, CardColor.RED, "Café", 2)
        {

        }

        public override void OnDiceResult(int diceResult, Player playerWhosPlaying)
        {
            if (diceResult == activationValue)
            {
                playerOwner.nbPiece++;
                playerWhosPlaying.nbPiece--;
            }
        }
    }

    public class MiniMarketCard : MasterCard
    {
        public MiniMarketCard() : base(4, CardColor.GREEN, "Superette", 2)
        {

        }

        public override void OnDiceResult(int diceResult, Player playerWhosPlaying)
        {
            if (playerOwner == playerWhosPlaying && diceResult == activationValue)
            {
                playerOwner.nbPiece += 3;
            }
        }
    }

    public class ForestCard : MasterCard
    {
        public ForestCard() : base(5, CardColor.BLUE, "Forêt", 2)
        {

        }

        public override void OnDiceResult(int diceResult, Player playerWhosPlaying)
        {
            if (diceResult == activationValue)
            {
                playerOwner.nbPiece++;
            }
        }
    }

    public class RestaurantCard : MasterCard
    {
        public RestaurantCard() : base(5, CardColor.RED, "Restaurant", 4)
        {

        }

        public override void OnDiceResult(int diceResult, Player playerWhosPlaying)
        {
            if (diceResult == activationValue)
            {
                playerWhosPlaying.nbPiece -= 2;
                playerOwner.nbPiece += 2;
            }
        }

    }

    public class StadiumCard : MasterCard
    {
        public StadiumCard() : base(6, CardColor.BLUE, "Stade", 6)
        {

        }

        public override void OnDiceResult(int diceResult, Player playerWhosPlaying)
        {
            if (diceResult == activationValue)
            {
                playerOwner.nbPiece += 4;
            }
        }
    }
    public class FromagerieCard : MasterCard
    {
        public FromagerieCard() : base(7, CardColor.GREEN, "Fromagerie", 5)
        {

        }
        public override void OnDiceResult(int diceResult, Player playerWhosPlaying)
        {
            if (playerOwner == playerWhosPlaying && diceResult == activationValue)
            {
                playerOwner.nbPiece += 3;
            }
        }
    }

    public class FabriqueDeMeublesCard : MasterCard
    {
        public FabriqueDeMeublesCard() : base(8, CardColor.GREEN, "Fabrique de meubles", 3)
        {

        }
        public override void OnDiceResult(int diceResult, Player playerWhosPlaying)
        {
            if (playerOwner == playerWhosPlaying && diceResult == activationValue)
            {
                playerOwner.nbPiece += 3;
            }
        }
    }
    public class MineCard : MasterCard
    {
        public MineCard() : base(9, CardColor.BLUE, "Mine", 6)
        {

        }
        public override void OnDiceResult(int diceResult, Player playerWhosPlaying)
        {
            if (diceResult == activationValue)
            {
                playerOwner.nbPiece += 5;
            }
        }
    }
    public class Restaurant : MasterCard
    {
        public Restaurant() : base(9 | 10, CardColor.RED, "Restaurant", 3)
        {

        }
        public override void OnDiceResult(int diceResult, Player playerWhosPlaying)
        {
            if (diceResult == activationValue)
            {
                playerOwner.nbPiece += 2;
                playerWhosPlaying.nbPiece -= 2;
            }
        }
    }
    public class Verger : MasterCard
    {
        public Verger() : base(10, CardColor.BLUE, "Verger", 3)
        {

        }

        public override void OnDiceResult(int diceResult, Player playerWhosPlaying)
        {
            if (diceResult == activationValue)
            {
                playerOwner.nbPiece += 3;
            }
        }
    }
    public class Marche : MasterCard
    {
        public Marche() : base(11 | 12, CardColor.GREEN, "Marche de fruits et légumes", 2)
        {

        }
        public override void OnDiceResult(int diceResult, Player playerWhosPlaying)
        {
            if (playerOwner == playerWhosPlaying && diceResult == activationValue)
            {
                playerOwner.nbPiece += 2;
            }
        }
    }
}
