package gildedrose

import (
	"testing"

	"gotest.tools/v3/assert"
)

func TestNormalItemBeforeSellDate(t *testing.T) {
	items := []*Item{{"randomstring", 5, 10}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, 4)
	assert.Equal(t, items[0].quality, 9)
}

func TestNormalItemWithMinQuality(t *testing.T) {
	items := []*Item{{"randomstring", 5, 0}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, 4)
	assert.Equal(t, items[0].quality, 0)
}

func TestNormalItemOnSellDate(t *testing.T) {
	items := []*Item{{"randomstring", 0, 10}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, -1)
	assert.Equal(t, items[0].quality, 8)
}

func TestNormalItemOnSellDateWithMinQuality(t *testing.T) {
	items := []*Item{{"randomstring", 0, 0}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, -1)
	assert.Equal(t, items[0].quality, 0)
}

func TestNormalItemOnSellDateNearMinQuality(t *testing.T) {
	items := []*Item{{"randomstring", 0, 1}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, -1)
	assert.Equal(t, items[0].quality, 0)
}

func TestNormalItemAfterSellDate(t *testing.T) {
	items := []*Item{{"randomstring", -10, 10}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, -11)
	assert.Equal(t, items[0].quality, 8)
}

func TestNormalItemAfterSellDateWithMinQuality(t *testing.T) {
	items := []*Item{{"randomstring", -10, 0}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, -11)
	assert.Equal(t, items[0].quality, 0)
}

func TestNormalItemAfterSellDateNearMinQuality(t *testing.T) {
	items := []*Item{{"randomstring", -10, 1}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, -11)
	assert.Equal(t, items[0].quality, 0)
}

func TestAgedCheddarBeforeSellDate(t *testing.T) {
	items := []*Item{{"Aged Cheddar", 5, 10}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, 4)
	assert.Equal(t, items[0].quality, 11)
}

func TestAgedCheddarWithMaxQuality(t *testing.T) {
	items := []*Item{{"Aged Cheddar", 5, 50}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, 4)
	assert.Equal(t, items[0].quality, 50)
}

func TestAgedCheddarOnSellDate(t *testing.T) {
	items := []*Item{{"Aged Cheddar", 0, 10}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, -1)
	assert.Equal(t, items[0].quality, 12)
}

func TestAgedCheddarOnSellDateWithMaxQuality(t *testing.T) {
	items := []*Item{{"Aged Cheddar", 0, 50}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, -1)
	assert.Equal(t, items[0].quality, 50)
}

func TestAgedCheddarOnSellDateNearMaxQuality(t *testing.T) {
	items := []*Item{{"Aged Cheddar", 0, 49}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, -1)
	assert.Equal(t, items[0].quality, 50)
}

func TestAgedCheddarAfterSellDate(t *testing.T) {
	items := []*Item{{"Aged Cheddar", -10, 10}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, -11)
	assert.Equal(t, items[0].quality, 12)
}

func TestAgedCheddarAfterSellDateWithMaxQuality(t *testing.T) {
	items := []*Item{{"Aged Cheddar", -10, 50}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, -11)
	assert.Equal(t, items[0].quality, 50)
}

func TestAgedCheddarAfterSellDateNearMaxQuality(t *testing.T) {
	items := []*Item{{"Aged Cheddar", -10, 49}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, -11)
	assert.Equal(t, items[0].quality, 50)
}

func TestHammerBeforeSellDate(t *testing.T) {
	items := []*Item{{"Hammer", 5, 40}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, 5)
	assert.Equal(t, items[0].quality, 40)
}

func TestHammerOnSellDate(t *testing.T) {
	items := []*Item{{"Hammer", 0, 40}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, 0)
	assert.Equal(t, items[0].quality, 40)
}

func TestHammerAfterSellDate(t *testing.T) {
	items := []*Item{{"Hammer", -10, 40}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, -10)
	assert.Equal(t, items[0].quality, 40)
}

