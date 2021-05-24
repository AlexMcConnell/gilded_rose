<?php

declare(strict_types=1);

namespace Tests;

use GildedRose\GildedRose;
use GildedRose\Item;
use PHPUnit\Framework\TestCase;

class GildedRoseTest extends TestCase
{
    public function testNormalItem_BeforeSellDate(): void
    {
        $item = new Item('foo', 5, 10);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(4, $item->days_remaining);
        $this->assertSame(9, $item->quality);
    }

    public function testNormalItem_WithMinQuality(): void
    {
        $item = new Item('foo', 5, 0);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(4, $item->days_remaining);
        $this->assertSame(0, $item->quality);
    }

    public function testNormalItem_OnSellDate(): void
    {
        $item = new Item('foo', 0, 10);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(-1, $item->days_remaining);
        $this->assertSame(8, $item->quality);
    }

    public function testNormalItem_OnSellDateWithMinQuality(): void
    {
        $item = new Item('foo', 0, 0);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(-1, $item->days_remaining);
        $this->assertSame(0, $item->quality);
    }

    public function testNormalItem_OnSellDateNearMinQuality(): void
    {
        $item = new Item('foo', 0, 1);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(-1, $item->days_remaining);
        $this->assertSame(0, $item->quality);
    }

    public function testNormalItem_AfterSellDate(): void
    {
        $item = new Item('foo', -10, 10);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(-11, $item->days_remaining);
        $this->assertSame(8, $item->quality);
    }

    public function testNormalItem_AfterSellDateWithMinQuality(): void
    {
        $item = new Item('foo', -10, 0);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(-11, $item->days_remaining);
        $this->assertSame(0, $item->quality);
    }

    public function testNormalItem_AfterSellDateNearMinQuality(): void
    {
        $item = new Item('foo', -10, 1);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(-11, $item->days_remaining);
        $this->assertSame(0, $item->quality);
    }

    public function testAgedBrie_BeforeSellDate(): void
    {
        $item = new Item('Aged Brie', 5, 10);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(4, $item->days_remaining);
        $this->assertSame(11, $item->quality);
    }

    public function testAgedBrie_WithMaxQuality(): void
    {
        $item = new Item('Aged Brie', 5, 50);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(4, $item->days_remaining);
        $this->assertSame(50, $item->quality);
    }

    public function testAgedBrie_OnSellDate(): void
    {
        $item = new Item('Aged Brie', 0, 10);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(-1, $item->days_remaining);
        $this->assertSame(12, $item->quality);
    }

    public function testAgedBrie_OnSellDateWithMaxQuality(): void
    {
        $item = new Item('Aged Brie', 0, 50);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(-1, $item->days_remaining);
        $this->assertSame(50, $item->quality);
    }

    public function testAgedBrie_OnSellDateNearMaxQuality(): void
    {
        $item = new Item('Aged Brie', 0, 49);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(-1, $item->days_remaining);
        $this->assertSame(50, $item->quality);
    }

    public function testAgedBrie_AfterSellDate(): void
    {
        $item = new Item('Aged Brie', -10, 10);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(-11, $item->days_remaining);
        $this->assertSame(12, $item->quality);
    }

    public function testAgedBrie_AfterSellDateWithMaxQuality(): void
    {
        $item = new Item('Aged Brie', -10, 50);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(-11, $item->days_remaining);
        $this->assertSame(50, $item->quality);
    }

    public function testAgedBrie_AfterSellDateNearMaxQuality(): void
    {
        $item = new Item('Aged Brie', -10, 49);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(-11, $item->days_remaining);
        $this->assertSame(50, $item->quality);
    }

    public function testSulfuras_BeforeSellDate(): void
    {
        $item = new Item('Sulfuras, Hand of Ragnaros', 5, 80);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(5, $item->days_remaining);
        $this->assertSame(80, $item->quality);
    }

    public function testSulfuras_OnSellDate(): void
    {
        $item = new Item('Sulfuras, Hand of Ragnaros', 0, 80);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(0, $item->days_remaining);
        $this->assertSame(80, $item->quality);
    }

    public function testSulfuras_AfterSellDate(): void
    {
        $item = new Item('Sulfuras, Hand of Ragnaros', -10, 80);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(-10, $item->days_remaining);
        $this->assertSame(80, $item->quality);
    }

