package com.gildedrose;

public class SulfurasUpdater extends ItemUpdater {

    public SulfurasUpdater(Item original) {
        super(original);
    }

    @Override
    protected void updateSellIn() {
        // Intentially blank. Item does not change SellIn time.
    }

    @Override
    protected void updateQuality() {
        // Intentially blank. Item does not change quality.
    }

    @Override
    protected void clampQuality() {
        // Always a set quality
        item.quality = 80;
    }
}
