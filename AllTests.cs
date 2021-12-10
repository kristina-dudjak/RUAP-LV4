using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class AllTest
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.google.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void LoginTest()
        {
            driver.Navigate().GoToUrl("http://demowebshop.tricentis.com/");
            driver.FindElement(By.LinkText("Log in")).Click();
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("kdddddddd@gmail.com");
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("123456");
            driver.FindElement(By.XPath("//input[@value='Log in']")).Click();
        }

        [Test]
        public void TheAddToCartTest()
        {
            driver.Navigate().GoToUrl("http://demowebshop.tricentis.com/");
            driver.FindElement(By.LinkText("Books")).Click();
            driver.FindElement(By.XPath("//input[@value='Add to cart']")).Click();
        }

        [Test]
        public void TheLoginAndChangeInfoTest()
        {
            driver.Navigate().GoToUrl("http://demowebshop.tricentis.com/");
            driver.FindElement(By.LinkText("Log in")).Click();
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("dudjakkristina@gmail.com");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='New Customer'])[1]/following::div[3]")).Click();
            driver.FindElement(By.Id("Password")).Click();
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("LozZaKatalon.1");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Password:'])[1]/following::div[1]")).Click();
            driver.FindElement(By.XPath("//input[@value='Log in']")).Click();
            driver.FindElement(By.LinkText("dudjakkristina@gmail.com")).Click();
            driver.FindElement(By.Id("FirstName")).Click();
            driver.FindElement(By.Id("FirstName")).Clear();
            driver.FindElement(By.Id("FirstName")).SendKeys("Kristina");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Your Personal Details'])[1]/following::div[1]")).Click();
            driver.FindElement(By.Name("save-info-button")).Click();
        }

        [Test]
        public void TheCompareItemsTest()
        {
            driver.Navigate().GoToUrl("http://demowebshop.tricentis.com/");
            driver.FindElement(By.LinkText("Books")).Click();
            driver.FindElement(By.XPath("//img[@alt='Picture of Computing and Internet']")).Click();
            driver.FindElement(By.XPath("//input[@value='Add to compare list']")).Click();
            driver.FindElement(By.LinkText("Books")).Click();
            driver.FindElement(By.XPath("//img[@alt='Picture of Fiction']")).Click();
            driver.FindElement(By.XPath("//input[@value='Add to compare list']")).Click();
        }

        [Test]
        public void TheSearchTest()
        {
            driver.Navigate().GoToUrl("http://demowebshop.tricentis.com/");
            driver.FindElement(By.Id("small-searchterms")).Click();
            driver.FindElement(By.Id("small-searchterms")).Clear();
            driver.FindElement(By.Id("small-searchterms")).SendKeys("computing");
            driver.FindElement(By.XPath("//input[@value='Search']")).Click();
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
