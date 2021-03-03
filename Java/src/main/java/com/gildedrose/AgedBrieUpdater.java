package com.gildedrose;

public class AgedBrieUpdater extends ItemUpdater {
    
    public AgedBrieUpdater(Item original){
        super(original);
    }

    @Override
    protected void updateQuality() {
        if (item.sellIn < 0) {
            item.quality += 2;
        }else{
            item.quality += 1;
        }
    }
}
