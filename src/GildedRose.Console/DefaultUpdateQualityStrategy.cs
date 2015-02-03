using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console
{
    public class DefaultUpdateQualityStrategy : IUpdateQualityStrategy
    {
        public void UpdateQuality(StoreItem storeItem)
        {
            if (storeItem.Quality > 0)
                storeItem.Quality--;
            
            if (storeItem.SellIn > 0)
                storeItem.SellIn--;

        }
    }
}
