# GildedRose Kata - PHP Version

See the [top level readme](../README.md) for general information about this exercise. This is the PHP version of the
Gilded Rose Kata.

## Installation

The kata uses:

- [PHP 7.3 or 7.4 or 8.0+](https://www.php.net/downloads.php)
- [Composer](https://getcomposer.org)

Recommended:

- [Git](https://git-scm.com/downloads)


Install all the dependencies using composer

```shell script
cd ./php
composer install
```

## Testing

PHPUnit is configured for testing, a composer script has been provided. To run the unit tests, from the root of the PHP
project run:

```shell script
composer test
```

A Windows a batch file has been created, like an alias on Linux/Mac (e.g. `alias pu="composer test"`), the same
PHPUnit `composer test` can be run:

```shell script
pu
```
