package com.gildedrose;

public class AgedBrieUpdater extends ItemUpdater {
    
    public AgedBrieUpdater(Item original){
        super(original);
    }

    @Override
    public void endOfDay() {
        item.sellIn--;
        int qualityChange = 1;
        if (item.sellIn < 0) {
            qualityChange *= 2;
        }
        item.quality = Math.min(50, Math.max(0, item.quality + qualityChange));
    }

}
