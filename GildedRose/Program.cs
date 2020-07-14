using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            var items = SetupBasicItems();
            var app = new GildedRose(items);

            WriteOutput(app);
        }

        private static void WriteOutput(GildedRose gildedRose)
        {
            for (var i = 0; i < 31; i++)
            {
                var items = gildedRose.GetItems();

                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");

                foreach (var item in items)
                {
                    Console.WriteLine(item.Name + ", " + item.SellIn + ", " + item.Quality);
                }

                Console.WriteLine("");
                gildedRose.UpdateQuality();
            }
        }

        private static List<Item> SetupBasicItems()
        {
            return new List<Item>
            {
                new Item
                {
                    Name = "+5 Dexterity Vest",
                    SellIn = 10,
                    Quality = 20
                },
                new Item
                {
                    Name = "Aged Brie",
                    SellIn = 2,
                    Quality = 0
                },
                new Item
                {
                    Name = "Elixir of the Mongoose",
                    SellIn = 5,
                    Quality = 7
                },
                new Item
                {
                    Name = "Sulfuras, Hand of Ragnaros",
                    SellIn = 0,
                    Quality = 80
                },
                new Item
                {
                    Name = "Sulfuras, Hand of Ragnaros",
                    SellIn = -1,
                    Quality = 80
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
                new Item
                {
                    Name = "Conjured Mana Cake",
                    SellIn = 3,
                    Quality = 6
                }
            };
        }
    }
}
