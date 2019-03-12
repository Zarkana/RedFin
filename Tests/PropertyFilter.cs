using NUnit.Framework;
using OpenQA.Selenium;
using RedFin.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedFin.Tests
{
    /**     
     *Automate the following test scenario:
     * Property Search: Using Redfin (https://www.redfin.com), write an automated test that checks whether the property search returned the correct results.
     * 
     * Test Details:
     * Use your city to perform the property search.
     * Use at least 3 filters to perform the search.
     * Verify that the results returned matches the search criteria.
     * 
     * Instructions:
     * Use GitHub for your repository.  When complete, please send the link to your GitHub repo.
     * You may use any programming language, testing framework, and library to complete the assignment.
     * You must use a design pattern such as Page Object Model.
     * Feel free to ask questions regarding the assignment. 
     **/

    [TestFixture]
    class PropertyFilter : BaseTest
    {
        private IWebDriver driver;


        [OneTimeSetUp]
        public void BeforeTest()
        {

        }


        [Test]
        public void PropertyFilterTest()
        {
            driver = CreateDriver();

            driver.Url = "https://www.redfin.com";

            Home.Initialize(driver).txt_SearchBox_SendKeys("Huntingtion Beach").btn_Search_Click();            

            PropertySearch.Initialize(driver).drpbx_MinPrice_Click("$75k");
            PropertySearch.Initialize(driver).drpbx_MaxPrice_Click("$10M");


        }

    }
}
