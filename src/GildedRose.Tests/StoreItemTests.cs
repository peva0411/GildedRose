using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class StoreItemTests
    {
        private const int DEFAULT_STARTING_SELLIN = 10;
        private const int DEFAULT_STARTING_QUALITY = 20;
        private const int SYSTEM_MAX_QUALITY = 50;

        public ItemQualityService ItemQualityService = new ItemQualityService();

        [Test]
        public void TestTheTruth()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public void UpdateItemQuality_NormalItem_ReduceQualityByOne()
        {
            var normalItem = GetNormalItem(DEFAULT_STARTING_QUALITY, 5);
            var startingQuality = normalItem.Quality;

            normalItem.UpdateItemQuality();

            Assert.That(normalItem.Quality, Is.EqualTo(startingQuality - 1));
        }

        [Test]
        public void UpdateItemQuality_NormalItem_ReduceSellInByOne()
        {
            var normalItem = GetNormalItem();
            var startingSellIn = normalItem.SellIn;

            normalItem.UpdateItemQuality();

            Assert.That(normalItem.SellIn, Is.EqualTo(startingSellIn - 1));
        }

        [Test]
        public void UpdateItemQuality_NormalItemWhenSellInLessThan1_ReduceQualityByTwo()
        {
            var normalItem = GetNormalItem(0);
            var startingQuality = normalItem.Quality;

            normalItem.UpdateItemQuality();

            Assert.That(normalItem.Quality, Is.EqualTo(startingQuality - 2));
        }

        [Test]
        public void UpdateItemQuality_NormalItemWhenQualityZero_NotBelowZero()
        {
            var normalItem = GetNormalItem(quality: 0);

           normalItem.UpdateItemQuality();

            Assert.That(normalItem.Quality, Is.EqualTo(0));
        }

        [Test]
        public void UpdateItemQuality_AgedBrie_QualityIncreases()
        {
            var agedBrie = GetAgedBrie();
            var startingQuality = agedBrie.Quality;

            agedBrie.UpdateItemQuality();

            Assert.That(agedBrie.Quality, Is.GreaterThan(startingQuality));
        }

        [Test]
        public void UpdateItemQuality_AgedBrie_QualityDoesNotGoAbove50()
        {

            var agedBrie = GetAgedBrie(quality: SYSTEM_MAX_QUALITY);
            var startingQuality = agedBrie.Quality;

            agedBrie.UpdateItemQuality();

            Assert.That(agedBrie.Quality, Is.EqualTo(startingQuality));
        }

        [Test]
        public void UpdateItemQuality_AgedBrieAfterSellIn_QualityIncreasesBy2()
        {
            var agedBrie = GetAgedBrie(sellIn: 0);
            var startingQuality = agedBrie.Quality;

            agedBrie.UpdateItemQuality();

            Assert.That(agedBrie.Quality, Is.EqualTo(startingQuality + 2));
        }

        [Test]
        public void UpdateItemQuality_Sulfuras_QualityDoesNotChanage()
        {
            var sulfuras = GetSulfuras();
            var startingQuality = sulfuras.Quality;

           sulfuras.UpdateItemQuality();

            Assert.That(sulfuras.Quality, Is.EqualTo(startingQuality));
        }

        [Test]
        public void UpdateItemQuality_Sulfuras_SellInDoesNotChange()
        {
            var sulfuras = GetSulfuras();
            var startingSellin = sulfuras.SellIn;

            sulfuras.UpdateItemQuality();

            Assert.That(sulfuras.SellIn, Is.EqualTo(startingSellin));
        }

        [Test]
        public void UpdateItemQuality_BackstagePassesWhen11DaysLeft_IncreaseQualityByOne()
        {
            var backstagePasses = GetBackstagePasses(sellIn: 11);
            var startingQuality = backstagePasses.Quality;

            backstagePasses.UpdateItemQuality();

            Assert.That(backstagePasses.Quality, Is.EqualTo(startingQuality + 1));
        }

        [Test]
        public void UpdateItemQuality_BackstagePassesWhen10DaysLeft_IncreaseQualityByTwo()
        {
            var backstagePasses = GetBackstagePasses(sellIn: 10);
            var startingQuality = backstagePasses.Quality;

           backstagePasses.UpdateItemQuality();

            Assert.That(backstagePasses.Quality, Is.EqualTo(startingQuality + 2));
        }

        [Test]
        public void UpdateItemQuality_BackstagePassesWhen6DaysLeft_IncreaseQualityByTwo()
        {
            var backstagePasses = GetBackstagePasses(sellIn: 6);
            var startingQuality = backstagePasses.Quality;

           backstagePasses.UpdateItemQuality();

            Assert.That(backstagePasses.Quality, Is.EqualTo(startingQuality + 2));
        }

        [Test]
        public void UpdateItemQuality_BackstagePassesWhen5DaysLeft_IncreaseQualityBy3()
        {
            var backstagePasses = GetBackstagePasses(sellIn: 5);
            var startingQuality = backstagePasses.Quality;

           backstagePasses.UpdateItemQuality();

            Assert.That(backstagePasses.Quality, Is.EqualTo(startingQuality + 3));
        }

        [Test]
        public void UpdateItemQuality_BackstagePassesWhen1DaysLeft_IncreaseQualityBy3()
        {
            var backstagePasses = GetBackstagePasses(sellIn: 1);
            var startingQuality = backstagePasses.Quality;

            backstagePasses.UpdateItemQuality();

            Assert.That(backstagePasses.Quality, Is.EqualTo(startingQuality + 3));
        }

        [Test]
        public void UpdateItemQuality_BackstagePassesWhenPastSellIn_QualityZero()
        {
            var backstagePasses = GetBackstagePasses(sellIn: 0);

            backstagePasses.UpdateItemQuality();

            Assert.That(backstagePasses.Quality, Is.EqualTo(0));
        }

        private static StoreItem GetAgedBrie(int sellIn = DEFAULT_STARTING_SELLIN, int quality = DEFAULT_STARTING_QUALITY)
        {
            var item = new Item() { Name = "Aged Brie", SellIn = sellIn, Quality = quality };
            return new StoreItem(item);
        }

        private static StoreItem GetNormalItem(int sellIn = DEFAULT_STARTING_SELLIN, int quality = DEFAULT_STARTING_QUALITY)
        {
            var item = new Item() { Name = "+5 Dexterity Vest", SellIn = sellIn, Quality = quality };
            return new StoreItem(item);
        }

        private static StoreItem GetSulfuras()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
            return new StoreItem(item);
        }

        private static StoreItem GetBackstagePasses(int sellIn = DEFAULT_STARTING_SELLIN, int quality = DEFAULT_STARTING_QUALITY)
        {
            var item = new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality };
            return new StoreItem(item);
        }
    }
}
