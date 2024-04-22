use crate::item::Item;

pub struct GildedRose;

impl GildedRose {
    pub fn new() -> Self {
        Self
    }
    
    pub fn process_end_of_day(&self, items: &mut Vec<Item>) {
        for item in items.iter_mut() {
            self.process_item_end_of_day(item);
        }
    }

    fn process_item_end_of_day(&self, item: &mut Item) {
        if item.name != "Aged Cheddar" && item.name != "Concert Tickets" {
            if item.quality > 0 {
                if item.name != "Hammer" {
                    item.quality -= 1;
                }
            }
        } else {
            if item.quality < 50 {
                item.quality += 1;
                if item.name == "Concert Tickets" {
                    if item.days_remaining < 11 {
                        if item.quality < 50 {
                            item.quality += 1;
                        }
                    }
                    if item.days_remaining < 6 {
                        if item.quality < 50 {
                            item.quality += 1;
                        }
                    }
                }
            }
        }
        if item.name != "Hammer" {
            item.days_remaining -= 1;
        }
        if item.days_remaining < 0 {
            if item.name != "Aged Cheddar" {
                if item.name != "Concert Tickets" {
                    if item.quality > 0 {
                        if item.name != "Hammer" {
                            item.quality -= 1;
                        }
                    }
                } else {
                    item.quality = 0;
                }
            } else {
                if item.quality < 50 {
                    item.quality += 1;
                }
            }
        }
    }
}