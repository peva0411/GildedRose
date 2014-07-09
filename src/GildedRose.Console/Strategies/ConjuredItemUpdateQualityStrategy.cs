using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console.Strategies
{
    public class ConjuredItemUpdateQualityStrategy :IUpdateQualityStrategy
    {
        public void UpdateQuality(StoreItem item)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }
            if (item.SellIn > 0)
            {
                item.SellIn--;
            }
            else
            {
                if (item.Quality > 0)
                {
                    item.Quality--;
                }
            }

            if (item.Quality > 0)
            {
                item.Quality--;
            }
            if (item.SellIn <= 0)
            {
                if (item.Quality > 0)
                {
                    item.Quality--;
                }
            }
        }
    }
}
