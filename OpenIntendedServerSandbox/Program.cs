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

namespace OpenIntendedServerSandbox
{

    public class OpenIntendedServer
    {

        IWebDriver driver = new ChromeDriver();
        public void LaunchBrowser()
        {
            try
            {

                //var url = new Uri ("https://test.easybook.com/en-my");
                var url = "https://test.easybook.com/en-my";
                driver.Navigate().GoToUrl(url);
              

            }
            catch (Exception e)
            {
                Console.WriteLine("Homepage not found", e);

            }

        }
        public void ConnectServer1()
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
                    //Console.WriteLine("3.4.1");
                
                }
                else if (footerStr.Contains("G3ASPRO02"))
                {
                    Console.WriteLine("Current server is : G3ASPRO02");
                    Console.WriteLine("Server 2 found at 1 attempt");
                    Console.WriteLine();
                    Console.WriteLine();
                    driver.Close();
                    OpenIntendedServer server1 = new OpenIntendedServer();
                    server1.Server1Test();
                    Thread.Sleep(2000);
                    //Console.WriteLine("3.4.2");
                }
                else
                {
                    Console.WriteLine("Wrong server name");
                }

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Server not found");

            }

        }

        public void ConnectServer2()
        {
            try
            {
                ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                Thread.Sleep(1000);
                var footer = driver.FindElement(By.XPath("//*[@id=\"footer\"]/div/div[5]/div/p"));
                string footerStr = footer.Text.ToString();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
               
                if (footerStr.Contains("G3ASPRO02"))
                {
                    Console.WriteLine("Current server is : G3ASPRO02");
                    Console.WriteLine("Server 2 found at 1 attempt");
                    Console.WriteLine();
                    Console.WriteLine();
                  
                    //Console.WriteLine("3.4.2");
                }
                else if (footerStr.Contains("G3ASPRO01"))
                {
                    Console.WriteLine("Current server is : G3ASPRO01");
                    Console.WriteLine("Server 1 found 1 attempt");
                    Console.WriteLine();
                    Console.WriteLine();
                    driver.Close();
                    //Console.WriteLine("2.4.1111");
                    OpenIntendedServer server2 = new OpenIntendedServer();
                    server2.Server2Test();
                    Thread.Sleep(2000);
                    //Console.WriteLine("3.4.1");
                }
                else
                {
                    Console.WriteLine("Wrong server name");
                }

               
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
                OpenIntendedServer server1 = new OpenIntendedServer();
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
            Console.WriteLine("Server 2 found " + i + " attempt");
            Thread.Sleep(2000);
            Console.WriteLine();
            Console.WriteLine();
            //Console.WriteLine("2.4.1");
            //Console.WriteLine("2.4.11");
            return;
            //Console.WriteLine("2.4.111");
        }

        private void Server1Test()
        {
            var url = "https://test.easybook.com/en-my";
            driver.Navigate().GoToUrl(url);
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
            Thread.Sleep(1000);
            var footer = driver.FindElement(By.XPath("//*[@id=\"footer\"]/div/div[5]/div/p"));
            string footerStr = footer.Text.ToString();
            int i = 1;
            while (!footerStr.Contains("G3ASPRO01"))
            {
                driver.Close();
                // Console.WriteLine("1.1");
                i++;
                Thread.Sleep(2000);
                // Console.WriteLine("1.2");
                if (footerStr.Contains("G3ASPRO01"))
                {
                    break;
                }
                OpenIntendedServer server2 = new OpenIntendedServer();
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
            Console.WriteLine("Server 1 found at " + i + " attempt");
            Console.WriteLine();
            Console.WriteLine();
            Thread.Sleep(2000);
           // Console.WriteLine("1.4.1");
            return;

        }

        public int ChooseServer()
        {
            Console.WriteLine("Choose server to connect (1/2) : ");
            int server = Convert.ToInt32(Console.ReadLine());
            return server;

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
            OpenIntendedServer test1 = new OpenIntendedServer();
            //test1.LaunchBrowser();
            //test1.CheckServerName();
            int server = test1.ChooseServer();
            if (server == 1 && server != 2)
            {
                test1.LaunchBrowser();
                test1.ConnectServer1();
            }
            else if (server == 2 && server != 1)
            {
                test1.LaunchBrowser();
                test1.ConnectServer2();
            }

            //test1.ConnectServer1();
            //test1.ConnectServer2();
            //test1.CheckIPName();
            //test1.CloseBrowser();
            

        }
    }
}
