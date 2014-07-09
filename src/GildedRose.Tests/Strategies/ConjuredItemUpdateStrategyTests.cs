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
    public class ConjuredItemUpdateStrategyTests : BaseStrategyTest
    {
        private readonly ConjuredItemUpdateQualityStrategy _strategy = new ConjuredItemUpdateQualityStrategy();

        [Test]
        public void UpdateQuality_ReduceNormalItemByTwo()
        {
            var normalItem = GetConjuredItem();
            var startSellIn = normalItem.SellIn;

            _strategy.UpdateQuality(normalItem);

            Assert.That(normalItem.SellIn, Is.EqualTo(startSellIn - 1));
        }

        [Test]
        public void UpdateQuality_WhenSellInLessThan1_ReduceNormalItemByFour()
        {
            var normalItem = GetConjuredItem(sellIn: 0);
            var startingQuality = normalItem.Quality;

            _strategy.UpdateQuality(normalItem);

            Assert.That(normalItem.Quality, Is.EqualTo(startingQuality - 2));
        }

        [Test]
        public void UpdateQuality_WhenQualityZero_WillNotReduceQualityBelowZero()
        {
            var normalItem = GetConjuredItem(quality: 0);

            _strategy.UpdateQuality(normalItem);

            Assert.That(normalItem.Quality, Is.GreaterThanOrEqualTo(0));
        }



        private static StoreItem GetConjuredItem(int sellIn = DEFAULT_STARTING_SELLIN, int quality = DEFAULT_STARTING_QUALITY)
        {
            var item = new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6};
            return new StoreItem(item);
        }
    }
}
