package com.gildedrose;

class GildedRose {

    public void processEndOfDay(Item item) {
        AgingFactor agingFactor = ItemAging.findAgingFactor(item);
        item.quality = agingFactor.dayPassed(item.daysRemaining, item.quality);

        if (!item.name.equals("Sulfuras, Hand of Ragnaros")) {
            item.daysRemaining = item.daysRemaining - 1;
        }
    }
}
