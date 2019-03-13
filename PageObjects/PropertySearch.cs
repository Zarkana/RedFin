using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Threading;

namespace RedFin.PageObjects
{
    class PropertySearch : BasePage
    {
        private IWebDriver driver;

        private List<int> priceResults = new List<int>();
        private List<float> numberOfBedResults = new List<float>();
        private List<float> numberOfBathResults = new List<float>();

        private PropertySearch(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public static PropertySearch Initialize(IWebDriver driver)
        {
            return new PageObjects.PropertySearch(driver);
        }

        private By btn_MoreFilters = By.CssSelector("button.button.Button.wideSidepaneFilterButton");
        public PropertySearch btn_MoreFilters_Click()
        {
            wElement = getWebElement(driver, btn_MoreFilters);
            wElement.Click();
            return this;
        }

        //FILTERS

        private By drpbx_MinPrice = By.CssSelector("span.quickMinPrice.withFlyout.withOptions.mounted.field.select.Select.clickable.optional");
        public PropertySearch drpbx_MinPrice_Click(string text)
        {
            //Note: Could not use SelectElement as the dropdown is a custom implemented dropdown and actual select is not displayed

            //IWebElement flyout = driver.FindElement(By.CssSelector("select[name='namequickMinPrice']"));
            //SelectElement el = new SelectElement(flyout);
            //el.SelectByText("$75k");
            
            wElement = getWebElement(driver, drpbx_MinPrice);
            wElement.Click();

            SelectFromFlyOut(driver, text, By.CssSelector(".quickMinPrice div.Flyout[role='Dialog'] div.option span"));
            return this;
        }

        private By drpbx_MaxPrice = By.CssSelector("span.quickMaxPrice.withFlyout.withOptions.mounted.field.select.Select.clickable.optional");
        public PropertySearch drpbx_MaxPrice_Click(string text)
        {
            wElement = getWebElement(driver, drpbx_MaxPrice);
            wElement.Click();

            SelectFromFlyOut(driver, text, By.CssSelector(".quickMaxPrice div.Flyout[role='Dialog'] div.option span"));
            return this;
        }

        private By drpbx_MinBeds = By.CssSelector("span.minBeds.withFlyout.withOptions.mounted.field.select.Select.clickable.optional");
        public PropertySearch drpbx_MinBeds_Click(string text)
        {
            wElement = getWebElement(driver, drpbx_MinBeds);
            wElement.Click();

            SelectFromFlyOut(driver, text, By.CssSelector(".minBeds div.Flyout[role='Dialog'] div.option span"));
            return this;
        }
        private By drpbx_MaxBeds = By.CssSelector("span.maxBeds.withFlyout.withOptions.mounted.field.select.Select.clickable.optional");
        public PropertySearch drpbx_MaxBeds_Click(string text)
        {
            wElement = getWebElement(driver, drpbx_MaxBeds);
            wElement.Click();

            SelectFromFlyOut(driver, text, By.CssSelector(".maxBeds div.Flyout[role='Dialog'] div.option span"));
            return this;
        }

        private By txt_Baths = By.CssSelector("span.baths span.value");
        public PropertySearch txt_Baths_SendKeys(string text)
        {
            wElement = getWebElement(driver, txt_Baths);
            string numBeds = wElement.Text;
            int limit = 100;
            int i = 0;

            while (!numBeds.Equals(text) && !(i > limit))
            {
                btn_StepUp_Click();
                wElement = getWebElement(driver, txt_Baths);
                numBeds = wElement.Text;
                i++;
            }
            if (!numBeds.Equals(text))
            {
                Assert.Fail("Could not find correct number of beds");
            }
            return this;
        }

        private By btn_StepUp = By.CssSelector("span.baths span.step-up");
        private PropertySearch btn_StepUp_Click()
        {
            wElement = getWebElement(driver, btn_StepUp);
            wElement.Click();
            
            return this;
        }


        private By btn_ApplyFilters = By.CssSelector("button[data-rf-test-id='apply-search-options']");
        public PropertySearch btn_ApplyFilters_Click()
        {
            wElement = getWebElement(driver, btn_ApplyFilters);
            wElement.Click();
            return this;
        }

        //HOME CARDS

        private By HomeCards = By.CssSelector("div.homecards div.HomeCardContainer .bottomV2");

        public IList<IWebElement> GetHomeCards()
        {
            return getWebElements(driver, HomeCards);
        }


        private By HomeCardPrices = By.CssSelector("div.homecards div.HomeCardContainer .bottomV2 [data-rf-test-name='homecard-price']");
        //public PropertySearch ValidateMinPrice(int minPrice)
        //{            
        //    IList<IWebElement> elements = getWebElements(driver, HomeCardPrices);
        //    //To allow for results to populate
        //    Thread.Sleep(1000);
        //    List<string> elementTexts = new List<string>(driver.FindElements(HomeCardPrices).Select(iw => iw.Text));

        //    foreach (string elementText in elementTexts)
        //    {
        //        int value = Int32.Parse(elementText.Replace(",", "").Replace("$", ""));
        //        if (value < minPrice)
        //            Assert.Fail("Price lower than the minimum price");                
        //    }
        //    return this;
        //}
        public PropertySearch Validate_MinPrice(int minPrice)
        {
            foreach (float price in priceResults)
            {
                if (price < minPrice)
                    Assert.Fail("Price lower than the minimum price");
            }
            return this;
        }
        //public PropertySearch ValidateMaxPrice(int maxPrice)
        //{
        //    IList<IWebElement> elements = getWebElements(driver, HomeCardPrices);
        //    //To allow for results to populate
        //    Thread.Sleep(1000);
        //    List<string> elementTexts = new List<string>(driver.FindElements(HomeCardPrices).Select(iw => iw.Text));

        //    foreach (string elementText in elementTexts)
        //    {
        //        int value = Int32.Parse(elementText.Replace(",", "").Replace("$", ""));
        //        if (value > maxPrice)
        //            Assert.Fail("Price higher than the maximum price");
        //    }
        //    return this;
        //}

        public PropertySearch Validate_MaxPrice(int maxPrice)
        {
            foreach (float price in priceResults)
            {
                if (price > maxPrice)
                    Assert.Fail("Price higher than the maximum price");
            }
            return this;
        }


        private By HomeCardBeds = By.CssSelector("div.homecards div.HomeCardContainer .bottomV2 .HomeStatsV2 .stats");
        //public PropertySearch ValidateMinBeds(float minBeds)
        //{
        //    //IList<IWebElement> elements = getWebElements(driver, HomeCardPrices);
        //    //To allow for results to populate
        //    Thread.Sleep(1000);
        //    //List<string> elementTexts = new List<string>(driver.FindElements(HomeCardBeds).Select(iw => iw.Text));
        //    IEnumerable<string> elementTexts = new List<string>(driver.FindElements(HomeCardBeds).Select(iw => iw.Text));
        //    elementTexts = elementTexts.Where(u => u.Contains("Bed"));

        //    foreach (string elementText in elementTexts)
        //    {
        //        float value = float.Parse(elementText.Replace("Beds", "").Replace(" ", ""));
        //        if (value < minBeds)
        //            Assert.Fail("Less beds than the minimum");
        //    }
        //    return this;
        //}
        public PropertySearch Validate_MinBeds(float minBeds)
        {
            foreach (float bedNumber in numberOfBedResults)
            {
                if (bedNumber < minBeds)
                    Assert.Fail("Less beds than the minimum");
            }
            return this;
        }


        //public PropertySearch ValidateMaxBeds(float maxBeds)
        //{
        //    //IList<IWebElement> elements = getWebElements(driver, HomeCardPrices);
        //    //To allow for results to populate
        //    Thread.Sleep(1000);
        //    //List<string> elementTexts = new List<string>(driver.FindElements(HomeCardBeds).Select(iw => iw.Text));
        //    IEnumerable<string> elementTexts = new List<string>(driver.FindElements(HomeCardBeds).Select(iw => iw.Text));
        //    elementTexts = elementTexts.Where(u => u.Contains("Bed"));

        //    foreach (string elementText in elementTexts)
        //    {
        //        float value = float.Parse(elementText.Replace("Beds", "").Replace(" ", ""));
        //        if (value > maxBeds)
        //            Assert.Fail("More beds than the maximum");
        //    }
        //    return this;
        //}
        public PropertySearch Validate_MaxBeds(float maxBeds)
        {
            foreach (float bedNumber in numberOfBedResults)
            {
                if (bedNumber > maxBeds)
                    Assert.Fail("More beds than the maximum");
            }
            return this;
        }

        //private By HomeCardBaths = By.CssSelector("div.homecards div.HomeCardContainer .bottomV2 .HomeStatsV2 .stats");
        //public PropertySearch ValidateMinBaths(float minBaths)
        //{
        //    //IList<IWebElement> elements = getWebElements(driver, HomeCardPrices);
        //    //To allow for results to populate
        //    Thread.Sleep(1000);
        //    IEnumerable<string> elementTexts = new List<string>(driver.FindElements(HomeCardBaths).Select(iw => iw.Text));
        //    elementTexts = elementTexts.Where(u => u.Contains("Baths"));

        //    foreach (string elementText in elementTexts)
        //    {
        //        float value = float.Parse(elementText.Replace("Baths", "").Replace(" ", ""));
        //        if (value < minBaths)
        //            Assert.Fail("Less baths than the minimum");
        //    }
        //    return this;
        //}
        private By HomeCardBaths = By.CssSelector("div.homecards div.HomeCardContainer .bottomV2 .HomeStatsV2 .stats");
        public PropertySearch Validate_MinBaths(float minBaths)
        {
            ////IList<IWebElement> elements = getWebElements(driver, HomeCardPrices);
            ////To allow for results to populate
            //Thread.Sleep(1000);
            //IEnumerable<string> elementTexts = new List<string>(driver.FindElements(HomeCardBaths).Select(iw => iw.Text));
            //elementTexts = elementTexts.Where(u => u.Contains("Baths"));
            foreach (float bathNumber in numberOfBathResults)
            {                
                if (bathNumber < minBaths)
                    Assert.Fail("Less baths than the minimum");
            }
            return this;
        }

        //PAGE NAVIGATION
        private By SearchResultsPages = By.CssSelector("[data-rf-test-id='paging-controls'] .goToPage");
        public PropertySearch GetSearchResults()
        {
            //IList<IWebElement> elements = getWebElements(driver, SearchResultsPages);
            //To allow for the pageNumbers to populate
            Thread.Sleep(1000);
            IEnumerable<string> pageNumbers = new List<string>(driver.FindElements(SearchResultsPages).Select(iw => iw.Text));
            int totalPages = Int32.Parse(pageNumbers.Last());
            
            for (int i = 0; i < totalPages; i++)
            {
                if(i > 0)
                {
                    IWebElement nextButton = getWebElement(driver, By.CssSelector(String.Format("[data-rf-test-id='react-data-paginate-page-{0}']", i)));
                    nextButton.Click();                    
                }
                //To allow for the house cards to populate
                Thread.Sleep(1000);

                IEnumerable<string> priceElementTexts = new List<string>(driver.FindElements(HomeCardPrices).Select(iw => iw.Text));                

                foreach (string price in priceElementTexts)
                {
                    int value = Int32.Parse(price.Replace(",", "").Replace("$", "").Replace("+", ""));
                    priceResults.Add(value);
                }

                IEnumerable<string> bathElementTexts = new List<string>(driver.FindElements(HomeCardBaths).Select(iw => iw.Text));
                bathElementTexts = bathElementTexts.Where(u => u.Contains("Baths") && !u.Contains("—"));

                foreach (string numberOfBaths in bathElementTexts)
                {
                    float value = float.Parse(numberOfBaths.Replace("Baths", "").Replace(" ", ""));
                    numberOfBathResults.Add(value);
                }

                IEnumerable<string> bedElementTexts = new List<string>(driver.FindElements(HomeCardBeds).Select(iw => iw.Text));
                bedElementTexts = bedElementTexts.Where(u => u.Contains("Beds") && !u.Contains("—"));

                foreach (string numberOfBeds in bedElementTexts)
                {
                    float value = float.Parse(numberOfBeds.Replace("Beds", "").Replace(" ", ""));
                    numberOfBedResults.Add(value);
                }
            }
            return this;
        }
    }
}
