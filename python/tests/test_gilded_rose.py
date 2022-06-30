import unittest
from gilded_rose import GildedRose, Item


class Test_Normal_Item(unittest.TestCase):
    def test_before_sell_date(self):
        gilded_rose = GildedRose()
        items = [Item('randomstring', 5, 10)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, 4)
        self.assertEqual(items[0].quality, 9)

    def test_with_min_quality(self):
        gilded_rose = GildedRose()
        items = [Item('randomstring', 5, 0)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, 4)
        self.assertEqual(items[0].quality, 0)

    def test_on_sell_date(self):
        gilded_rose = GildedRose()
        items = [Item('randomstring', 0, 10)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, -1)
        self.assertEqual(items[0].quality, 8)

    def test_on_sell_date_with_min_quality(self):
        gilded_rose = GildedRose()
        items = [Item('randomstring', 0, 0)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, -1)
        self.assertEqual(items[0].quality, 0)

    def test_on_sell_date_near_min_quality(self):
        gilded_rose = GildedRose()
        items = [Item('randomstring', 0, 1)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, -1)
        self.assertEqual(items[0].quality, 0)

    def test_after_sell_date(self):
        gilded_rose = GildedRose()
        items = [Item('randomstring', -10, 10)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, -11)
        self.assertEqual(items[0].quality, 8)

    def test_after_sell_date_with_min_quality(self):
        gilded_rose = GildedRose()
        items = [Item('randomstring', -10, 0)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, -11)
        self.assertEqual(items[0].quality, 0)

    def test_after_sell_date_near_min_quality(self):
        gilded_rose = GildedRose()
        items = [Item('randomstring', -10, 1)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, -11)
        self.assertEqual(items[0].quality, 0)


class Test_Aged_Cheddar(unittest.TestCase):
    def test_before_sell_date(self):
        gilded_rose = GildedRose()
        items = [Item('Aged Cheddar', 5, 10)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, 4)
        self.assertEqual(items[0].quality, 11)

    def test_with_max_quality(self):
        gilded_rose = GildedRose()
        items = [Item('Aged Cheddar', 5, 50)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, 4)
        self.assertEqual(items[0].quality, 50)

    def test_on_sell_date(self):
        gilded_rose = GildedRose()
        items = [Item('Aged Cheddar', 0, 10)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, -1)
        self.assertEqual(items[0].quality, 12)

    def test_on_sell_date_with_max_quality(self):
        gilded_rose = GildedRose()
        items = [Item('Aged Cheddar', 0, 50)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, -1)
        self.assertEqual(items[0].quality, 50)

    def test_on_sell_date_near_max_quality(self):
        gilded_rose = GildedRose()
        items = [Item('Aged Cheddar', 0, 49)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, -1)
        self.assertEqual(items[0].quality, 50)

    def test_after_sell_date(self):
        gilded_rose = GildedRose()
        items = [Item('Aged Cheddar', -10, 10)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, -11)
        self.assertEqual(items[0].quality, 12)

    def test_after_sell_date_with_max_quality(self):
        gilded_rose = GildedRose()
        items = [Item('Aged Cheddar', -10, 50)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, -11)
        self.assertEqual(items[0].quality, 50)

    def test_after_sell_date_near_max_quality(self):
        gilded_rose = GildedRose()
        items = [Item('Aged Cheddar', -10, 49)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, -11)
        self.assertEqual(items[0].quality, 50)


class Test_Hammer(unittest.TestCase):
    def test_before_sell_date(self):
        gilded_rose = GildedRose()
        items = [Item('Hammer', 5, 40)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, 5)
        self.assertEqual(items[0].quality, 40)

    def test_on_sell_date(self):
        gilded_rose = GildedRose()
        items = [Item('Hammer', 0, 40)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, 0)
        self.assertEqual(items[0].quality, 40)

    def test_after_sell_date(self):
        gilded_rose = GildedRose()
        items = [Item('Hammer', -10, 40)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, -10)
        self.assertEqual(items[0].quality, 40)


