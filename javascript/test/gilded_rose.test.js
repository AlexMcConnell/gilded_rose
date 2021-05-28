const {GildedRose} = require("../src/gilded_rose");
const {Item} = require("../src/item");

describe("Gilded Rose", () => {
  describe("Normal Item", () => {
    it("before sell date", () => {
      const gildedRose = new GildedRose([new Item("foo", 5, 10)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(4);
      expect(gildedRose.items[0].quality).toBe(9);
    });

    it("with min quality", () => {
      const gildedRose = new GildedRose([new Item("foo", 5, 0)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(4);
      expect(gildedRose.items[0].quality).toBe(0);
    });

    it("on sell date", () => {
      const gildedRose = new GildedRose([new Item("foo", 0, 10)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(-1);
      expect(gildedRose.items[0].quality).toBe(8);
    });

    it("on sell date with min quality", () => {
      const gildedRose = new GildedRose([new Item("foo", 0, 0)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(-1);
      expect(gildedRose.items[0].quality).toBe(0);
    });

    it("on sell date near min quality", () => {
      const gildedRose = new GildedRose([new Item("foo", 0, 1)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(-1);
      expect(gildedRose.items[0].quality).toBe(0);
    });

    it("after sell date", () => {
      const gildedRose = new GildedRose([new Item("foo", -10, 10)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(-11);
      expect(gildedRose.items[0].quality).toBe(8);
    });

    it("after sell date with min quality", () => {
      const gildedRose = new GildedRose([new Item("foo", -10, 0)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(-11);
      expect(gildedRose.items[0].quality).toBe(0);
    });

    it("after sell date near min quality", () => {
      const gildedRose = new GildedRose([new Item("foo", -10, 1)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(-11);
      expect(gildedRose.items[0].quality).toBe(0);
    });
  });

  describe("Aged Brie", () => {
    it("before sell date", () => {
      const gildedRose = new GildedRose([new Item("Aged Brie", 5, 10)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(4);
      expect(gildedRose.items[0].quality).toBe(11);
    });

    it("with max quality", () => {
      const gildedRose = new GildedRose([new Item("Aged Brie", 5, 50)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(4);
      expect(gildedRose.items[0].quality).toBe(50);
    });

    it("on sell date", () => {
      const gildedRose = new GildedRose([new Item("Aged Brie", 0, 10)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(-1);
      expect(gildedRose.items[0].quality).toBe(12);
    });

    it("on sell date with max quality", () => {
      const gildedRose = new GildedRose([new Item("Aged Brie", 0, 50)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(-1);
      expect(gildedRose.items[0].quality).toBe(50);
    });

    it("on sell date near max quality", () => {
      const gildedRose = new GildedRose([new Item("Aged Brie", 0, 49)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(-1);
      expect(gildedRose.items[0].quality).toBe(50);
    });

    it("after sell date", () => {
      const gildedRose = new GildedRose([new Item("Aged Brie", -10, 10)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(-11);
      expect(gildedRose.items[0].quality).toBe(12);
    });

    it("after sell date with max quality", () => {
      const gildedRose = new GildedRose([new Item("Aged Brie", -10, 50)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(-11);
      expect(gildedRose.items[0].quality).toBe(50);
    });

    it("after sell date near max quality", () => {
      const gildedRose = new GildedRose([new Item("Aged Brie", -10, 49)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(-11);
      expect(gildedRose.items[0].quality).toBe(50);
    });
  });

  describe("Sulfuras, Hand of Ragnaros", () => {
    it("before sell date", () => {
      const gildedRose = new GildedRose([new Item("Sulfuras, Hand of Ragnaros", 5, 80)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(5);
      expect(gildedRose.items[0].quality).toBe(80);
    });

    it("on sell date", () => {
      const gildedRose = new GildedRose([new Item("Sulfuras, Hand of Ragnaros", 0, 80)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(0);
      expect(gildedRose.items[0].quality).toBe(80);
    });

    it("after sell date", () => {
      const gildedRose = new GildedRose([new Item("Sulfuras, Hand of Ragnaros", -10, 80)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(-10);
      expect(gildedRose.items[0].quality).toBe(80);
    });
  });

  describe("Backstage passes to a TAFKAL80ETC concert", () => {
    it("long before sell date", () => {
      const gildedRose = new GildedRose([new Item("Backstage passes to a TAFKAL80ETC concert", 11, 10)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(10);
      expect(gildedRose.items[0].quality).toBe(11);
    });

    it("long before sell date at max quality", () => {
      const gildedRose = new GildedRose([new Item("Backstage passes to a TAFKAL80ETC concert", 11, 50)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(10);
      expect(gildedRose.items[0].quality).toBe(50);
    });

    it("medium close to sell date upper bound", () => {
      const gildedRose = new GildedRose([new Item("Backstage passes to a TAFKAL80ETC concert", 10, 10)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(9);
      expect(gildedRose.items[0].quality).toBe(12);
    });

    it("medium close to sell date upper bound at max quality", () => {
      const gildedRose = new GildedRose([new Item("Backstage passes to a TAFKAL80ETC concert", 10, 50)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(9);
      expect(gildedRose.items[0].quality).toBe(50);
    });

    it("medium close to sell date upper bound near max quality", () => {
      const gildedRose = new GildedRose([new Item("Backstage passes to a TAFKAL80ETC concert", 10, 49)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(9);
      expect(gildedRose.items[0].quality).toBe(50);
    });

    it("medium close to sell date lower bound", () => {
      const gildedRose = new GildedRose([new Item("Backstage passes to a TAFKAL80ETC concert", 6, 10)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(5);
      expect(gildedRose.items[0].quality).toBe(12);
    });

    it("medium close to sell date lower bound at max quality", () => {
      const gildedRose = new GildedRose([new Item("Backstage passes to a TAFKAL80ETC concert", 6, 50)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(5);
      expect(gildedRose.items[0].quality).toBe(50);
    });

    it("medium close to sell date lower bound near max quality", () => {
      const gildedRose = new GildedRose([new Item("Backstage passes to a TAFKAL80ETC concert", 6, 49)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(5);
      expect(gildedRose.items[0].quality).toBe(50);
    });

    it("very close to sell date upper bound", () => {
      const gildedRose = new GildedRose([new Item("Backstage passes to a TAFKAL80ETC concert", 5, 10)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(4);
      expect(gildedRose.items[0].quality).toBe(13);
    });

    it("very close to sell date upper bound at max quality", () => {
      const gildedRose = new GildedRose([new Item("Backstage passes to a TAFKAL80ETC concert", 5, 50)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(4);
      expect(gildedRose.items[0].quality).toBe(50);
    });

    it("very close to sell date upper bound near max quality", () => {
      const gildedRose = new GildedRose([new Item("Backstage passes to a TAFKAL80ETC concert", 5, 48)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(4);
      expect(gildedRose.items[0].quality).toBe(50);
    });

    it("very close to sell date lower bound", () => {
      const gildedRose = new GildedRose([new Item("Backstage passes to a TAFKAL80ETC concert", 1, 10)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(0);
      expect(gildedRose.items[0].quality).toBe(13);
    });

    it("very close to sell date lower bound at max quality", () => {
      const gildedRose = new GildedRose([new Item("Backstage passes to a TAFKAL80ETC concert", 1, 50)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(0);
      expect(gildedRose.items[0].quality).toBe(50);
    });

    it("very close to sell date lower bound near max quality", () => {
      const gildedRose = new GildedRose([new Item("Backstage passes to a TAFKAL80ETC concert", 1, 48)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(0);
      expect(gildedRose.items[0].quality).toBe(50);
    });

    it("on sell date", () => {
      const gildedRose = new GildedRose([new Item("Backstage passes to a TAFKAL80ETC concert", 0, 10)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(-1);
      expect(gildedRose.items[0].quality).toBe(0);
    });

    it("after sell date", () => {
      const gildedRose = new GildedRose([new Item("Backstage passes to a TAFKAL80ETC concert", -10, 10)]);

      gildedRose.updateQuality();

      expect(gildedRose.items[0].daysRemaining).toBe(-11);
      expect(gildedRose.items[0].quality).toBe(0);
    });
  });
});
