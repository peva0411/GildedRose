using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests.Strategies
{
    [TestFixture]
    public  class DefaultUpdateQualityStrategyTests : BaseStrategyTest
    {

        private readonly DefaultUpdateQualityStrategy _strategy = new DefaultUpdateQualityStrategy();

        [Test]
        public void UpdateQuality_ReduceNormalItemByOne()
        {
            var normalItem = GetNormalItem();
            var startSellIn = normalItem.SellIn;

            _strategy.UpdateQuality(normalItem);

            Assert.That(normalItem.SellIn, Is.EqualTo(startSellIn - 1));
        }

        [Test]
        public void UpdateQuality_WhenSellInLessThan1_ReduceNormalItemByTwo()
        {
            var normalItem = GetNormalItem(sellIn:0);
            var startingQuality = normalItem.Quality;

            _strategy.UpdateQuality(normalItem);

            Assert.That(normalItem.Quality, Is.EqualTo(startingQuality - 2));
        }

        [Test]
        public void UpdateQuality_WhenQualityZero_WillNotReduceQualityBelowZero()
        {
            var normalItem = GetNormalItem(quality: 0);

            _strategy.UpdateQuality(normalItem);

            Assert.That(normalItem.Quality, Is.GreaterThanOrEqualTo(0));
        }



        private static StoreItem GetNormalItem(int sellIn = DEFAULT_STARTING_SELLIN, int quality = DEFAULT_STARTING_QUALITY)
        {
            var item = new Item() { Name = "+5 Dexterity Vest", SellIn = sellIn, Quality = quality };
            return new StoreItem(item);
        }

    }
}
