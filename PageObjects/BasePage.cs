using OpenQA.Selenium;
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

        public BasePage(IWebDriver driver) {
            baseWebDriver = driver;
        }
    }
}
