using System.Collections.Generic;

namespace GildedRose.Console
{
    public class ItemQualityService
    {
        public void UpdateItemQuality(IList<Item> items )
        {
            foreach (Item item in items)
            {
                var storeItem = new StoreItem(item);
                storeItem.UpdateItemQuality();
            }
        }
    }
}