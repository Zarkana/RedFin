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

            //Use your city to perform the property search
            Home.Initialize(driver).txt_SearchBox_SendKeys("Huntingtion Beach").btn_Search_Click();            

            //Use at least 3 filters to perform the search
            PropertySearch.Initialize(driver)
                .drpbx_MinPrice_Click("$75k")
                .drpbx_MaxPrice_Click("$10M")
                .btn_MoreFilters_Click()
                .drpbx_MinBeds_Click("1")                
                .drpbx_MaxBeds_Click("3")
                .txt_Baths_SendKeys("2+")
                .btn_ApplyFilters_Click();

            //Verify that the results math the search criteria
            PropertySearch.Initialize(driver)
                .ValidateMinPrice(75000)
                .ValidateMaxPrice(10000000)
                .ValidateMinBaths(1)
                .ValidateMinBeds(1)
                .ValidateMaxBeds(3);
        }

    }
}
