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
        public void agedCheddar_BeforeSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Cheddar", DaysRemaining = 5, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(4, Items[0].DaysRemaining);
            Assert.Equal(11, Items[0].Quality);
        }

        [Fact]
        public void agedCheddar_WithMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Cheddar", DaysRemaining = 5, Quality = 50 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(4, Items[0].DaysRemaining);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void agedCheddar_OnSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Cheddar", DaysRemaining = 0, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(-1, Items[0].DaysRemaining);
            Assert.Equal(12, Items[0].Quality);
        }

        [Fact]
        public void agedCheddar_OnSellDateWithMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Cheddar", DaysRemaining = 0, Quality = 50 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(-1, Items[0].DaysRemaining);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void agedCheddar_OnSellDateNearMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Cheddar", DaysRemaining = 0, Quality = 49 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(-1, Items[0].DaysRemaining);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void agedCheddar_AfterSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Cheddar", DaysRemaining = -10, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(-11, Items[0].DaysRemaining);
            Assert.Equal(12, Items[0].Quality);
        }

        [Fact]
        public void agedCheddar_AfterSellDateWithMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Cheddar", DaysRemaining = -10, Quality = 50 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(-11, Items[0].DaysRemaining);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void agedCheddar_AfterSellDateNearMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Cheddar", DaysRemaining = -10, Quality = 49 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(-11, Items[0].DaysRemaining);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void hammer_BeforeSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Hammer", DaysRemaining = 5, Quality = 80 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(5, Items[0].DaysRemaining);
            Assert.Equal(80, Items[0].Quality);
        }

        [Fact]
        public void hammer_OnSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Hammer", DaysRemaining = 0, Quality = 80 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(0, Items[0].DaysRemaining);
            Assert.Equal(80, Items[0].Quality);
        }

        [Fact]
        public void hammer_AfterSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Hammer", DaysRemaining = -10, Quality = 80 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(-10, Items[0].DaysRemaining);
            Assert.Equal(80, Items[0].Quality);
        }

        [Fact]
        public void concertTickets_LongBeforeSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Concert Tickets", DaysRemaining = 11, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(10, Items[0].DaysRemaining);
            Assert.Equal(11, Items[0].Quality);
        }

        [Fact]
        public void concertTickets_LongBeforeSellDateAtMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Concert Tickets", DaysRemaining = 11, Quality = 50 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(10, Items[0].DaysRemaining);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void concertTickets_MediumCloseToSellDateUpperBound()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Concert Tickets", DaysRemaining = 10, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(9, Items[0].DaysRemaining);
            Assert.Equal(12, Items[0].Quality);
        }

        [Fact]
        public void concertTickets_MediumCloseToSellDateUpperBoundAtMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Concert Tickets", DaysRemaining = 10, Quality = 50 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(9, Items[0].DaysRemaining);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void concertTickets_MediumCloseToSellDateUpperBoundNearMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Concert Tickets", DaysRemaining = 10, Quality = 49 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(9, Items[0].DaysRemaining);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void concertTickets_MediumCloseToSellDateLowerBound()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Concert Tickets", DaysRemaining = 6, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(5, Items[0].DaysRemaining);
            Assert.Equal(12, Items[0].Quality);
        }

        [Fact]
        public void concertTickets_MediumCloseToSellDateLowerBoundAtMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Concert Tickets", DaysRemaining = 6, Quality = 50 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(5, Items[0].DaysRemaining);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void concertTickets_MediumCloseToSellDateLowerBoundNearMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Concert Tickets", DaysRemaining = 6, Quality = 49 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(5, Items[0].DaysRemaining);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void concertTickets_VeryCloseToSellDateUpperBound()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Concert Tickets", DaysRemaining = 5, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(4, Items[0].DaysRemaining);
            Assert.Equal(13, Items[0].Quality);
        }

        [Fact]
        public void concertTickets_VeryCloseToSellDateUpperBoundAtMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Concert Tickets", DaysRemaining = 5, Quality = 50 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(4, Items[0].DaysRemaining);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void concertTickets_VeryCloseToSellDateUpperBoundNearMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Concert Tickets", DaysRemaining = 5, Quality = 48 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(4, Items[0].DaysRemaining);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void concertTickets_VeryCloseToSellDateLowerBound()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Concert Tickets", DaysRemaining = 1, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(0, Items[0].DaysRemaining);
            Assert.Equal(13, Items[0].Quality);
        }

        [Fact]
        public void concertTickets_VeryCloseToSellDateLowerBoundAtMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Concert Tickets", DaysRemaining = 1, Quality = 50 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(0, Items[0].DaysRemaining);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void concertTickets_VeryCloseToSellDateLowerBoundNearMaxQuality()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Concert Tickets", DaysRemaining = 1, Quality = 48 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(0, Items[0].DaysRemaining);
            Assert.Equal(50, Items[0].Quality);
        }

        [Fact]
        public void concertTickets_OnSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Concert Tickets", DaysRemaining = 0, Quality = 50 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(-1, Items[0].DaysRemaining);
            Assert.Equal(0, Items[0].Quality);
        }

        [Fact]
        public void concertTickets_AfterSellDate()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Concert Tickets", DaysRemaining = -10, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(Items);

            Assert.Equal(-11, Items[0].DaysRemaining);
            Assert.Equal(0, Items[0].Quality);
        }
    }
}