class Test_Concert_Tickets(unittest.TestCase):
    def test_long_before_sell_date(self):
        gilded_rose = GildedRose()
        items = [Item('Concert Tickets', 11, 10)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, 10)
        self.assertEqual(items[0].quality, 11)

    def test_long_before_sell_date_at_max_quality(self):
        gilded_rose = GildedRose()
        items = [Item('Concert Tickets', 11, 50)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, 10)
        self.assertEqual(items[0].quality, 50)

    def test_medium_close_to_sell_date_upper_bound(self):
        gilded_rose = GildedRose()
        items = [Item('Concert Tickets', 10, 10)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, 9)
        self.assertEqual(items[0].quality, 12)

    def test_medium_close_to_sell_date_upper_bound_at_max_quality(self):
        gilded_rose = GildedRose()
        items = [Item('Concert Tickets', 10, 50)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, 9)
        self.assertEqual(items[0].quality, 50)

    def test_medium_close_to_sell_date_upper_bound_near_max_quality(self):
        gilded_rose = GildedRose()
        items = [Item('Concert Tickets', 10, 49)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, 9)
        self.assertEqual(items[0].quality, 50)

    def test_medium_close_to_sell_date_lower_bound(self):
        gilded_rose = GildedRose()
        items = [Item('Concert Tickets', 6, 10)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, 5)
        self.assertEqual(items[0].quality, 12)

    def test_medium_close_to_sell_date_lower_bound_at_max_quality(self):
        gilded_rose = GildedRose()
        items = [Item('Concert Tickets', 6, 50)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, 5)
        self.assertEqual(items[0].quality, 50)

    def test_medium_close_to_sell_date_lower_bound_near_max_quality(self):
        gilded_rose = GildedRose()
        items = [Item('Concert Tickets', 6, 49)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, 5)
        self.assertEqual(items[0].quality, 50)

    def test_very_close_to_sell_date_upper_bound(self):
        gilded_rose = GildedRose()
        items = [Item('Concert Tickets', 5, 10)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, 4)
        self.assertEqual(items[0].quality, 13)

    def test_very_close_to_sell_date_upper_bound_at_max_quality(self):
        gilded_rose = GildedRose()
        items = [Item('Concert Tickets', 5, 50)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, 4)
        self.assertEqual(items[0].quality, 50)

    def test_very_close_to_sell_date_upper_bound_near_max_quality(self):
        gilded_rose = GildedRose()
        items = [Item('Concert Tickets', 5, 48)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, 4)
        self.assertEqual(items[0].quality, 50)

    def test_very_close_to_sell_date_lower_bound(self):
        gilded_rose = GildedRose()
        items = [Item('Concert Tickets', 1, 10)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, 0)
        self.assertEqual(items[0].quality, 13)

    def test_very_close_to_sell_date_lower_bound_at_max_quality(self):
        gilded_rose = GildedRose()
        items = [Item('Concert Tickets', 1, 50)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, 0)
        self.assertEqual(items[0].quality, 50)

    def test_very_close_to_sell_date_lower_bound_near_max_quality(self):
        gilded_rose = GildedRose()
        items = [Item('Concert Tickets', 1, 48)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, 0)
        self.assertEqual(items[0].quality, 50)

    def test_on_sell_date(self):
        gilded_rose = GildedRose()
        items = [Item('Concert Tickets', 0, 10)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, -1)
        self.assertEqual(items[0].quality, 0)

    def test_after_sell_date(self):
        gilded_rose = GildedRose()
        items = [Item('Concert Tickets', -10, 10)]

        gilded_rose.process_end_of_day(items)

        self.assertEqual(items[0].days_remaining, -11)
        self.assertEqual(items[0].quality, 0)


if __name__ == '__main__':
    unittest.main()