    public function testBackstagePass_LongBeforeSellDate(): void
    {
        $item = new Item('Backstage passes to a TAFKAL80ETC concert', 11, 10);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(10, $item->days_remaining);
        $this->assertSame(11, $item->quality);
    }

    public function testBackstagePass_LongBeforeSellDateAtMaxQuality(): void
    {
        $item = new Item('Backstage passes to a TAFKAL80ETC concert', 11, 50);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(10, $item->days_remaining);
        $this->assertSame(50, $item->quality);
    }

    public function testBackstagePass_MediumCloseToSellDateUpperBound(): void
    {
        $item = new Item('Backstage passes to a TAFKAL80ETC concert', 10, 10);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(9, $item->days_remaining);
        $this->assertSame(12, $item->quality);
    }

    public function testBackstagePass_MediumCloseToSellDateUpperBoundAtMaxQuality(): void
    {
        $item = new Item('Backstage passes to a TAFKAL80ETC concert', 10, 50);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(9, $item->days_remaining);
        $this->assertSame(50, $item->quality);
    }

    public function testBackstagePass_MediumCloseToSellDateUpperBoundNearMaxQuality(): void
    {
        $item = new Item('Backstage passes to a TAFKAL80ETC concert', 10, 49);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(9, $item->days_remaining);
        $this->assertSame(50, $item->quality);
    }

    public function testBackstagePass_MediumCloseToSellDateLowerBound(): void
    {
        $item = new Item('Backstage passes to a TAFKAL80ETC concert', 6, 10);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(5, $item->days_remaining);
        $this->assertSame(12, $item->quality);
    }

    public function testBackstagePass_MediumCloseToSellDateLowerBoundAtMaxQuality(): void
    {
        $item = new Item('Backstage passes to a TAFKAL80ETC concert', 6, 50);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(5, $item->days_remaining);
        $this->assertSame(50, $item->quality);
    }

    public function testBackstagePass_MediumCloseToSellDateLowerBoundNearMaxQuality(): void
    {
        $item = new Item('Backstage passes to a TAFKAL80ETC concert', 6, 49);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(5, $item->days_remaining);
        $this->assertSame(50, $item->quality);
    }

    public function testBackstagePass_VeryCloseToSellDateUpperBound(): void
    {
        $item = new Item('Backstage passes to a TAFKAL80ETC concert', 5, 10);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(4, $item->days_remaining);
        $this->assertSame(13, $item->quality);
    }

    public function testBackstagePass_VeryCloseToSellDateUpperBoundAtMaxQuality(): void
    {
        $item = new Item('Backstage passes to a TAFKAL80ETC concert', 5, 50);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(4, $item->days_remaining);
        $this->assertSame(50, $item->quality);
    }

    public function testBackstagePass_VeryCloseToSellDateUpperBoundNearMaxQuality(): void
    {
        $item = new Item('Backstage passes to a TAFKAL80ETC concert', 5, 48);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(4, $item->days_remaining);
        $this->assertSame(50, $item->quality);
    }

    public function testBackstagePass_VeryCloseToSellDateLowerBound(): void
    {
        $item = new Item('Backstage passes to a TAFKAL80ETC concert', 1, 10);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(0, $item->days_remaining);
        $this->assertSame(13, $item->quality);
    }

    public function testBackstagePass_VeryCloseToSellDateLowerBoundAtMaxQuality(): void
    {
        $item = new Item('Backstage passes to a TAFKAL80ETC concert', 1, 50);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(0, $item->days_remaining);
        $this->assertSame(50, $item->quality);
    }

    public function testBackstagePass_VeryCloseToSellDateLowerBoundNearMaxQuality(): void
    {
        $item = new Item('Backstage passes to a TAFKAL80ETC concert', 1, 48);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(0, $item->days_remaining);
        $this->assertSame(50, $item->quality);
    }

    public function testBackstagePass_OnSellDate(): void
    {
        $item = new Item('Backstage passes to a TAFKAL80ETC concert', 0, 10);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(-1, $item->days_remaining);
        $this->assertSame(0, $item->quality);
    }

    public function testBackstagePass_AfterSellDate(): void
    {
        $item = new Item('Backstage passes to a TAFKAL80ETC concert', -10, 10);
        $gildedRose = new GildedRose();
        $gildedRose->processEndOfDay($item);
        $this->assertSame(-11, $item->days_remaining);
        $this->assertSame(0, $item->quality);
    }
}
