using GildedRose.Console;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class ItemQualityServiceTests
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

            ItemQualityService.UpdateItemQuality(normalItem);

            Assert.That(normalItem.Quality, Is.EqualTo(startingQuality - 1));
        }

        [Test]
        public void UpdateItemQuality_NormalItem_ReduceSellInByOne()
        {
            var normalItem = GetNormalItem();
            var startingSellIn = normalItem.SellIn;

            ItemQualityService.UpdateItemQuality(normalItem);

            Assert.That(normalItem.SellIn, Is.EqualTo(startingSellIn - 1));
        }

        [Test]
        public void UpdateItemQuality_NormalItemWhenSellInLessThan1_ReduceQualityByTwo()
        {
            var normalItem = GetNormalItem(0);
            var startingQuality = normalItem.Quality;

            ItemQualityService.UpdateItemQuality(normalItem);

            Assert.That(normalItem.Quality, Is.EqualTo(startingQuality - 2));
        }

        [Test]
        public void UpdateItemQuality_NormalItemWhenQualityZero_NotBelowZero()
        {
            var normalItem = GetNormalItem(quality: 0);

            ItemQualityService.UpdateItemQuality(normalItem);

            Assert.That(normalItem.Quality, Is.EqualTo(0));
        }

        [Test]
        public void UpdateItemQuality_AgedBrie_QualityIncreases()
        {
            var agedBrie = GetAgedBrie();
            var startingQuality = agedBrie.Quality;

            ItemQualityService.UpdateItemQuality(agedBrie);

            Assert.That(agedBrie.Quality, Is.GreaterThan(startingQuality));
        }

        [Test]
        public void UpdateItemQuality_AgedBrie_QualityDoesNotGoAbove50()
        {

            var agedBrie = GetAgedBrie(quality: SYSTEM_MAX_QUALITY);
            var startingQuality = agedBrie.Quality;

            ItemQualityService.UpdateItemQuality(agedBrie);

            Assert.That(agedBrie.Quality, Is.EqualTo(startingQuality));
        }

        [Test]
        public void UpdateItemQuality_AgedBrieAfterSellIn_QualityIncreasesBy2()
        {
            var agedBrie = GetAgedBrie(sellIn: 0);
            var startingQuality = agedBrie.Quality;

            ItemQualityService.UpdateItemQuality(agedBrie);

            Assert.That(agedBrie.Quality, Is.EqualTo(startingQuality + 2));
        }

        [Test]
        public void UpdateItemQuality_Sulfuras_QualityDoesNotChanage()
        {
            var sulfuras = GetSulfuras();
            var startingQuality = sulfuras.Quality;

            ItemQualityService.UpdateItemQuality(sulfuras);

            Assert.That(sulfuras.Quality, Is.EqualTo(startingQuality));
        }

        [Test]
        public void UpdateItemQuality_Sulfuras_SellInDoesNotChange()
        {
            var sulfuras = GetSulfuras();
            var startingSellin = sulfuras.SellIn;

            ItemQualityService.UpdateItemQuality(sulfuras);

            Assert.That(sulfuras.SellIn, Is.EqualTo(startingSellin));
        }

        [Test]
        public void UpdateItemQuality_BackstagePassesWhen11DaysLeft_IncreaseQualityByOne()
        {
            var backstagePasses = GetBackstagePasses(sellIn: 11);
            var startingQuality = backstagePasses.Quality;

            ItemQualityService.UpdateItemQuality(backstagePasses);

            Assert.That(backstagePasses.Quality, Is.EqualTo(startingQuality + 1));
        }

        [Test]
        public void UpdateItemQuality_BackstagePassesWhen10DaysLeft_IncreaseQualityByTwo()
        {
            var backstagePasses = GetBackstagePasses(sellIn: 10);
            var startingQuality = backstagePasses.Quality;

            ItemQualityService.UpdateItemQuality(backstagePasses);

            Assert.That(backstagePasses.Quality, Is.EqualTo(startingQuality + 2));
        }

        [Test]
        public void UpdateItemQuality_BackstagePassesWhen6DaysLeft_IncreaseQualityByTwo()
        {
            var backstagePasses = GetBackstagePasses(sellIn: 6);
            var startingQuality = backstagePasses.Quality;

            ItemQualityService.UpdateItemQuality(backstagePasses);

            Assert.That(backstagePasses.Quality, Is.EqualTo(startingQuality + 2));
        }

        [Test]
        public void UpdateItemQuality_BackstagePassesWhen5DaysLeft_IncreaseQualityBy3()
        {
            var backstagePasses = GetBackstagePasses(sellIn: 5);
            var startingQuality = backstagePasses.Quality;

            ItemQualityService.UpdateItemQuality(backstagePasses);

            Assert.That(backstagePasses.Quality, Is.EqualTo(startingQuality + 3));
        }

        [Test]
        public void UpdateItemQuality_BackstagePassesWhen1DaysLeft_IncreaseQualityBy3()
        {
            var backstagePasses = GetBackstagePasses(sellIn: 1);
            var startingQuality = backstagePasses.Quality;

            ItemQualityService.UpdateItemQuality(backstagePasses);

            Assert.That(backstagePasses.Quality, Is.EqualTo(startingQuality + 3));
        }

        [Test]
        public void UpdateItemQuality_BackstagePassesWhenPastSellIn_QualityZero()
        {
            var backstagePasses = GetBackstagePasses(sellIn: 0);

            ItemQualityService.UpdateItemQuality(backstagePasses);

            Assert.That(backstagePasses.Quality, Is.EqualTo(0));
        }

        private static Item GetAgedBrie(int sellIn = DEFAULT_STARTING_SELLIN, int quality = DEFAULT_STARTING_QUALITY)
        {
            return new Item() {Name = "Aged Brie", SellIn = sellIn, Quality = quality};
        }

        private static Item GetNormalItem(int sellIn = DEFAULT_STARTING_SELLIN, int quality = DEFAULT_STARTING_QUALITY)
        {
            return new Item() {Name = "+5 Dexterity Vest", SellIn = sellIn, Quality = quality};
        }

        private static Item GetSulfuras()
        {
            return new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80};
        }

        private static Item GetBackstagePasses(int sellIn = DEFAULT_STARTING_SELLIN, int quality = DEFAULT_STARTING_QUALITY)
        {
            return new Item() { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = sellIn, Quality = quality };
        }

    }
}