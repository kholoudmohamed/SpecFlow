using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecFlow.BaseFramework;
using OpenQA.Selenium;

namespace SpecFlow.PageObjects
{
    public class LoginPageElementMap:BasePageElementMap
    {
        public IWebElement UserNameTxt => Browser.FindElement(By.CssSelector("[id*='_txtLoginName']"));
        public IWebElement PasswordTxt => Browser.FindElement(By.CssSelector("[id*='_txtPassword']"));
        public IWebElement LoginButton => Browser.FindElement(By.CssSelector(LoginBtnCssSelector));
        public string LoginBtnCssSelector => "[id*='_pnlLoginForm']>div>div>div.section.buttons>input.btn";
    }
}
