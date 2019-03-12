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
    }
}
