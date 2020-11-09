package com.gildedrose;

import org.junit.jupiter.api.Disabled;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

class GildedRoseTest {
    @Test
    void normalItem_BeforeSellDate() {
        Item[] items = new Item[] { new Item("foo", 5, 10) };
        GildedRose app = new GildedRose(items);
        app.updateQuality();
        assertEquals(4, app.items[0].sellIn);
        assertEquals(9, app.items[0].quality);
    }

    @Test
    void normalItem_OnSellDate() {
        Item[] items = new Item[] { new Item("foo", 0, 10) };
        GildedRose app = new GildedRose(items);
        app.updateQuality();
        assertEquals(-1, app.items[0].sellIn);
        assertEquals(8, app.items[0].quality);
    }

    @Test
    void normalItem_AfterSellDate() {
        Item[] items = new Item[] { new Item("foo", -10, 10) };
        GildedRose app = new GildedRose(items);
        app.updateQuality();
        assertEquals(-11, app.items[0].sellIn);
        assertEquals(8, app.items[0].quality);
    }

    @Test
    void normalItem_OfZeroQuality() {
        Item[] items = new Item[] { new Item("foo", 5, 0) };
        GildedRose app = new GildedRose(items);
        app.updateQuality();
        assertEquals(4, app.items[0].sellIn);
        assertEquals(0, app.items[0].quality);
    }

    @Test
    void agedBrie_BeforeSellDate() {
        Item[] items = new Item[] { new Item("Aged Brie", 5, 10) };
        GildedRose app = new GildedRose(items);
        app.updateQuality();
        assertEquals(4, app.items[0].sellIn);
        assertEquals(11, app.items[0].quality);
    }

    @Test
    void agedBrie_WithMaxQuality() {
        Item[] items = new Item[] { new Item("Aged Brie", 5, 50) };
        GildedRose app = new GildedRose(items);
        app.updateQuality();
        assertEquals(4, app.items[0].sellIn);
        assertEquals(50, app.items[0].quality);
    }

    @Test
    void agedBrie_OnSellDate() {
        Item[] items = new Item[] { new Item("Aged Brie", 0, 10) };
        GildedRose app = new GildedRose(items);
        app.updateQuality();
        assertEquals(-1, app.items[0].sellIn);
        assertEquals(12, app.items[0].quality);
    }

    @Test
    void agedBrie_OnSellDateNearMaxQuality() {
        Item[] items = new Item[] { new Item("Aged Brie", 0, 49) };
        GildedRose app = new GildedRose(items);
        app.updateQuality();
        assertEquals(-1, app.items[0].sellIn);
        assertEquals(50, app.items[0].quality);
    }

    @Test
    void agedBrie_OnSellDateWithMaxQuality() {
        Item[] items = new Item[] { new Item("Aged Brie", 0, 50) };
        GildedRose app = new GildedRose(items);
        app.updateQuality();
        assertEquals(-1, app.items[0].sellIn);
        assertEquals(50, app.items[0].quality);
    }

    @Test
    void agedBrie_AfterSellDate() {
        Item[] items = new Item[] { new Item("Aged Brie", -10, 10) };
        GildedRose app = new GildedRose(items);
        app.updateQuality();
        assertEquals(-11, app.items[0].sellIn);
        assertEquals(12, app.items[0].quality);
    }

    @Test
    void agedBrie_AfterSellDateWithMaxQuality() {
        Item[] items = new Item[] { new Item("Aged Brie", -10, 50) };
        GildedRose app = new GildedRose(items);
        app.updateQuality();
        assertEquals(-11, app.items[0].sellIn);
        assertEquals(50, app.items[0].quality);
    }

    @Test
    void sulfuras_BeforeSellDate() {
        Item[] items = new Item[] { new Item("Sulfuras, Hand of Ragnaros", 5, 80) };
        GildedRose app = new GildedRose(items);
        app.updateQuality();
        assertEquals(5, app.items[0].sellIn);
        assertEquals(80, app.items[0].quality);
    }

    @Test
    void sulfuras_OnSellDate() {
        Item[] items = new Item[] { new Item("Sulfuras, Hand of Ragnaros", 0, 80) };
        GildedRose app = new GildedRose(items);
        app.updateQuality();
        assertEquals(0, app.items[0].sellIn);
        assertEquals(80, app.items[0].quality);
    }

    @Test
    void sulfuras_AfterSellDate() {
        Item[] items = new Item[] { new Item("Sulfuras, Hand of Ragnaros", -10, 80) };
        GildedRose app = new GildedRose(items);
        app.updateQuality();
        assertEquals(-10, app.items[0].sellIn);
        assertEquals(80, app.items[0].quality);
    }

    @Test
    void backstagePass_LongBeforeSellDate() {
        Item[] items = new Item[] { new Item("Backstage passes to a TAFKAL80ETC concert", 11, 10) };
        GildedRose app = new GildedRose(items);
        app.updateQuality();
        assertEquals(10, app.items[0].sellIn);
        assertEquals(11, app.items[0].quality);
    }

    @Test
    void backstagePass_LongBeforeSellDateAtMaxQuality() {
        Item[] items = new Item[] { new Item("Backstage passes to a TAFKAL80ETC concert", 11, 50) };
        GildedRose app = new GildedRose(items);
        app.updateQuality();
        assertEquals(10, app.items[0].sellIn);
        assertEquals(50, app.items[0].quality);
    }

    @Test
    void backstagePass_MediumCloseToSellDateUpperBound() {
        Item[] items = new Item[] { new Item("Backstage passes to a TAFKAL80ETC concert", 10, 10) };
        GildedRose app = new GildedRose(items);
        app.updateQuality();
        assertEquals(9, app.items[0].sellIn);
        assertEquals(12, app.items[0].quality);
    }

