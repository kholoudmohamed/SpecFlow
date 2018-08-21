using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SpecFlow.BaseFramework
{
    public class BasePageElementMap
    {
        protected IWebDriver Browser;
        protected WebDriverWait BrowserWait;

        public BasePageElementMap()
        {
            Browser = Driver.Browser;
            BrowserWait = Driver.BrowserWait;

        }

        // Header Items
        public IWebElement HeaderLoggedInUserName => Browser.FindElement(By.CssSelector("div.topHeader>div>div>a:nth-child(1)"));
    }
}
