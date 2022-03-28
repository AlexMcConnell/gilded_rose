class GildedRose
  def process_end_of_day(items)
    items.each { |item| process_item_end_of_day item }
  end

  def process_item_end_of_day(item)
    if item.name != "Aged Cheddar" and item.name != "Concert Tickets"
      if item.quality > 0
        if item.name != "Sulfuras, Hand of Ragnaros"
          item.quality = item.quality - 1
        end
      end
    else
      if item.quality < 50
        item.quality = item.quality + 1
        if item.name == "Concert Tickets"
          if item.days_remaining < 11
            if item.quality < 50
              item.quality = item.quality + 1
            end
          end
          if item.days_remaining < 6
            if item.quality < 50
              item.quality = item.quality + 1
            end
          end
        end
      end
    end
    if item.name != "Sulfuras, Hand of Ragnaros"
      item.days_remaining = item.days_remaining - 1
    end
    if item.days_remaining < 0
      if item.name != "Aged Cheddar"
        if item.name != "Concert Tickets"
          if item.quality > 0
            if item.name != "Sulfuras, Hand of Ragnaros"
              item.quality = item.quality - 1
            end
          end
        else
          item.quality = item.quality - item.quality
        end
      else
        if item.quality < 50
          item.quality = item.quality + 1
        end
      end
    end
  end
end
