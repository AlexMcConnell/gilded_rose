using System;
using System.Collections.Generic;
namespace ConsoleApplication
{
    public class GildedRose
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Dummy Main");
        }

        public void ProcessEndOfDay(IList<Item> items)
        {
            for (int i = 0; i < items.Count; i++) {
                ProcessEndOfDay(items[i]);
            }
        }

        public void ProcessEndOfDay(Item item)
        {
            if (item.Name != "Aged Brie" && item.Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (item.Quality > 0)
                {
                    if (item.Name != "Sulfuras, Hand of Ragnaros")
                    {
                        item.Quality = item.Quality - 1;
                    }
                }
            }
            else
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                    if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.DaysRemaining < 11)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }
                        if (item.DaysRemaining < 6)
                        {
                            if (item.Quality < 50)
                            {
                                item.Quality = item.Quality + 1;
                            }
                        }
                    }
                }
            }
            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.DaysRemaining = item.DaysRemaining - 1;
            }
            if (item.DaysRemaining < 0)
            {
                if (item.Name != "Aged Brie")
                {
                    if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (item.Quality > 0)
                        {
                            if (item.Name != "Sulfuras, Hand of Ragnaros")
                            {
                                item.Quality = item.Quality - 1;
                            }
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
    }
}
