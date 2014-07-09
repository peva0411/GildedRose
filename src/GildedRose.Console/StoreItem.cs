﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GildedRose.Console.Strategies;

namespace GildedRose.Console
{
    public class StoreItem
    {
        private readonly Item _item;

        private readonly IUpdateQualityStrategy _updateQualityStrategy;

        public StoreItem(Item item)
        {
            _item = item;

            _updateQualityStrategy = new DefaultUpdateQualityStrategy();

            if (Name == "Aged Brie")
            {
                _updateQualityStrategy = new BetterWithTimeUpdateQualityStrategy();
            }
            if (Name == "Sulfuras, Hand of Ragnaros")
            {
                _updateQualityStrategy = new LegendaryUpdateStrategy();
            }
            if (Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                _updateQualityStrategy = new BackstagePassUpdateQualityStrategy();
            }
            if (Name == "Conjured Mana Cake")
            {
                _updateQualityStrategy = new ConjuredItemUpdateQualityStrategy();
            }
        }

        public string Name
        {
            get { return _item.Name; }
            set { _item.Name = value; }
        }

        public int SellIn {
            get { return _item.SellIn; }
            set { _item.SellIn = value; }
        }

        public int Quality {
            get { return _item.Quality; }
            protected set { _item.Quality = value; } }


        public void IncrementQuality()
        {
            if (Quality < 50)
                Quality++;
        }

        public void DecrementQuality()
        {
            if (Quality > 0)
                Quality--;
        }

        public void Expire()
        {
            Quality = 0;
        }

        public void UpdateItemQuality()
        {
            _updateQualityStrategy.UpdateQuality(this);
        }

    }
}
