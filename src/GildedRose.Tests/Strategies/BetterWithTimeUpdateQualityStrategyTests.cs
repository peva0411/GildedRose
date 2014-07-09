using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests.Strategies
{
    [TestFixture]
    public class BetterWithTimeUpdateQualityStrategyTests:BaseStrategyTest
    {
        private BetterWithTimeUpdateQualityStrategy _strategy = new BetterWithTimeUpdateQualityStrategy();

        [Test]
        public void UpdateQuality_QualityIncreases()
        {
            var agedBrie = GetAgedBrie();
            var startingQuality = agedBrie.Quality;

            _strategy.UpdateQuality(agedBrie);

            Assert.That(agedBrie.Quality, Is.GreaterThan(startingQuality));
        }

        [Test]
        public void UpdateQuality_QualityEqualTo50_DoesNotIncreasePast50()
        {
            var agedBrie = GetAgedBrie(quality:SYSTEM_MAX_QUALITY);
            var startingQuality = agedBrie.Quality;

            _strategy.UpdateQuality(agedBrie);

            Assert.That(agedBrie.Quality, Is.EqualTo(startingQuality));
        }

        [Test]
        public void UpdateQuality_AfterSellIn_QualityIncreasesByTwo()
        {
            var agedBrie = GetAgedBrie(sellIn: 0);
            var startingQuality = agedBrie.Quality;

            _strategy.UpdateQuality(agedBrie);

            Assert.That(agedBrie.Quality, Is.EqualTo(startingQuality + 2));
        }

        private static StoreItem GetAgedBrie(int sellIn = DEFAULT_STARTING_SELLIN, int quality = DEFAULT_STARTING_QUALITY)
        {
            var item = new Item() { Name = "Aged Brie", SellIn = sellIn, Quality = quality };
            return new StoreItem(item);
        }

    }


}
