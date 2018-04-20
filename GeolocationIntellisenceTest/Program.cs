using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Globalization;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using OpenQA.Selenium.Remote;
using static System.Net.Mime.MediaTypeNames;

namespace GeolocationIntellisenceTest
{
    public class GeolocationIntellisence
    {

        IWebDriver driver = new ChromeDriver();
        public void LaunchBrowser()
        {
            try
            {

                var url = "https://test.easybook.com";
                driver.Navigate().GoToUrl(url);

            }
            catch (Exception e)
            {
                Console.WriteLine("Homepage not found", e);

            }

        }


        public void CheckServerConnection()
        {
            try
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                Thread.Sleep(1000);
                var footer = driver.FindElement(By.XPath("//*[@id=\"footer\"]/div/div[5]/div/p"));
                string footerStr = footer.Text.ToString();
               // string server = footerStr.Substring(142, 10);
               // string serverName = server.Trim();
                Console.WriteLine();
                Console.WriteLine();
                //Console.WriteLine("Current server is : " + serverName.Trim());
                int i = 0;

                if (footerStr.Contains("G3ASPRO01"))
                {
                    string ServerName = "G3ASPRO01";
                    Console.WriteLine("Current server is : " + ServerName);
                    Console.WriteLine("Server 1 found 1 attempt");
                    driver.Close();
                    GeolocationIntellisence server2 = new GeolocationIntellisence();
                    server2.Server2Test();
                }
                else if (footerStr.Contains("G3ASPRO02"))
                {
                    string ServerName = "G3ASPRO01";
                    Console.WriteLine("Current server is : " + ServerName);
                    Console.WriteLine("Server 2 found at 1 attempt");
                    driver.Close();
                    GeolocationIntellisence server1 = new GeolocationIntellisence();
                    server1.Server1Test();
                }
                else
                {
                    Console.WriteLine("Wrong server name");
                }

                //Console.WriteLine("Server 1 found at " + i + "attempt.");
                //Thread.Sleep(2000);

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Server not found");

            }

        }

