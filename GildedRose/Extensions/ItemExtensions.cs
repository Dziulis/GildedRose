namespace GildedRose.Extensions
{
    public static class ItemExtensions
    {
        public static ItemType GetItemType(this Item item)
        {
            if (item.Name.StartsWith("Conjured"))
            {
                return ItemType.Conjured;
            }

            if (item.Name.StartsWith("Backstage passes"))
            {
                return ItemType.BackStagePass;
            }

            if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                return ItemType.Sulfuras;
            }

            if (item.Name == "Aged Brie")
            {
                return ItemType.AgedBrie;
            }

            return ItemType.Other;
        }
    }
}
