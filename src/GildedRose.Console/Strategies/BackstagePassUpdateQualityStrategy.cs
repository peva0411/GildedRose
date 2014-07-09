namespace GildedRose.Console.Strategies
{
    public class BackstagePassUpdateQualityStrategy:IUpdateQualityStrategy
    {
        public void UpdateQuality(StoreItem item)
        {
            if (item.Quality < 50)
                item.Quality ++;
            
            item.SellIn--;

            if (item.SellIn < 10)
                item.Quality = item.Quality + 1;

            if (item.SellIn < 5)
                item.Quality = item.Quality + 1;

            if (item.SellIn < 0)
                item.Quality = 0;
        }
    }
}