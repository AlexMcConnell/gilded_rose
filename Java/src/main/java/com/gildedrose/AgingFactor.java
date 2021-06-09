package com.gildedrose;

@FunctionalInterface
public interface AgingFactor {

    /**
     * Calculate the remaining quality after a day passes for an item.
     *
     * @param daysRemaining the item's current days remaining
     * @param quality the item's current quality
     * @return the new quality for the item
     */
    int dayPassed(int daysRemaining, int quality);
}
