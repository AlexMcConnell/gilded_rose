using System.Collections.Generic;
using Xunit;

namespace GildedRose.Tests;

public class GildedRoseTests
{
    public class NormalItemTests
    {
        [Fact]
        public void BeforeSellDate()
        {
            IList<Item> items = new List<Item> { new Item { Name = "randomstring", DaysRemaining = 5, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(4, items[0].DaysRemaining);
            Assert.Equal(9, items[0].Quality);
        }

        [Fact]
        public void WithMinQuality()
        {
            IList<Item> items = new List<Item> { new Item { Name = "randomstring", DaysRemaining = 5, Quality = 0 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(4, items[0].DaysRemaining);
            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void OnSellDate()
        {
            IList<Item> items = new List<Item> { new Item { Name = "randomstring", DaysRemaining = 0, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(-1, items[0].DaysRemaining);
            Assert.Equal(8, items[0].Quality);
        }

        [Fact]
        public void OnSellDateWithMinQuality()
        {
            IList<Item> items = new List<Item> { new Item { Name = "randomstring", DaysRemaining = 0, Quality = 0 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(-1, items[0].DaysRemaining);
            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void OnSellDateNearMinQuality()
        {
            IList<Item> items = new List<Item> { new Item { Name = "randomstring", DaysRemaining = 0, Quality = 1 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(-1, items[0].DaysRemaining);
            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void AfterSellDate()
        {
            IList<Item> items = new List<Item>
                { new Item { Name = "randomstring", DaysRemaining = -10, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(-11, items[0].DaysRemaining);
            Assert.Equal(8, items[0].Quality);
        }

        [Fact]
        public void AfterSellDateWithMinQuality()
        {
            IList<Item> items = new List<Item> { new Item { Name = "randomstring", DaysRemaining = -10, Quality = 0 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(-11, items[0].DaysRemaining);
            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void AfterSellDateNearMinQuality()
        {
            IList<Item> items = new List<Item> { new Item { Name = "randomstring", DaysRemaining = -10, Quality = 1 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(-11, items[0].DaysRemaining);
            Assert.Equal(0, items[0].Quality);
        }
    }

    public class AgedCheddarTests
    {
        [Fact]
        public void BeforeSellDate()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged Cheddar", DaysRemaining = 5, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(4, items[0].DaysRemaining);
            Assert.Equal(11, items[0].Quality);
        }

        [Fact]
        public void WithMaxQuality()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged Cheddar", DaysRemaining = 5, Quality = 50 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(4, items[0].DaysRemaining);
            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void OnSellDate()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged Cheddar", DaysRemaining = 0, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(-1, items[0].DaysRemaining);
            Assert.Equal(12, items[0].Quality);
        }

        [Fact]
        public void OnSellDateWithMaxQuality()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged Cheddar", DaysRemaining = 0, Quality = 50 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(-1, items[0].DaysRemaining);
            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void OnSellDateNearMaxQuality()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Aged Cheddar", DaysRemaining = 0, Quality = 49 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(-1, items[0].DaysRemaining);
            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void AfterSellDate()
        {
            IList<Item> items = new List<Item>
                { new Item { Name = "Aged Cheddar", DaysRemaining = -10, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(-11, items[0].DaysRemaining);
            Assert.Equal(12, items[0].Quality);
        }

        [Fact]
        public void AfterSellDateWithMaxQuality()
        {
            IList<Item> items = new List<Item>
                { new Item { Name = "Aged Cheddar", DaysRemaining = -10, Quality = 50 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(-11, items[0].DaysRemaining);
            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void AfterSellDateNearMaxQuality()
        {
            IList<Item> items = new List<Item>
                { new Item { Name = "Aged Cheddar", DaysRemaining = -10, Quality = 49 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(-11, items[0].DaysRemaining);
            Assert.Equal(50, items[0].Quality);
        }
    }

    public class HammerTests
    {
        [Fact]
        public void hammer_BeforeSellDate()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Hammer", DaysRemaining = 5, Quality = 40 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(5, items[0].DaysRemaining);
            Assert.Equal(40, items[0].Quality);
        }

        [Fact]
        public void hammer_OnSellDate()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Hammer", DaysRemaining = 0, Quality = 40 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(0, items[0].DaysRemaining);
            Assert.Equal(40, items[0].Quality);
        }

        [Fact]
        public void hammer_AfterSellDate()
        {
            IList<Item> items = new List<Item> { new Item { Name = "Hammer", DaysRemaining = -10, Quality = 40 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(-10, items[0].DaysRemaining);
            Assert.Equal(40, items[0].Quality);
        }
    }

    public class ConcertTicketsTests
    {
        [Fact]
        public void LongBeforeSellDate()
        {
            IList<Item> items = new List<Item>
                { new Item { Name = "Concert Tickets", DaysRemaining = 11, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(10, items[0].DaysRemaining);
            Assert.Equal(11, items[0].Quality);
        }

        [Fact]
        public void LongBeforeSellDateAtMaxQuality()
        {
            IList<Item> items = new List<Item>
                { new Item { Name = "Concert Tickets", DaysRemaining = 11, Quality = 50 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(10, items[0].DaysRemaining);
            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void MediumCloseToSellDateUpperBound()
        {
            IList<Item> items = new List<Item>
                { new Item { Name = "Concert Tickets", DaysRemaining = 10, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(9, items[0].DaysRemaining);
            Assert.Equal(12, items[0].Quality);
        }

        [Fact]
        public void MediumCloseToSellDateUpperBoundAtMaxQuality()
        {
            IList<Item> items = new List<Item>
                { new Item { Name = "Concert Tickets", DaysRemaining = 10, Quality = 50 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(9, items[0].DaysRemaining);
            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void MediumCloseToSellDateUpperBoundNearMaxQuality()
        {
            IList<Item> items = new List<Item>
                { new Item { Name = "Concert Tickets", DaysRemaining = 10, Quality = 49 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(9, items[0].DaysRemaining);
            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void MediumCloseToSellDateLowerBound()
        {
            IList<Item> items = new List<Item>
                { new Item { Name = "Concert Tickets", DaysRemaining = 6, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(5, items[0].DaysRemaining);
            Assert.Equal(12, items[0].Quality);
        }

        [Fact]
        public void MediumCloseToSellDateLowerBoundAtMaxQuality()
        {
            IList<Item> items = new List<Item>
                { new Item { Name = "Concert Tickets", DaysRemaining = 6, Quality = 50 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(5, items[0].DaysRemaining);
            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void MediumCloseToSellDateLowerBoundNearMaxQuality()
        {
            IList<Item> items = new List<Item>
                { new Item { Name = "Concert Tickets", DaysRemaining = 6, Quality = 49 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(5, items[0].DaysRemaining);
            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void VeryCloseToSellDateUpperBound()
        {
            IList<Item> items = new List<Item>
                { new Item { Name = "Concert Tickets", DaysRemaining = 5, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(4, items[0].DaysRemaining);
            Assert.Equal(13, items[0].Quality);
        }

        [Fact]
        public void VeryCloseToSellDateUpperBoundAtMaxQuality()
        {
            IList<Item> items = new List<Item>
                { new Item { Name = "Concert Tickets", DaysRemaining = 5, Quality = 50 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(4, items[0].DaysRemaining);
            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void VeryCloseToSellDateUpperBoundNearMaxQuality()
        {
            IList<Item> items = new List<Item>
                { new Item { Name = "Concert Tickets", DaysRemaining = 5, Quality = 48 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(4, items[0].DaysRemaining);
            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void VeryCloseToSellDateLowerBound()
        {
            IList<Item> items = new List<Item>
                { new Item { Name = "Concert Tickets", DaysRemaining = 1, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(0, items[0].DaysRemaining);
            Assert.Equal(13, items[0].Quality);
        }

        [Fact]
        public void VeryCloseToSellDateLowerBoundAtMaxQuality()
        {
            IList<Item> items = new List<Item>
                { new Item { Name = "Concert Tickets", DaysRemaining = 1, Quality = 50 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(0, items[0].DaysRemaining);
            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void VeryCloseToSellDateLowerBoundNearMaxQuality()
        {
            IList<Item> items = new List<Item>
                { new Item { Name = "Concert Tickets", DaysRemaining = 1, Quality = 48 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(0, items[0].DaysRemaining);
            Assert.Equal(50, items[0].Quality);
        }

        [Fact]
        public void OnSellDate()
        {
            IList<Item> items = new List<Item>
                { new Item { Name = "Concert Tickets", DaysRemaining = 0, Quality = 50 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(-1, items[0].DaysRemaining);
            Assert.Equal(0, items[0].Quality);
        }

        [Fact]
        public void AfterSellDate()
        {
            IList<Item> items = new List<Item>
                { new Item { Name = "Concert Tickets", DaysRemaining = -10, Quality = 10 } };
            new GildedRose().ProcessEndOfDay(items);

            Assert.Equal(-11, items[0].DaysRemaining);
            Assert.Equal(0, items[0].Quality);
        }
    }
}