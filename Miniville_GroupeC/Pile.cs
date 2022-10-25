using System;
using System.Collections.Generic;
using System.Text;

namespace Miniville_GroupeC
{
    public class Pile
    {
        #region Déclaration des variables
        public List<MasterCard> mainPile = new List<MasterCard>();
        #endregion

        #region Constructeur
        public Pile()
        {
            int nb = 0;
            for (int i = 0; i < 6 * 8; i++)
            {

                //Ajout de 6 instances de chaque carte dans la pile
                if (i % 6 == 0)
                    nb++;
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
                }

            }
        }
        #endregion

        #region Méthodes
        
        //Retire la carte achetée de la pile
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
        #endregion
    }
}