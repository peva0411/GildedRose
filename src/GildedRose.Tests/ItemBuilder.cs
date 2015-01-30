using GildedRose.Console;

namespace GildedRose.Tests
{
    public class ItemBuilder
    {
        private StoreItem _item;

        public static ItemBuilder DefaultItem()
        {
            return new ItemBuilder();
        }

        public ItemBuilder()
        {
            _item = new StoreItem(new Item());
            _item.Name = "+5 Dexterity Vest";
            _item.Quality = 20;
            _item.SellIn = 10;
        }

        public ItemBuilder ItemAsAgedBrie()
        {
            _item.Name = "Aged Brie";
            return this;
        }

        public ItemBuilder ItemAsSulfuras()
        {
            _item.Name = "Sulfuras, Hand of Ragnaros";
            return this;
        }

        public ItemBuilder ItemAsBackstagePasses()
        {
            _item.Name = "Backstage passes to a TAFKAL80ETC concert";
            return this;
        }

        public ItemBuilder WithQualityOf(int quality)
        {
            _item.Quality = quality;
            return this;
        }

        public ItemBuilder WithSellInOf(int sellIn)
        {
            _item.SellIn = sellIn;
            return this;
        }

        public StoreItem Build()
        {
            return _item;
        }
    }
}