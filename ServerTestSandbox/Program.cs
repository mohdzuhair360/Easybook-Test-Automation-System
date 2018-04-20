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

namespace ServerTestSandbox
{

    public class ServerTest
    {

        IWebDriver driver = new ChromeDriver();
        public void LaunchBrowser()
        {
            try
            {
                
                /*var url = new Uri ("https://test.easybook.com/en-my");
                var capabilities = DesiredCapabilities.PhantomJS();
                var driver = new RemoteWebDriver(url, capabilities);*/
                var url = "https://test.easybook.com/en-my";
                driver.Navigate().GoToUrl(url);
                //driver.Manage().Window.Maximize();
                //Console.WriteLine("Chrome open");
                //Thread.Sleep(2000);

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
                Console.WriteLine(); 
                
               // string server = footerStr.Substring(142, 10);
                //string serverName = server.Trim();
                Console.WriteLine();
                Console.WriteLine();
                if (footerStr.Contains("G3ASPRO01"))
                {
                    Console.WriteLine("Current server is : G3ASPRO01");
                    Console.WriteLine("Server 1 found 1 attempt");
                    Console.WriteLine();
                    Console.WriteLine();
                    driver.Close();
                    ServerTest server2 = new ServerTest();
                    server2.Server2Test();
                    Thread.Sleep(2000);
                    Console.WriteLine("3.4.1");
                    
                }
                else if (footerStr.Contains("G3ASPRO02"))
                {
                    Console.WriteLine("Current server is : G3ASPRO02");
                    Console.WriteLine("Server 2 found at 1 attempt");
                    Console.WriteLine();
                    Console.WriteLine();
                    driver.Close();
                    ServerTest server1 = new ServerTest();
                    server1.Server1Test();
                    Thread.Sleep(2000);
                    Console.WriteLine("3.4.2");
                }
               /* Console.WriteLine("Current server is : " +serverName.Trim());
                int i = 0;

                if (serverName == "G3ASPRO01")
                {
                    Console.WriteLine("Server 1 found 1 attempt");
                    driver.Close();
                    ServerTest server2 = new ServerTest();
                    server2.Server2Test();
                }
                else if (serverName == "G3ASPRO02")
                {
                    Console.WriteLine("Server 2 found at 1 attempt");
                    driver.Close();
                    ServerTest server1 = new ServerTest();
                    server1.Server1Test();
                }*/
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
            /*string server = footerStr.Substring(142, 10);
            string serverName = server.Trim();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Current server is : " + serverName.Trim());*/
            int i = 1;
            while (!footerStr.Contains("G3ASPRO02"))
            {
                driver.Close();
               // Console.WriteLine("2.1");
                i++;
                Thread.Sleep(2000);
               // Console.WriteLine("2.2");
                if (footerStr.Contains("G3ASPRO02"))
                {
                    break;
                }
                ServerTest server1 = new ServerTest();
                server1.Server2Test();
                if (footerStr.Contains("G3ASPRO02"))
                {
                    break;
                }
               // Console.WriteLine("2.3");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Current server is : G3ASPRO02");
           // Console.WriteLine("Current server is : " + serverName.Trim());
            Console.WriteLine("Server 2 found "+i+" attempt");
            Thread.Sleep(2000);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("2.4.1");
            //return;
            //Console.WriteLine("2.4.2");
            /*if (footerStr.Contains("G3ASPRO02"))
            {
                return;
            }*/

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
            //string server = footerStr.Substring(142, 10);
            /*string serverName = server.Trim();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Current server is : " + serverName.Trim());*/
            int i = 1;
            while (!footerStr.Contains("G3ASPRO01"))
            {
                driver.Close();
               // Console.WriteLine("1.1");
                i++;
                Thread.Sleep(2000);
               // Console.WriteLine("1.2");
                if(footerStr.Contains("G3ASPRO01"))
                {
                    break;
                }
                ServerTest server2 = new ServerTest();
                server2.Server1Test();
                if (footerStr.Contains("G3ASPRO01"))
                {
                    break;
                }
                //Console.WriteLine("1.3");

            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Current server is : G3ASPRO01");
            //Console.WriteLine("Current server is : " + serverName.Trim());
            Console.WriteLine("Server 1 found at "+i+" attempt");
            Console.WriteLine();
            Console.WriteLine();
            Thread.Sleep(2000);
            Console.WriteLine("1.4.1");
            //return;
            //Console.WriteLine("1.4.2");
            /*if (footerStr.Contains("G3ASPRO01"))
            {
                return;
            }*/
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

                if (footerStr.Contains("G3ASPRO01"))
                {
                    string ServerName = "G3ASPRO01";
                    Console.WriteLine("Current server is : server 1 - " + ServerName);
                }
                else if (footerStr.Contains("G3ASPRO02"))
                {
                    string ServerName = "G3ASPRO02";
                    Console.WriteLine("Current server is : server 2 - " + ServerName);
                }
               
                
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Server not found");
                

            }
        }


        public void CheckIPName()
        {
            try
            {

                Console.WriteLine();
                Console.WriteLine();
                var footer = driver.FindElement(By.XPath("//*[@id=\"footer\"]/div/div[5]/div/p"));
                string footerStr = footer.Text.ToString();
                string IP = footerStr.Substring(117, 17);
                string IPName = IP.Trim();
                Console.WriteLine("IP address = "+IPName);
                
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("IP not found");

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
            ServerTest test1 = new ServerTest();
            test1.LaunchBrowser();
            //test1.CheckServerName();
            test1.CheckServerConnection();
            //test1.CheckIPName();
            //test1.CloseBrowser();
            

        }
    }
}
