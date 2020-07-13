using System.Collections.Generic;
using GildedRose.Extensions;

namespace GildedRose
{
    public class GildedRose
    {
        IList<Item> Items;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public IList<Item> GetItems()
        {
            return Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                var itemType = item.GetItemType();

                switch (itemType)
                {
                    case ItemType.AgedBrie:
                        HandleAgedBrie(item);
                        break;

                    case ItemType.BackStagePass:
                        HandleBackStagePass(item);
                        break;

                    case ItemType.Conjured:
                        HandleConjured(item);
                        break;

                    case ItemType.Other:
                        HandleOther(item);
                        break;

                    case ItemType.Sulfuras:
                        HandleSulfuras(item);
                        break;
                }
            }
        }

        private void HandleAgedBrie(Item item)
        {
            IncreaseQuality(item);
            DecreaseSellIn(item);

            if (item.SellIn < 0)
            {
                IncreaseQuality(item);
            }
        }

        private void HandleBackStagePass(Item item)
        {
            throw new System.NotImplementedException();
        }

        private void HandleConjured(Item item)
        {
            throw new System.NotImplementedException();
        }

        private static void HandleOther(Item item)
        {
            DecreaseQuality(item);
            DecreaseSellIn(item);

            if (item.SellIn < 0)
            {
                DecreaseQuality(item);
            }
        }

        private static void HandleSulfuras(Item item)
        {
            return;
        }

        private static void DecreaseSellIn(Item item)
        {
            item.SellIn--;
        }

        private static void DecreaseQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality--;
            }
        }

        private static void IncreaseQuality(Item item)
        {
            if (item.Quality >= 50)
            {
                return;
            }

            item.Quality++;
        }

        public void UpdateQualityOld()
        {
            foreach (var item in Items)
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;

                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }
                    }
                }

                if (item.Name != "Sulfuras, Hand of Ragnaros")
                {
                    DecreaseSellIn(item);
                }

                if (item.SellIn < 0 && item.Name == "Backstage passes to a TAFKAL80ETC concert")
                {
                    item.Quality = item.Quality - item.Quality;
                }
            }
        }
    }
}
