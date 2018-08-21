using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow.BaseFramework
{
    public class BasePageValidator<M>
       where M : BasePageElementMap, new()
    {
        protected M Map => new M();

        private readonly BasePage<M> _basePage = new BasePage<M>();

        //private readonly LoginPage _loginPage = new LoginPage();
        public void VerifyLoggedInUserName(string expectedUsername)
        {
            Assert.AreEqual(expectedUsername, _basePage.GetLoggedInUserNameFromHeader(), "Logged In Username is not displayed at the header");
        }
    }
}