        private void Server2Test()
        {
            var url = "https://test.easybook.com/en-my";
            driver.Navigate().GoToUrl(url);
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
            Thread.Sleep(1000);
            var footer = driver.FindElement(By.XPath("//*[@id=\"footer\"]/div/div[5]/div/p"));
            string footerStr = footer.Text.ToString();
            string server = footerStr.Substring(142, 10);
            string serverName = server.Trim();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Current server is : " + serverName.Trim());
            int i = 1;
            while (serverName != "G3ASPRO02")
            {
                driver.Close();
                // Console.WriteLine("2.1");
                i++;
                Thread.Sleep(2000);
                // Console.WriteLine("2.2");
                if ((serverName == "G3ASPRO02") && (serverName != "G3ASPRO01"))
                {
                    break;
                }
                GeolocationIntellisence server1 = new GeolocationIntellisence();
                server1.Server2Test();
                if ((serverName == "G3ASPRO02") && (serverName != "G3ASPRO01"))
                {
                    break;
                }
                // Console.WriteLine("2.3");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Current server is : " + serverName.Trim());
            Console.WriteLine("Server 2 found " + i + " attempt");
            Thread.Sleep(2000);
            //Console.WriteLine("2.4");
            if ((serverName == "G3ASPRO02") && (serverName != "G3ASPRO01"))
            {
                return;
            }

            //driver.Close();

        }

        private void Server1Test()
        {
            var url = "https://test.easybook.com/en-my";
            driver.Navigate().GoToUrl(url);
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
            Thread.Sleep(1000);
            var footer = driver.FindElement(By.XPath("//*[@id=\"footer\"]/div/div[5]/div/p"));
            string footerStr = footer.Text.ToString();
            string server = footerStr.Substring(142, 10);
            string serverName = server.Trim();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Current server is : " + serverName.Trim());
            int i = 1;
            while (serverName != "G3ASPRO01")
            {
                driver.Close();
                // Console.WriteLine("1.1");
                i++;
                Thread.Sleep(2000);
                // Console.WriteLine("1.2");
                if ((serverName == "G3ASPRO01") && (serverName != "G3ASPRO02"))
                {
                    break;
                }
                GeolocationIntellisence server2 = new GeolocationIntellisence();
                server2.Server1Test();
                if ((serverName == "G3ASPRO01") && (serverName != "G3ASPRO02"))
                {
                    break;
                }
                //Console.WriteLine("1.3");

            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Current server is : " + serverName.Trim());
            Console.WriteLine("Server 1 found at " + i + " attempt");
            Thread.Sleep(2000);
            //Console.WriteLine("1.4");
            if ((serverName == "G3ASPRO01") && (serverName != "G3ASPRO02"))
            {
                return;
            }
            //driver.Close();
        }

        public void CheckServerName()
        {
            try
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                Thread.Sleep(1000);
                var footer = driver.FindElement(By.XPath("//*[@id=\"footer\"]/div/div[5]/div/p"));
                string footerStr = footer.Text.ToString();
                string server = footerStr.Substring(142, 10);
                string serverName = server.Trim();
                Console.WriteLine("Current server is : " + serverName);

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Server not found");


            }
        }

        public void CheckServerIPName()
        {
            try
            {
                //((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                //Thread.Sleep(1000);
                var footer = driver.FindElement(By.XPath("//*[@id=\"footer\"]/div/div[5]/div/p"));
                string footerStr = footer.Text.ToString();
                //string server = footerStr.Substring(142, 10);
                //string serverName = server.Trim();
                //Console.WriteLine("Current server is : " + serverName);
               /* Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(footerStr);
                Console.WriteLine();
                Console.WriteLine();*/
                if (footerStr.Contains("G3ASPRO01"))
                {
                    Console.WriteLine("Current server is : G3ASPRO01");
                }
                else if (footerStr.Contains("G3ASPRO02"))
                {
                    Console.WriteLine("Current server is : G3ASPRO02");
                }

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Server not found");


            }
        }

        public void GeolocationTest()
        {
            try
            {
                string CurrentUrl = driver.Url;
                //string extUrl = CurrentUrl.Substring(25, 6);
                Console.WriteLine("URL extension : "+ CurrentUrl);
                

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("URL extension not found");

            }

            try
            {
                IWebElement flag = driver.FindElement(By.XPath("//div[@id='bs-example-navbar-collapse-1']/ul/li[2]/a/img"));
                
                //var flag = driver.FindElement(By.XPath("//div[@id='bs-example-navbar-collapse-1']/ul/li[2]/a/img"));
                String src = flag.GetAttribute("src");
                string flagStr = src.ToString();
                //Console.WriteLine("Flag : " + flagStr);
                if (flagStr == "https://test.easybook.com/images/flags/flag_sg.jpg")
                {
                    Console.WriteLine("Flag : Singapore");
                }
                else if (flagStr == "https://test.easybook.com/images/flags/flag_sea.jpg")
                {
                    Console.WriteLine("Flag : SEA");
                }
                else if (flagStr == "https://test.easybook.com/images/flags/flag_my.jpg")
                {
                    Console.WriteLine("Flag : Malaysia");
                }
                else if (flagStr == "https://test.easybook.com/images/flags/flag_vn.jpg")
                {
                    Console.WriteLine("Flag : Vietnam");
                }
                else if (flagStr == "https://test.easybook.com/images/flags/flag_kh.jpg")
                {
                    Console.WriteLine("Flag : Cambodia");
                }
                else if (flagStr == "https://test.easybook.com/images/flags/flag_mm-v2.jpg")
                {
                    Console.WriteLine("Flag : Myanmar");
                }
                else if (flagStr == "https://test.easybook.com/images/flags/flag_la.jpg")
                {
                    Console.WriteLine("Flag : Laos");
                }
                else if (flagStr == "https://test.easybook.com/images/flags/flag_bn.jpg")
                {                    
                    Console.WriteLine("Flag : Brunei");
                }
                else if (flagStr == "https://test.easybook.com/images/flags/flag_th.jpg")
                {
                    Console.WriteLine("Flag : Thailand");
                }
                else
                {
                    Console.WriteLine("Flag not found");
                }


               

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Flag not found");

            }

            try
            {
                var currency = driver.FindElement(By.Id("currency"));
                string CurrencyStr = currency.Text.ToString();

                Console.WriteLine("Curency : " + CurrencyStr);

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Currency not found");

            }

            try
            {
                driver.FindElement(By.Id("language")).Click();
                //*[@id="bs-example-navbar-collapse-1"]/ul/li[4]/ul/li[1]/a
                //*[@id="bs-example-navbar-collapse-1"]/ul/li[4]/ul/li[1]/a/text()

                //driver.FindElement(By.LinkText("English ✔")).Click();
                var language = driver.FindElement(By.XPath("//*[@id=\"bs-example-navbar-collapse-1\"]/ul/li[4]/ul/li[1]/a"));
                string languageStr = language.Text.ToString();

                Console.WriteLine("Language : " + languageStr);

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Language not found");

            }

        }



        public void IntellisenceTest()
        {
            try
            {

                driver.FindElement(By.Id("txtSearchOrigin_Bus")).Click();
               // var defLoc = driver.FindElement(By.Id("hdnOrigin_Bus"));
                var defLoc = driver.FindElement(By.XPath("//*[@id=\"originBasicMode_Bus\"]/div/span/div/div/div[1]/div/span[1]"));
                //*[@id="originBasicMode_Bus"]/div/span/div/div/div[1]/div/span[1]
                string defLocStr = defLoc.Text.ToString();
                Console.WriteLine("Default from location : "+defLocStr);

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Default Location not found");

            }

        }

        public void CloseBrowser()
        {
            try
            {
                Thread.Sleep(2000);
                driver.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot close", e);

            }

        }
    }   
    class Program
    {
        static void Main(string[] args)
        {
            GeolocationIntellisence test1 = new GeolocationIntellisence();
            test1.LaunchBrowser();
            //test1.CheckServerName();
            //test1.CheckServerConnection();
            //test1.CheckServerIPName();
            //test1.GeolocationTest();
            //test1.IntellisenceTest();
            //test1.CloseBrowser();
        }
    }
}
