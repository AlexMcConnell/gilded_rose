package com.gildedrose;

import java.util.HashMap;
import java.util.Map;

public enum ItemAging {
    NORMAL_ITEM(null, (daysRemaining, quality) ->
            daysRemaining > 0  ? Math.max(quality - 1, 0) : Math.max(quality - 2, 0)),
    CONJURED_MANA_CAKE("Conjured Mana Cake", (daysRemaining, quality) ->
            daysRemaining > 0  ? Math.max(quality - 2, 0) : Math.max(quality - 4, 0)),
    AGED_BRIE("Aged Brie", (daysRemaining, quality) ->
            daysRemaining > 0  ? Math.min(quality + 1, 50) : Math.min(quality + 2, 50)),
    HAND_OF_RAGNAROS("Sulfuras, Hand of Ragnaros", (daysRemaining, quality) -> quality),
    BACKSTAGE_PASSES("Backstage passes to a TAFKAL80ETC concert", (daysRemaining, quality) -> {
        if (daysRemaining > 10) {
            return Math.min(quality + 1, 50);
        } else if (daysRemaining > 5) {
            return Math.min(quality + 2, 50);
        } else if (daysRemaining > 0) {
            return Math.min(quality + 3, 50);
        } else {
            return 0;
        }
    })
    ;

    private final String name;
    private final AgingFactor agingFactor;

    ItemAging(String name, AgingFactor agingFactor) {
        this.name = name;
        this.agingFactor = agingFactor;
    }

    private static Map<String, ItemAging> itemAgingMap = new HashMap<>();

    static {
        for (ItemAging aging : ItemAging.values()) {
            itemAgingMap.put(aging.name, aging);
        }
    }

    public static AgingFactor findAgingFactor(Item item) {
        ItemAging aging = itemAgingMap.get(item.name);
        return aging != null ? aging.agingFactor : NORMAL_ITEM.agingFactor;
    }
}
