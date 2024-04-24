using System.Collections.Generic;

namespace GildedRose;

public class GildedRose
{
    public void ProcessEndOfDay(IList<Item> items)
    {
        for (int i = 0; i < items.Count; i++)
        {
            ProcessItemsEndOfDay(items[i]);
        }
    }

    private void ProcessItemsEndOfDay(Item item)
    {
        if (item.Name != "Aged Cheddar" && item.Name != "Concert Tickets")
        {
            if (item.Quality > 0)
            {
                if (item.Name != "Hammer")
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
                if (item.Name == "Concert Tickets")
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

        if (item.Name != "Hammer")
        {
            item.DaysRemaining = item.DaysRemaining - 1;
        }

        if (item.DaysRemaining < 0)
        {
            if (item.Name != "Aged Cheddar")
            {
                if (item.Name != "Concert Tickets")
                {
                    if (item.Quality > 0)
                    {
                        if (item.Name != "Hammer")
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