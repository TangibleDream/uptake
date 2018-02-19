using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using UptakeTechTest.extensionMethods;
using UptakeTechTest.pages;

namespace UptakeTechTest.steps
{
    [Binding]
    public class FieldValidationSteps
    {
        IndexPage       pgIndex         = new IndexPage();
        DimensionsPage  pgDimensions    = new DimensionsPage();
        ResultsPage     pgResults       = new ResultsPage();
        public IWebDriver _driver = new ChromeDriver();
        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver.Url = "localhost:5000/";
            _driver.Manage().Window.Maximize();
        }
        [When(@"I place ""(.*)"" number of rooms")]
        public void WhenIPlaceNumberOfRooms(string rooms)
        {
            _driver.XSet(pgIndex.txtRooms, rooms);
            _driver.XEnter(pgIndex.txtRooms);
        }
                
        [When(@"I leave number of rooms blank and submit")]
        public void WhenILeaveNumberOfRoomsBlankAndSubmit()
        {
            _driver.XEnter(pgIndex.txtRooms);
        }
        
        [When(@"I place a negative length")]
        public void WhenIPlaceANegativeLength()
        {
            _driver.XSet(pgIndex.txtRooms, "1");
            _driver.XEnter(pgIndex.txtRooms);
            _driver.XSet(pgDimensions.getLength(0), "-5");
            _driver.XSet(pgDimensions.getWidth(0), "2.5");
            _driver.XEnter(pgDimensions.getHeight(0));
        }
        
        [When(@"I place a decimal for width")]
        public void WhenIPlaceADecimalForWidth()
        {
            _driver.XSet(pgIndex.txtRooms, "1");
            _driver.XEnter(pgIndex.txtRooms);
            _driver.XSet(pgDimensions.getLength(0), "5");
            _driver.XSet(pgDimensions.getWidth(0), "2.5");
            _driver.XEnter(pgDimensions.getHeight(0));
        }
        
        [When(@"I leave height blank")]
        public void WhenILeaveHeightBlank()
        {
            _driver.XSet(pgIndex.txtRooms, "1");
            _driver.XEnter(pgIndex.txtRooms);
            _driver.XSet(pgDimensions.getLength(0), "5");
            _driver.XSet(pgDimensions.getWidth(0), "4");
            _driver.XEnter(pgDimensions.getHeight(0));
        }

        [Then(@"a rejection will appear/""(.*)"" page will not load")]
        public void ThenARejectionWillAppearPageWillNotLoad(string page)
        {
            if (page == "dimension")
            {
                Assert.IsTrue(_driver.Url == "http://localhost:5000/");
            }
            else
            {
                Assert.IsTrue(_driver.Url.Contains("http://localhost:5000/dimensions?rooms="));
            }
               
        }

        [When(@"I set the dimensions for room (.*) as (.*) length (.*) width and (.*) height")]
        public void WhenISetTheDimensionsForRoomAsLengthWidthAndHeight(int room, int length, int width, int height)
        {
            _driver.XSet(pgDimensions.getLength(room - 1), $"{length}");
            _driver.XSet(pgDimensions.getWidth(room - 1), $"{width}");
            _driver.XSet(pgDimensions.getHeight(room - 1), $"{height}");
        }

        [When(@"I submit dimensions")]
        public void WhenISubmitDimensions()
        {
            _driver.XClick(pgDimensions.btnSubmit);            
        }

        [Then(@"I should see a result of (.*) gallons")]
        public void ThenIShouldSeeAResultOfGallons(int paintGallons)
        {
            Assert.AreEqual($"Total Gallons Required: {paintGallons}", _driver.FindElement(By.XPath(pgResults.lblTotalGallons)).Text);
        }

        [Then(@"the area to paint for room (.*) is (.*) feet")]
        public void ThenTheAreaToPaintForRoomIsFeet(int room, string feetToPaint)
        {
            Assert.AreEqual(feetToPaint, _driver.FindElement(By.XPath(pgResults.getFeetToPaint(room))).Text);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
        }
    }
}
