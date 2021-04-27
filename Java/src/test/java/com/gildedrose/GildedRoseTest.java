package com.gildedrose;

import org.junit.jupiter.api.Disabled;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

class GildedRoseTest {
    @Test
    void normalItem_BeforeSellDate() {
        Item item = new Item("foo", 5, 10);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(4, item.sellIn);
        assertEquals(9, item.quality);
    }

    @Test
    void normalItem_WithMinQuality() {
        Item item = new Item("foo", 5, 0);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(4, item.sellIn);
        assertEquals(0, item.quality);
    }

    @Test
    void normalItem_OnSellDate() {
        Item item = new Item("foo", 0, 10);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(-1, item.sellIn);
        assertEquals(8, item.quality);
    }

    @Test
    void normalItem_OnSellDateWithMinQuality() {
        Item item = new Item("foo", 0, 0);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(-1, item.sellIn);
        assertEquals(0, item.quality);
    }

    @Test
    void normalItem_OnSellDateNearMinQuality() {
        Item item = new Item("foo", 0, 1);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(-1, item.sellIn);
        assertEquals(0, item.quality);
    }

    @Test
    void normalItem_AfterSellDate() {
        Item item = new Item("foo", -10, 10);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(-11, item.sellIn);
        assertEquals(8, item.quality);
    }

    @Test
    void normalItem_AfterSellDateWithMinQuality() {
        Item item = new Item("foo", -10, 0);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(-11, item.sellIn);
        assertEquals(0, item.quality);
    }

    @Test
    void normalItem_AfterSellDateNearMinQuality() {
        Item item = new Item("foo", -10, 1);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(-11, item.sellIn);
        assertEquals(0, item.quality);
    }

    @Test
    void agedBrie_BeforeSellDate() {
        Item item = new Item("Aged Brie", 5, 10);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(4, item.sellIn);
        assertEquals(11, item.quality);
    }

    @Test
    void agedBrie_WithMaxQuality() {
        Item item = new Item("Aged Brie", 5, 50);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(4, item.sellIn);
        assertEquals(50, item.quality);
    }

    @Test
    void agedBrie_OnSellDate() {
        Item item = new Item("Aged Brie", 0, 10);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(-1, item.sellIn);
        assertEquals(12, item.quality);
    }

    @Test
    void agedBrie_OnSellDateWithMaxQuality() {
        Item item = new Item("Aged Brie", 0, 50);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(-1, item.sellIn);
        assertEquals(50, item.quality);
    }

    @Test
    void agedBrie_OnSellDateNearMaxQuality() {
        Item item = new Item("Aged Brie", 0, 49);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(-1, item.sellIn);
        assertEquals(50, item.quality);
    }

    @Test
    void agedBrie_AfterSellDate() {
        Item item = new Item("Aged Brie", -10, 10);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(-11, item.sellIn);
        assertEquals(12, item.quality);
    }

    @Test
    void agedBrie_AfterSellDateWithMaxQuality() {
        Item item = new Item("Aged Brie", -10, 50);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(-11, item.sellIn);
        assertEquals(50, item.quality);
    }

    @Test
    void agedBrie_AfterSellDateNearMaxQuality() {
        Item item = new Item("Aged Brie", -10, 49);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(-11, item.sellIn);
        assertEquals(50, item.quality);
    }

    @Test
    void sulfuras_BeforeSellDate() {
        Item item = new Item("Sulfuras, Hand of Ragnaros", 5, 80);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(5, item.sellIn);
        assertEquals(80, item.quality);
    }

    @Test
    void sulfuras_OnSellDate() {
        Item item = new Item("Sulfuras, Hand of Ragnaros", 0, 80);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(0, item.sellIn);
        assertEquals(80, item.quality);
    }

    @Test
    void sulfuras_AfterSellDate() {
        Item item = new Item("Sulfuras, Hand of Ragnaros", -10, 80);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(-10, item.sellIn);
        assertEquals(80, item.quality);
    }

