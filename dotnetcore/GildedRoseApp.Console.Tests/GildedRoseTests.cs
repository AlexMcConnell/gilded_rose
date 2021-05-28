using ConsoleApplication;
using Xunit;

namespace GildedRoseApp.Console.Tests
{
    public class GildedRoseTests
    {
        [Fact]
        public void normalItem_BeforeSellDate()
        {
            Item item = new Item { Name = "foo", DaysRemaining = 5, Quality = 10 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(4, item.DaysRemaining);
            Assert.Equal(9, item.Quality);
        }

        [Fact]
        public void normalItem_WithMinQuality()
        {
            Item item = new Item { Name = "foo", DaysRemaining = 5, Quality = 0 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(4, item.DaysRemaining);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void normalItem_OnSellDate()
        {
            Item item = new Item { Name = "foo", DaysRemaining = 0, Quality = 10 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(-1, item.DaysRemaining);
            Assert.Equal(8, item.Quality);
        }

        [Fact]
        public void normalItem_OnSellDateWithMinQuality()
        {
            Item item = new Item { Name = "foo", DaysRemaining = 0, Quality = 0 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(-1, item.DaysRemaining);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void normalItem_OnSellDateNearMinQuality()
        {
            Item item = new Item { Name = "foo", DaysRemaining = 0, Quality = 1 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(-1, item.DaysRemaining);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void normalItem_AfterSellDate()
        {
            Item item = new Item { Name = "foo", DaysRemaining = -10, Quality = 10 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(-11, item.DaysRemaining);
            Assert.Equal(8, item.Quality);
        }

        [Fact]
        public void normalItem_AfterSellDateWithMinQuality()
        {
            Item item = new Item { Name = "foo", DaysRemaining = -10, Quality = 0 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(-11, item.DaysRemaining);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void normalItem_AfterSellDateNearMinQuality()
        {
            Item item = new Item { Name = "foo", DaysRemaining = -10, Quality = 1 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(-11, item.DaysRemaining);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void agedBrie_BeforeSellDate()
        {
            Item item = new Item { Name = "Aged Brie", DaysRemaining = 5, Quality = 10 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(4, item.DaysRemaining);
            Assert.Equal(11, item.Quality);
        }

        [Fact]
        public void agedBrie_WithMaxQuality()
        {
            Item item = new Item { Name = "Aged Brie", DaysRemaining = 5, Quality = 50 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(4, item.DaysRemaining);
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void agedBrie_OnSellDate()
        {
            Item item = new Item { Name = "Aged Brie", DaysRemaining = 0, Quality = 10 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(-1, item.DaysRemaining);
            Assert.Equal(12, item.Quality);
        }

        [Fact]
        public void agedBrie_OnSellDateWithMaxQuality()
        {
            Item item = new Item { Name = "Aged Brie", DaysRemaining = 0, Quality = 50 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(-1, item.DaysRemaining);
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void agedBrie_OnSellDateNearMaxQuality()
        {
            Item item = new Item { Name = "Aged Brie", DaysRemaining = 0, Quality = 49 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(-1, item.DaysRemaining);
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void agedBrie_AfterSellDate()
        {
            Item item = new Item { Name = "Aged Brie", DaysRemaining = -10, Quality = 10 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(-11, item.DaysRemaining);
            Assert.Equal(12, item.Quality);
        }

        [Fact]
        public void agedBrie_AfterSellDateWithMaxQuality()
        {
            Item item = new Item { Name = "Aged Brie", DaysRemaining = -10, Quality = 50 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(-11, item.DaysRemaining);
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void agedBrie_AfterSellDateNearMaxQuality()
        {
            Item item = new Item { Name = "Aged Brie", DaysRemaining = -10, Quality = 49 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(-11, item.DaysRemaining);
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void sulfuras_BeforeSellDate()
        {
            Item item = new Item { Name = "Sulfuras, Hand of Ragnaros", DaysRemaining = 5, Quality = 80 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(5, item.DaysRemaining);
            Assert.Equal(80, item.Quality);
        }

        [Fact]
        public void sulfuras_OnSellDate()
        {
            Item item = new Item { Name = "Sulfuras, Hand of Ragnaros", DaysRemaining = 0, Quality = 80 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(0, item.DaysRemaining);
            Assert.Equal(80, item.Quality);
        }

        [Fact]
        public void sulfuras_AfterSellDate()
        {
            Item item = new Item { Name = "Sulfuras, Hand of Ragnaros", DaysRemaining = -10, Quality = 80 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(-10, item.DaysRemaining);
            Assert.Equal(80, item.Quality);
        }

        [Fact]
        public void backstagePass_LongBeforeSellDate()
        {
            Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", DaysRemaining = 11, Quality = 10 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(10, item.DaysRemaining);
            Assert.Equal(11, item.Quality);
        }

        [Fact]
        public void backstagePass_LongBeforeSellDateAtMaxQuality()
        {
            Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", DaysRemaining = 11, Quality = 50 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(10, item.DaysRemaining);
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void backstagePass_MediumCloseToSellDateUpperBound()
        {
            Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", DaysRemaining = 10, Quality = 10 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(9, item.DaysRemaining);
            Assert.Equal(12, item.Quality);
        }

        [Fact]
        public void backstagePass_MediumCloseToSellDateUpperBoundAtMaxQuality()
        {
            Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", DaysRemaining = 10, Quality = 50 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(9, item.DaysRemaining);
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void backstagePass_MediumCloseToSellDateUpperBoundNearMaxQuality()
        {
            Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", DaysRemaining = 10, Quality = 49 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(9, item.DaysRemaining);
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void backstagePass_MediumCloseToSellDateLowerBound()
        {
            Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", DaysRemaining = 6, Quality = 10 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(5, item.DaysRemaining);
            Assert.Equal(12, item.Quality);
        }

        [Fact]
        public void backstagePass_MediumCloseToSellDateLowerBoundAtMaxQuality()
        {
            Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", DaysRemaining = 6, Quality = 50 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(5, item.DaysRemaining);
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void backstagePass_MediumCloseToSellDateLowerBoundNearMaxQuality()
        {
            Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", DaysRemaining = 6, Quality = 49 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(5, item.DaysRemaining);
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void backstagePass_VeryCloseToSellDateUpperBound()
        {
            Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", DaysRemaining = 5, Quality = 10 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(4, item.DaysRemaining);
            Assert.Equal(13, item.Quality);
        }

        [Fact]
        public void backstagePass_VeryCloseToSellDateUpperBoundAtMaxQuality()
        {
            Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", DaysRemaining = 5, Quality = 50 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(4, item.DaysRemaining);
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void backstagePass_VeryCloseToSellDateUpperBoundNearMaxQuality()
        {
            Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", DaysRemaining = 5, Quality = 48 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(4, item.DaysRemaining);
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void backstagePass_VeryCloseToSellDateLowerBound()
        {
            Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", DaysRemaining = 1, Quality = 10 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(0, item.DaysRemaining);
            Assert.Equal(13, item.Quality);
        }

        [Fact]
        public void backstagePass_VeryCloseToSellDateLowerBoundAtMaxQuality()
        {
            Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", DaysRemaining = 1, Quality = 50 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(0, item.DaysRemaining);
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void backstagePass_VeryCloseToSellDateLowerBoundNearMaxQuality()
        {
            Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", DaysRemaining = 1, Quality = 48 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(0, item.DaysRemaining);
            Assert.Equal(50, item.Quality);
        }

        [Fact]
        public void backstagePass_OnSellDate()
        {
            Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", DaysRemaining = 0, Quality = 50 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(-1, item.DaysRemaining);
            Assert.Equal(0, item.Quality);
        }

        [Fact]
        public void backstagePass_AfterSellDate()
        {
            Item item = new Item { Name = "Backstage passes to a TAFKAL80ETC concert", DaysRemaining = -10, Quality = 10 };
            var app = new GildedRose();
            app.ProcessEndOfDay(item);

            Assert.Equal(-11, item.DaysRemaining);
            Assert.Equal(0, item.Quality);
        }
    }
}
