package com.gildedrose;

class GildedRose {

    Item[] items;

    public GildedRose(Item[] items) {
        this.items = items;
    }

    public static final String AGED_BRIE = "Aged Brie";
    public static final String SULFURAS = "Sulfuras, Hand of Ragnaros";
    public static final String PASSES_TAFKAL80ETC = "Backstage passes to a TAFKAL80ETC concert";

    public void updateQuality() {

        for (int i = 0; i < items.length; i++) {
            updateItem(i);
        }
    }

    private void updateItem(int i) {
        Item item = items[i];
        // "Aged Brie"
        // "Sulfuras, Hand of Ragnaros"
        // "Backstage passes to a TAFKAL80ETC concert"
        ItemUpdater updater;
        switch (items[i].name) {
            case AGED_BRIE:
                updater = new AgedBrieUpdater(item);
                break;
            case SULFURAS:
                updater = new SulfurasUpdater(item);
                break;
            case PASSES_TAFKAL80ETC:
                updater = new PassesUpdater(item);
                break;
            default:
                updater = new ItemUpdater(item);
                break;
        }
        updater.endOfDay();

    }

    private void updateItem_old(int i) {
        if (!items[i].name.equals("Aged Brie")
                && !items[i].name.equals("Backstage passes to a TAFKAL80ETC concert")) {
            if (items[i].quality > 0) {
                if (!items[i].name.equals("Sulfuras, Hand of Ragnaros")) {
                    items[i].quality = items[i].quality - 1;
                }
            }
        } else {
            if (items[i].quality < 50) {
                items[i].quality = items[i].quality + 1;

                if (items[i].name.equals("Backstage passes to a TAFKAL80ETC concert")) {
                    if (items[i].sellIn < 11) {
                        if (items[i].quality < 50) {
                            items[i].quality = items[i].quality + 1;
                        }
                    }

                    if (items[i].sellIn < 6) {
                        if (items[i].quality < 50) {
                            items[i].quality = items[i].quality + 1;
                        }
                    }
                }
            }
        }

        if (!items[i].name.equals("Sulfuras, Hand of Ragnaros")) {
            items[i].sellIn = items[i].sellIn - 1;
        }

        if (items[i].sellIn < 0) {
            if (!items[i].name.equals("Aged Brie")) {
                if (!items[i].name.equals("Backstage passes to a TAFKAL80ETC concert")) {
                    if (items[i].quality > 0) {
                        if (!items[i].name.equals("Sulfuras, Hand of Ragnaros")) {
                            items[i].quality = items[i].quality - 1;
                        }
                    }
                } else {
                    items[i].quality = items[i].quality - items[i].quality;
                }
            } else {
                if (items[i].quality < 50) {
                    items[i].quality = items[i].quality + 1;
                }
            }
        }
    }
}
