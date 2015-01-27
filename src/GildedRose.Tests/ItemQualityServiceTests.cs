using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class ItemQualityServiceTests
    {

        [Test]
        public void UpdateItemQuality_NormalItem_ReduceQualityByOne()
        {
            var qualityService = GetQualityService();

            var noramlItem = ItemBuilder
                             .DefaultItem()
                             .Build();

            var startingQuality = noramlItem.Quality;

            qualityService.UpdateItemQuality(noramlItem);

            Assert.That(noramlItem.Quality, Is.EqualTo(startingQuality - 1));
        }

        private static ItemQualityService GetQualityService()
        {
            return new ItemQualityService();
        }


        [Test]
        public void UpdateItemQuality_NormalItem_ReduceSellInByOne()
        {
            var qualityService = GetQualityService();

            var noramlItem = ItemBuilder.DefaultItem().Build();
            var startingSellIn = noramlItem.SellIn;

            qualityService.UpdateItemQuality(noramlItem);

            Assert.That(noramlItem.SellIn, Is.EqualTo(startingSellIn - 1));
        }

        [Test]
        public void UpdateItemQuality_NormalItemSellInLessThan1_ReduceQualityByTwo()
        {
            var qualityService = GetQualityService();

            var noramlItem = ItemBuilder.DefaultItem().WithSellInOf(0).Build();
            var startingQuality = noramlItem.Quality;

            qualityService.UpdateItemQuality(noramlItem);

            Assert.That(noramlItem.Quality, Is.EqualTo(startingQuality - 2));
        }


        [Test]
        public void UpdateItemQuality_NormalItem_NotReduceQualityBelowZero()
        {
            var qualityService = GetQualityService();

            var normalItem = ItemBuilder.DefaultItem().WithQualityOf(0).Build();
            qualityService.UpdateItemQuality(normalItem);

            Assert.That(normalItem.Quality, Is.EqualTo(0));
        }


    }

    public class ItemBuilder
    {
        private Item _item;

        public static ItemBuilder DefaultItem()
        {
            return new ItemBuilder();
        }

        public ItemBuilder()
        {
            _item = new Item();
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

        public Item Build()
        {
            return _item;
        }
    }

}
