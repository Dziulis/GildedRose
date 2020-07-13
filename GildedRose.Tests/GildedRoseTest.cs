using System.Collections.Generic;
using NUnit.Framework;

namespace GildedRose.Tests
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test]
        public void foo()
        {
            var Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            var app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual("fixme", Items[0].Name);
        }
    }
}