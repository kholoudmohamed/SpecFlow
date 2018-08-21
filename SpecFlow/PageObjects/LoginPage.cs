using SpecFlow.BaseFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecFlow.Utilities;

namespace SpecFlow.PageObjects
{
    public class LoginPage : BasePage<LoginPageElementMap, LoginPageValidator>
    {
        public override string Url => GetData.UrlOf(Pages.Login);

        public void EnterUserNameAndPassword(string username, string password)
        {
            Map.UserNameTxt.SendKeys(username);
            Map.PasswordTxt.SendKeys(password);
        }

        public void ClickOnLoginBtn()
        {
            Map.LoginButton.Click();
        }
    }
}
