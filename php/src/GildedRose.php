<?php

namespace GildedRose;

class GildedRose
{
    public function processEndOfDay(array $items): void
    {
        for ($i = 0; $i < count($items); $i += 1) {
            $this->processItemEndOfDay($items[$i]);
        }
    }

    public function processItemEndOfDay(Item $item): void
    {
        if ($item->name != 'Aged Cheddar' and $item->name != 'Concert Tickets') {
            if ($item->quality > 0) {
                if ($item->name != 'Sulfuras, Hand of Ragnaros') {
                    $item->quality = $item->quality - 1;
                }
            }
        } else {
            if ($item->quality < 50) {
                $item->quality = $item->quality + 1;
                if ($item->name == 'Concert Tickets') {
                    if ($item->days_remaining < 11) {
                        if ($item->quality < 50) {
                            $item->quality = $item->quality + 1;
                        }
                    }
                    if ($item->days_remaining < 6) {
                        if ($item->quality < 50) {
                            $item->quality = $item->quality + 1;
                        }
                    }
                }
            }
        }

        if ($item->name != 'Sulfuras, Hand of Ragnaros') {
            $item->days_remaining = $item->days_remaining - 1;
        }

        if ($item->days_remaining < 0) {
            if ($item->name != 'Aged Cheddar') {
                if ($item->name != 'Concert Tickets') {
                    if ($item->quality > 0) {
                        if ($item->name != 'Sulfuras, Hand of Ragnaros') {
                            $item->quality = $item->quality - 1;
                        }
                    }
                } else {
                    $item->quality = $item->quality - $item->quality;
                }
            } else {
                if ($item->quality < 50) {
                    $item->quality = $item->quality + 1;
                }
            }
        }
    }
}
