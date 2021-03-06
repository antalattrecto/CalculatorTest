﻿using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;



namespace Calculator
{
    [TestFixture]

    public class TestSuit1
    {
       
        private IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new FirefoxDriver();
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]

        //General-2. Decimal Input

        public void Decimal()
        {
            try
            {

                driver.Navigate().GoToUrl("https://www.desmos.com/scientific");
                driver.FindElement(By.LinkText("$$1")).Click();
                driver.FindElement(By.LinkText("$$.")).Click();
                driver.FindElement(By.LinkText("$$1")).Click();
                string decimalValue = driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div[2]/div")).Text;
                Assert.AreEqual("1.1", decimalValue);
                Console.WriteLine("Test No. 2 - Passed");
            }

            catch (Exception e)
            {
                Console.WriteLine("Test No. 2 - An error has occurred.", e);
            }

        }

        [Test]

        //General - 3. Clear All

        public void ClearAll()
        {
            try
            {
                driver.Navigate().GoToUrl("https://www.desmos.com/scientific");
                driver.FindElement(By.LinkText("$$9")).Click();
                driver.FindElement(By.LinkText("$$6")).Click();
                driver.FindElement(By.LinkText("$$5")).Click();
                driver.FindElement(By.XPath("//div[@id='main']/div/div/div[3]/div/div[8]")).Click();
                string clearAllValue = driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div[2]/div/div[4]/div/div/span[2]")).Text;
                Assert.IsEmpty(clearAllValue);
                Console.WriteLine("Test No. 3 - Passed");
            }
            catch (Exception e)
            {
                Console.WriteLine("Test No. 3 - An error has occurred.", e);
            }
        }

        [Test]

        //General - 4. Undo

        public void Undo()
        {
            try
            {

                driver.Navigate().GoToUrl("https://www.desmos.com/scientific");
                driver.FindElement(By.LinkText("$$5")).Click();
                driver.FindElement(By.XPath("//div[@id='main']/div/div/div[3]/div/div[8]")).Click();
                driver.FindElement(By.XPath("//div[@id='main']/div/div/div[3]/div/div[5]/i")).Click();
                driver.FindElement(By.XPath("//div[@id='main']/div/div/div[3]/div/div[6]/i")).Click();
                string undoValue = driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div[2]/div/div[4]/div/div")).Text;
                Assert.IsEmpty(undoValue);
                Console.WriteLine("Test No. 4 - Passed");
            }

            catch (Exception e)
            {
                Console.WriteLine("Test No. 4 - An error has occurred.", e);
            }
        }

        [Test]

        //General - 5. Invalid input

        public void Invalid()

        {
            try
            {

                driver.Navigate().GoToUrl("https://www.desmos.com/scientific");
                driver.FindElement(By.XPath("//div[@id='main']/div/div/div[3]/div/div[2]")).Click();
                driver.FindElement(By.LinkText("$$q")).Click();
                driver.FindElement(By.LinkText("$$a")).Click();
                driver.FindElement(By.LinkText("$$s")).Click();
                IWebElement element = driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div[2]/div/div[5]/div[1]"));
                String toolTipText = element.GetAttribute("tooltip");
                Assert.AreEqual("Too many variables. Try defining 'q', 'a' or 's'.", toolTipText);
                Console.WriteLine("Test No. 5 - Passed");
            }

            catch (Exception e)

            {
                Console.WriteLine("Test No. 5 - An error has occurred.", e);
            }
        }


        [Test]

        //General - 6. Delete one character

        public void Delete()

        {
            try
            {

                driver.Navigate().GoToUrl("https://www.desmos.com/scientific");
                driver.FindElement(By.LinkText("$$7")).Click();
                driver.FindElement(By.LinkText("$$8")).Click();
                driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[3]/div[2]/div[1]/div[9]/a")).Click();
                string deleteValue = driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div[2]/div/div[4]/div/div/span[2]/span")).Text;
                Assert.AreEqual("7", deleteValue);
                Console.WriteLine("Test No.6 - Passed");
            }

            catch (Exception e)
            {
                Console.WriteLine("Test No. 6 - An error has occurred.", e);
            }
        }

        [Test]

        //General - 7. Answer text

        public void Answer()
        {
            try
            {
                driver.Navigate().GoToUrl("https://www.desmos.com/scientific");
                driver.FindElement(By.LinkText("$$9")).Click();
                driver.FindElement(By.LinkText("$$÷")).Click();
                Thread.Sleep(1000);
                IWebElement element = driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div[2]/div/div[5]/div[1]"));
                String toolTipText3 = element.GetAttribute("tooltip");
                Assert.AreEqual("You need a denominator for the bottom of your fraction.", toolTipText3);
                driver.FindElement(By.LinkText("$$5")).Click();
                string answerValue = driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div[1]/div")).Text;
                Assert.AreEqual("Your answers show up on this side.", answerValue);
                Console.WriteLine("Test no.7-Passed");
            }
            catch (Exception e)
            {
                Console.WriteLine("Test No. 7 - An error has occurred.", e);
            }
        }


