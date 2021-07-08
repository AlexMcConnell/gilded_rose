Hi and welcome to team Gilded Rose. As you know, we are a small inn with a prime location in a
prominent city run by a friendly innkeeper named Allison. We also buy and sell only the finest goods.

Unfortunately, our goods are constantly degrading in quality as their "days remaining" approaches
zero. We have an inventory management system in place that updates our inventory for us at the end
of every day. Your task is to add "Conjured Mana Cake" to our system so that we can begin selling
this new category of items.

## First, an introduction to our system:

- All items have a **days remaining** value which denotes the number of days left until the item
  expires
- All items have a **quality** value which denotes how valuable the item is
- At the end of each day, our system decreases the **days remaining** value for each item by 1
  (**days remaining** can be negative) and updates the **quality**

Pretty simple, right? Well this is where it gets interesting:

  - For default/normal items, **quality** degrades by 1 per day before the **days remaining**
    date has passed and by 2 after
  - For "*Aged Brie*", **quality** increases by 1 per day before the **days remaining** date has
    passed and by 2 after
  - "*Sulfuras, Hand of Ragnaros*", being a legendary item, **never changes**
  - The **quality** for "*Backstage passes to a TAFKAL80ETC concert*"
    - Increases by 1 when there are 10 or more **days remaining**
    - Increases by 2 when there are less than 10 **days remaining**
    - Increases by 3 when there are less than 5 **days remaining**
    - Drops to 0 after the concert
  - The **quality** of an item can never decrease to less than 0
  - The **quality** of an item can never increase to more than 50

## We have recently signed a supplier for a new item. Please implement the following:

  - For "*Conjured Mana Cake*", **quality** degrades by 2 per day before the **days remaining**
    date has passed and by 4 after

## The tests work and are fully comprehensive. Use them to your advantage!

Also, please treat this app as if it were a library imported by another app. That means to respect
the existing contract when it comes to how the tests interface with the primary classes.
