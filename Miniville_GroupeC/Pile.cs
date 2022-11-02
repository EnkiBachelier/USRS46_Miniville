using System.Collections.Generic;

namespace Miniville_GroupeC
{
    public class Pile
    {
        #region Déclaration des variables
        public List<MasterCard> mainPile = new List<MasterCard>();
        #endregion

        #region Constructeur
        public Pile(int nbCountPlayers)
        {
            //Ajout de 6 instances de chaque carte standard (sauf Monuments) dans la pile
            int nbStandardCard = 0;
            for (int i = 0; i < 6 * 13; i++)
            {
                if (i % 6 == 0)
                    nbStandardCard++;
                AddStandardCardToPile(nbStandardCard);
            }

            //Ajout d'un monument par Joueur dans la pile
            int nbMonument = 0;
            for (int i = 0; i < nbCountPlayers * 4; i++)
            {
                if (i % nbCountPlayers == 0)
                    nbMonument++;
                AddMonumentToPile(nbMonument);
            }
        }
        #endregion

        #region Méthodes
        //Pour le debug, affiche toutes les cartes présentes dans la pile
        public override string ToString()
        {
            string thisReturn = "";
            foreach (MasterCard thisCard in mainPile)
                thisReturn += thisCard.name + "\n";
            return thisReturn;
        }

        //Retire une carte précise (achetée par exemple) de la pile
        public void RemoveCardFromPile(MasterCard card)
        {
            int inactiveValueOfDicex = -1;
            for (int i = 0; i < mainPile.Count; i++)
            {
                if (card.name == mainPile[i].name)
                {
                    inactiveValueOfDicex = i;
                    break;
                }
            }
            mainPile.RemoveAt(inactiveValueOfDicex);
        }

        //Selon un numéro, ajoute une instance de la carte correspondante à la pile
        private void AddStandardCardToPile(int nbStandardCard)
        {
            switch (nbStandardCard)
            {
                case 1:
                    mainPile.Add(new WheatFieldCard());
                    break;
                case 2:
                    mainPile.Add(new FarmCard());
                    break;
                case 3:
                    mainPile.Add(new BakeryCard());
                    break;
                case 4:
                    mainPile.Add(new CoffeeCard());
                    break;
                case 5:
                    mainPile.Add(new MiniMarketCard());
                    break;
                case 6:
                    mainPile.Add(new ForestCard());
                    break;
                case 7:
                    mainPile.Add(new RestaurantCard());
                    break;
                case 8:
                    mainPile.Add(new StadiumCard());
                    break;
                case 9:
                    mainPile.Add(new CheeseFactoryCard());
                    break;
                case 10:
                    mainPile.Add(new FurnitureFactoryCard());
                    break;
                case 11:
                    mainPile.Add(new MineCard());
                    break;
                case 12:
                    mainPile.Add(new OrchardCard());
                    break;
                case 13:
                    mainPile.Add(new MarketCard());
                    break;
            }
        }

        //Selon un numéro, ajoute une instance du monument correspondant à la pile
        private void AddMonumentToPile(int nbMonument)
        {
            switch (nbMonument)
            {
                case 1:
                    mainPile.Add(new TrainStationCard());
                    break;
                case 2:
                    mainPile.Add(new AmusementParcCard());
                    break;
                case 3:
                    mainPile.Add(new RadioTowerCard());
                    break;
                case 4:
                    mainPile.Add(new ShoppingCentreCard());
                    break;
            }
        }
        #endregion
    }
}