namespace GildedRose.Console
{
    public class BetterWithTimeUpdateQualityStrategy : IUpdateQualityStrategy
    {
        public void UpdateQuality(StoreItem storeItem)
        {
            if (storeItem.Quality < 50)
            {
                storeItem.Quality++;
            }
            storeItem.SellIn--;
        }
    }
}