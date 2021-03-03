package com.gildedrose;

public class ItemUpdater {

    Item item;

    public ItemUpdater(Item item) {
        this.item = item;
    }

    public final void endOfDayUpdate() {
        updateSellIn();
        updateQuality();
        clampQuality();
    }

    protected void updateSellIn() {
        item.sellIn--;
    }

    protected void updateQuality() {
        if (item.sellIn < 0) {
            item.quality -= 2;
        } else {
            item.quality -= 1;
        }
    }

    protected void clampQuality() {
        item.quality = Math.min(50, Math.max(0, item.quality));
    }
}
