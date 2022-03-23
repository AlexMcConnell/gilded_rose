require "spec_helper"
require "json"

require_relative "../lib/gilded_rose"
require_relative "../lib/item"

RSpec.describe GildedRose do

  file = File.read('../test_cases.json')
  parsed = JSON.parse(file)

  parsed.each do |context_group|
    context context_group['context'] do
      context_group['testCases'].each do |test_case|
        it test_case['testName'] do
          item = Item.new(
            name: context_group['itemName'],
            days_remaining: test_case['startingDaysRemaining'],
            quality: test_case['startingQuality']
          )
          items = [item]

          GildedRose.new.process_end_of_day(items)

          expect(items[0]).to have_attributes(
            days_remaining: test_case['expectedDaysRemaining'],
            quality: test_case['expectedQuality']
          )
        end
      end
    end
  end
end
