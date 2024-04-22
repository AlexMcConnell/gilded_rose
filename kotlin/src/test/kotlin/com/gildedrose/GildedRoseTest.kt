package com.gildedrose

import org.junit.jupiter.api.Nested
import org.junit.jupiter.api.Test
import kotlin.test.assertEquals

class GildedRoseTest {
    @Nested
    inner class NormalItemTest {
        @Test
        fun BeforeSellDate() {
            val items = arrayOf(Item("randomstring", 5, 10))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(4, items[0].daysRemaining)
            assertEquals(9, items[0].quality)
        }

        @Test
        fun WithMinQuality() {
            val items = arrayOf(Item("randomstring", 5, 0))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(4, items[0].daysRemaining)
            assertEquals(0, items[0].quality)
        }

        @Test
        fun OnSellDate() {
            val items = arrayOf(Item("randomstring", 0, 10))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(-1, items[0].daysRemaining)
            assertEquals(8, items[0].quality)
        }

        @Test
        fun OnSellDateWithMinQuality() {
            val items = arrayOf(Item("randomstring", 0, 0))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(-1, items[0].daysRemaining)
            assertEquals(0, items[0].quality)
        }

        @Test
        fun OnSellDateNearMinQuality() {
            val items = arrayOf(Item("randomstring", 0, 1))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(-1, items[0].daysRemaining)
            assertEquals(0, items[0].quality)
        }

        @Test
        fun AfterSellDate() {
            val items = arrayOf(Item("randomstring", -10, 10))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(-11, items[0].daysRemaining)
            assertEquals(8, items[0].quality)
        }

        @Test
        fun AfterSellDateWithMinQuality() {
            val items = arrayOf(Item("randomstring", -10, 0))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(-11, items[0].daysRemaining)
            assertEquals(0, items[0].quality)
        }

        @Test
        fun AfterSellDateNearMinQuality() {
            val items = arrayOf(Item("randomstring", -10, 1))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(-11, items[0].daysRemaining)
            assertEquals(0, items[0].quality)
        }
    }

    @Nested
    inner class AgedCheddarTest {
        @Test
        fun BeforeSellDate() {
            val items = arrayOf(Item("Aged Cheddar", 5, 10))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(4, items[0].daysRemaining)
            assertEquals(11, items[0].quality)
        }

        @Test
        fun WithMaxQuality() {
            val items = arrayOf(Item("Aged Cheddar", 5, 50))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(4, items[0].daysRemaining)
            assertEquals(50, items[0].quality)
        }

        @Test
        fun OnSellDate() {
            val items = arrayOf(Item("Aged Cheddar", 0, 10))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(-1, items[0].daysRemaining)
            assertEquals(12, items[0].quality)
        }

        @Test
        fun OnSellDateWithMaxQuality() {
            val items = arrayOf(Item("Aged Cheddar", 0, 50))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(-1, items[0].daysRemaining)
            assertEquals(50, items[0].quality)
        }

        @Test
        fun OnSellDateNearMaxQuality() {
            val items = arrayOf(Item("Aged Cheddar", 0, 49))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(-1, items[0].daysRemaining)
            assertEquals(50, items[0].quality)
        }

        @Test
        fun AfterSellDate() {
            val items = arrayOf(Item("Aged Cheddar", -10, 10))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(-11, items[0].daysRemaining)
            assertEquals(12, items[0].quality)
        }

        @Test
        fun AfterSellDateWithMaxQuality() {
            val items = arrayOf(Item("Aged Cheddar", -10, 50))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(-11, items[0].daysRemaining)
            assertEquals(50, items[0].quality)
        }

        @Test
        fun AfterSellDateNearMaxQuality() {
            val items = arrayOf(Item("Aged Cheddar", -10, 49))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(-11, items[0].daysRemaining)
            assertEquals(50, items[0].quality)
        }
    }

    @Nested
    inner class HammerTest {
        @Test
        fun BeforeSellDate() {
            val items = arrayOf(Item("Hammer", 5, 40))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(5, items[0].daysRemaining)
            assertEquals(40, items[0].quality)
        }

        @Test
        fun OnSellDate() {
            val items = arrayOf(Item("Hammer", 0, 40))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(0, items[0].daysRemaining)
            assertEquals(40, items[0].quality)
        }

        @Test
        fun AfterSellDate() {
            val items = arrayOf(Item("Hammer", -10, 40))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(-10, items[0].daysRemaining)
            assertEquals(40, items[0].quality)
        }
    }

