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
            int nb = 0;
            for (int i = 0; i < 6 * 13; i++)
            {
                //Ajout de 6 instances de chaque carte dans la pile
                if (i % 6 == 0)
                    nb++;
                AddCardToPile(nb);
            }
            int monument = 0;
            for(int i = 0; i < nbCountPlayers * 4 ; i++)
            {
                if(i % nbCountPlayers == 0)
                    monument++;
                AddMonumentToPile(monument);
                
            }
        }
        #endregion

        #region Méthodes
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
        private void AddCardToPile(int nb)
        {
            switch (nb)
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
        private void AddMonumentToPile(int monument)
        {
            switch (monument)
            {
                case 1:
                    mainPile.Add(new GareCard());
                    break;
                case 2:
                    mainPile.Add(new ParcAttractionsCard());
                    break;
                case 3:
                    mainPile.Add(new TourRadioCard());
                    break;
                case 4:
                    mainPile.Add(new CentreCommercialCard());
                    break;
            }
        }
        #endregion
    }
}