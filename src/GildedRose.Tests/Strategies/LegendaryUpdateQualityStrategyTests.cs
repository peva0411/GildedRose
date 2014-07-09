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
   public  class LegendaryUpdateQualityStrategyTests:BaseStrategyTest
    {
        private LegendaryUpdateStrategy _strategy = new LegendaryUpdateStrategy();

        [Test]
        public void UpdateItemQuality_Sulfuras_QualityDoesNotChanage()
        {
            var sulfuras = GetSulfuras();
            var startingQuality = sulfuras.Quality;

            _strategy.UpdateQuality(sulfuras);

            Assert.That(sulfuras.Quality, Is.EqualTo(startingQuality));
        }

        [Test]
        public void UpdateItemQuality_Sulfuras_SellInDoesNotChange()
        {
            var sulfuras = GetSulfuras();
            var startingSellin = sulfuras.SellIn;

           _strategy.UpdateQuality(sulfuras);

            Assert.That(sulfuras.SellIn, Is.EqualTo(startingSellin));
        }

        private static StoreItem GetSulfuras()
        {
            var item = new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 };
            return new StoreItem(item);
        }
    }
}
