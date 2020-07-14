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
            IncreaseQuality(item);
            DecreaseSellIn(item);

            if (item.SellIn < 0)
            {
                DecreaseQuality(item, item.Quality);
                return;
            }

            if (item.SellIn < 5)
            {
                IncreaseQuality(item, 2);
                return;
            }

            if (item.SellIn < 10)
            {
                IncreaseQuality(item);
            }
        }

        private void HandleConjured(Item item)
        {
            DecreaseQuality(item, 2);
            DecreaseSellIn(item);

            if (item.SellIn < 0)
            {
                DecreaseQuality(item, 2);
            }
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

        private static void DecreaseQuality(Item item, int amount = 1)
        {
            if (item.Quality > 0)
            {
                item.Quality -= amount;
            }
        }

        private static void IncreaseQuality(Item item, int amount = 1)
        {
            if (item.Quality >= 50)
            {
                return;
            }

            item.Quality += amount;
        }
    }
}
