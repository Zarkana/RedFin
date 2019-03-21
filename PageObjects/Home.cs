using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace RedFin.PageObjects
{
    class Home : BasePage
    {
        private IWebDriver driver;

        private Home(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public static Home Initialize(IWebDriver driver)
        {
            return new PageObjects.Home(driver);
        }

        private By btn_Search = By.CssSelector("button.SearchButton.clickable");
        public void btn_Search_Click()
        {
            wElement = getWebElement(driver, btn_Search);
            wElement.Click();
        }

        private By txt_SearchBox = By.Id("search-box-input");
        public Home txt_SearchBox_SendKeys(string text)
        {
            
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wElement = wait.Until(ExpectedConditions.ElementToBeClickable(txt_SearchBox));
            //wElement = getWebElement(driver, txt_SearchBox);
            wElement.SendKeys(text);
            return this;
        }
    }
}
