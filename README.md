Hi and welcome to team Gilded Rose. We provide an inventory management library that provides calculations for how items should change each day.

Items have the following fields:

**name** - The name of the item.

**days remaining** - The number of days remaining until the item "expires".

**quality** - The quality of the item.

Most items follow these rules at the end of each day:

**days remaining** decreases by 1

**quality** decreases by 1 if **days remaining** has not passed 0

**quality** decreases by 2 if **days remaining** has passed 0

**quality** cannot go below 0

In additional to the standard rules for items, there are a few special cases that have their own rules for how they behave.

## We have recently signed a supplier for a new item. Please implement the following:

  - "*Raw Milk*": **quality** degrades by 2 per day before the **days remaining**
    date has passed and by 4 after. Its **days remaining** decreases by one every day. Its quality can never decrease to less than 0.

## The tests work and are fully comprehensive. Use them to your advantage!

Remember, this app is just a piece of a greater whole, so respect the contract defined in the tests, as they represent how other apps consume our library. You may add tests, but you should not change the existing tests, as they represent how other applications interface with our app.
