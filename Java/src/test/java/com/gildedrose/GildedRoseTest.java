package com.gildedrose;

import org.junit.jupiter.api.Test;

import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import static org.junit.jupiter.api.Assertions.assertEquals;

class GildedRoseTest {
    @Test
    void normalItem_BeforeSellDate() {
        Item[] items = {new Item("foo", 5, 10)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(4, items[0].daysRemaining);
        assertEquals(9, items[0].quality);
    }

    @Test
    void normalItem_WithMinQuality() {
        Item[] items = {new Item("foo", 5, 0)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(4, items[0].daysRemaining);
        assertEquals(0, items[0].quality);
    }

    @Test
    void normalItem_OnSellDate() {
        Item[] items = {new Item("foo", 0, 10)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(-1, items[0].daysRemaining);
        assertEquals(8, items[0].quality);
    }

    @Test
    void normalItem_OnSellDateWithMinQuality() {
        Item[] items = {new Item("foo", 0, 0)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(-1, items[0].daysRemaining);
        assertEquals(0, items[0].quality);
    }

    @Test
    void normalItem_OnSellDateNearMinQuality() {
        Item[] items = {new Item("foo", 0, 1)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(-1, items[0].daysRemaining);
        assertEquals(0, items[0].quality);
    }

    @Test
    void normalItem_AfterSellDate() {
        Item[] items = {new Item("foo", -10, 10)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(-11, items[0].daysRemaining);
        assertEquals(8, items[0].quality);
    }

    @Test
    void normalItem_AfterSellDateWithMinQuality() {
        Item[] items = {new Item("foo", -10, 0)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(-11, items[0].daysRemaining);
        assertEquals(0, items[0].quality);
    }

    @Test
    void normalItem_AfterSellDateNearMinQuality() {
        Item[] items = {new Item("foo", -10, 1)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(-11, items[0].daysRemaining);
        assertEquals(0, items[0].quality);
    }

    @Test
    void agedBrie_BeforeSellDate() {
        Item[] items = {new Item("Aged Brie", 5, 10)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(4, items[0].daysRemaining);
        assertEquals(11, items[0].quality);
    }

    @Test
    void agedBrie_WithMaxQuality() {
        Item[] items = {new Item("Aged Brie", 5, 50)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(4, items[0].daysRemaining);
        assertEquals(50, items[0].quality);
    }

    @Test
    void agedBrie_OnSellDate() {
        Item[] items = {new Item("Aged Brie", 0, 10)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(-1, items[0].daysRemaining);
        assertEquals(12, items[0].quality);
    }

    @Test
    void agedBrie_OnSellDateWithMaxQuality() {
        Item[] items = {new Item("Aged Brie", 0, 50)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(-1, items[0].daysRemaining);
        assertEquals(50, items[0].quality);
    }

    @Test
    void agedBrie_OnSellDateNearMaxQuality() {
        Item[] items = {new Item("Aged Brie", 0, 49)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(-1, items[0].daysRemaining);
        assertEquals(50, items[0].quality);
    }

    @Test
    void agedBrie_AfterSellDate() {
        Item[] items = {new Item("Aged Brie", -10, 10)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(-11, items[0].daysRemaining);
        assertEquals(12, items[0].quality);
    }

    @Test
    void agedBrie_AfterSellDateWithMaxQuality() {
        Item[] items = {new Item("Aged Brie", -10, 50)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(-11, items[0].daysRemaining);
        assertEquals(50, items[0].quality);
    }

    @Test
    void agedBrie_AfterSellDateNearMaxQuality() {
        Item[] items = {new Item("Aged Brie", -10, 49)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(-11, items[0].daysRemaining);
        assertEquals(50, items[0].quality);
    }

    @Test
    void sulfuras_BeforeSellDate() {
        Item[] items = {new Item("Sulfuras, Hand of Ragnaros", 5, 80)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(5, items[0].daysRemaining);
        assertEquals(80, items[0].quality);
    }

    @Test
    void sulfuras_OnSellDate() {
        Item[] items = {new Item("Sulfuras, Hand of Ragnaros", 0, 80)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(0, items[0].daysRemaining);
        assertEquals(80, items[0].quality);
    }

    @Test
    void sulfuras_AfterSellDate() {
        Item[] items = {new Item("Sulfuras, Hand of Ragnaros", -10, 80)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(-10, items[0].daysRemaining);
        assertEquals(80, items[0].quality);
    }

    @Test
    void backstagePass_LongBeforeSellDate() {
        Item[] items = {new Item("Backstage passes to a TAFKAL80ETC concert", 11, 10)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(10, items[0].daysRemaining);
        assertEquals(11, items[0].quality);
    }

    @Test
    void backstagePass_LongBeforeSellDateAtMaxQuality() {
        Item[] items = {new Item("Backstage passes to a TAFKAL80ETC concert", 11, 50)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(10, items[0].daysRemaining);
        assertEquals(50, items[0].quality);
    }

    @Test
    void backstagePass_MediumCloseToSellDateUpperBound() {
        Item[] items = {new Item("Backstage passes to a TAFKAL80ETC concert", 10, 10)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(9, items[0].daysRemaining);
        assertEquals(12, items[0].quality);
    }

    @Test
    void backstagePass_MediumCloseToSellDateUpperBoundAtMaxQuality() {
        Item[] items = {new Item("Backstage passes to a TAFKAL80ETC concert", 10, 50)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(9, items[0].daysRemaining);
        assertEquals(50, items[0].quality);
    }

    @Test
    void backstagePass_MediumCloseToSellDateUpperBoundNearMaxQuality() {
        Item[] items = {new Item("Backstage passes to a TAFKAL80ETC concert", 10, 49)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(9, items[0].daysRemaining);
        assertEquals(50, items[0].quality);
    }

    @Test
    void backstagePass_MediumCloseToSellDateLowerBound() {
        Item[] items = {new Item("Backstage passes to a TAFKAL80ETC concert", 6, 10)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(5, items[0].daysRemaining);
        assertEquals(12, items[0].quality);
    }

    @Test
    void backstagePass_MediumCloseToSellDateLowerBoundAtMaxQuality() {
        Item[] items = {new Item("Backstage passes to a TAFKAL80ETC concert", 6, 50)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(5, items[0].daysRemaining);
        assertEquals(50, items[0].quality);
    }

    @Test
    void backstagePass_MediumCloseToSellDateLowerBoundNearMaxQuality() {
        Item[] items = {new Item("Backstage passes to a TAFKAL80ETC concert", 6, 49)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(5, items[0].daysRemaining);
        assertEquals(50, items[0].quality);
    }

    @Test
    void backstagePass_VeryCloseToSellDateUpperBound() {
        Item[] items = {new Item("Backstage passes to a TAFKAL80ETC concert", 5, 10)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(4, items[0].daysRemaining);
        assertEquals(13, items[0].quality);
    }

    @Test
    void backstagePass_VeryCloseToSellDateUpperBoundAtMaxQuality() {
        Item[] items = {new Item("Backstage passes to a TAFKAL80ETC concert", 5, 50)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(4, items[0].daysRemaining);
        assertEquals(50, items[0].quality);
    }

    @Test
    void backstagePass_VeryCloseToSellDateUpperBoundNearMaxQuality() {
        Item[] items = {new Item("Backstage passes to a TAFKAL80ETC concert", 5, 48)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(4, items[0].daysRemaining);
        assertEquals(50, items[0].quality);
    }

    @Test
    void backstagePass_VeryCloseToSellDateLowerBound() {
        Item[] items = {new Item("Backstage passes to a TAFKAL80ETC concert", 1, 10)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(0, items[0].daysRemaining);
        assertEquals(13, items[0].quality);
    }

    @Test
    void backstagePass_VeryCloseToSellDateLowerBoundAtMaxQuality() {
        Item[] items = {new Item("Backstage passes to a TAFKAL80ETC concert", 1, 50)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(0, items[0].daysRemaining);
        assertEquals(50, items[0].quality);
    }

    @Test
    void backstagePass_VeryCloseToSellDateLowerBoundNearMaxQuality() {
        Item[] items = {new Item("Backstage passes to a TAFKAL80ETC concert", 1, 48)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(0, items[0].daysRemaining);
        assertEquals(50, items[0].quality);
    }

    @Test
    void backstagePass_OnSellDate() {
        Item[] items = {new Item("Backstage passes to a TAFKAL80ETC concert", 0, 10)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(-1, items[0].daysRemaining);
        assertEquals(0, items[0].quality);
    }

    @Test
    void backstagePass_AfterSellDate() {
        Item[] items = {new Item("Backstage passes to a TAFKAL80ETC concert", -10, 10)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(-11, items[0].daysRemaining);
        assertEquals(0, items[0].quality);
    }
}
