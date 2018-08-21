using SpecFlow.BaseFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SpecFlow.Utilities;

namespace SpecFlow.PageObjects
{
    public class LoginPageValidator : BasePageValidator<LoginPageElementMap>
    {
        public void UserLoggedIn()
        {
            Assert.IsTrue(Driver.Browser.Url.Contains(GetData.UrlOf(Pages.PublicAdvisorDashboard)), "Login Failed!");
        }
    }
}
