using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests.Strategies
{
    [TestFixture]
    public class DefaultUpdateQualityStrategyTests
    {

        private IUpdateQualityStrategy _strategy = new DefaultUpdateQualityStrategy();

        [Test]
        public void UpdateItemQuality_NormalItem_ReduceQualityByOne()
        {
            var noramlItem = ItemBuilder
                             .DefaultItem()
                             .Build();

            var startingQuality = noramlItem.Quality;

            _strategy.UpdateQuality(noramlItem);

            Assert.That(noramlItem.Quality, Is.EqualTo(startingQuality - 1));
        }

        private static ItemQualityService GetQualityService()
        {
            return new ItemQualityService();
        }


        [Test]
        public void UpdateItemQuality_NormalItem_ReduceSellInByOne()
        {

            var noramlItem = ItemBuilder.DefaultItem().Build();
            var startingSellIn = noramlItem.SellIn;

            _strategy.UpdateQuality(noramlItem);

            Assert.That(noramlItem.SellIn, Is.EqualTo(startingSellIn - 1));
        }

        [Test]
        public void UpdateItemQuality_NormalItemSellInLessThan1_ReduceQualityByTwo()
        {


            var noramlItem = ItemBuilder.DefaultItem().WithSellInOf(0).Build();
            var startingQuality = noramlItem.Quality;

            _strategy.UpdateQuality(noramlItem);

            Assert.That(noramlItem.Quality, Is.EqualTo(startingQuality - 2));
        }


        [Test]
        public void UpdateItemQuality_NormalItem_NotReduceQualityBelowZero()
        {

            var normalItem = ItemBuilder.DefaultItem().WithQualityOf(0).Build();

            _strategy.UpdateQuality(normalItem);

            Assert.That(normalItem.Quality, Is.EqualTo(0));
        }

    }
}
