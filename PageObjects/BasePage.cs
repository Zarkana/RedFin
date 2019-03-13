using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        public IWebElement getWebElement(IWebDriver driver, By by, int timeout = 120)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
            return driver.FindElement(by);
        }
        public IList<IWebElement> getWebElements(IWebDriver driver, By by, int timeout = 30)
        {            
            Thread.Sleep(1000);
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
            return driver.FindElements(by);            
        }

        public void ExecuteJavascript(string javascript)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)baseWebDriver;
            js.ExecuteScript(javascript);
        }

        public void SelectFromFlyOut(IWebDriver driver, string text, By by)
        {
            IList<IWebElement> elements = getWebElements(driver, by);            

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
        }
    }
}
