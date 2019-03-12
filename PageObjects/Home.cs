using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            wElement = getWebElement(driver, txt_SearchBox);
            wElement.SendKeys(text);
            return this;
        }
    }
}
