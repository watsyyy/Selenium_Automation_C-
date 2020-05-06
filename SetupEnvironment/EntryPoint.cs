using NUnit.Framework;
using NUnit.Framework.Internal;

namespace SetupEnvironment
{
    [Parallelizable]
    public class EntryPoint
    {
       [Test]
        [Category("Parallel Search Engine Tests")]
        public void GoogleTest1()
        {
            var url = "www.google.co.uk";

            BaseTest.driver.Navigate().GoToUrl(url);
        }
    }
}
