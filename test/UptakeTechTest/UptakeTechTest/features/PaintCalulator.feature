Feature: PaintCalulator
	Paint Calulator takes the length, width and height of every room and calculates the total gallons of paint required.

@uptake
Scenario: One room calculation
	When I place "1" number of rooms
	And I set the dimensions for room 1 as 20 length 20 width and 5 height
	And I submit dimensions
	Then the area to paint for room 1 is 400 feet
	And I should see a result of 1 gallons

Scenario: Three room calculation
	When I place "3" number of rooms
	And I set the dimensions for room 1 as 10 length 10 width and 5 height
	And I set the dimensions for room 2 as 5 length 5 width and 5 height
	And I set the dimensions for room 3 as 5 length 5 width and 5 height
	And I submit dimensions
	Then the area to paint for room 1 is 200 feet
	Then the area to paint for room 2 is 100 feet
	Then the area to paint for room 3 is 100 feet
	And I should see a result of 3 gallons

	Scenario: Rounding calculation
	When I place "1" number of rooms
	And I set the dimensions for room 1 as 20 length 20 width and 6 height
	And I submit dimensions
	Then the area to paint for room 1 is 480 feet
	And I should see a result of 2 gallons

	Scenario: Three Fifty Special
	When I place "1" number of rooms
	And I set the dimensions for room 1 as 15 length 15 width and 6 height
	And I submit dimensions
	Then the area to paint for room 1 is 360 feet
	And I should see a result of 1 gallons