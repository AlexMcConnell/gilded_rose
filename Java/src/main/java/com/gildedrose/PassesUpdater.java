package com.gildedrose;

public class PassesUpdater extends ItemUpdater {

    public PassesUpdater(Item original) {
        super(original);
    }

    @Override
    protected void updateQuality() {
        if (item.sellIn < 0) {
            item.quality = 0;
        } else if (item.sellIn < 5) {
            item.quality += 3;
        } else if (item.sellIn < 10) {
            item.quality += 2;
        } else {
            item.quality += 1;
        }
    }
}
