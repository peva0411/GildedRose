using GildedRose.Console.Strategies;

namespace GildedRose.Console
{
    public class DefaultUpdateQualityStrategy : IUpdateQualityStrategy
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
        }
    }
}