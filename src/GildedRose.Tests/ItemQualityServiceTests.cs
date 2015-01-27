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
        private int SYSTEM_MAX_Quality = 50;

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

        [Test]
        public void UpdateItemQuality_AgedBrie_QualityShouldIncrease()
        {
            var qualityService = GetQualityService();

            var agedBrie = ItemBuilder.DefaultItem()
                .WithQualityOf(0)
                .WithSellInOf(2)
                .ItemAsAgedBrie()
                .Build();

            var startingQuality = agedBrie.Quality;

            qualityService.UpdateItemQuality(agedBrie);

            Assert.That(agedBrie.Quality, Is.EqualTo(startingQuality + 1));
        }

        [Test]
        public void UpdateItemQuality_AgedBrie_QualityNeverGreaterThan50()
        {
            var qualityService = GetQualityService();

          
            var agedBrie = ItemBuilder.DefaultItem()
                .WithQualityOf(SYSTEM_MAX_Quality)
                .WithSellInOf(2)
                .ItemAsAgedBrie()
                .Build();

            qualityService.UpdateItemQuality(agedBrie);

            Assert.That(agedBrie.Quality, Is.EqualTo(SYSTEM_MAX_Quality));
        }

        [Test]
        public void UpdateItemQuality_AgedBrieAfterSellin_QualityIncreaseBy2()
        {
            var qualityService = GetQualityService();

            var agedBrie = ItemBuilder.DefaultItem()
                .WithQualityOf(0)
                .WithSellInOf(0)
                .ItemAsAgedBrie()
                .Build();

            var startingQuality = agedBrie.Quality;

            qualityService.UpdateItemQuality(agedBrie);

            Assert.That(agedBrie.Quality, Is.EqualTo(startingQuality + 2));
        }

        [Test]
        public void UpdateItemQuality_Sulfuras_QualityDoesNotDecrease()
        {
            var qualityService = GetQualityService();

            var sulfuras = ItemBuilder.DefaultItem()
                .WithQualityOf(10)
                .WithSellInOf(0)
                .ItemAsSulfuras()
                .Build();

            var startingQuality = sulfuras.Quality;

            qualityService.UpdateItemQuality(sulfuras);
            
            Assert.That(sulfuras.Quality, Is.EqualTo(startingQuality));
        }

        [Test]
        public void UpdateItemQuality_Tickets11DaysBeforeConcert_QualityIncreasesBy1()
        {
            var qualityService = GetQualityService();

            var tickets = ItemBuilder.DefaultItem()
                .WithQualityOf(20)
                .WithSellInOf(11)
                .ItemAsBackstagePasses()
                .Build();

            var startingQuality = tickets.Quality;

            qualityService.UpdateItemQuality(tickets);


            Assert.That(tickets.Quality, Is.EqualTo(startingQuality + 1));
        }


        [Test]
        public void UpdateItemQuality_Ticket10DaysBeforeConcert_QualityIncreasesBy2()
        {
            var qualityService = GetQualityService();

            var tickets = ItemBuilder.DefaultItem()
                .WithQualityOf(20)
                .WithSellInOf(10)
                .ItemAsBackstagePasses()
                .Build();

            var startingQuality = tickets.Quality;

            qualityService.UpdateItemQuality(tickets);


            Assert.That(tickets.Quality, Is.EqualTo(startingQuality + 2));
        }

        [Test]
        public void UpdateItemQuality_Tickets6DaysBeforeConcert_QualityIncreasesBy2()
        {
            var qualityService = GetQualityService();

            var tickets = ItemBuilder.DefaultItem()
                .WithQualityOf(20)
                .WithSellInOf(6)
                .ItemAsBackstagePasses()
                .Build();

            var startingQuality = tickets.Quality;

            qualityService.UpdateItemQuality(tickets);


            Assert.That(tickets.Quality, Is.EqualTo(startingQuality + 2));
        }

        [Test]
        public void UpdateItemQuality_Tickets5DaysBeforeConcert_QualityIncreasesBy3()
        {
            var qualityService = GetQualityService();

            var tickets = ItemBuilder.DefaultItem()
                .WithQualityOf(20)
                .WithSellInOf(5)
                .ItemAsBackstagePasses()
                .Build();

            var startingQuality = tickets.Quality;

            qualityService.UpdateItemQuality(tickets);


            Assert.That(tickets.Quality, Is.EqualTo(startingQuality + 3));
        }

        [Test]
        public void UpdateItemQuality_Tickets0DaysBeforeConcert_QualityIs0()
        {
            var qualityService = GetQualityService();

            var tickets = ItemBuilder.DefaultItem()
                .WithQualityOf(20)
                .WithSellInOf(0)
                .ItemAsBackstagePasses()
                .Build();


            qualityService.UpdateItemQuality(tickets);


            Assert.That(tickets.Quality, Is.EqualTo(0));
        }


    }
}