        [Test]

        //Basic-8. Addition

        public void Addition()
        {
            try
            {

                driver.Navigate().GoToUrl("https://www.desmos.com/scientific");
                driver.FindElement(By.LinkText("$$7")).Click();
                driver.FindElement(By.LinkText("$$7")).Click();
                driver.FindElement(By.LinkText("$$+")).Click();
                IWebElement element = driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div[2]/div/div[5]/div[1]"));
                String toolTipText2 = element.GetAttribute("tooltip");
                Assert.AreEqual("You need something on both sides of the '+' symbol.", toolTipText2);
                driver.FindElement(By.LinkText("$$1")).Click();
                driver.FindElement(By.LinkText("$$7")).Click();
                driver.FindElement(By.LinkText("$$2")).Click();
                string additionValue = driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div[2]/div/div[5]/div[2]/div/span[2]")).Text;
                Assert.AreEqual("=249", additionValue);
                Console.WriteLine("Test No. 8 - Passed");
            }

            catch (Exception e)

            {
                Console.WriteLine("Test No. 8 - An error has occurred.", e);
            }
        }

        [Test]

        //Basic - 9. Subtraction

        public void Subtraction()
        {
            try
            {

                driver.Navigate().GoToUrl("https://www.desmos.com/scientific");
                driver.FindElement(By.LinkText("$$1")).Click();
                driver.FindElement(By.LinkText("$$−")).Click();
                Thread.Sleep(1000);
                IWebElement element = driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div[2]/div/div[5]/div[1]"));
                String toolTipText6 = element.GetAttribute("tooltip");
                Assert.AreEqual("You need something on both sides of the '-' symbol.", toolTipText6);
                driver.FindElement(By.LinkText("$$−")).Click();
                driver.FindElement(By.LinkText("$$1")).Click();
                string subtractValue = driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div[2]/div/div[5]/div[2]/div/span[2]/span[2]")).Text;
                Assert.AreEqual("2", subtractValue);
                Console.WriteLine("Test No. 9 - Passed");
            }

            catch (Exception e)

            {
                Console.WriteLine("Test No. 9 - An error has occurred.", e);
            }
        }

        [Test]

        //Basic - 10. Multiplication

        public void Multiplication()

        {
            try
            {

                driver.Navigate().GoToUrl("https://www.desmos.com/scientific");
                driver.FindElement(By.LinkText("$$7")).Click();
                driver.FindElement(By.LinkText("$$.")).Click();
                driver.FindElement(By.LinkText("$$1")).Click();
                driver.FindElement(By.LinkText("$$×")).Click();
                IWebElement element = driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div[2]/div/div[5]/div[1]"));
                String toolTipText4 = element.GetAttribute("tooltip");
                Assert.AreEqual("You need something on both sides of the '*' symbol.", toolTipText4);
                driver.FindElement(By.LinkText("$$5")).Click();
                driver.FindElement(By.LinkText("$$1")).Click();
                string multipValue = driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div[2]/div/div[5]/div[2]/div/span[2]")).Text;
                Assert.AreEqual("=362.1", multipValue);
                Console.WriteLine("Test No. 10 - Passed");
            }

            catch (Exception e)
            {
                Console.WriteLine("Test No. 10 - An error has occurred.", e);
            }
        }

        [Test]

        //Basic - 11. Fraction

        public void Fraction()
        {
            try
            {

                driver.Navigate().GoToUrl("https://www.desmos.com/scientific");
                driver.FindElement(By.LinkText("$$1")).Click();
                driver.FindElement(By.LinkText("$$÷")).Click();
                Thread.Sleep(1000);
                IWebElement element = driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div[2]/div/div[5]/div[1]"));
                String toolTipText5 = element.GetAttribute("tooltip");
                Assert.AreEqual("You need a denominator for the bottom of your fraction.", toolTipText5);
                driver.FindElement(By.LinkText("$$0")).Click();
                string fractionValue = driver.FindElement(By.XPath("/html/body/div[3]/div/div/div[1]/div[2]/div/div[5]/div[2]/div/span[2]")).Text;
                Assert.AreEqual("=undefined", fractionValue);
                Console.WriteLine("Test No. 11 - Passed");
            }

            catch (Exception e)

            {
                Console.WriteLine("Test No. 11 - An error has occurred.", e);
            }
        }

    }

}