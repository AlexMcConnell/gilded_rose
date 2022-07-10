use crate::item::Item;

pub fn process_end_of_day(items: Vec<&mut Item>) {
    for mut item in items {
        process_item_end_of_day(&mut item);
    }
}

pub fn process_item_end_of_day(item: &mut Item) {
    if item.name != "Aged Cheddar" && item.name != "Concert Tickets" {
        if item.quality > 0 {
            if item.name != "Hammer" {
                item.quality = item.quality - 1;
            }
        }
    } else {
        if item.quality < 50 {
            item.quality = item.quality + 1;
            if item.name == "Concert Tickets" {
                if item.days_remaining < 11 {
                    if item.quality < 50 {
                        item.quality = item.quality + 1;
                    }
                }
                if item.days_remaining < 6 {
                    if item.quality < 50 {
                        item.quality = item.quality + 1;
                    }
                }
            }
        }
    }

    if item.name != "Hammer" {
        item.days_remaining = item.days_remaining - 1;
    }

    if item.days_remaining < 0 {
        if item.name != "Aged Cheddar" {
            if item.name != "Concert Tickets" {
                if item.quality > 0 {
                    if item.name != "Hammer" {
                        item.quality = item.quality - 1;
                    }
                }
            }
            else {
                item.quality = item.quality - item.quality;
            }
        }
        else {
            if item.quality < 50 {
                item.quality = item.quality + 1;
            }
        }
    }
}