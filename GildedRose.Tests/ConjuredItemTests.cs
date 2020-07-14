using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Tests
{
    [TestFixture]
    public class ConjuredItemTests
    {
        [Test]
        public void GivenConjuredItem_WhenOneDayPassesAndSellInDateAboveZero_ItemQualityDecreasedByTwoAndSellInDateDecreased()
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Conjured Item", 
                    SellIn = 10, 
                    Quality = 20
                }
            };

            var app = new GildedRose(items);
            app.UpdateQuality();

            var expectedItem = new Item
            {
                Name = "Conjured Item",
                SellIn = 9,
                Quality = 18
            };

            var actualItem = app.GetItems().First();

            Assert.AreEqual(expectedItem.SellIn, actualItem.SellIn);
            Assert.AreEqual(expectedItem.Name, actualItem.Name);
            Assert.AreEqual(expectedItem.Quality, actualItem.Quality);
        }

        [Test]
        public void GivenConjuredItem_WhenOneDayPassesAndSellInDateBelowZero_ItemQualityDecreasedByFourAndSellInDateDecreased()
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Conjured Item", 
                    SellIn = 0, 
                    Quality = 20
                }
            };

            var app = new GildedRose(items);
            app.UpdateQuality();

            var expectedItem = new Item
            {
                Name = "Conjured Item",
                SellIn = -1,
                Quality = 16
            };

            var actualItem = app.GetItems().First();

            Assert.AreEqual(expectedItem.SellIn, actualItem.SellIn);
            Assert.AreEqual(expectedItem.Name, actualItem.Name);
            Assert.AreEqual(expectedItem.Quality, actualItem.Quality);
        }

        [Test]
        public void GivenConjuredItemWithQualityOfZero_WhenOneDayPassesAndSellInAboveZero_ItemQualityNotChangedAndSellInDateDecreased()
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Conjured Item", 
                    SellIn = 1, 
                    Quality = 0
                }
            };

            var app = new GildedRose(items);
            app.UpdateQuality();

            var expectedItem = new Item
            {
                Name = "Conjured Item",
                SellIn = 0,
                Quality = 0
            };

            var actualItem = app.GetItems().First();

            Assert.AreEqual(expectedItem.SellIn, actualItem.SellIn);
            Assert.AreEqual(expectedItem.Name, actualItem.Name);
            Assert.AreEqual(expectedItem.Quality, actualItem.Quality);
        }

        [Test]
        public void GivenConjuredItemWithQualityOfZero_WhenOneDayPassesAndSellInDateBelowZero_ItemQualityNotChangedAndSellInDateDecreased()
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Conjured Item", 
                    SellIn = 0, 
                    Quality = 0
                }
            };

            var app = new GildedRose(items);
            app.UpdateQuality();

            var expectedItem = new Item
            {
                Name = "Conjured Item",
                SellIn = -1,
                Quality = 0
            };

            var actualItem = app.GetItems().First();

            Assert.AreEqual(expectedItem.SellIn, actualItem.SellIn);
            Assert.AreEqual(expectedItem.Name, actualItem.Name);
            Assert.AreEqual(expectedItem.Quality, actualItem.Quality);
        }
    }
}