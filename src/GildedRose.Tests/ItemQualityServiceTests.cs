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

        [Test]
        public void UpdateItemQuality_Sulfuras_QualityDoesNotDecrease()
        {

            var sulfuras = ItemBuilder.DefaultItem()
                .WithQualityOf(10)
                .WithSellInOf(0)
                .ItemAsSulfuras()
                .Build();

            var startingQuality = sulfuras.Quality;
            
            sulfuras.UpdateItemQuality();
            
            Assert.That(sulfuras.Quality, Is.EqualTo(startingQuality));
        }

        [Test]
        public void UpdateItemQuality_Tickets11DaysBeforeConcert_QualityIncreasesBy1()
        {

            var tickets = ItemBuilder.DefaultItem()
                .WithQualityOf(20)
                .WithSellInOf(11)
                .ItemAsBackstagePasses()
                .Build();

            var startingQuality = tickets.Quality;

            tickets.UpdateItemQuality();

            Assert.That(tickets.Quality, Is.EqualTo(startingQuality + 1));
        }


        [Test]
        public void UpdateItemQuality_Ticket10DaysBeforeConcert_QualityIncreasesBy2()
        {

            var tickets = ItemBuilder.DefaultItem()
                .WithQualityOf(20)
                .WithSellInOf(10)
                .ItemAsBackstagePasses()
                .Build();

            var startingQuality = tickets.Quality;

           tickets.UpdateItemQuality();


            Assert.That(tickets.Quality, Is.EqualTo(startingQuality + 2));
        }

        [Test]
        public void UpdateItemQuality_Tickets6DaysBeforeConcert_QualityIncreasesBy2()
        {

            var tickets = ItemBuilder.DefaultItem()
                .WithQualityOf(20)
                .WithSellInOf(6)
                .ItemAsBackstagePasses()
                .Build();

            var startingQuality = tickets.Quality;

            tickets.UpdateItemQuality();

            Assert.That(tickets.Quality, Is.EqualTo(startingQuality + 2));
        }

        [Test]
        public void UpdateItemQuality_Tickets5DaysBeforeConcert_QualityIncreasesBy3()
        {

            var tickets = ItemBuilder.DefaultItem()
                .WithQualityOf(20)
                .WithSellInOf(5)
                .ItemAsBackstagePasses()
                .Build();

            var startingQuality = tickets.Quality;

            tickets.UpdateItemQuality();

            Assert.That(tickets.Quality, Is.EqualTo(startingQuality + 3));
        }

        [Test]
        public void UpdateItemQuality_Tickets0DaysBeforeConcert_QualityIs0()
        {

            var tickets = ItemBuilder.DefaultItem()
                .WithQualityOf(20)
                .WithSellInOf(0)
                .ItemAsBackstagePasses()
                .Build();

            tickets.UpdateItemQuality();


            Assert.That(tickets.Quality, Is.EqualTo(0));
        }


    }
}
