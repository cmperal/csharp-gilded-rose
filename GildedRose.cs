using System.Collections.Generic;

namespace csharp
{
    public class GildedRose
    {
        readonly string agedBried = "Aged Brie";
        readonly string backstageTAFKAL80ETC = "Backstage passes to a TAFKAL80ETC concert";
        readonly string sulfuras = "Sulfuras, Hand of Ragnaros";
        readonly string conjured = "Conjured Mana Cake";
        readonly int maxQuality = 50;
        readonly int minQuality = 0;        

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
            item.SellIn--;

            if (item.Name == sulfuras)
                return;

            if (item.Name == backstageTAFKAL80ETC)
            {
                updateBackStageQuality(item);
                return;
            }

            if (item.Name == agedBried)
            {
                updateAgedBriedQuality(item);
                return;
            }

            if (item.Name == conjured) 
            {
                updateConjuredQuality(item);
                return;
            }

            updateOtherProductQuality(item);
        }

        private void updateBackStageQuality(Item item)
        {
            if (isExpired(item.SellIn))
            {
                item.Quality = 0;
                return;
            }

            var resultingQuality = (item.SellIn < 5 ? item.Quality += 3 :
                item.SellIn < 11 ? item.Quality += 2 :
                item.Quality);


            item.Quality = getMaxQuality(resultingQuality);
            
        }

        private void updateAgedBriedQuality(Item item)
        {
            if (isExpired(item.SellIn) && item.Quality < maxQuality)
            {
                item.Quality+=2;
                return;
            }

            item.Quality = getMaxQuality(item.Quality); 
        }

        private void updateOtherProductQuality(Item item) 
        {
            item.Quality--;

            if (isExpired(item.SellIn))
                item.Quality--;

            item.Quality = getMinQuality(item.Quality);
        }

        private void updateConjuredQuality(Item item) 
        {
            item.Quality -= 2;

            item.Quality = getMinQuality(item.Quality);
        }

        private int getMaxQuality(int quality)
        {
            return quality > maxQuality ? maxQuality : quality;
        }

        private int getMinQuality(int quality) 
        {
            return quality < minQuality ? minQuality : quality;
        }

        private bool isExpired(int sellIn)
        {
            return (sellIn < 0);
        }
    }
}
