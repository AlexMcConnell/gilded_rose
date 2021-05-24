<?php

declare(strict_types=1);

namespace GildedRose;

final class Item
{
    /**
     * @var string
     */
    public $name;

    /**
     * @var int
     */
    public $days_remaining;

    /**
     * @var int
     */
    public $quality;

    public function __construct(string $name, int $days_remaining, int $quality)
    {
        $this->name = $name;
        $this->days_remaining = $days_remaining;
        $this->quality = $quality;
    }

    public function __toString(): string
    {
        return "{$this->name}, {$this->days_remaining}, {$this->quality}";
    }
}
