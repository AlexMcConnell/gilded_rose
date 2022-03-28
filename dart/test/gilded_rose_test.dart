import 'dart:convert';
import 'dart:io';

import 'package:test/test.dart';
import 'package:gilded_rose/gilded_rose.dart';
import 'package:gilded_rose/item.dart';

main() async {
  await new File('../test_cases.json').readAsString().then((file) {
    final List<dynamic> parsed = json.decode(file);

    parsed.forEach((contextGroup) {
      group(contextGroup['context'], () {
        contextGroup['testCases'].forEach((testCase) {
          test(testCase['testName'], () {
            var item = new Item(
              name: contextGroup['itemName'],
              daysRemaining: testCase['startingDaysRemaining'],
              quality: testCase['startingQuality'],
            );
            var items = [item];

            GildedRose(items).processEndOfDay();

            expect(items[0].daysRemaining, testCase['expectedDaysRemaining']);
            expect(items[0].quality, testCase['expectedQuality']);
          });
        });
      });
    });
  });
}
