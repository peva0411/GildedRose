using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GildedRose.Console;
using GildedRose.Console.Strategies;
using NUnit.Framework;

namespace GildedRose.Tests.Strategies
{
    [TestFixture]
    public class BackstagePassUpdateQualityStrategyTests : BaseStrategyTest
    {

        private readonly BackstagePassUpdateQualityStrategy _strategy = new BackstagePassUpdateQualityStrategy();

        [Test]
        public void UpdateItemQuality_BackstagePassesWhen11DaysLeft_IncreaseQualityByOne()
        {
            var backstagePasses = GetBackstagePasses(sellIn: 11);
            var startingQuality = backstagePasses.Quality;

            _strategy.UpdateQuality(backstagePasses);

            Assert.That(backstagePasses.Quality, Is.EqualTo(startingQuality + 1));
        }

        [Test]
        public void UpdateItemQuality_BackstagePassesWhen10DaysLeft_IncreaseQualityByTwo()
        {
            var backstagePasses = GetBackstagePasses(sellIn: 10);
            var startingQuality = backstagePasses.Quality;

            _strategy.UpdateQuality(backstagePasses);

            Assert.That(backstagePasses.Quality, Is.EqualTo(startingQuality + 2));
        }

        [Test]
        public void UpdateItemQuality_BackstagePassesWhen6DaysLeft_IncreaseQualityByTwo()
        {
            var backstagePasses = GetBackstagePasses(sellIn: 6);
            var startingQuality = backstagePasses.Quality;

            _strategy.UpdateQuality(backstagePasses);

            Assert.That(backstagePasses.Quality, Is.EqualTo(startingQuality + 2));
        }

        [Test]
        public void UpdateItemQuality_BackstagePassesWhen5DaysLeft_IncreaseQualityBy3()
        {
            var backstagePasses = GetBackstagePasses(sellIn: 5);
            var startingQuality = backstagePasses.Quality;

            _strategy.UpdateQuality(backstagePasses);

            Assert.That(backstagePasses.Quality, Is.EqualTo(startingQuality + 3));
        }

        [Test]
        public void UpdateItemQuality_BackstagePassesWhen1DaysLeft_IncreaseQualityBy3()
        {
            var backstagePasses = GetBackstagePasses(sellIn: 1);
            var startingQuality = backstagePasses.Quality;

            _strategy.UpdateQuality(backstagePasses);

            Assert.That(backstagePasses.Quality, Is.EqualTo(startingQuality + 3));
        }

        [Test]
        public void UpdateItemQuality_BackstagePassesWhenPastSellIn_QualityZero()
        {
            var backstagePasses = GetBackstagePasses(sellIn: 0);

            _strategy.UpdateQuality(backstagePasses);

            Assert.That(backstagePasses.Quality, Is.EqualTo(0));
        }

        private static StoreItem GetBackstagePasses(int sellIn = DEFAULT_STARTING_SELLIN, int quality = DEFAULT_STARTING_QUALITY)
        {
            var item = new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality };
            return new StoreItem(item);
        }
    }
}
