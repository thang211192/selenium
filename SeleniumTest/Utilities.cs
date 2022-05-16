using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace SeleniumTest
{
    public class Utilities
    {
        #region selenium
        public static IWebDriver GetSeleniumDriver(string channelUrl, int timespan = 10)
        {
            try
            {
                var chromeDriverService = ChromeDriverService.CreateDefaultService();
                //chromeDriverService.HideCommandPromptWindow = true;
                var options = new ChromeOptions();
                //options.AddArgument("no-sandbox");
                //options.AddArgument("headless");
                //options.BinaryLocation = @"C:\spider\SPIDER\SeleniumTest\bin\Debug\logs\chromedriver.exe";
                var driver = new ChromeDriver(chromeDriverService, options);
                //driver.Url = channelUrl;
                // Navigate to Url
                driver.Navigate().GoToUrl("https://google.com");

                // Enter "webdriver" text and perform "ENTER" keyboard action
                driver.FindElement(By.XPath("//input[@class='gLFyf gsfi']")).SendKeys("trang web cong an các tỉnh" + Keys.Enter);

                // Perform action ctrl + A (modifier CONTROL + Alphabet A) to select the page
                
                driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(timespan);
                //driver.Navigate().GoToUrl(channelUrl);
                return driver;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static IWebElement WaitForElement(IWebDriver driver, string xPath, int timespan = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timespan));
            try
            {
                IWebElement element = wait.Until<IWebElement>((d) =>
                {
                    return d.FindElement(By.XPath(xPath));
                });
                return element;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        public static IList<IWebElement> WaitForElements(IWebDriver driver, string xPath, int timespan = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timespan));
            try
            {
                IList<IWebElement> element = wait.Until(d =>
                {
                    return d.FindElements(By.XPath(xPath));
                });
                return element;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }

        #endregion
    }
}
