## Synopsis

The **Paint Calculator** is a hypothetical project that calculates how many gallons of paint would be required to paint a number of rooms.

## Requirements

* Python 3 (not 2)
* Pip

## What we're looking for

* Install Python / Pip
* Run application
* Write tests against the application. They do not have to be in Python, and should be in whatever language you are most comfortable with.
* Write a test plan for the application.  You are free to determine the structure and length of the test plan.
* You are allowed to change any of the source code as you see fit to make things easier for yourself. You are encouraged to fix any bugs you discover.
* Explain any problems you had while writing the tests, and what you did to make it easier. Pointing to localhost for the application is OK.
* What would be the proper level of execution for tests of this application?  If this differs from the testing level you wrote tests for, please explain where they would be better suited.

## Instructions

Because each applicant's code should be secret from one another, we should not submit it to the same repo.

1. Clone the repo (do not fork)
2. Create a new public repo on Github
3. Add the new repo as as a new remote
* `git remote add uptake <url>`
4. Initialize the new repo with what is cloned
* `git push uptake master`
5. Create a new branch off of master to put your changes on
6. Run the application locally
* `pip3 install -r requirements.txt`
* `python3 app/run.py`
7. Perform testing and debugging activities

## Submitting 

To make it easier on everybody, it's best if we use a PR to diff what work was completed.

1. Make any and all commits to your new branch and push the changes
* `git push uptake <branch>`
2. Create a PR to your new repo
3. Make sure you include your test plan and any automated tests, as well as update this README to instruct someone on how to run the tests
4. Include any other text in a file - which tests would be suited for a different level of execution, or any problems encountered...etc
5. Send the link to the PR

## Testing Methodology
1.	View the software to be tested.
2.	Elicit requirements by exploring functionality of the paint calculator
  -  Field validation
  -  Simple Calculation
  -  Complex Calculation
  -  RoundingCalculation
3.	Automate tests

Since I had the option of technology, I used C#/Selenium/SpecFlow/ReportUnit.  For each test I mapped out xpath selectors by page object modeling. For most commands I created extension methods for cleaner code.

  -  Field validation seems important for this test, and thankfully baked in with type=”number” and min=”1” properties of input.  Decimal, negative numbers, and empty fields  are tested to assure the script will not advance to the dimension page or the result page
  -  For simple and complex calculation, I assure that the total area to paint is calculated, and that the total gallons required is likewise calculated.
  4.  View initial results

On the initial run, I see flawless field validation, but a failed test made for area to paint in the simple, 
    complex and rounding calculation.
    
  5.	Flushing out additional bugs
 
 By observing the failed test under debug, I see that the total area to paint is being miscalculated. 
 
  6.	Report 1st bug.
    
    JIRA PC-0001 Total Area to paint is miscalculated.
        When I run the following test cases.`
        -   RoundingCalculation
        -   OneRoomCalculation
        -   ThreeRoomCalculation
        The total area to paint is not calculated correctly
        To reproduce

        -  When I submit 1 room to paint
        -  And I set the calculation to 20L, 20W, and 5H
        Then I should have a total length to paint of 400 or ((20x2)+ (20x2))*5

        Currently I receive 2000 gallons.

        Note: Issue tested on Chrome and IE

  7.	Receive repair, rerun test.
  8.	Flush out 2nd bug.
  
The second running of the test now isolates a rounding error. 
  9.	Report 2nd bug.
	
    JIRA PC-0002 Paint for each room does not round up
  	    When I run the following test cases.
        -   RoundingCalculation
        -   ThreeRoomCalculation
        The gallons of paint per room is not properly calculated due to rounding.

        To reproduce
        -  When I submit 1 room to paint
        -  And I set the calculation to 20L, 20W, and 6H

        Then I should have a total length to paint of 480. This would calculate to 1.2 gallons of paint which should, 
        in turn round up to 2 gallons.

        Currently, it rounds down to 1 gallon.

  10.	Receive repair, rerun test.

  Note:
  While crawling the code for the fix, I noted that the calculations were rounding down instead of up.  But I also noticed it was dividing by 350 and not 400, I added an additional test to check for proper rounding

  11.	Flush out 3rd bug.
  
  Looking at the 3rd build report, both the One Room Calculation and the new 350 special test round to the wrong number of gallons
  12.	Report 3rd bug.
  
    JIRA PC-0003 Paint gallons for each room does not round correctly  
        When I run the following test cases.
        -   RoundingCalculation
        -   OneRoomCalculation
        The gallons of paint per room is not properly calculated.

        To reproduce
        -  When I submit 1 room to paint
        -  And I set the calculation to 15L, 15W, and 6H
        Then I should have a total length to paint of 360. This would calculate to .8 gallons of paint which should, 
        in turn, round up to 1 gallon.
        Currently, it rounds to 2 gallons.
  13.	 Receive repair, rerun test.
  14.	 All tests now pass; this build can be sent to UAT.

## Running Tests

Write instructions for how a user executes the automated tests you created.
