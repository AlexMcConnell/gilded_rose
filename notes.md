Based on analysis of the tests and new requirements:

min quality: 0 (cannot be negative)

raw milk:
- max quality: n/a
- min quality: 0 (cannot be negative)
- exp rate: 1 day
- quality -2 / day while days > 0
- quality -4 / day while days <= 0

normal item:
- max quality: n/a
- min quality: 0 (cannot be negative)
- exp rate: 1 day
- quality -1 / day while days > 0
- quality -2 / day while days <= 0

aged cheddar:
- max quality: 50
- min quality: 0 (cannot be negative)
- exp rate: 1 day
- quality +1 / day while days > 0
- quality +2 / day while days <= 0

hammer:
- max quality: n/a
- min quality: 0 (cannot be negative)
- exp rate: 0 day
- quality +0 / day while days > 0
- quality +0 / day while days <= 0

concert tickets:
- max quality: 50
- min quality: 0 (cannot be negative)
- exp rate: 1 day
- quality +1 / day while days > 10
- quality +2 / day while days <= 10 && > 5
- quality +3 / day while days <= 5 && > 0
- quality == 0 while days <= 0
