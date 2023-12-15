package com.gildedrose;

import org.junit.jupiter.api.Nested;
import org.junit.jupiter.api.Test;

import java.util.Arrays;
import java.util.Collections;
import java.util.List;
import static org.junit.jupiter.api.Assertions.assertEquals;

class GildedRoseTest {
    @Nested
    class NormalItemTest {
        @Test
        void BeforeSellDate() {
            Item[] items = {new Item("randomstring", 5, 10)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(4, items[0].daysRemaining);
            assertEquals(9, items[0].quality);
        }

        @Test
        void WithMinQuality() {
            Item[] items = {new Item("randomstring", 5, 0)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(4, items[0].daysRemaining);
            assertEquals(0, items[0].quality);
        }

        @Test
        void OnSellDate() {
            Item[] items = {new Item("randomstring", 0, 10)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(-1, items[0].daysRemaining);
            assertEquals(8, items[0].quality);
        }

        @Test
        void OnSellDateWithMinQuality() {
            Item[] items = {new Item("randomstring", 0, 0)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(-1, items[0].daysRemaining);
            assertEquals(0, items[0].quality);
        }

        @Test
        void OnSellDateNearMinQuality() {
            Item[] items = {new Item("randomstring", 0, 1)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(-1, items[0].daysRemaining);
            assertEquals(0, items[0].quality);
        }

        @Test
        void AfterSellDate() {
            Item[] items = {new Item("randomstring", -10, 10)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(-11, items[0].daysRemaining);
            assertEquals(8, items[0].quality);
        }

        @Test
        void AfterSellDateWithMinQuality() {
            Item[] items = {new Item("randomstring", -10, 0)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(-11, items[0].daysRemaining);
            assertEquals(0, items[0].quality);
        }

        @Test
        void AfterSellDateNearMinQuality() {
            Item[] items = {new Item("randomstring", -10, 1)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(-11, items[0].daysRemaining);
            assertEquals(0, items[0].quality);
        }
    }

    @Nested
    class AgedCheddarTest {
        @Test
        void BeforeSellDate() {
            Item[] items = {new Item("Aged Cheddar", 5, 10)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(4, items[0].daysRemaining);
            assertEquals(11, items[0].quality);
        }

        @Test
        void WithMaxQuality() {
            Item[] items = {new Item("Aged Cheddar", 5, 50)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(4, items[0].daysRemaining);
            assertEquals(50, items[0].quality);
        }

        @Test
        void OnSellDate() {
            Item[] items = {new Item("Aged Cheddar", 0, 10)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(-1, items[0].daysRemaining);
            assertEquals(12, items[0].quality);
        }

        @Test
        void OnSellDateWithMaxQuality() {
            Item[] items = {new Item("Aged Cheddar", 0, 50)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(-1, items[0].daysRemaining);
            assertEquals(50, items[0].quality);
        }

        @Test
        void OnSellDateNearMaxQuality() {
            Item[] items = {new Item("Aged Cheddar", 0, 49)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(-1, items[0].daysRemaining);
            assertEquals(50, items[0].quality);
        }

        @Test
        void AfterSellDate() {
            Item[] items = {new Item("Aged Cheddar", -10, 10)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(-11, items[0].daysRemaining);
            assertEquals(12, items[0].quality);
        }

        @Test
        void AfterSellDateWithMaxQuality() {
            Item[] items = {new Item("Aged Cheddar", -10, 50)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(-11, items[0].daysRemaining);
            assertEquals(50, items[0].quality);
        }

        @Test
        void AfterSellDateNearMaxQuality() {
            Item[] items = {new Item("Aged Cheddar", -10, 49)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(-11, items[0].daysRemaining);
            assertEquals(50, items[0].quality);
        }
    }

    @Nested
    class HammerTest {
        @Test
        void BeforeSellDate() {
            Item[] items = {new Item("Hammer", 5, 40)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(5, items[0].daysRemaining);
            assertEquals(40, items[0].quality);
        }

        @Test
        void OnSellDate() {
            Item[] items = {new Item("Hammer", 0, 40)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(0, items[0].daysRemaining);
            assertEquals(40, items[0].quality);
        }

        @Test
        void AfterSellDate() {
            Item[] items = {new Item("Hammer", -10, 40)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(-10, items[0].daysRemaining);
            assertEquals(40, items[0].quality);
        }
    }

    @Nested
    class ConcertTicketsTest {
        @Test
        void LongBeforeSellDate() {
            Item[] items = {new Item("Concert Tickets", 11, 10)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(10, items[0].daysRemaining);
            assertEquals(11, items[0].quality);
        }

        @Test
        void LongBeforeSellDateAtMaxQuality() {
            Item[] items = {new Item("Concert Tickets", 11, 50)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(10, items[0].daysRemaining);
            assertEquals(50, items[0].quality);
        }

        @Test
        void MediumCloseToSellDateUpperBound() {
            Item[] items = {new Item("Concert Tickets", 10, 10)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(9, items[0].daysRemaining);
            assertEquals(12, items[0].quality);
        }

        @Test
        void MediumCloseToSellDateUpperBoundAtMaxQuality() {
            Item[] items = {new Item("Concert Tickets", 10, 50)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(9, items[0].daysRemaining);
            assertEquals(50, items[0].quality);
        }

        @Test
        void MediumCloseToSellDateUpperBoundNearMaxQuality() {
            Item[] items = {new Item("Concert Tickets", 10, 49)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(9, items[0].daysRemaining);
            assertEquals(50, items[0].quality);
        }

        @Test
        void MediumCloseToSellDateLowerBound() {
            Item[] items = {new Item("Concert Tickets", 6, 10)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(5, items[0].daysRemaining);
            assertEquals(12, items[0].quality);
        }

        @Test
        void MediumCloseToSellDateLowerBoundAtMaxQuality() {
            Item[] items = {new Item("Concert Tickets", 6, 50)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(5, items[0].daysRemaining);
            assertEquals(50, items[0].quality);
        }

        @Test
        void MediumCloseToSellDateLowerBoundNearMaxQuality() {
            Item[] items = {new Item("Concert Tickets", 6, 49)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(5, items[0].daysRemaining);
            assertEquals(50, items[0].quality);
        }

        @Test
        void VeryCloseToSellDateUpperBound() {
            Item[] items = {new Item("Concert Tickets", 5, 10)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(4, items[0].daysRemaining);
            assertEquals(13, items[0].quality);
        }

        @Test
        void VeryCloseToSellDateUpperBoundAtMaxQuality() {
            Item[] items = {new Item("Concert Tickets", 5, 50)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(4, items[0].daysRemaining);
            assertEquals(50, items[0].quality);
        }

        @Test
        void VeryCloseToSellDateUpperBoundNearMaxQuality() {
            Item[] items = {new Item("Concert Tickets", 5, 48)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(4, items[0].daysRemaining);
            assertEquals(50, items[0].quality);
        }

        @Test
        void VeryCloseToSellDateLowerBound() {
            Item[] items = {new Item("Concert Tickets", 1, 10)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(0, items[0].daysRemaining);
            assertEquals(13, items[0].quality);
        }

        @Test
        void VeryCloseToSellDateLowerBoundAtMaxQuality() {
            Item[] items = {new Item("Concert Tickets", 1, 50)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(0, items[0].daysRemaining);
            assertEquals(50, items[0].quality);
        }

        @Test
        void VeryCloseToSellDateLowerBoundNearMaxQuality() {
            Item[] items = {new Item("Concert Tickets", 1, 48)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(0, items[0].daysRemaining);
            assertEquals(50, items[0].quality);
        }

        @Test
        void OnSellDate() {
            Item[] items = {new Item("Concert Tickets", 0, 10)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(-1, items[0].daysRemaining);
            assertEquals(0, items[0].quality);
        }

        @Test
        void AfterSellDate() {
            Item[] items = {new Item("Concert Tickets", -10, 10)};
            GildedRose app = new GildedRose();

            app.processEndOfDay(items);

            assertEquals(-11, items[0].daysRemaining);
            assertEquals(0, items[0].quality);
        }
    }
}
