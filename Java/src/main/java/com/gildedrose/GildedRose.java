package com.gildedrose;

import java.util.List;

public class GildedRose {
    public void processEndOfDay(Item[] items) {
        for (int i = 0; i < items.length; i++) {
            processEndOfDay(items[i]);
        }
    }

    public void processEndOfDay(Item item) {
        if (!item.name.equals("Aged Cheddar")
                && !item.name.equals("Concert Tickets")) {
            if (item.quality > 0) {
                if (!item.name.equals("Hammer")) {
                    item.quality = item.quality - 1;
                }
            }
        } else {
            if (item.quality < 50) {
                item.quality = item.quality + 1;

                if (item.name.equals("Concert Tickets")) {
                    if (item.daysRemaining < 11) {
                        if (item.quality < 50) {
                            item.quality = item.quality + 1;
                        }
                    }

                    if (item.daysRemaining < 6) {
                        if (item.quality < 50) {
                            item.quality = item.quality + 1;
                        }
                    }
                }
            }
        }

        if (!item.name.equals("Hammer")) {
            item.daysRemaining = item.daysRemaining - 1;
        }

        if (item.daysRemaining < 0) {
            if (!item.name.equals("Aged Cheddar")) {
                if (!item.name.equals("Concert Tickets")) {
                    if (item.quality > 0) {
                        if (!item.name.equals("Hammer")) {
                            item.quality = item.quality - 1;
                        }
                    }
                } else {
                    item.quality = item.quality - item.quality;
                }
            } else {
                if (item.quality < 50) {
                    item.quality = item.quality + 1;
                }
            }
        }
    }
}
