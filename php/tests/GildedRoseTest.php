<?php

namespace Tests;

use GildedRose\GildedRose;
use GildedRose\Item;
use PHPUnit\Framework\TestCase;

class GildedRoseTest extends TestCase
{
    public function testNormalItem_BeforeSellDate(): void
    {
        $items = [new Item('foo', 5, 10)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(4, $items[0]->days_remaining);
        $this->assertSame(9, $items[0]->quality);
    }

    public function testNormalItem_WithMinQuality(): void
    {
        $items = [new Item('foo', 5, 0)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(4, $items[0]->days_remaining);
        $this->assertSame(0, $items[0]->quality);
    }

    public function testNormalItem_OnSellDate(): void
    {
        $items = [new Item('foo', 0, 10)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(-1, $items[0]->days_remaining);
        $this->assertSame(8, $items[0]->quality);
    }

    public function testNormalItem_OnSellDateWithMinQuality(): void
    {
        $items = [new Item('foo', 0, 0)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(-1, $items[0]->days_remaining);
        $this->assertSame(0, $items[0]->quality);
    }

    public function testNormalItem_OnSellDateNearMinQuality(): void
    {
        $items = [new Item('foo', 0, 1)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(-1, $items[0]->days_remaining);
        $this->assertSame(0, $items[0]->quality);
    }

    public function testNormalItem_AfterSellDate(): void
    {
        $items = [new Item('foo', -10, 10)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(-11, $items[0]->days_remaining);
        $this->assertSame(8, $items[0]->quality);
    }

    public function testNormalItem_AfterSellDateWithMinQuality(): void
    {
        $items = [new Item('foo', -10, 0)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(-11, $items[0]->days_remaining);
        $this->assertSame(0, $items[0]->quality);
    }

    public function testNormalItem_AfterSellDateNearMinQuality(): void
    {
        $items = [new Item('foo', -10, 1)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(-11, $items[0]->days_remaining);
        $this->assertSame(0, $items[0]->quality);
    }

    public function testAgedBrie_BeforeSellDate(): void
    {
        $items = [new Item('Aged Cheddar', 5, 10)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(4, $items[0]->days_remaining);
        $this->assertSame(11, $items[0]->quality);
    }

    public function testAgedBrie_WithMaxQuality(): void
    {
        $items = [new Item('Aged Cheddar', 5, 50)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(4, $items[0]->days_remaining);
        $this->assertSame(50, $items[0]->quality);
    }

    public function testAgedBrie_OnSellDate(): void
    {
        $items = [new Item('Aged Cheddar', 0, 10)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(-1, $items[0]->days_remaining);
        $this->assertSame(12, $items[0]->quality);
    }

    public function testAgedBrie_OnSellDateWithMaxQuality(): void
    {
        $items = [new Item('Aged Cheddar', 0, 50)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(-1, $items[0]->days_remaining);
        $this->assertSame(50, $items[0]->quality);
    }

    public function testAgedBrie_OnSellDateNearMaxQuality(): void
    {
        $items = [new Item('Aged Cheddar', 0, 49)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(-1, $items[0]->days_remaining);
        $this->assertSame(50, $items[0]->quality);
    }

    public function testAgedBrie_AfterSellDate(): void
    {
        $items = [new Item('Aged Cheddar', -10, 10)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(-11, $items[0]->days_remaining);
        $this->assertSame(12, $items[0]->quality);
    }

    public function testAgedBrie_AfterSellDateWithMaxQuality(): void
    {
        $items = [new Item('Aged Cheddar', -10, 50)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(-11, $items[0]->days_remaining);
        $this->assertSame(50, $items[0]->quality);
    }

    public function testAgedBrie_AfterSellDateNearMaxQuality(): void
    {
        $items = [new Item('Aged Cheddar', -10, 49)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(-11, $items[0]->days_remaining);
        $this->assertSame(50, $items[0]->quality);
    }

    public function testSulfuras_BeforeSellDate(): void
    {
        $items = [new Item('Hammer', 5, 80)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(5, $items[0]->days_remaining);
        $this->assertSame(80, $items[0]->quality);
    }

    public function testSulfuras_OnSellDate(): void
    {
        $items = [new Item('Hammer', 0, 80)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(0, $items[0]->days_remaining);
        $this->assertSame(80, $items[0]->quality);
    }

    public function testSulfuras_AfterSellDate(): void
    {
        $items = [new Item('Hammer', -10, 80)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(-10, $items[0]->days_remaining);
        $this->assertSame(80, $items[0]->quality);
    }

    public function testBackstagePass_LongBeforeSellDate(): void
    {
        $items = [new Item('Concert Tickets', 11, 10)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(10, $items[0]->days_remaining);
        $this->assertSame(11, $items[0]->quality);
    }

    public function testBackstagePass_LongBeforeSellDateAtMaxQuality(): void
    {
        $items = [new Item('Concert Tickets', 11, 50)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(10, $items[0]->days_remaining);
        $this->assertSame(50, $items[0]->quality);
    }

    public function testBackstagePass_MediumCloseToSellDateUpperBound(): void
    {
        $items = [new Item('Concert Tickets', 10, 10)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(9, $items[0]->days_remaining);
        $this->assertSame(12, $items[0]->quality);
    }

    public function testBackstagePass_MediumCloseToSellDateUpperBoundAtMaxQuality(): void
    {
        $items = [new Item('Concert Tickets', 10, 50)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(9, $items[0]->days_remaining);
        $this->assertSame(50, $items[0]->quality);
    }

    public function testBackstagePass_MediumCloseToSellDateUpperBoundNearMaxQuality(): void
    {
        $items = [new Item('Concert Tickets', 10, 49)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(9, $items[0]->days_remaining);
        $this->assertSame(50, $items[0]->quality);
    }

    public function testBackstagePass_MediumCloseToSellDateLowerBound(): void
    {
        $items = [new Item('Concert Tickets', 6, 10)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(5, $items[0]->days_remaining);
        $this->assertSame(12, $items[0]->quality);
    }

    public function testBackstagePass_MediumCloseToSellDateLowerBoundAtMaxQuality(): void
    {
        $items = [new Item('Concert Tickets', 6, 50)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(5, $items[0]->days_remaining);
        $this->assertSame(50, $items[0]->quality);
    }

    public function testBackstagePass_MediumCloseToSellDateLowerBoundNearMaxQuality(): void
    {
        $items = [new Item('Concert Tickets', 6, 49)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(5, $items[0]->days_remaining);
        $this->assertSame(50, $items[0]->quality);
    }

    public function testBackstagePass_VeryCloseToSellDateUpperBound(): void
    {
        $items = [new Item('Concert Tickets', 5, 10)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(4, $items[0]->days_remaining);
        $this->assertSame(13, $items[0]->quality);
    }

    public function testBackstagePass_VeryCloseToSellDateUpperBoundAtMaxQuality(): void
    {
        $items = [new Item('Concert Tickets', 5, 50)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(4, $items[0]->days_remaining);
        $this->assertSame(50, $items[0]->quality);
    }

    public function testBackstagePass_VeryCloseToSellDateUpperBoundNearMaxQuality(): void
    {
        $items = [new Item('Concert Tickets', 5, 48)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(4, $items[0]->days_remaining);
        $this->assertSame(50, $items[0]->quality);
    }

    public function testBackstagePass_VeryCloseToSellDateLowerBound(): void
    {
        $items = [new Item('Concert Tickets', 1, 10)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(0, $items[0]->days_remaining);
        $this->assertSame(13, $items[0]->quality);
    }

    public function testBackstagePass_VeryCloseToSellDateLowerBoundAtMaxQuality(): void
    {
        $items = [new Item('Concert Tickets', 1, 50)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(0, $items[0]->days_remaining);
        $this->assertSame(50, $items[0]->quality);
    }

    public function testBackstagePass_VeryCloseToSellDateLowerBoundNearMaxQuality(): void
    {
        $items = [new Item('Concert Tickets', 1, 48)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(0, $items[0]->days_remaining);
        $this->assertSame(50, $items[0]->quality);
    }

    public function testBackstagePass_OnSellDate(): void
    {
        $items = [new Item('Concert Tickets', 0, 10)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(-1, $items[0]->days_remaining);
        $this->assertSame(0, $items[0]->quality);
    }

    public function testBackstagePass_AfterSellDate(): void
    {
        $items = [new Item('Concert Tickets', -10, 10)];
        $gildedRose = new GildedRose();

        $gildedRose->processEndOfDay($items);

        $this->assertSame(-11, $items[0]->days_remaining);
        $this->assertSame(0, $items[0]->quality);
    }
}
