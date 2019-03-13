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
                .drpbx_MaxPrice_Click("$1.25M")
                .btn_MoreFilters_Click()
                .drpbx_MinBeds_Click("1")
                .drpbx_MaxBeds_Click("6")
                .txt_Baths_SendKeys("3+")
                .btn_ApplyFilters_Click();

            //Verify that the results match the search criteria
            PropertySearch.Initialize(driver)
                .GetSearchResults()
                .Validate_MinPrice(75000)
                .Validate_MaxPrice(1250000)
                .Validate_MinBeds(1)
                .Validate_MaxBeds(6)
                .Validate_MinBaths(3);
        }
    }
}
