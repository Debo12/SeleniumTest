using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationTestingProject
{
    [TestClass]
    public class UnitTest1
    {
        private TestContext testContextInstance;
        private IWebDriver driver;
        private string appURL;

        public UnitTest1() { }

        [TestInitialize]
        public void SetUpTest()
        {
            appURL = "https://www.google.com/";
            string browser = "Chrome";

            switch (browser)
            {
                case "Chrome":
                    driver = new ChromeDriver();
                    break;

                default:
                    driver = new ChromeDriver();
                    break;
            }
        }

        //http:/executeautomation.com/blog/tag/testcontext/
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        [TestCategory("Chrome")]
        public void GoogleSearchResult()
        {
            driver.Navigate().GoToUrl(appURL + "/");
            //driver.FindElement(By.Id("sb_form_q")).SendKeys("Azure Pipelines");
            driver.FindElement(By.XPath("//*[@title='Search']")).SendKeys("Selenium");
            Thread.Sleep(500);
            driver.FindElement(By.XPath("//*[@value='Google Search']")).Click();
            Assert.IsTrue(driver.Title.Contains("Selenium"), "Verified title of the page");
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            driver.Quit();
        }

    }
}
