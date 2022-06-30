#!/usr/bin/python
# -*- coding: utf-8 -*-
import unittest
from lib.item import Item
from lib.gilded_rose import GildedRose


class TestGildedRose(unittest.TestCase):

    def test_normalItem_beforeSellDate(self):
        items = [Item('foo', 5, 10)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(4, items[0].daysRemaining)
        self.assertEqual(9, items[0].quality)

    def test_normalItem_WithMinQuality(self):
        items = [Item('foo', 5, 0)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(4, items[0].daysRemaining)
        self.assertEqual(0, items[0].quality)

    def test_normalItem_OnSellDate(self):
        items = [Item('foo', 0, 10)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(-1, items[0].daysRemaining)
        self.assertEqual(8, items[0].quality)

    def test_normalItem_OnSellDateWithMinQuality(self):
        items = [Item('foo', 0, 0)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(-1, items[0].daysRemaining)
        self.assertEqual(0, items[0].quality)

    def test_normalItem_OnSellDateNearMinQuality(self):
        items = [Item('foo', 0, 1)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(-1, items[0].daysRemaining)
        self.assertEqual(0, items[0].quality)

    def test_normalItem_AfterSellDate(self):
        items = [Item('foo', -10, 10)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(-11, items[0].daysRemaining)
        self.assertEqual(8, items[0].quality)

    def test_normalItem_AfterSellDateWithMinQuality(self):
        items = [Item('foo', -10, 0)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(-11, items[0].daysRemaining)
        self.assertEqual(0, items[0].quality)

    def test_normalItem_AfterSellDateNearMinQuality(self):
        items = [Item('foo', -10, 1)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(-11, items[0].daysRemaining)
        self.assertEqual(0, items[0].quality)

    def test_agedCheddar_BeforeSellDate(self):
        items = [Item('Aged Cheddar', 5, 10)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(4, items[0].daysRemaining)
        self.assertEqual(11, items[0].quality)

    def test_agedCheddar_WithMaxQuality(self):
        items = [Item('Aged Cheddar', 5, 50)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(4, items[0].daysRemaining)
        self.assertEqual(50, items[0].quality)

    def test_agedCheddar_OnSellDate(self):
        items = [Item('Aged Cheddar', 0, 10)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(-1, items[0].daysRemaining)
        self.assertEqual(12, items[0].quality)

    def test_agedCheddar_OnSellDateWithMaxQuality(self):
        items = [Item('Aged Cheddar', 0, 50)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(-1, items[0].daysRemaining)
        self.assertEqual(50, items[0].quality)

    def test_agedCheddar_OnSellDateNearMaxQuality(self):
        items = [Item('Aged Cheddar', 0, 49)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(-1, items[0].daysRemaining)
        self.assertEqual(50, items[0].quality)

    def test_agedCheddar_AfterSellDate(self):
        items = [Item('Aged Cheddar', -10, 10)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(-11, items[0].daysRemaining)
        self.assertEqual(12, items[0].quality)

    def test_agedCheddar_AfterSellDateWithMaxQuality(self):
        items = [Item('Aged Cheddar', -10, 50)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(-11, items[0].daysRemaining)
        self.assertEqual(50, items[0].quality)

    def test_agedCheddar_AfterSellDateNearMaxQuality(self):
        items = [Item('Aged Cheddar', -10, 49)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(-11, items[0].daysRemaining)
        self.assertEqual(50, items[0].quality)

    def test_hammer_BeforeSellDate(self):
        items = [Item('Hammer', 5, 80)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(5, items[0].daysRemaining)
        self.assertEqual(80, items[0].quality)

    def test_hammer_OnSellDate(self):

        items = [Item('Hammer', 0, 80)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(0, items[0].daysRemaining)
        self.assertEqual(80, items[0].quality)

    def test_hammer_AfterSellDate(self):
        items = [Item('Hammer', -10, 80)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(-10, items[0].daysRemaining)
        self.assertEqual(80, items[0].quality)

    def test_concertTickets_LongBeforeSellDate(self):
        items = [Item('Concert Tickets', 11, 10)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(10, items[0].daysRemaining)
        self.assertEqual(11, items[0].quality)

    def test_concertTickets_LongBeforeSellDateAtMaxQuality(self):
        items = [Item('Concert Tickets', 11, 50)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(10, items[0].daysRemaining)
        self.assertEqual(50, items[0].quality)

    def test_concertTickets_MediumCloseToSellDateUpperBound(self):
        items = [Item('Concert Tickets', 10, 10)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(9, items[0].daysRemaining)
        self.assertEqual(12, items[0].quality)

    def test_concertTickets_MediumCloseToSellDateUpperBoundAtMaxQuality(self):
        items = [Item('Concert Tickets', 10, 50)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(9, items[0].daysRemaining)
        self.assertEqual(50, items[0].quality)

    def test_concertTickets_MediumCloseToSellDateUpperBoundNearMaxQuality(self):
        items = [Item('Concert Tickets', 10, 49)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(9, items[0].daysRemaining)
        self.assertEqual(50, items[0].quality)

    def test_concertTickets_MediumCloseToSellDateLowerBound(self):
        items = [Item('Concert Tickets', 6, 10)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(5, items[0].daysRemaining)
        self.assertEqual(12, items[0].quality)

    def test_concertTickets_MediumCloseToSellDateLowerBoundAtMaxQuality(self):
        items = [Item('Concert Tickets', 6, 50)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(5, items[0].daysRemaining)
        self.assertEqual(50, items[0].quality)

    def test_concertTickets_MediumCloseToSellDateLowerBoundNearMaxQuality(self):
        items = [Item('Concert Tickets', 6, 49)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(5, items[0].daysRemaining)
        self.assertEqual(50, items[0].quality)

    def test_concertTickets_VeryCloseToSellDateUpperBound(self):
        items = [Item('Concert Tickets', 5, 10)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(4, items[0].daysRemaining)
        self.assertEqual(13, items[0].quality)

    def test_concertTickets_VeryCloseToSellDateUpperBoundAtMaxQuality(self):
        items = [Item('Concert Tickets', 5, 50)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(4, items[0].daysRemaining)
        self.assertEqual(50, items[0].quality)

    def test_concertTickets_VeryCloseToSellDateUpperBoundNearMaxQuality(self):
        items = [Item('Concert Tickets', 5, 48)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(4, items[0].daysRemaining)
        self.assertEqual(50, items[0].quality)

    def test_concertTickets_VeryCloseToSellDateLowerBound(self):
        items = [Item('Concert Tickets', 1, 10)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(0, items[0].daysRemaining)
        self.assertEqual(13, items[0].quality)

    def test_concertTickets_VeryCloseToSellDateLowerBoundAtMaxQuality(self):
        items = [Item('Concert Tickets', 1, 50)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(0, items[0].daysRemaining)
        self.assertEqual(50, items[0].quality)

    def test_concertTickets_VeryCloseToSellDateLowerBoundNearMaxQuality(self):
        items = [Item('Concert Tickets', 1, 48)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(0, items[0].daysRemaining)
        self.assertEqual(50, items[0].quality)

    def test_concertTickets_OnSellDate(self):
        items = [Item('Concert Tickets', 0, 50)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(-1, items[0].daysRemaining)
        self.assertEqual(0, items[0].quality)

    def test_concertTickets_AfterSellDate(self):
        items = [Item('Concert Tickets', -10, 10)]
        gilded_rose = GildedRose()
        gilded_rose.processEndOfDay(items)

        self.assertEqual(-11, items[0].daysRemaining)
        self.assertEqual(0, items[0].quality)


if __name__ == '__main__':
    unittest.main()
