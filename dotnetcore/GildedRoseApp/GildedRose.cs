namespace ConsoleApplication {
    using System;
    using System.Collections.Generic;

    public class GildedRose {
        public static void Main(string[] args) {
            // This method is not used in this exercise.
            // Please ignore it. 
        }

        public void ProcessEndOfDay(IList<Item> items) {
            for (int i = 0; i < items.Count; i++) {
                ProcessEndOfDay(items[i]);
            }
        }

        public void ProcessEndOfDay(Item item) {
        // "Conjured Mana Cake": quality degrades by 2 per day before the days remaining date has passed and by 4 after. Its days remaining decreases by one every day. Its quality can never decrease to less than 0.

            switch(item.Name) {
                case "Conjured Mana Cake":
                    item.DecrementDaysRemaining();
                    if (item.Quality > 0) {
                        if (item.DaysRemaining < 0) {
                            item.DecrementQuality(4);
                        } else {
                            item.DecrementQuality(2);
                        }

                        if (item.Quality < 0) {
                            item.SpoilQuality();
                        }
                    }
                break;

                case "Aged Brie":
                    item.IncrementQuality();
                    item.DecrementDaysRemaining();
                    if (item.DaysRemaining < 0) {
                        item.IncrementQuality();
                    }

                break;

                case "Backstage passes to a TAFKAL80ETC concert":
                    item.IncrementQuality();
                    if (item.DaysRemaining < 11) {
                        item.IncrementQuality();
                    }

                    if (item.DaysRemaining < 6) {
                        item.IncrementQuality();
                    }

                    item.DecrementDaysRemaining();
                    if (item.DaysRemaining < 0) {
                        item.SpoilQuality();
                    }

                break;

                case "Sulfuras, Hand of Ragnaros":
                break;

                default:
                    if (item.Quality > 0) {
                        item.DecrementQuality();
                    }
                    item.DecrementDaysRemaining();
                    if (item.DaysRemaining < 0) {
                        if (item.Quality > 0) {
                            item.DecrementQuality();
                        }
                    }

                break;
            }
        }
    }
}