    @Test
    void backstagePass_LongBeforeSellDate() {
        Item item = new Item("Backstage passes to a TAFKAL80ETC concert", 11, 10);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(10, item.sellIn);
        assertEquals(11, item.quality);
    }

    @Test
    void backstagePass_LongBeforeSellDateAtMaxQuality() {
        Item item = new Item("Backstage passes to a TAFKAL80ETC concert", 11, 50);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(10, item.sellIn);
        assertEquals(50, item.quality);
    }

    @Test
    void backstagePass_MediumCloseToSellDateUpperBound() {
        Item item = new Item("Backstage passes to a TAFKAL80ETC concert", 10, 10);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(9, item.sellIn);
        assertEquals(12, item.quality);
    }

    @Test
    void backstagePass_MediumCloseToSellDateUpperBoundAtMaxQuality() {
        Item item = new Item("Backstage passes to a TAFKAL80ETC concert", 10, 50);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(9, item.sellIn);
        assertEquals(50, item.quality);
    }

    @Test
    void backstagePass_MediumCloseToSellDateUpperBoundNearMaxQuality() {
        Item item = new Item("Backstage passes to a TAFKAL80ETC concert", 10, 49);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(9, item.sellIn);
        assertEquals(50, item.quality);
    }

    @Test
    void backstagePass_MediumCloseToSellDateLowerBound() {
        Item item = new Item("Backstage passes to a TAFKAL80ETC concert", 6, 10);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(5, item.sellIn);
        assertEquals(12, item.quality);
    }

    @Test
    void backstagePass_MediumCloseToSellDateLowerBoundAtMaxQuality() {
        Item item = new Item("Backstage passes to a TAFKAL80ETC concert", 6, 50);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(5, item.sellIn);
        assertEquals(50, item.quality);
    }

    @Test
    void backstagePass_MediumCloseToSellDateLowerBoundNearMaxQuality() {
        Item item = new Item("Backstage passes to a TAFKAL80ETC concert", 6, 49);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(5, item.sellIn);
        assertEquals(50, item.quality);
    }

    @Test
    void backstagePass_VeryCloseToSellDateUpperBound() {
        Item item = new Item("Backstage passes to a TAFKAL80ETC concert", 5, 10);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(4, item.sellIn);
        assertEquals(13, item.quality);
    }

    @Test
    void backstagePass_VeryCloseToSellDateUpperBoundAtMaxQuality() {
        Item item = new Item("Backstage passes to a TAFKAL80ETC concert", 5, 50);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(4, item.sellIn);
        assertEquals(50, item.quality);
    }

    @Test
    void backstagePass_VeryCloseToSellDateUpperBoundNearMaxQuality() {
        Item item = new Item("Backstage passes to a TAFKAL80ETC concert", 5, 48);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(4, item.sellIn);
        assertEquals(50, item.quality);
    }

    @Test
    void backstagePass_VeryCloseToSellDateLowerBound() {
        Item item = new Item("Backstage passes to a TAFKAL80ETC concert", 1, 10);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(0, item.sellIn);
        assertEquals(13, item.quality);
    }

    @Test
    void backstagePass_VeryCloseToSellDateLowerBoundAtMaxQuality() {
        Item item = new Item("Backstage passes to a TAFKAL80ETC concert", 1, 50);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(0, item.sellIn);
        assertEquals(50, item.quality);
    }

    @Test
    void backstagePass_VeryCloseToSellDateLowerBoundNearMaxQuality() {
        Item item = new Item("Backstage passes to a TAFKAL80ETC concert", 1, 48);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(0, item.sellIn);
        assertEquals(50, item.quality);
    }

    @Test
    void backstagePass_OnSellDate() {
        Item item = new Item("Backstage passes to a TAFKAL80ETC concert", 0, 10);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(-1, item.sellIn);
        assertEquals(0, item.quality);
    }

    @Test
    void backstagePass_AfterSellDate() {
        Item item = new Item("Backstage passes to a TAFKAL80ETC concert", -10, 10);
        GildedRose app = new GildedRose();
        app.updateQuality(item);
        assertEquals(-11, item.sellIn);
        assertEquals(0, item.quality);
    }
}
