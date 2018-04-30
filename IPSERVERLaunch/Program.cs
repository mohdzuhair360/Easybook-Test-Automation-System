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

namespace IPSERVERLaunch
{
    class Program
    {
        public class IPServerLaunch
        {
            public void LaunchBrowser()
            {
                try
                {
                    string urlLive = "https://www.easybook.com/en-my";
                    string urlTest = "https://test.easybook.com/en-my";
                    driver.Navigate().GoToUrl(urlLive);
                    driver.Manage().Window.Maximize();
                 

                }
                catch (Exception e)
                {
                    Console.WriteLine("Homepage not found", e);

                }

            }
            IWebDriver driver = new ChromeDriver();
            public void Login()
            {
                try
                {
                    driver.FindElement(By.LinkText("Sign in")).Click();
                    driver.FindElement(By.Id("loginLink")).Click();
                    driver.FindElement(By.Id("Email")).Clear();
                    driver.FindElement(By.Id("Email")).SendKeys("mohdzuhair@easybook.com");
                    driver.FindElement(By.Id("Password")).Clear();
                    driver.FindElement(By.Id("Password")).SendKeys("123456");
                    driver.FindElement(By.Id("CaptchaCode")).Click();
                    Thread.Sleep(6000);

                    driver.FindElement(By.Id("btnLogin")).Click();

                }

                catch (NoSuchElementException)
                {
                    Console.WriteLine("Login not found");
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
                    Console.WriteLine(footerStr);
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

                    }
                    else if (footerStr.Contains("G3ASPRO02"))
                    {
                        Console.WriteLine("Current server is : G3ASPRO02");
                        Console.WriteLine("Server 2 found at 1 attempt");
                        Console.WriteLine();
                        Console.WriteLine();
                
                    }
                
          

                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("Server not found");

                }

            }
        }


        static void Main(string[] args)
        {
            IPServerLaunch test1 = new IPServerLaunch();
            test1.LaunchBrowser();
            test1.CheckServerConnection();
            test1.Login();
          


        }
    }
}
