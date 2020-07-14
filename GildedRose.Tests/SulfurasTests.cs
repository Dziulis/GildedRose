using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace GildedRose.Tests
{
    [TestFixture]
    public class SulfurasTests
    {
        [Test]
        public void GivenSulfuras_WhenOneDayPasses_NothingChangedInTheItem()
        {
            var items = new List<Item>
            {
                new Item
                {
                    Name = "Sulfuras, Hand of Ragnaros",
                    SellIn = 10,
                    Quality = 80
                }
            };

            var app = new GildedRose(items);
            app.UpdateQuality();

            var expectedItem = new Item
            {
                Name = "Sulfuras, Hand of Ragnaros",
                SellIn = 10,
                Quality = 80
            };

            var actualItem = app.GetItems().First();

            Assert.AreEqual(expectedItem.SellIn, actualItem.SellIn);
            Assert.AreEqual(expectedItem.Name, actualItem.Name);
            Assert.AreEqual(expectedItem.Quality, actualItem.Quality);
        }
    }
}