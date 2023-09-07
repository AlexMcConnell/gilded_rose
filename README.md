Hello, and welcome to team. First, a little background:

We provide an inventory management library that provides calculations for how items should change each day.

<br>

## Items have the following fields:

**name** - The name of the item.

**days remaining** - The number of days remaining until the item "expires".

**quality** - The quality of the item.

<br>

## Most items follow these rules at the end of each day:

**days remaining** decreases by 1

**quality** decreases by 1 if **days remaining** has not passed 0

**quality** decreases by 2 if **days remaining** has passed 0

**quality** cannot go below 0

<br>

In addition to the standard rules for items, there are special cases that have their own rules for how they behave. The logic for these can be found in the code and tests.

<br>

## Here is the acceptance criteria for the story you are to implement:

**GIVEN** a process end of day request is made

**WHEN** one of the items is named *Raw Milk*

**AND** days remaining for that item has not passed 0

**THEN** that item's days remaining decreases by 1

**AND** that item's quality decreases by 1

<br>

**GIVEN** a process end of day request is made

**WHEN** one of the items is named *Raw Milk*

**AND** days remaining for that item has passed 0

**THEN** that item's days remaining decreases by 1

**AND** that item's quality decreases by 2

<br>

## The tests work and are fully comprehensive. Use them to your advantage!

Remember, this app is just a piece of a greater whole, so respect the contract defined in the tests, as they represent how other apps consume our library. You may add tests, but you should not change the existing tests, as they represent how other applications interface with our app.
