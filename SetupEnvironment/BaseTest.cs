﻿using NUnit.Framework;
using OpenQA.Selenium;
using System;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium.Chrome;

namespace SetupEnvironment
{
    [SetUpFixture]
    public class BaseTest
    {
        public static IWebDriver driver = new ChromeDriver();
        public static new ExtentTest ReporterTest;
        public static new ExtentHtmlReporter htmlReporter;
        public static new ExtentReports extent;
        public static new Exception LastException { get; private set; }

        static void Main()
        {

        }

        [OneTimeSetUp]
        public void Initialize()
        {
            extent = new ExtentReports();
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            htmlReporter = new ExtentHtmlReporter("C:\\Reports\\TestRun.html");

            extent.AttachReporter(htmlReporter);
            
            extent.Flush();
            driver.Quit();
        }

    }
}
