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
            string decimalvalue = driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div[2]/div")).Text;
            Assert.IsTrue(decimalvalue.Contains("1.1"));
            
        }


        [Test]

        //Basic-8. Addition

            public void Addition()
        {
            driver.Navigate().GoToUrl("https://www.desmos.com/scientific");
            driver.FindElement(By.LinkText("$$7")).Click();
            driver.FindElement(By.LinkText("$$+")).Click();
            driver.FindElement(By.LinkText("$$1")).Click();
            string additionvalue = driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div[2]/div/div[5]/div[2]/div/span[2]/span[2]")).Text;
            Assert.IsTrue(additionvalue.Contains("8"));
            
        }
       
    }
}
