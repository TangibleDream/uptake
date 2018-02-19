Feature: FieldValidation
	Paint calculator gracefully rejects invalid numbers

@uptake
Scenario: Index page negative value 
	When I place "-5" number of rooms	
	Then a rejection will appear/"dimension" page will not load

Scenario: Index page decimal value 
	When I place "2.3" number of rooms	
	Then a rejection will appear/"dimension" page will not load

Scenario: Index page empty value 
	When I leave number of rooms blank and submit
	Then a rejection will appear/"dimension" page will not load
	
Scenario: Dimension page negative value
	When I place a negative length
	Then a rejection will appear/"results" page will not load

Scenario: Dimension page decimal value
	When I place a decimal for width
	Then a rejection will appear/"results" page will not load

Scenario: Dimension page empty value
	When I leave height blank
	Then a rejection will appear/"results" page will not load
