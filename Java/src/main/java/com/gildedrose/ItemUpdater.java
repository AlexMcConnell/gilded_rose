package com.gildedrose;

public class ItemUpdater {

    Item item;
    
    public ItemUpdater(Item item){
        this.item = item;
    }
    
    public void endOfDay() {
        int qualityChange = -1;
        item.sellIn--;
        if (item.sellIn < 0) {
            qualityChange *= 2;
        }
        item.quality = Math.min(50, Math.max(0, item.quality + qualityChange));
    }
}
