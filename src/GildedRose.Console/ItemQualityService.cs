using System.Collections;
using System.Collections.Generic;

namespace GildedRose.Console
{
    public class ItemQualityService
    {
 
        public void UpdateQuality(IList<Item> items)
        {
            foreach (var item in items)
            {
                var storeItem = new StoreItem(item); 
                storeItem.UpdateItemQuality();
            }
        }

        
        
    }
}