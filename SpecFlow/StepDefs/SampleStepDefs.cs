using System;
using TechTalk.SpecFlow;
using SpecFlow.PageObjects;
using TechTalk.SpecFlow.Assist;

namespace SpecFlow.StepDefs
{
    [Binding]
    public class SampleStepDefs
    {
        private readonly LoginPage _loginPage = new LoginPage();
        [Given(@"I visited login page")]
        public void GivenIVisitedLoginPage()
        {
            _loginPage.Navigate();
        }

        [Given(@"I have entered username and password")]
        public void GivenIHaveEnteredUsernameAndPassword(Table table)
        {
            var LoginDetails = table.CreateInstance<LoginDetails>();
            _loginPage.EnterUserNameAndPassword(LoginDetails.Username, LoginDetails.Password);
        }

        [When(@"I press login")]
        public void WhenIPressLogin()
        {
            _loginPage.ClickOnLoginBtn();
        }

        [Then(@"I should be logged in")]
        public void ThenIShouldBeLoggedIn()
        {
            _loginPage.Validate().UserLoggedIn();
        }

        [Then(@"My (.*) displayed at the header")]
        public void ThenMyUsernameDisplayedAtTheHeader(string username)
        {
            _loginPage.Validate().VerifyLoggedInUserName(username);
        }

    }
}