func TestConcertTicketsLongBeforeSellDate(t *testing.T) {
	items := []*Item{{"Concert Tickets", 11, 10}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, 10)
	assert.Equal(t, items[0].quality, 11)
}

func TestConcertTicketsLongBeforeSellDateAtMaxQuality(t *testing.T) {
	items := []*Item{{"Concert Tickets", 11, 50}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, 10)
	assert.Equal(t, items[0].quality, 50)
}

func TestConcertTicketsMediumCloseToSellDateUpperBound(t *testing.T) {
	items := []*Item{{"Concert Tickets", 10, 10}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, 9)
	assert.Equal(t, items[0].quality, 12)
}

func TestConcertTicketsMediumCloseToSellDateUpperBoundAtMaxQuality(t *testing.T) {
	items := []*Item{{"Concert Tickets", 10, 50}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, 9)
	assert.Equal(t, items[0].quality, 50)
}

func TestConcertTicketsMediumCloseToSellDateUpperBoundNearMaxQuality(t *testing.T) {
	items := []*Item{{"Concert Tickets", 10, 49}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, 9)
	assert.Equal(t, items[0].quality, 50)
}

func TestConcertTicketsMediumCloseToSellDateLowerBound(t *testing.T) {
	items := []*Item{{"Concert Tickets", 6, 10}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, 5)
	assert.Equal(t, items[0].quality, 12)
}

func TestConcertTicketsMediumCloseToSellDateLowerBoundAtMaxQuality(t *testing.T) {
	items := []*Item{{"Concert Tickets", 6, 50}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, 5)
	assert.Equal(t, items[0].quality, 50)
}

func TestConcertTicketsMediumCloseToSellDateLowerBoundNearMaxQuality(t *testing.T) {
	items := []*Item{{"Concert Tickets", 6, 49}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, 5)
	assert.Equal(t, items[0].quality, 50)
}

func TestConcertTicketsVeryCloseToSellDateUpperBound(t *testing.T) {
	items := []*Item{{"Concert Tickets", 5, 10}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, 4)
	assert.Equal(t, items[0].quality, 13)
}

func TestConcertTicketsVeryCloseToSellDateUpperBoundAtMaxQuality(t *testing.T) {
	items := []*Item{{"Concert Tickets", 5, 50}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, 4)
	assert.Equal(t, items[0].quality, 50)
}

func TestConcertTicketsVeryCloseToSellDateUpperBoundNearMaxQuality(t *testing.T) {
	items := []*Item{{"Concert Tickets", 5, 48}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, 4)
	assert.Equal(t, items[0].quality, 50)
}

func TestConcertTicketsVeryCloseToSellDateLowerBound(t *testing.T) {
	items := []*Item{{"Concert Tickets", 1, 10}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, 0)
	assert.Equal(t, items[0].quality, 13)
}

func TestConcertTicketsVeryCloseToSellDateLowerBoundAtMaxQuality(t *testing.T) {
	items := []*Item{{"Concert Tickets", 1, 50}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, 0)
	assert.Equal(t, items[0].quality, 50)
}

func TestConcertTicketsVeryCloseToSellDateLowerBoundNearMaxQuality(t *testing.T) {
	items := []*Item{{"Concert Tickets", 1, 48}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, 0)
	assert.Equal(t, items[0].quality, 50)
}

func TestConcertTicketsOnSellDate(t *testing.T) {
	items := []*Item{{"Concert Tickets", 0, 10}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, -1)
	assert.Equal(t, items[0].quality, 0)
}

func TestConcertTicketsAfterSellDate(t *testing.T) {
	items := []*Item{{"Concert Tickets", -10, 10}}
	GildedRose{}.ProcessEndOfDay(items)
	assert.Equal(t, items[0].daysRemaining, -11)
	assert.Equal(t, items[0].quality, 0)
}
