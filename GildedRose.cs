using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        readonly string agedBried = "Aged Brie";
        readonly string backstageTAFKAL80ETC = "Backstage passes to a TAFKAL80ETC concert";
        readonly string sulfuras = "Sulfuras, Hand of Ragnaros";

        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                updateItem(item);
            }
        }

        private void updateItem(Item item)
        {
            if (item.Name == sulfuras)
                return;

            if (item.Name != agedBried && item.Name != backstageTAFKAL80ETC)
            {
                if (item.Quality > 0)
                {
                    item.Quality = addQuality(item.Quality, -1);
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality = addQuality(item.Quality, 1);

                    if (item.Name == backstageTAFKAL80ETC)
                    {
                        if (item.SellIn < 11)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = addQuality(item.Quality, 1);
                            }
                        }

                        if (item.SellIn < 6)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = addQuality(item.Quality, 1);
                            }
                        }
                    }
                }
            }

            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                if (item.Name != agedBried)
                {
                    if (item.Name != backstageTAFKAL80ETC)
                    {
                        if (item.Quality > 0)
                        {
                            item.Quality = item.Quality - 1;
                        }
                    }
                    else
                    {
                        item.Quality = item.Quality - item.Quality;
                    }
                }
                else
                {
                    if (item.Quality < 50)
                    {
                        item.Quality = item.Quality + 1;
                    }
                }
            }
        }

        private int addQuality(int currentQuality, int amount)
        {
            return currentQuality += amount;
        }
    }
}
