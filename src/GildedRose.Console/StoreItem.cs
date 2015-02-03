using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GildedRose.Console
{
    public class StoreItem
    {
        private readonly Item _item;
        private readonly IUpdateQualityStrategy _updateQualityStrategy;

        public StoreItem()
        {
        }

        public StoreItem(Item item)
        {
            _item = item;
            if (Name == "Aged Brie")
            {
                _updateQualityStrategy = new BetterWithTimeUpdateQualityStrategy();
            }
        }

        public string Name
        {
            get { return _item.Name; }
            set { _item.Name = value; }
        }

        public int SellIn
        {
            get { return _item.SellIn; }
            set { _item.SellIn = value; }
        }

        public int Quality
        {
            get { return _item.Quality; }
            set { _item.Quality = value; }
        }

        public void UpdateItemQuality()
        {

            if (this.Name != "Aged Brie" && this.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (this.Quality > 0)
                {
                    if (this.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        this.Quality = this.Quality - 1;
                    }
                }
            }
            else
            {
                if (this.Quality < 50)
                {
                    this.Quality = this.Quality + 1;

                    if (this.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (this.SellIn < 11)
                        {
                            if (this.Quality < 50)
                            {
                                this.Quality = this.Quality + 1;
                            }
                        }

                        if (this.SellIn < 6)
                        {
                            if (this.Quality < 50)
                            {
                                this.Quality = this.Quality + 1;
                            }
                        }
                    }
                }
            }

            if (this.Name != "Sulfuras, Hand of Ragnaros")
            {
                this.SellIn = this.SellIn - 1;
            }

            if (this.SellIn < 0)
            {
                if (this.Name != "Aged Brie")
                {
                    if (this.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (this.Quality > 0)
                        {
                            if (this.Name != "Sulfuras, Hand of Ragnaros")
                            {
                                this.Quality = this.Quality - 1;
                            }
                        }
                    }
                    else
                    {
                        this.Quality = this.Quality - this.Quality;
                    }
                }
                else
                {
                    if (this.Quality < 50)
                    {
                        this.Quality = this.Quality + 1;
                    }
                }
            }
        }
    }
}
