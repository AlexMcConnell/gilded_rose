using System;
using System.Collections.Generic;
using ConsoleApplication;
using Xunit;

namespace GildedRoseApp.Console.Tests
{
    public class GildedRoseTests
    {
        [Fact]
        public void normalItem_BeforeSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 5, Quality = 10 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(4, app.GetItems()[0].SellIn);
            Assert.Equal(9, app.GetItems()[0].Quality);
        }

        [Fact]
        public void normalItem_OnSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 10 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(-1, app.GetItems()[0].SellIn);
            Assert.Equal(8, app.GetItems()[0].Quality);
        }

        [Fact]
        public void normalItem_AfterSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = -10, Quality = 10 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(-11, app.GetItems()[0].SellIn);
            Assert.Equal(8, app.GetItems()[0].Quality);
        }

        [Fact]
        public void normalItem_OfZeroQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 5, Quality = 0 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(4, app.GetItems()[0].SellIn);
            Assert.Equal(0, app.GetItems()[0].Quality);
        }

        [Fact]
        public void agedBrie_BeforeSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 10 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(4, app.GetItems()[0].SellIn);
            Assert.Equal(11, app.GetItems()[0].Quality);
        }

        [Fact]
        public void agedBrie_WithMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 50 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(4, app.GetItems()[0].SellIn);
            Assert.Equal(50, app.GetItems()[0].Quality);
        }

        [Fact]
        public void agedBrie_OnSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 10 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(-1, app.GetItems()[0].SellIn);
            Assert.Equal(12, app.GetItems()[0].Quality);
        }

        [Fact]
        public void agedBrie_OnSellDateNearMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 49 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(-1, app.GetItems()[0].SellIn);
            Assert.Equal(50, app.GetItems()[0].Quality);
        }

        [Fact]
        public void agedBrie_OnSellDateWithMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 50 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(-1, app.GetItems()[0].SellIn);
            Assert.Equal(50, app.GetItems()[0].Quality);
        }

        [Fact]
        public void agedBrie_AfterSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = -10, Quality = 10 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(-11, app.GetItems()[0].SellIn);
            Assert.Equal(12, app.GetItems()[0].Quality);
        }

        [Fact]
        public void agedBrie_AfterSellDateWithMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = -10, Quality = 50 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(-11, app.GetItems()[0].SellIn);
            Assert.Equal(50, app.GetItems()[0].Quality);
        }

        [Fact]
        public void sulfuras_BeforeSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 5, Quality = 80 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(5, app.GetItems()[0].SellIn);
            Assert.Equal(80, app.GetItems()[0].Quality);
        }

        [Fact]
        public void sulfuras_OnSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(0, app.GetItems()[0].SellIn);
            Assert.Equal(80, app.GetItems()[0].Quality);
        }

        [Fact]
        public void sulfuras_AfterSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -10, Quality = 80 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(-10, app.GetItems()[0].SellIn);
            Assert.Equal(80, app.GetItems()[0].Quality);
        }

        [Fact]
        public void backstagePass_LongBeforeSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 10 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(10, app.GetItems()[0].SellIn);
            Assert.Equal(11, app.GetItems()[0].Quality);
        }

        [Fact]
        public void backstagePass_LongBeforeSellDateAtMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 11, Quality = 50 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(10, app.GetItems()[0].SellIn);
            Assert.Equal(50, app.GetItems()[0].Quality);
        }

        [Fact]
        public void backstagePass_MediumCloseToSellDateUpperBound()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(9, app.GetItems()[0].SellIn);
            Assert.Equal(12, app.GetItems()[0].Quality);
        }

        [Fact]
        public void backstagePass_MediumCloseToSellDateUpperBoundAtMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 50 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(9, app.GetItems()[0].SellIn);
            Assert.Equal(50, app.GetItems()[0].Quality);
        }

        [Fact]
        public void backstagePass_MediumCloseToSellDateLowerBound()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 6, Quality = 10 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(5, app.GetItems()[0].SellIn);
            Assert.Equal(12, app.GetItems()[0].Quality);
        }

        [Fact]
        public void backstagePass_MediumCloseToSellDateLowerBoundAtMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 6, Quality = 50 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(5, app.GetItems()[0].SellIn);
            Assert.Equal(50, app.GetItems()[0].Quality);
        }

        [Fact]
        public void backstagePass_VeryCloseToSellDateUpperBound()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(4, app.GetItems()[0].SellIn);
            Assert.Equal(13, app.GetItems()[0].Quality);
        }

        [Fact]
        public void backstagePass_VeryCloseToSellDateUpperBoundAtMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 50 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(4, app.GetItems()[0].SellIn);
            Assert.Equal(50, app.GetItems()[0].Quality);
        }

        [Fact]
        public void backstagePass_VeryCloseToSellDateLowerBound()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 10 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(0, app.GetItems()[0].SellIn);
            Assert.Equal(13, app.GetItems()[0].Quality);
        }

        [Fact]
        public void backstagePass_VeryCloseToSellDateLowerBoundAtMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 1, Quality = 50 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(0, app.GetItems()[0].SellIn);
            Assert.Equal(50, app.GetItems()[0].Quality);
        }

        [Fact]
        public void backstagePass_OnSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 50 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(-1, app.GetItems()[0].SellIn);
            Assert.Equal(0, app.GetItems()[0].Quality);
        }

        [Fact]
        public void backstagePass_AfterSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = -10, Quality = 10 } };
            var app = new Program(Items);
            app.UpdateQuality();

            Assert.Equal(-11, app.GetItems()[0].SellIn);
            Assert.Equal(0, app.GetItems()[0].Quality);
        }
    }
}