    @Test
    void backstagePass_MediumCloseToSellDateUpperBoundAtMaxQuality() {
        Item[] items = new Item[] { new Item("Backstage passes to a TAFKAL80ETC concert", 10, 50) };
        GildedRose app = new GildedRose(items);
        app.updateQuality();
        assertEquals(9, app.items[0].sellIn);
        assertEquals(50, app.items[0].quality);
    }

    @Test
    void backstagePass_MediumCloseToSellDateLowerBound() {
        Item[] items = new Item[] { new Item("Backstage passes to a TAFKAL80ETC concert", 6, 10) };
        GildedRose app = new GildedRose(items);
        app.updateQuality();
        assertEquals(5, app.items[0].sellIn);
        assertEquals(12, app.items[0].quality);
    }

    @Test
    void backstagePass_MediumCloseToSellDateLowerBoundAtMaxQuality() {
        Item[] items = new Item[] { new Item("Backstage passes to a TAFKAL80ETC concert", 6, 50) };
        GildedRose app = new GildedRose(items);
        app.updateQuality();
        assertEquals(5, app.items[0].sellIn);
        assertEquals(50, app.items[0].quality);
    }

    @Test
    void backstagePass_VeryCloseToSellDateUpperBound() {
        Item[] items = new Item[] { new Item("Backstage passes to a TAFKAL80ETC concert", 5, 10) };
        GildedRose app = new GildedRose(items);
        app.updateQuality();
        assertEquals(4, app.items[0].sellIn);
        assertEquals(13, app.items[0].quality);
    }

    @Test
    void backstagePass_VeryCloseToSellDateUpperBoundAtMaxQuality() {
        Item[] items = new Item[] { new Item("Backstage passes to a TAFKAL80ETC concert", 5, 50) };
        GildedRose app = new GildedRose(items);
        app.updateQuality();
        assertEquals(4, app.items[0].sellIn);
        assertEquals(50, app.items[0].quality);
    }

    @Test
    void backstagePass_VeryCloseToSellDateLowerBound() {
        Item[] items = new Item[] { new Item("Backstage passes to a TAFKAL80ETC concert", 1, 10) };
        GildedRose app = new GildedRose(items);
        app.updateQuality();
        assertEquals(0, app.items[0].sellIn);
        assertEquals(13, app.items[0].quality);
    }

    @Test
    void backstagePass_VeryCloseToSellDateLowerBoundAtMaxQuality() {
        Item[] items = new Item[] { new Item("Backstage passes to a TAFKAL80ETC concert", 1, 50) };
        GildedRose app = new GildedRose(items);
        app.updateQuality();
        assertEquals(0, app.items[0].sellIn);
        assertEquals(50, app.items[0].quality);
    }

    @Test
    void backstagePass_OnSellDate() {
        Item[] items = new Item[] { new Item("Backstage passes to a TAFKAL80ETC concert", 0, 10) };
        GildedRose app = new GildedRose(items);
        app.updateQuality();
        assertEquals(-1, app.items[0].sellIn);
        assertEquals(0, app.items[0].quality);
    }

    @Test
    void backstagePass_AfterSellDate() {
        Item[] items = new Item[] { new Item("Backstage passes to a TAFKAL80ETC concert", -10, 10) };
        GildedRose app = new GildedRose(items);
        app.updateQuality();
        assertEquals(-11, app.items[0].sellIn);
        assertEquals(0, app.items[0].quality);
    }

    @Test
    @Disabled
    void conjuredMana_BeforeSellDate() {
        Item[] items = new Item[] { new Item("Conjured Mana Cake", 5, 10) };
        GildedRose app = new GildedRose(items);
        app.updateQuality();
        assertEquals(4, app.items[0].sellIn);
        assertEquals(8, app.items[0].quality);
    }

    @Test
    @Disabled
    void conjuredMana_BeforeSellDateAtZeroQuality() {
        Item[] items = new Item[] { new Item("Conjured Mana Cake", 5, 0) };
        GildedRose app = new GildedRose(items);
        app.updateQuality();
        assertEquals(4, app.items[0].sellIn);
        assertEquals(0, app.items[0].quality);
    }

    @Test
    @Disabled
    void conjuredMana_OnSellDate() {
        Item[] items = new Item[] { new Item("Conjured Mana Cake", 0, 10) };
        GildedRose app = new GildedRose(items);
        app.updateQuality();
        assertEquals(-1, app.items[0].sellIn);
        assertEquals(6, app.items[0].quality);
    }

    @Test
    @Disabled
    void conjuredMana_OnSellDateAtZeroQuality() {
        Item[] items = new Item[] { new Item("Conjured Mana Cake", 0, 0) };
        GildedRose app = new GildedRose(items);
        app.updateQuality();
        assertEquals(-1, app.items[0].sellIn);
        assertEquals(0, app.items[0].quality);
    }

    @Test
    @Disabled
    void conjuredMana_AfterSellDate() {
        Item[] items = new Item[] { new Item("Conjured Mana Cake", -10, 10) };
        GildedRose app = new GildedRose(items);
        app.updateQuality();
        assertEquals(-11, app.items[0].sellIn);
        assertEquals(6, app.items[0].quality);
    }

    @Test
    @Disabled
    void conjuredMana_AfterSellDateAtZeroQuality() {
        Item[] items = new Item[] { new Item("Conjured Mana Cake", -10, 0) };
        GildedRose app = new GildedRose(items);
        app.updateQuality();
        assertEquals(-11, app.items[0].sellIn);
        assertEquals(0, app.items[0].quality);
    }
}
