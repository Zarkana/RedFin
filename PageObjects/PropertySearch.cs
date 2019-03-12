using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace RedFin.PageObjects
{
    class PropertySearch : BasePage
    {
        private IWebDriver driver;

        private PropertySearch(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public static PropertySearch Initialize(IWebDriver driver)
        {
            return new PageObjects.PropertySearch(driver);
        }

        private By btn_MoreFilters = By.CssSelector("button.button.Button.wideSidepaneFilterButton");
        public void btn_Search_Click()
        {
            wElement = getWebElement(driver, btn_MoreFilters);
            wElement.Click();
        }

        //Filters

        private By drpbx_MinPrice = By.CssSelector("span.quickMinPrice.withFlyout.withOptions.mounted.field.select.Select.clickable.optional");
        public PropertySearch drpbx_MinPrice_Click(string text)
        {
            //Note: Could not use SelectElement as the dropdown is a custom implemented dropdown and actual select is not displayed

            //IWebElement flyout = driver.FindElement(By.CssSelector("select[name='namequickMinPrice']"));
            //SelectElement el = new SelectElement(flyout);
            //el.SelectByText("$75k");
            
            wElement = getWebElement(driver, drpbx_MinPrice);
            wElement.Click();
           
            IList<IWebElement> elements = getWebElements(driver, By.CssSelector(".quickMinPrice div.Flyout[role='Dialog'] div.option span"));

            foreach (IWebElement element in elements)
            {
                try
                {
                    if (element.Text.Equals(text))
                    {
                        element.Click();
                    }
                    else
                    {

                    }
                }catch(StaleElementReferenceException ex)
                {
                    //The custom dropdown is really finicky and wants to dissapear causing stale elements
                    Console.WriteLine(ex);
                }
            }
            return this;
        }

        private By drpbx_MaxPrice = By.CssSelector("span.quickMaxPrice.withFlyout.withOptions.mounted.field.select.Select.clickable.optional");
        public PropertySearch drpbx_MaxPrice_Click(string text)
        {
            //Note: Could not use SelectElement as the dropdown is a custom implemented dropdown and actual select is not displayed

            //IWebElement flyout = driver.FindElement(By.CssSelector("select[name='namequickMinPrice']"));
            //SelectElement el = new SelectElement(flyout);
            //el.SelectByText("$75k");

            wElement = getWebElement(driver, drpbx_MaxPrice);
            wElement.Click();

            IList<IWebElement> elements = getWebElements(driver, By.CssSelector(".quickMaxPrice div.Flyout[role='Dialog'] div.option span"));

            foreach (IWebElement element in elements)
            {
                try
                {
                    if (element.Text.Equals(text))
                    {
                        element.Click();
                    }
                    else
                    {

                    }
                }
                catch (StaleElementReferenceException ex)
                {
                    //The custom dropdown is really finicky and wants to dissapear causing stale elements
                    Console.WriteLine(ex);
                }
            }
            return this;
        }

    }
}
