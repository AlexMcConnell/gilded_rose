class GildedRose {
  processEndOfDay(items) {
    for (let i = 0; i < items.length; i++) {
      this.processItemEndOfDay(items[i])
    }
  }

  processItemEndOfDay(item) {
    if (item.name != 'Aged Cheddar' && item.name != 'Concert Tickets') {
      if (item.quality > 0) {
        if (item.name != 'Hammer') {
          item.quality = item.quality - 1;
        }
      }
    } else {
      if (item.quality < 50) {
        item.quality = item.quality + 1;
        if (item.name == 'Concert Tickets') {
          if (item.daysRemaining < 11) {
            if (item.quality < 50) {
              item.quality = item.quality + 1;
            }
          }
          if (item.daysRemaining < 6) {
            if (item.quality < 50) {
              item.quality = item.quality + 1;
            }
          }
        }
      }
    }
    if (item.name != 'Hammer') {
      item.daysRemaining = item.daysRemaining - 1;
    }
    if (item.daysRemaining < 0) {
      if (item.name != 'Aged Cheddar') {
        if (item.name != 'Concert Tickets') {
          if (item.quality > 0) {
            if (item.name != 'Hammer') {
              item.quality = item.quality - 1;
            }
          }
        } else {
          item.quality = item.quality - item.quality;
        }
      } else {
        if (item.quality < 50) {
          item.quality = item.quality + 1;
        }
      }
    }
  }
}

module.exports = {
  GildedRose
}
