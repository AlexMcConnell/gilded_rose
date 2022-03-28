using ConsoleApplication;
using System;
using System.Collections.Generic;
using Xunit;

namespace GildedRoseApp.Console.Tests
{
    public class GildedRoseTests
    {
        [Fact]
        public void normalItem_BeforeSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", DaysRemaining = 5, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(4, Items[0].DaysRemaining);
            Assert.Equal(9, Items[0].Quality);
        }

        [Fact]
        public void normalItem_WithMinQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", DaysRemaining = 5, Quality = 0 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(4, Items[0].DaysRemaining);
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void normalItem_OnSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", DaysRemaining = 0, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(-1, Items[0].DaysRemaining);
            Assert.Equal(8, Items[0].Quality);
        }

        [Fact]
        public void normalItem_OnSellDateWithMinQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", DaysRemaining = 0, Quality = 0 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(-1, Items[0].DaysRemaining);
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void normalItem_OnSellDateNearMinQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", DaysRemaining = 0, Quality = 1 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(-1, Items[0].DaysRemaining);
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void normalItem_AfterSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", DaysRemaining = -10, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(-11, Items[0].DaysRemaining);
            Assert.Equal(8, Items[0].Quality);
        }

        [Fact]
        public void normalItem_AfterSellDateWithMinQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", DaysRemaining = -10, Quality = 0 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(-11, Items[0].DaysRemaining);
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void normalItem_AfterSellDateNearMinQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", DaysRemaining = -10, Quality = 1 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(-11, Items[0].DaysRemaining);
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void agedBrie_BeforeSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Cheddar", DaysRemaining = 5, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(4, Items[0].DaysRemaining);
            Assert.Equal(11, Items[0].Quality);
        }

        [Fact]
        public void agedBrie_WithMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Cheddar", DaysRemaining = 5, Quality = 50 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(4, Items[0].DaysRemaining);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void agedBrie_OnSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Cheddar", DaysRemaining = 0, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(-1, Items[0].DaysRemaining);
            Assert.Equal(12, Items[0].Quality);
        }

        [Fact]
        public void agedBrie_OnSellDateWithMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Cheddar", DaysRemaining = 0, Quality = 50 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(-1, Items[0].DaysRemaining);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void agedBrie_OnSellDateNearMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Cheddar", DaysRemaining = 0, Quality = 49 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(-1, Items[0].DaysRemaining);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void agedBrie_AfterSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Cheddar", DaysRemaining = -10, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(-11, Items[0].DaysRemaining);
            Assert.Equal(12, Items[0].Quality);
        }

        [Fact]
        public void agedBrie_AfterSellDateWithMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Cheddar", DaysRemaining = -10, Quality = 50 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(-11, Items[0].DaysRemaining);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void agedBrie_AfterSellDateNearMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Cheddar", DaysRemaining = -10, Quality = 49 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(-11, Items[0].DaysRemaining);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void sulfuras_BeforeSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Hammer", DaysRemaining = 5, Quality = 80 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(5, Items[0].DaysRemaining);
            Assert.Equal(80, Items[0].Quality);
        }

        [Fact]
        public void sulfuras_OnSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Hammer", DaysRemaining = 0, Quality = 80 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(0, Items[0].DaysRemaining);
            Assert.Equal(80, Items[0].Quality);
        }

        [Fact]
        public void sulfuras_AfterSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Hammer", DaysRemaining = -10, Quality = 80 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(-10, Items[0].DaysRemaining);
            Assert.Equal(80, Items[0].Quality);
        }

        [Fact]
        public void backstagePass_LongBeforeSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Concert Tickets", DaysRemaining = 11, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(10, Items[0].DaysRemaining);
            Assert.Equal(11, Items[0].Quality);
        }

        [Fact]
        public void backstagePass_LongBeforeSellDateAtMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Concert Tickets", DaysRemaining = 11, Quality = 50 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(10, Items[0].DaysRemaining);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void backstagePass_MediumCloseToSellDateUpperBound()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Concert Tickets", DaysRemaining = 10, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(9, Items[0].DaysRemaining);
            Assert.Equal(12, Items[0].Quality);
        }

        [Fact]
        public void backstagePass_MediumCloseToSellDateUpperBoundAtMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Concert Tickets", DaysRemaining = 10, Quality = 50 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(9, Items[0].DaysRemaining);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void backstagePass_MediumCloseToSellDateUpperBoundNearMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Concert Tickets", DaysRemaining = 10, Quality = 49 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(9, Items[0].DaysRemaining);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void backstagePass_MediumCloseToSellDateLowerBound()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Concert Tickets", DaysRemaining = 6, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(5, Items[0].DaysRemaining);
            Assert.Equal(12, Items[0].Quality);
        }

        [Fact]
        public void backstagePass_MediumCloseToSellDateLowerBoundAtMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Concert Tickets", DaysRemaining = 6, Quality = 50 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(5, Items[0].DaysRemaining);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void backstagePass_MediumCloseToSellDateLowerBoundNearMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Concert Tickets", DaysRemaining = 6, Quality = 49 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(5, Items[0].DaysRemaining);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void backstagePass_VeryCloseToSellDateUpperBound()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Concert Tickets", DaysRemaining = 5, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(4, Items[0].DaysRemaining);
            Assert.Equal(13, Items[0].Quality);
        }

        [Fact]
        public void backstagePass_VeryCloseToSellDateUpperBoundAtMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Concert Tickets", DaysRemaining = 5, Quality = 50 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(4, Items[0].DaysRemaining);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void backstagePass_VeryCloseToSellDateUpperBoundNearMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Concert Tickets", DaysRemaining = 5, Quality = 48 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(4, Items[0].DaysRemaining);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void backstagePass_VeryCloseToSellDateLowerBound()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Concert Tickets", DaysRemaining = 1, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(0, Items[0].DaysRemaining);
            Assert.Equal(13, Items[0].Quality);
        }

        [Fact]
        public void backstagePass_VeryCloseToSellDateLowerBoundAtMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Concert Tickets", DaysRemaining = 1, Quality = 50 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(0, Items[0].DaysRemaining);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void backstagePass_VeryCloseToSellDateLowerBoundNearMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Concert Tickets", DaysRemaining = 1, Quality = 48 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(0, Items[0].DaysRemaining);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void backstagePass_OnSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Concert Tickets", DaysRemaining = 0, Quality = 50 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(-1, Items[0].DaysRemaining);
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void backstagePass_AfterSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Concert Tickets", DaysRemaining = -10, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(-11, Items[0].DaysRemaining);
            Assert.Equal(0, Items[0].Quality);
        }
    }
}
