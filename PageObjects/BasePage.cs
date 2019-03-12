using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedFin.PageObjects
{
    class BasePage
    {
        public IWebDriver baseWebDriver { get; set; }
        public IWebElement wElement { get; set; }

        public BasePage(IWebDriver driver) {
            baseWebDriver = driver;
        }

		//public bool IsElementPresent(By by, int timeOutInSeconds = 5)
		//{
		//	bool results = false;
		//	try
		//	{
		//		baseWebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeOutInSeconds);
		//		results = baseWebDriver.FindElement(by).Displayed;
		//		return results;
		//	}
		//	catch (NoSuchElementException ex)
		//	{
		//		return false;
		//	}
		//	finally
		//	{
		//		baseWebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
		//	}
		//}

        public IWebElement getWebElement(IWebDriver driver, By by, int timeout = 120)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
            return driver.FindElement(by);
        }
        public IList<IWebElement> getWebElements(IWebDriver driver, By by, int timeout = 120)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
            return driver.FindElements(by);
        }
    }
}
