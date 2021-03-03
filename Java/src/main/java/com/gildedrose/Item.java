package com.gildedrose;

public class Item {
    
    public static final String AGED_BRIE = "Aged Brie";
    public static final String SULFURAS = "Sulfuras, Hand of Ragnaros";
    public static final String PASSES_TAFKAL80ETC = "Backstage passes to a TAFKAL80ETC concert";

    public String name;

    public int sellIn;

    public int quality;

    public Item(String name, int sellIn, int quality) {
        this.name = name;
        this.sellIn = sellIn;
        this.quality = quality;
    }

    @Override
    public String toString() {
        return this.name + ", " + this.sellIn + ", " + this.quality;
    }
    
    public void endOfDayUpdate(){
        // Select correct updater based on item name.
        ItemUpdater updater;
        switch (this.name) {
            case AGED_BRIE:
                updater = new AgedBrieUpdater(this);
                break;
            case SULFURAS:
                updater = new SulfurasUpdater(this);
                break;
            case PASSES_TAFKAL80ETC:
                updater = new PassesUpdater(this);
                break;
            default:
                updater = new ItemUpdater(this);
                break;
        }
        updater.endOfDayUpdate();
    }
}
