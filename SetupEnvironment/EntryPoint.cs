using AventStack.ExtentReports;
using NUnit.Framework;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System;
using System.IO;
using System.Net;

namespace SetupEnvironment
{
    [Parallelizable]
    public class EntryPoint
    {

        [SetUp]
        public void TestSetup()
        {
            BaseTest.ReporterTest = BaseTest.extent.CreateTest(TestContext.CurrentContext.Test.Name);
            BaseTest.ReporterTest.Log(Status.Info, $"|**|Nunit Test [{TestContext.CurrentContext.Test.Name}] STARTED |**|");
        }

        [Test]
        [Category("Parallel Search Engine Tests")]
        public void GoogleTest1()
        {
            var url = "www.google.co.uk";
            BaseTest.driver.Navigate().GoToUrl(url);
        }

        [TearDown]
        public void WebFixtureCleanup()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status.ToString().Equals("Failed"))
            {
                var screenshot = BaseTest.driver.TakeScreenshot();
                var screenshotFile = Path.Combine("C:\\Reports\\Screenshots", "my_screenshot.png");
                screenshot.SaveAsFile(screenshotFile, ScreenshotImageFormat.Png);
                BaseTest.ReporterTest.AddScreenCaptureFromPath(screenshotFile, "My Screenshot");

                try
                {
                    BaseTest.ReporterTest.Fail(WebUtility.HtmlEncode(BaseTest.LastException.Message.ToString()));
                }
                catch (Exception exception)
                {
                    BaseTest.ReporterTest.Fail(WebUtility.HtmlEncode(exception.ToString()));
                }
            }
            else
            {
                BaseTest.ReporterTest.Pass(TestContext.CurrentContext.Test.Name);
            }

            BaseTest.ReporterTest.Log(Status.Info, $"|**| Nunit Test [{TestContext.CurrentContext.Test.Name}] COMPLETED |**|");
        }
    }
}
