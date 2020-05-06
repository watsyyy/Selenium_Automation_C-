using AventStack.ExtentReports;
using NLog;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Diagnostics.Eventing.Reader;
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
        }

        [TearDown]
        public void WebFixtureCleanup()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status.ToString().Equals("Failed"))
            {
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
