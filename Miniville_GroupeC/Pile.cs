using System;
using System.Collections.Generic;
using System.Text;

namespace Miniville_GroupeC
{
    public class Pile
    {
        public List<MasterCard> mainpile = new List<MasterCard>();

        public Pile()
        {
            int nb = 0;
            for (int i = 0; i < 6*8; i++)
            {
                
                if(i % 6 == 0)
                    nb++;
                switch(nb)
                {
                    case 1:
                        mainpile.Add(new WheatFieldCard());
                        break;
                    case 2:
                        mainpile.Add(new FarmCard());
                        break;
                    case 3:
                        mainpile.Add(new BakeryCard());
                        break;
                    case 4:
                        mainpile.Add(new CafeCard());
                        break;
                    case 5:
                        mainpile.Add(new MiniMarketCard());
                        break;
                    case 6:
                        mainpile.Add(new ForestCard());
                        break;
                    case 7:
                        mainpile.Add(new RestaurantCard());
                        break;
                    case 8:
                        mainpile.Add(new StadiumCard());
                        break;
                }


            }
        }
    }
}
