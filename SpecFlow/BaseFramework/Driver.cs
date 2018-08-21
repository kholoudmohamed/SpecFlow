using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.Configuration;

namespace SpecFlow.BaseFramework
{
    public class Driver
    {
        private static WebDriverWait _browserWait;
        private static IWebDriver _browser;

        public static IWebDriver Browser
        {
            get
            {
                if (_browser == null)
                {
                    throw new NullReferenceException("The WebDriver browser instance was not initialized.You should first call the method Start.");
                }
                return _browser;
            }
            private set
            {
                _browser = value;
            }
        }
        public static WebDriverWait BrowserWait
        {
            get
            {
                if (_browserWait == null || _browser == null)
                {
                    throw new NullReferenceException("The WebDriver browser wait instance was not initialized.You should first call the method Start.");
                }
                return _browserWait;
            }
            private set
            {
                _browserWait = value;
            }
        }

        public static void ImplicitWait()
        {
            Browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }
        public static void StartBrowser(int defaultTimeOut = 60)
        {
            var browsertype = ConfigurationManager.AppSettings["BrowserType"];
            switch (browsertype)
            {
                case "chrome":
                    Browser = new ChromeDriver();
                    break;
                case "firefox":
                    Browser = new FirefoxDriver();
                    break;
                case "ie":
                    Browser = new InternetExplorerDriver();
                    break;
            }
            Browser.Manage().Window.Maximize();
            BrowserWait = new WebDriverWait(Browser, TimeSpan.FromSeconds(defaultTimeOut));
        }
        public static void StopBrowser()
        {
            Browser.Close();
            Browser.Quit();
            Browser.Dispose();
            Browser = null;
            BrowserWait = null;
        }
    }
}
