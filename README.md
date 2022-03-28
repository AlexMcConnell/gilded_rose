Hi and welcome to team Gilded Rose. We provide a library that provides calculations for how items should change each day.
We have no control over the app that consumes this library and cannot change how it interfaces with our library.

Items have the following fields:
**name** - The name of the item.
**days remaining** - The number of days remaining until the item "expires".
**quality** - The quality of the item.

## We have recently signed a supplier for a new item. Please implement the following:

  - "*Raw Milk*": **quality** degrades by 2 per day before the **days remaining**
    date has passed and by 4 after. Its **days remaining** decreases by one every day. Its quality can never decrease to less than 0.

## The tests work and are fully comprehensive. Use them to your advantage!

Remember, this app is just a piece of a greater whole, so respect the contract defined in the tests.
You may add tests, but you should not change the existing tests.
