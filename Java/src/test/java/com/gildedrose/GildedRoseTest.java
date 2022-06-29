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
    void agedCheddar_BeforeSellDate() {
        Item[] items = {new Item("Aged Cheddar", 5, 10)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(4, items[0].daysRemaining);
        assertEquals(11, items[0].quality);
    }

    @Test
    void agedCheddar_WithMaxQuality() {
        Item[] items = {new Item("Aged Cheddar", 5, 50)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(4, items[0].daysRemaining);
        assertEquals(50, items[0].quality);
    }

    @Test
    void agedCheddar_OnSellDate() {
        Item[] items = {new Item("Aged Cheddar", 0, 10)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(-1, items[0].daysRemaining);
        assertEquals(12, items[0].quality);
    }

    @Test
    void agedCheddar_OnSellDateWithMaxQuality() {
        Item[] items = {new Item("Aged Cheddar", 0, 50)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(-1, items[0].daysRemaining);
        assertEquals(50, items[0].quality);
    }

    @Test
    void agedCheddar_OnSellDateNearMaxQuality() {
        Item[] items = {new Item("Aged Cheddar", 0, 49)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(-1, items[0].daysRemaining);
        assertEquals(50, items[0].quality);
    }

    @Test
    void agedCheddar_AfterSellDate() {
        Item[] items = {new Item("Aged Cheddar", -10, 10)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(-11, items[0].daysRemaining);
        assertEquals(12, items[0].quality);
    }

    @Test
    void agedCheddar_AfterSellDateWithMaxQuality() {
        Item[] items = {new Item("Aged Cheddar", -10, 50)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(-11, items[0].daysRemaining);
        assertEquals(50, items[0].quality);
    }

    @Test
    void agedCheddar_AfterSellDateNearMaxQuality() {
        Item[] items = {new Item("Aged Cheddar", -10, 49)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(-11, items[0].daysRemaining);
        assertEquals(50, items[0].quality);
    }

    @Test
    void hammer_BeforeSellDate() {
        Item[] items = {new Item("Hammer", 5, 40)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(5, items[0].daysRemaining);
        assertEquals(40, items[0].quality);
    }

    @Test
    void hammer_OnSellDate() {
        Item[] items = {new Item("Hammer", 0, 40)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(0, items[0].daysRemaining);
        assertEquals(40, items[0].quality);
    }

    @Test
    void hammer_AfterSellDate() {
        Item[] items = {new Item("Hammer", -10, 40)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(-10, items[0].daysRemaining);
        assertEquals(40, items[0].quality);
    }

    @Test
    void concertTickets_LongBeforeSellDate() {
        Item[] items = {new Item("Concert Tickets", 11, 10)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(10, items[0].daysRemaining);
        assertEquals(11, items[0].quality);
    }

    @Test
    void concertTickets_LongBeforeSellDateAtMaxQuality() {
        Item[] items = {new Item("Concert Tickets", 11, 50)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(10, items[0].daysRemaining);
        assertEquals(50, items[0].quality);
    }

    @Test
    void concertTickets_MediumCloseToSellDateUpperBound() {
        Item[] items = {new Item("Concert Tickets", 10, 10)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(9, items[0].daysRemaining);
        assertEquals(12, items[0].quality);
    }

    @Test
    void concertTickets_MediumCloseToSellDateUpperBoundAtMaxQuality() {
        Item[] items = {new Item("Concert Tickets", 10, 50)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(9, items[0].daysRemaining);
        assertEquals(50, items[0].quality);
    }

    @Test
    void concertTickets_MediumCloseToSellDateUpperBoundNearMaxQuality() {
        Item[] items = {new Item("Concert Tickets", 10, 49)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(9, items[0].daysRemaining);
        assertEquals(50, items[0].quality);
    }

    @Test
    void concertTickets_MediumCloseToSellDateLowerBound() {
        Item[] items = {new Item("Concert Tickets", 6, 10)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(5, items[0].daysRemaining);
        assertEquals(12, items[0].quality);
    }

    @Test
    void concertTickets_MediumCloseToSellDateLowerBoundAtMaxQuality() {
        Item[] items = {new Item("Concert Tickets", 6, 50)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(5, items[0].daysRemaining);
        assertEquals(50, items[0].quality);
    }

    @Test
    void concertTickets_MediumCloseToSellDateLowerBoundNearMaxQuality() {
        Item[] items = {new Item("Concert Tickets", 6, 49)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(5, items[0].daysRemaining);
        assertEquals(50, items[0].quality);
    }

    @Test
    void concertTickets_VeryCloseToSellDateUpperBound() {
        Item[] items = {new Item("Concert Tickets", 5, 10)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(4, items[0].daysRemaining);
        assertEquals(13, items[0].quality);
    }

    @Test
    void concertTickets_VeryCloseToSellDateUpperBoundAtMaxQuality() {
        Item[] items = {new Item("Concert Tickets", 5, 50)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(4, items[0].daysRemaining);
        assertEquals(50, items[0].quality);
    }

    @Test
    void concertTickets_VeryCloseToSellDateUpperBoundNearMaxQuality() {
        Item[] items = {new Item("Concert Tickets", 5, 48)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(4, items[0].daysRemaining);
        assertEquals(50, items[0].quality);
    }

    @Test
    void concertTickets_VeryCloseToSellDateLowerBound() {
        Item[] items = {new Item("Concert Tickets", 1, 10)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(0, items[0].daysRemaining);
        assertEquals(13, items[0].quality);
    }

    @Test
    void concertTickets_VeryCloseToSellDateLowerBoundAtMaxQuality() {
        Item[] items = {new Item("Concert Tickets", 1, 50)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(0, items[0].daysRemaining);
        assertEquals(50, items[0].quality);
    }

    @Test
    void concertTickets_VeryCloseToSellDateLowerBoundNearMaxQuality() {
        Item[] items = {new Item("Concert Tickets", 1, 48)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(0, items[0].daysRemaining);
        assertEquals(50, items[0].quality);
    }

    @Test
    void concertTickets_OnSellDate() {
        Item[] items = {new Item("Concert Tickets", 0, 10)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(-1, items[0].daysRemaining);
        assertEquals(0, items[0].quality);
    }

    @Test
    void concertTickets_AfterSellDate() {
        Item[] items = {new Item("Concert Tickets", -10, 10)};
        GildedRose app = new GildedRose();

        app.processEndOfDay(items);

        assertEquals(-11, items[0].daysRemaining);
        assertEquals(0, items[0].quality);
    }
}
