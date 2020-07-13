using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Tests
{
    [TestFixture]
    public class AgedBrieTests
    {
        [Test]
        public void GivenAgedBrie_WhenOneDayPassesAndSellInDateAboveZero_ItemQualityIncreasedByOneAndSellInDateDecreased()
        {
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 20 } };

            var app = new GildedRose(items);
            app.UpdateQuality();

            var expectedItem = new Item
            {
                Name = "Aged Brie",
                SellIn = 9,
                Quality = 21
            };

            var actualItem = items.First();

            Assert.AreEqual(expectedItem.SellIn, actualItem.SellIn);
            Assert.AreEqual(expectedItem.Name, actualItem.Name);
            Assert.AreEqual(expectedItem.Quality, actualItem.Quality);
        }

        [Test]
        public void GivenAgedBrie_WhenOneDayPassesAndSellInDateBelowZero_ItemQualityIncreasedByTwoAndSellInDateDecreased()
        {
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 20 } };

            var app = new GildedRose(items);
            app.UpdateQuality();

            var expectedItem = new Item
            {
                Name = "Aged Brie",
                SellIn = -1,
                Quality = 22
            };

            var actualItem = items.First();

            Assert.AreEqual(expectedItem.SellIn, actualItem.SellIn);
            Assert.AreEqual(expectedItem.Name, actualItem.Name);
            Assert.AreEqual(expectedItem.Quality, actualItem.Quality);
        }

        [Test]
        public void GivenAgedBrieWithQualityOfFifty_WhenOneDayPassesAndSellInAboveZero_ItemQualityNotIncreasedAndSellInDateDecreased()
        {
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 1, Quality = 50 } };

            var app = new GildedRose(items);
            app.UpdateQuality();

            var expectedItem = new Item
            {
                Name = "Aged Brie",
                SellIn = 0,
                Quality = 50
            };

            var actualItem = items.First();

            Assert.AreEqual(expectedItem.SellIn, actualItem.SellIn);
            Assert.AreEqual(expectedItem.Name, actualItem.Name);
            Assert.AreEqual(expectedItem.Quality, actualItem.Quality);
        }

        [Test]
        public void GivenAgedBrieWithQualityOfFifty_WhenOneDayPassesAndSellInDateBelowZero_ItemQualityNotIncreasedAndSellInDateDecreased()
        {
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 50 } };

            var app = new GildedRose(items);
            app.UpdateQuality();

            var expectedItem = new Item
            {
                Name = "Aged Brie",
                SellIn = -1,
                Quality = 50
            };

            var actualItem = items.First();

            Assert.AreEqual(expectedItem.SellIn, actualItem.SellIn);
            Assert.AreEqual(expectedItem.Name, actualItem.Name);
            Assert.AreEqual(expectedItem.Quality, actualItem.Quality);
        }
    }
}