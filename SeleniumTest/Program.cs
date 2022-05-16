using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace SeleniumTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //init spider
            if (System.Diagnostics.Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location)).Count() > 1)
                return;
            string logFile = "logFile.txt";

            string LogDir = "logs";
            if (!System.IO.Directory.Exists(LogDir))
            {
                System.IO.Directory.CreateDirectory(LogDir);
            }
            logFile = LogDir + "\\" + logFile;

            StreamWriter logger = new StreamWriter(logFile, false, System.Text.Encoding.UTF8);

            var lstLink = GetListLinkInfo("");
            foreach (var link in lstLink)
            {
                logger.WriteLine(link.Url);
            }
            //close
            logger.Close();
            logger.Dispose();
            Console.WriteLine("done all");
            Console.ReadKey();
        }

        public static List<LinkInfo> GetListLinkInfo(string articleUrl)
        {
            var lstLinkInfo = new List<LinkInfo>();
            var driver = Utilities.GetSeleniumDriver(articleUrl);
            if (driver == null)
            {
                //driver.Quit();
                return lstLinkInfo;
            }
            try
            {
                for(int i = 0; i< 20; i++)
                {
                    var UrlNodes = Utilities.WaitForElements(driver, "//cite[@class='iUh30 tjvcx']");
                    if (UrlNodes != null)
                    {
                        foreach (IWebElement e in UrlNodes)
                        {
                            try
                            {
                                string url = HttpUtility.HtmlDecode(e.Text).Trim();
                                if (url != String.Empty && url.Contains("gov") && !lstLinkInfo.Any(c=>c.Url == url))
                                    lstLinkInfo.Add(new LinkInfo { Url = url });

                            }
                            catch { continue; }
                        }
                    }
                    driver.FindElement(By.XPath("//a[@id='pnnext']")).Click();
                }
                
                
            }
            catch { return lstLinkInfo; }
            finally
            {
                driver.Quit();
            }

            return lstLinkInfo;
        }
    }

}
