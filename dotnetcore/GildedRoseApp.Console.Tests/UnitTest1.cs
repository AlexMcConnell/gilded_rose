using System;
using System.Collections.Generic;
using ConsoleApplication;
using Xunit;

namespace GildedRoseApp.Console.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void CanSetandReadItems()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            var app = new Program(Items);

            Assert.Equal("foo", app.GetItems()[0].Name);
        }

        [Fact]
        public void NormalItemAfterOneDay_QualityandSellInDecrementedByOne()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 10 } };
            var app = new Program(Items);
            app.UpdateQuality();

            // Quality should be 9
            Assert.Equal(9, app.GetItems()[0].Quality);
            // SellIn should be 9
            Assert.Equal(9, app.GetItems()[0].SellIn);
        }

        [Fact]
        public void NormalItemAfterSellIn_QualityDecrementedByTwo()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 10 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(8, app.GetItems()[0].Quality);
        }

        [Fact]
        public void QualityCanNeverBeNegative()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 10, Quality = 0 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(0, app.GetItems()[0].Quality);
        }

        [Fact]
        public void AgedBrieGetsBetterWithAge()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 0 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(1, app.GetItems()[0].Quality);
        }

        [Fact]
        public void ItemQualityCannotBeGreaterThanFifty()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 10, Quality = 50 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(50, app.GetItems()[0].Quality);
        }

        [Fact]
        public void SulfurasValuesDoNotChange()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(80, app.GetItems()[0].Quality);
        }

        [Fact]
        public void BackstagePasses_GreaterThan10Days_QualityIncreasesByOne()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 12, Quality = 10 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(11, app.GetItems()[0].Quality);
        }

        [Fact]
        public void BackstagePasses_LessThanOrEqual10DaysButGreaterThanFive_QualityIncreasesByTwo()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 }
            };
            var app = new Program(Items);
            app.UpdateQuality();

            // 10 days
            Assert.Equal(12, app.GetItems()[0].Quality);
            // 5 days
            Assert.Equal(13, app.GetItems()[1].Quality);
        }

        [Fact]
        public void BackstagePasses_LessThanOrEqual5DaysButGreaterThanZero_QualityIncreasesByThree()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 },
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 10 }
            };
            var app = new Program(Items);
            app.UpdateQuality();

            // 5 days
            Assert.Equal(13, app.GetItems()[0].Quality);
            // 1 days
            Assert.Equal(13, app.GetItems()[1].Quality);
        }

        [Fact]
        public void BackstagePasses_AfterShowPasses_QualityEqualsZero()
        {
            IList<Item> Items = new List<Item> {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10 }
            };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(0, app.GetItems()[0].Quality);
        }

//        [Fact]
//        public void ConjuredItemsDegradeTwoPerDay_PositiveSellIn()
//        {
//            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 5, Quality = 10 } };
//            var app = new Program(Items);
//            app.UpdateQuality();
//
//            Assert.Equal(8, app.GetItems()[0].Quality);
//        }
//
//        [Fact]^M
//        public void ConjuredItemsNoDegrade_ZeroQuality()
//        {
//            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 5, Quality = 0 } };
//            var app = new Program(Items);
//            app.UpdateQuality();
//
//            Assert.Equal(0, app.GetItems()[0].Quality);
//        }
//
//        [Fact]^M
//        public void ConjuredItemsDegradeFourPerDay_ZeroSellIn()
//        {
//            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 0, Quality = 10 } };
//            var app = new Program(Items);
//            app.UpdateQuality();
//
//            Assert.Equal(6, app.GetItems()[0].Quality);
//        }
//
//        [Fact]
//        public void ConjuredItemsDegradeFourPerDay_NegativeSellIn()
//        {
//            IList<Item> Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = -1, Quality = 10 } };
//            var app = new Program(Items);
//            app.UpdateQuality();
//
//            Assert.Equal(6, app.GetItems()[0].Quality);
//        }
    }
}
