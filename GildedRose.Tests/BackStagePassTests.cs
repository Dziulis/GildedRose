using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Tests
{
    [TestFixture]
    public class BackStagePassTests
    {
        [Test]
        public void GivenBackStagePass_WhenOneDayPassesAndSellInAboveTen_ItemQualityIncreasedAndSellInDateDecreased()
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert", 
                    SellIn = 11, 
                    Quality = 20
                }
            };

            var app = new GildedRose(items);
            app.UpdateQuality();

            var expectedItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 10,
                Quality = 21
            };

            var actualItem = items.First();

            Assert.AreEqual(expectedItem.SellIn, actualItem.SellIn);
            Assert.AreEqual(expectedItem.Name, actualItem.Name);
            Assert.AreEqual(expectedItem.Quality, actualItem.Quality);
        }

        [Test]
        public void GivenBackStagePass_WhenOneDayPassesAndSellInAboveFiveAndBelowTen_ItemQualityIncreasedByTwoAndSellInDateDecreased()
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert", 
                    SellIn = 6, 
                    Quality = 20
                }
            };

            var app = new GildedRose(items);
            app.UpdateQuality();

            var expectedItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 5,
                Quality = 22
            };

            var actualItem = items.First();

            Assert.AreEqual(expectedItem.SellIn, actualItem.SellIn);
            Assert.AreEqual(expectedItem.Name, actualItem.Name);
            Assert.AreEqual(expectedItem.Quality, actualItem.Quality);
        }

        [Test]
        public void GivenBackStagePassWithQualityOfFifty_WhenOneDayPassesAndSellInAboveFiveAndBelowTen_ItemQualityNotIncreasedAndSellInDateDecreased()
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert", 
                    SellIn = 6, 
                    Quality = 50
                }
            };

            var app = new GildedRose(items);
            app.UpdateQuality();

            var expectedItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 5,
                Quality = 50
            };

            var actualItem = items.First();

            Assert.AreEqual(expectedItem.SellIn, actualItem.SellIn);
            Assert.AreEqual(expectedItem.Name, actualItem.Name);
            Assert.AreEqual(expectedItem.Quality, actualItem.Quality);
        }

        [Test]
        public void GivenBackStagePass_WhenOneDayPassesAndSellInAboveZeroAndBelowFive_ItemQualityIncreasedByThreeAndSellInDateDecreased()
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert", 
                    SellIn = 1, 
                    Quality = 20
                }
            };

            var app = new GildedRose(items);
            app.UpdateQuality();

            var expectedItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 0,
                Quality = 23
            };

            var actualItem = items.First();

            Assert.AreEqual(expectedItem.SellIn, actualItem.SellIn);
            Assert.AreEqual(expectedItem.Name, actualItem.Name);
            Assert.AreEqual(expectedItem.Quality, actualItem.Quality);
        }

        [Test]
        public void GivenBackStagePassWithQualityOfFifty_WhenOneDayPassesAndSellInAboveZeroAndBelowFive_ItemQualityNotIncreasedAndSellInDateDecreased()
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert", 
                    SellIn = 1, 
                    Quality = 50
                }
            };

            var app = new GildedRose(items);
            app.UpdateQuality();

            var expectedItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = 0,
                Quality = 50
            };

            var actualItem = items.First();

            Assert.AreEqual(expectedItem.SellIn, actualItem.SellIn);
            Assert.AreEqual(expectedItem.Name, actualItem.Name);
            Assert.AreEqual(expectedItem.Quality, actualItem.Quality);
        }

        [Test]
        public void GivenBackStagePassWithQualityOfFifty_WhenOneDayPassesAndSellInDateBelowZero_ItemQualitySetToZeroAndSellInDateDecreased()
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert", 
                    SellIn = 0, 
                    Quality = 50
                }
            };

            var app = new GildedRose(items);
            app.UpdateQuality();

            var expectedItem = new Item
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                SellIn = -1,
                Quality = 0
            };

            var actualItem = items.First();

            Assert.AreEqual(expectedItem.SellIn, actualItem.SellIn);
            Assert.AreEqual(expectedItem.Name, actualItem.Name);
            Assert.AreEqual(expectedItem.Quality, actualItem.Quality);
        }
    }
}