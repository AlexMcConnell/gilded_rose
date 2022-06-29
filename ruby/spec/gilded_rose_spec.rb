require "spec_helper"
require "json"

require_relative "../lib/gilded_rose"
require_relative "../lib/item"

RSpec.describe GildedRose do

  context "Normal Item" do
    it "before sell date" do
      items = [Item.new(name: "Any other string", days_remaining: 5, quality: 10)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: 4, quality: 9)
    end

    it "with min quality" do
      items = [Item.new(name: "Any other string", days_remaining: 5, quality: 0)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: 4, quality: 0)
    end

    it "on sell date" do
      items = [Item.new(name: "Any other string", days_remaining: 0, quality: 10)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: -1, quality: 8)
    end

    it "on sell date with min quality" do
      items = [Item.new(name: "Any other string", days_remaining: 0, quality: 0)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: -1, quality: 0)
    end

    it "on sell date near min quality" do
      items = [Item.new(name: "Any other string", days_remaining: 0, quality: 1)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: -1, quality: 0)
    end

    it "after sell date" do
      items = [Item.new(name: "Any other string", days_remaining: -10, quality: 10)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: -11, quality: 8)
    end

    it "after sell date with min quality" do
      items = [Item.new(name: "Any other string", days_remaining: -10, quality: 0)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: -11, quality: 0)
    end

    it "after sell date near min quality" do
      items = [Item.new(name: "Any other string", days_remaining: -10, quality: 1)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: -11, quality: 0)
    end
  end

  context "Aged Cheddar" do
    it "before sell date" do
      items = [Item.new(name: "Aged Cheddar", days_remaining: 5, quality: 10)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: 4, quality: 11)
    end

    it "with max quality" do
      items = [Item.new(name: "Aged Cheddar", days_remaining: 5, quality: 50)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: 4, quality: 50)
    end

    it "on sell date" do
      items = [Item.new(name: "Aged Cheddar", days_remaining: 0, quality: 10)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: -1, quality: 12)
    end

    it "on sell date with max quality" do
      items = [Item.new(name: "Aged Cheddar", days_remaining: 0, quality: 50)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: -1, quality: 50)
    end

    it "on sell date near max quality" do
      items = [Item.new(name: "Aged Cheddar", days_remaining: 0, quality: 49)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: -1, quality: 50)
    end

    it "after sell date" do
      items = [Item.new(name: "Aged Cheddar", days_remaining: -10, quality: 10)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: -11, quality: 12)
    end

    it "after sell date with max quality" do
      items = [Item.new(name: "Aged Cheddar", days_remaining: -10, quality: 50)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: -11, quality: 50)
    end

    it "after sell date near max quality" do
      items = [Item.new(name: "Aged Cheddar", days_remaining: -10, quality: 49)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: -11, quality: 50)
    end
  end

  context "Hammer" do
    it "before sell date" do
      items = [Item.new(name: "Hammer", days_remaining: 10, quality: 40)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: 10, quality: 40)
    end

    it "on sell date" do
      items = [Item.new(name: "Hammer", days_remaining: 0, quality: 40)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: 0, quality: 40)
    end

    it "after sell date" do
      items = [Item.new(name: "Hammer", days_remaining: -10, quality: 40)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: -10, quality: 40)
    end
  end

  context "Concert Tickets" do
    it "long before sell date" do
      items = [Item.new(name: "Concert Tickets", days_remaining: 11, quality: 10)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: 10, quality: 11)
    end

    it "long before sell date at max quality" do
      items = [Item.new(name: "Concert Tickets", days_remaining: 11, quality: 50)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: 10, quality: 50)
    end

    it "medium close to sell date upper bound" do
      items = [Item.new(name: "Concert Tickets", days_remaining: 10, quality: 10)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: 9, quality: 12)
    end

    it "medium close to sell date upper bound at max quality" do
      items = [Item.new(name: "Concert Tickets", days_remaining: 10, quality: 50)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: 9, quality: 50)
    end

    it "medium close to sell date upper bound near max quality" do
      items = [Item.new(name: "Concert Tickets", days_remaining: 10, quality: 49)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: 9, quality: 50)
    end

    it "medium close to sell date lower bound" do
      items = [Item.new(name: "Concert Tickets", days_remaining: 6, quality: 10)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: 5, quality: 12)
    end

    it "medium close to sell date lower bound at max quality" do
      items = [Item.new(name: "Concert Tickets", days_remaining: 6, quality: 50)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: 5, quality: 50)
    end

    it "medium close to sell date lower bound near max quality" do
      items = [Item.new(name: "Concert Tickets", days_remaining: 6, quality: 49)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: 5, quality: 50)
    end

    it "very close to sell date upper bound" do
      items = [Item.new(name: "Concert Tickets", days_remaining: 5, quality: 10)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: 4, quality: 13)
    end

    it "very close to sell date upper bound at max quality" do
      items = [Item.new(name: "Concert Tickets", days_remaining: 5, quality: 50)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: 4, quality: 50)
    end

    it "very close to sell date upper bound near max quality" do
      items = [Item.new(name: "Concert Tickets", days_remaining: 5, quality: 48)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: 4, quality: 50)
    end

    it "very close to sell date lower bound" do
      items = [Item.new(name: "Concert Tickets", days_remaining: 1, quality: 10)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: 0, quality: 13)
    end

    it "very close to sell date lower bound at max quality" do
      items = [Item.new(name: "Concert Tickets", days_remaining: 1, quality: 50)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: 0, quality: 50)
    end

    it "very close to sell date lower bound near max quality" do
      items = [Item.new(name: "Concert Tickets", days_remaining: 1, quality: 48)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: 0, quality: 50)
    end

    it "on sell date" do
      items = [Item.new(name: "Concert Tickets", days_remaining: 0, quality: 10)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: -1, quality: 0)
    end

    it "after sell date" do
      items = [Item.new(name: "Concert Tickets", days_remaining: -10, quality: 10)]
    
      subject.process_end_of_day(items)
    
      expect(items[0]).to have_attributes(days_remaining: -11, quality: 0)
    end
  end
end
