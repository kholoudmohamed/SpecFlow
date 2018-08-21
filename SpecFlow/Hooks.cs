using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SpecFlow.BaseFramework;
using SpecFlow.Utilities;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;
using System.Reflection;

namespace SpecFlow
{
    [Binding]
    public sealed class Hooks:Driver
    {
        private static ExtentReports Extent;
        private static ExtentTest Test;
        private static ExtentTest featureName;


        [BeforeTestRun]
        public static void StartReport()
        {

            //Append the html report file to current project path
            var reportPath = Helpers.GetCurrentProjectPath() + "Reports\\TestRunReport.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);

            Extent = new ExtentReports();
            Extent.AttachReporter(htmlReporter);
        }

        [AfterTestRun]
        public static void StopReport()
        {
            Extent.Flush();
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            StartBrowser();
            Test = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);

        }

        [AfterScenario]
        public void AfterScenario()
        {
            StopBrowser();
        }

        [BeforeFeature]
        public static void BeforeFeature()
        {
            // create Test
            featureName = Extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [AfterStep]
        public void InsertReportingSteps()
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            PropertyInfo pInfo = typeof(ScenarioContext).GetProperty("TestStatus", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo getter = pInfo.GetGetMethod(nonPublic: true);
            object Testresult = getter.Invoke(ScenarioContext.Current, null);

            if(ScenarioContext.Current.TestError ==null)
            {
                if (stepType =="Given")
                    Test.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    Test.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    Test.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    Test.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if(ScenarioContext.Current.TestError != null)
            {
                if (stepType == "Given")
                    Test.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException.Message);
                else if (stepType == "When")
                    Test.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException.Message);
                else if (stepType == "Then")
                    Test.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException.Message);
                else if (stepType == "And")
                    Test.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException.Message);
            }

            // Pending Status
            if (Testresult.ToString()=="StepDefinitionPending")
            {
                if (stepType == "Given")
                    Test.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "When")
                    Test.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    Test.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
            }
            
        }
    }
}
