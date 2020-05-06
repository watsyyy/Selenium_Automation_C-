using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SetupEnvironment
{
    public class BaseTest
    {
        public static IWebDriver driver = new ChromeDriver();

        static void Main()
        {

        }

        [OneTimeSetUp]
        public void Initialize()
        {
            //Something
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
           driver.Quit();
        }
    }
}
