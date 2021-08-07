<?php

namespace GildedRose;

class Item
{
    public $name;
    public $days_remaining;
    public $quality;

    public function __construct(string $name, int $days_remaining, int $quality)
    {
        $this->name = $name;
        $this->days_remaining = $days_remaining;
        $this->quality = $quality;
    }
}
