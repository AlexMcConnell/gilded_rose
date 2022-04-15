import 'dart:convert';
import 'dart:io';

import 'package:test/test.dart';
import 'package:gilded_rose/gilded_rose.dart';
import 'package:gilded_rose/item.dart';

main() async {
  void testItem(
    itemName,
    testName,
    startingDaysRemaining,
    startingQuality,
    expectedDaysRemaining,
    expectedQuality,
  ) {
    test('before sell date', () {
      final item = new Item(
        name: itemName,
        daysRemaining: startingDaysRemaining,
        quality: startingQuality,
      );
      final items = [item];

      GildedRose(items).processEndOfDay();

      expect(items[0].daysRemaining, expectedDaysRemaining);
      expect(items[0].quality, expectedQuality);
    });
  }

  group('Normal Item', () {
    const name = 'Any other string';

    testItem(name, 'before sell date',                  10, 10,   9,  9);
    testItem(name, 'with min quality',                  10,  0,   9,  0);
    testItem(name, 'on sell date',                       0, 10,  -1,  8);
    testItem(name, 'on sell date with min quality',      0,  0,  -1,  0);
    testItem(name, 'on sell date near min quality',      0,  1,  -1,  0);
    testItem(name, 'after sell date',                  -10, 10, -11,  8);
    testItem(name, 'after sell date with min quality', -10,  0, -11,  0);
    testItem(name, 'after sell date near min quality', -10,  1, -11,  0);
  });

  group('Aged Cheddar', () {
    const name = 'Aged Cheddar';

    testItem(name, 'before sell date',                  10, 10,   9, 11);
    testItem(name, 'with max quality',                  10, 50,   9, 50);
    testItem(name, 'on sell date',                       0, 10,  -1, 12);
    testItem(name, 'on sell date with max quality',      0, 50,  -1, 50);
    testItem(name, 'on sell date near max quality',      0, 49,  -1, 50);
    testItem(name, 'after sell date',                  -10, 10, -11, 12);
    testItem(name, 'after sell date with max quality', -10, 50, -11, 50);
    testItem(name, 'after sell date near max quality', -10, 49, -11, 50);
  });

  group('Hammer', () {
    const name = 'Hammer';

    testItem(name, 'before sell date',                  10, 80,  10, 80);
    testItem(name, 'on sell date',                       0, 80,   0, 80);
    testItem(name, 'after sell date',                  -10, 80, -10, 80);
  });

  group('Concert Tickets', () {
    const name = 'Concert Tickets';

    testItem(name, 'far from expired',                                    11, 10,  10, 11);
    testItem(name, 'far from expired at max quality',                     11, 50,  10, 50);
    testItem(name, 'close to expired upper bound',                        10, 10,   9, 12);
    testItem(name, 'close to expired upper bound at max quality',         10, 50,   9, 50);
    testItem(name, 'close to expired upper bound near max quality',       10, 49,   9, 50);
    testItem(name, 'close to expired lower bound',                         6, 10,   5, 12);
    testItem(name, 'close to expired lower bound at max quality',          6, 50,   5, 50);
    testItem(name, 'close to expired lower bound near max quality',        6, 49,   5, 50);
    testItem(name, 'very close to expired upper bound',                    5, 10,   4, 13);
    testItem(name, 'very close to expired upper bound at max quality',     5, 50,   4, 50);
    testItem(name, 'very close to expired upper bound near max quality',   5, 48,   4, 50);
    testItem(name, 'very close to expired lower bound',                    1, 10,   0, 13);
    testItem(name, 'very close to expired lower bound at max quality',     1, 50,   0, 50);
    testItem(name, 'very close to expired lower bound near max quality',   1, 48,   0, 50);
    testItem(name, 'on sell date',                                         0, 10,  -1,  0);
    testItem(name, 'after sell date',                                    -10, 10, -11,  0);
  });
}
