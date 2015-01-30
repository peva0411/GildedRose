using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace GildedRose.Tests.Strategies
{


    [TestFixture]
    public class BetterWithTimeUpdateQualityStrategyTests : BaseStrategyTest
    {
        [Test]
        public void UpdateItemQuality_AgedBrie_QualityShouldIncrease()
        {

            var agedBrie = ItemBuilder.DefaultItem()
                .WithQualityOf(0)
                .WithSellInOf(2)
                .ItemAsAgedBrie()
                .Build();

            var startingQuality = agedBrie.Quality;

            agedBrie.UpdateItemQuality();

            Assert.That(agedBrie.Quality, Is.EqualTo(startingQuality + 1));
        }

        [Test]
        public void UpdateItemQuality_AgedBrie_QualityNeverGreaterThan50()
        {


            var agedBrie = ItemBuilder.DefaultItem()
                .WithQualityOf(SYSTEM_MAX_Quality)
                .WithSellInOf(2)
                .ItemAsAgedBrie()
                .Build();

            agedBrie.UpdateItemQuality();

            Assert.That(agedBrie.Quality, Is.EqualTo(SYSTEM_MAX_Quality));
        }

        [Test]
        public void UpdateItemQuality_AgedBrieAfterSellin_QualityIncreaseBy2()
        {

            var agedBrie = ItemBuilder.DefaultItem()
                .WithQualityOf(0)
                .WithSellInOf(0)
                .ItemAsAgedBrie()
                .Build();

            var startingQuality = agedBrie.Quality;

            agedBrie.UpdateItemQuality();

            Assert.That(agedBrie.Quality, Is.EqualTo(startingQuality + 2));
        }
    }

    public class BaseStrategyTest
    {
        protected int SYSTEM_MAX_Quality = 50;
    }
}
