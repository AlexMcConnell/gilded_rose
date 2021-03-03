package com.gildedrose;

public class SulfurasUpdater extends ItemUpdater {

    public SulfurasUpdater(Item original) {
        super(original);
    }

    @Override
    protected void updateSellIn() {
    }

    @Override
    protected void updateQuality() {
    }
    
    @Override
    protected void clampQuality(){
        item.quality = 80;
    }
}
