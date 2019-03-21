using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace RedFin.PageObjects
{
    class BasePage
    {
        public IWebDriver baseWebDriver { get; set; }
        public IWebElement wElement { get; set; }

        public BasePage(IWebDriver driver)
        {
            baseWebDriver = driver;
        }

        public IWebElement getWebElement(IWebDriver driver, By by, int timeout = 30)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
            return driver.FindElement(by);
        }
        public IList<IWebElement> getWebElements(IWebDriver driver, By by, int timeout = 30)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
            return driver.FindElements(by);
        }
    }   
}