    @Nested
    inner class ConcertTicketsTest {
        @Test
        fun LongBeforeSellDate() {
            val items = arrayOf(Item("Concert Tickets", 11, 10))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(10, items[0].daysRemaining)
            assertEquals(11, items[0].quality)
        }

        @Test
        fun LongBeforeSellDateAtMaxQuality() {
            val items = arrayOf(Item("Concert Tickets", 11, 50))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(10, items[0].daysRemaining)
            assertEquals(50, items[0].quality)
        }

        @Test
        fun MediumCloseToSellDateUpperBound() {
            val items = arrayOf(Item("Concert Tickets", 10, 10))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(9, items[0].daysRemaining)
            assertEquals(12, items[0].quality)
        }

        @Test
        fun MediumCloseToSellDateUpperBoundAtMaxQuality() {
            val items = arrayOf(Item("Concert Tickets", 10, 50))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(9, items[0].daysRemaining)
            assertEquals(50, items[0].quality)
        }

        @Test
        fun MediumCloseToSellDateUpperBoundNearMaxQuality() {
            val items = arrayOf(Item("Concert Tickets", 10, 49))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(9, items[0].daysRemaining)
            assertEquals(50, items[0].quality)
        }

        @Test
        fun MediumCloseToSellDateLowerBound() {
            val items = arrayOf(Item("Concert Tickets", 6, 10))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(5, items[0].daysRemaining)
            assertEquals(12, items[0].quality)
        }

        @Test
        fun MediumCloseToSellDateLowerBoundAtMaxQuality() {
            val items = arrayOf(Item("Concert Tickets", 6, 50))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(5, items[0].daysRemaining)
            assertEquals(50, items[0].quality)
        }

        @Test
        fun MediumCloseToSellDateLowerBoundNearMaxQuality() {
            val items = arrayOf(Item("Concert Tickets", 6, 49))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(5, items[0].daysRemaining)
            assertEquals(50, items[0].quality)
        }

        @Test
        fun VeryCloseToSellDateUpperBound() {
            val items = arrayOf(Item("Concert Tickets", 5, 10))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(4, items[0].daysRemaining)
            assertEquals(13, items[0].quality)
        }

        @Test
        fun VeryCloseToSellDateUpperBoundAtMaxQuality() {
            val items = arrayOf(Item("Concert Tickets", 5, 50))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(4, items[0].daysRemaining)
            assertEquals(50, items[0].quality)
        }

        @Test
        fun VeryCloseToSellDateUpperBoundNearMaxQuality() {
            val items = arrayOf(Item("Concert Tickets", 5, 48))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(4, items[0].daysRemaining)
            assertEquals(50, items[0].quality)
        }

        @Test
        fun VeryCloseToSellDateLowerBound() {
            val items = arrayOf(Item("Concert Tickets", 1, 10))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(0, items[0].daysRemaining)
            assertEquals(13, items[0].quality)
        }

        @Test
        fun VeryCloseToSellDateLowerBoundAtMaxQuality() {
            val items = arrayOf(Item("Concert Tickets", 1, 50))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(0, items[0].daysRemaining)
            assertEquals(50, items[0].quality)
        }

        @Test
        fun VeryCloseToSellDateLowerBoundNearMaxQuality() {
            val items = arrayOf(Item("Concert Tickets", 1, 48))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(0, items[0].daysRemaining)
            assertEquals(50, items[0].quality)
        }

        @Test
        fun OnSellDate() {
            val items = arrayOf(Item("Concert Tickets", 0, 10))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(-1, items[0].daysRemaining)
            assertEquals(0, items[0].quality)
        }

        @Test
        fun AfterSellDate() {
            val items = arrayOf(Item("Concert Tickets", -10, 10))
            val app = GildedRose()

            app.processEndOfDay(items)

            assertEquals(-11, items[0].daysRemaining)
            assertEquals(0, items[0].quality)
        }
    }
}
