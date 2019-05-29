using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        TestContext testContextInstance;
        IWebDriver driver;
        string appURL = "http://host.mydemotesting.com/login.html";

        [TestInitialize]
        public void testInitialize()
        {
            
            driver = new ChromeDriver();
        }

        public TestContext testContext
        {
            get{
                return testContextInstance;
            }

            set{
                testContextInstance = value; 
            }
        }

        [TestMethod]
        [TestCategory("Chrome")]
        public void TestMethod1()
        {
            driver.Navigate().GoToUrl(appURL);
            driver.FindElement(By.XPath("//*[@id='idUsername']")).SendKeys("debu");
            driver.FindElement(By.XPath("//*[@id='idPassword']")).SendKeys("debu");
            driver.FindElement(By.XPath("//*[@id='btnLogin']")).Click();
            //Assert.IsTrue(driver.FindElement(By.XPath("//*[@id='text1']")), "Verified");
            IWebElement element = driver.FindElement(By.XPath("//*[@id='text1']"));
            Assert.AreEqual(element.Text, "Congratulation!!! You have successfully logged in.");
        }
    }
}
