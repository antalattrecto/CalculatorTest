using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Calculator
{
    public class TestSuit1
    {

        IWebDriver driver = new FirefoxDriver();

        [Test]

        //General-2. Decimal Input
        
            public void Decimal()
        {
            driver.Navigate().GoToUrl("https://www.desmos.com/scientific");
            driver.FindElement(By.LinkText("$$1")).Click();
            driver.FindElement(By.LinkText("$$.")).Click();
            driver.FindElement(By.LinkText("$$1")).Click();
            string decimalValue = driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div[2]/div")).Text;
            Assert.IsTrue(decimalValue.Contains("1.1"));
            
        }

        [Test]

        //General - 3. Clear All

            public void ClearAll()
        {
            driver.Navigate().GoToUrl("https://www.desmos.com/scientific");
            driver.FindElement(By.LinkText("$$9")).Click();
            driver.FindElement(By.LinkText("$$6")).Click();
            driver.FindElement(By.LinkText("$$5")).Click();
            driver.FindElement(By.XPath("//div[@id='main']/div/div/div[3]/div/div[8]")).Click();
            string clearAllValue = driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div[2]/div/div[4]/div/div/span[2]")).Text;
            Assert.IsEmpty(clearAllValue);
        }


        [Test]

        //Basic-8. Addition

            public void Addition()
        {
            driver.Navigate().GoToUrl("https://www.desmos.com/scientific");
            driver.FindElement(By.LinkText("$$7")).Click();
            driver.FindElement(By.LinkText("$$7")).Click();
            driver.FindElement(By.LinkText("$$+")).Click();
            driver.FindElement(By.LinkText("$$1")).Click();
            driver.FindElement(By.LinkText("$$7")).Click();
            driver.FindElement(By.LinkText("$$2")).Click();
            string additionValue = driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div[2]/div/div[5]/div[2]/div")).Text;
            Assert.IsTrue(additionValue.Contains("249"));
            
        }
       
    }
}
