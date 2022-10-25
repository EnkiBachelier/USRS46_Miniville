using System;
using System.Collections.Generic;
using System.Text;

namespace Miniville_GroupeC
{
    #region Enum : CardColor
    public enum CardColor
    {
        RED,
        GREEN,
        BLUE
    }
    #endregion

    #region Class : Mastercard (Abstraite)
    public abstract class MasterCard
    {
        #region Déclaration des variables
        public string name;
        public int activationValue;
        public int costValue;
        public CardColor cardColor;
        public Player playerOwner;
        #endregion

        #region Constructeur
        public MasterCard(int activationValue, CardColor cardColor, string name, int costValue)
        {
            this.name = name;
            this.activationValue = activationValue;
            this.costValue = costValue;
            this.cardColor = cardColor;
        }
        #endregion

        #region Méthodes

        //Selon la valeur du dé, réalise l'effet de la carte
        public abstract void OnDiceResult(int diceResult, Player playerWhosPlaying);

        //Attribue à la carte son joueur
        public void SetPlayerOwner(Player owner)
        {
            playerOwner = owner;
        }
        #endregion
    }
    #endregion

    #region Class : WheatFieldCard (Dérivée de MasterCard)
    public class WheatFieldCard : MasterCard
    {
        public WheatFieldCard() : base(1, CardColor.BLUE, "Champs de blé", 1)
        {
        }

        public override void OnDiceResult(int diceResult, Player playerWhosPlaying)
        {
            if (diceResult == activationValue)
                playerOwner.nbPiece++;
        }
    }
    #endregion

    #region Class : FarmCard (Dérivée de MasterCard)
    public class FarmCard : MasterCard
    {
        public FarmCard() : base(1, CardColor.BLUE, "Ferme", 2)
        {
        }

        public override void OnDiceResult(int diceResult, Player playerWhosPlaying)
        {
            if (diceResult == activationValue)
                playerOwner.nbPiece++;
        }
    }
    #endregion

    #region Class : BakeryCard (Dérivée de MasterCard)
    public class BakeryCard : MasterCard
    {
        public BakeryCard() : base(2, CardColor.GREEN, "Boulangerie", 1)
        {
        }

        public override void OnDiceResult(int diceResult, Player playerWhosPlaying)
        {
            if (playerOwner == playerWhosPlaying && diceResult == activationValue)
                playerOwner.nbPiece += 2;
        }
    }
    #endregion

    #region Class : CoffeeCard (Dérivée de MasterCard)
    public class CoffeeCard : MasterCard
    {
        public CoffeeCard() : base(3, CardColor.RED, "Café", 2)
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
    #endregion

    #region Class : MiniMarketCard (Dérivée de MasterCard)
    public class MiniMarketCard : MasterCard
    {
        public MiniMarketCard() : base(4, CardColor.GREEN, "Superette", 2)
        {
        }

        public override void OnDiceResult(int diceResult, Player playerWhosPlaying)
        {
            if (playerOwner == playerWhosPlaying && diceResult == activationValue)
                playerOwner.nbPiece += 3;
        }
    }
    #endregion

    #region Class : ForestCard (Dérivée de MasterCard)
    public class ForestCard : MasterCard
    {
        public ForestCard() : base(5, CardColor.BLUE, "Forêt", 2)
        {
        }

        public override void OnDiceResult(int diceResult, Player playerWhosPlaying)
        {
            if (diceResult == activationValue)
                playerOwner.nbPiece++;
        }
    }
    #endregion

    #region Class : RestaurantCard (Dérivée de MasterCard)
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
    #endregion

    #region Class : StadiumCard (Dérivée de MasterCard)
    public class StadiumCard : MasterCard
    {
        public StadiumCard() : base(6, CardColor.BLUE, "Stade", 6)
        {
        }

        public override void OnDiceResult(int diceResult, Player playerWhosPlaying)
        {
            if (diceResult == activationValue)
                playerOwner.nbPiece += 4;
        }
    }
    #endregion
}
