This is an inventory updating library that provides logic for how items should change each day.

<br>

## Items have the following fields:

**name** - The name of the item.

**days remaining** - The number of days remaining until the item "expires".

**quality** - The quality of the item.

<br>

At the end of each day, a process runs to update each item. Different types of items have their **days remaining** and **quality** values updated in different ways.

<br>

## Your assignment:

Please implement the following item:

**name** - Raw Milk

At the end of each day, if the days remaining for **Raw Milk** is greater than 0, its quality decreases by 2. If the days remaining for  **Raw Milk** is less than 0, its quality decreases by 4. The quality of Raw Milk can never be less than 0.

<br>

## The tests work and are fully comprehensive. Use them to your advantage!

Remember, this app is just a piece of a greater whole, so respect the contract defined in the tests, as they represent how other apps consume our library. You may add tests, but you should not change the existing tests, as they represent how other applications interface with our app.
