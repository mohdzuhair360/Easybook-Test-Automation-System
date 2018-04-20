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

namespace TripsAvailabilitySandbox
{
    public class tripsAvailability
    {
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
        public void LaunchBrowser()
        {
            try
            {

                driver.Navigate().GoToUrl("https://test.easybook.com/en-my");
                driver.Manage().Window.Maximize();
                //Console.WriteLine("Chrome open");
                //Thread.Sleep(2000);

            }
            catch (Exception e)
            {
                Console.WriteLine("Homepage not found", e);

            }

        }


        public void GoToURL()
        {
            try
            {

                driver.Navigate().GoToUrl("https://test.easybook.com/en-my/bus/booking/melakasentral-to-sungainibong");
                Console.WriteLine("Test Site - Bus Test Buy");
                //Thread.Sleep(2000);

            }
            catch (Exception e)
            {
                Console.WriteLine("URL not found", e);

            }

        }
        public void SelectTripType()
        {
            try
            {
                driver.FindElement(By.Id("TripType")).Click();
                //Console.WriteLine("Select one way");
                //Thread.Sleep(1000);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Trip type not found");
                //driver.Close();

            }


        }

        public void CaptureDate()
        {
            try
            {
                //var date = driver.FindElement(By.Id("lblCurrentDepartureDate"));
                driver.FindElement(By.Id("dpDepartureDate_Bus")).Click();
                driver.FindElement(By.XPath("//tr[2]/th[2]")).Click();
                driver.FindElement(By.XPath("//div[2]/table/thead/tr[2]/th[2]")).Click();
                driver.FindElement(By.XPath("//div[3]/table/tbody/tr/td/span[12]")).Click();
                driver.FindElement(By.XPath("//td/span[3]")).Click();
                var date = driver.FindElement(By.XPath("/html/body/div[12]/div[1]/table/tbody/tr[3]/td[1]"));



                Console.WriteLine("Date is : "+ date.Text);
                Console.WriteLine("Date is : "+ date.Text.ToString());
                
               

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Current date not found");
                //driver.Close();

            }


        }
        /*public void SearchDate()
        {
            Boolean elementDisplayed;
            try
            {
                for (int i = 0; i < 32; i++)
                {
                    
                    Thread.Sleep(2000);
                    driver.FindElement(By.XPath("//div[@id='depart-trip-list']/div/div/div/div/div[2]/a[2]/i")).Click();
                    IWebElement trip = driver.FindElement(By.LinkText("Select Seats"));
                    if (elementDisplayed = trip.Displayed)
                    {
                        Console.WriteLine("There are trips on : ", date);
                    }
                    else
                    {
                        elementDisplayed = false;
                        Console.WriteLine("No available trips on : ", date);
                    }
                }
                
                
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Date not found");

            }


        }*/
    }
    class Program
    {
        static void Main(string[] args)
        {
            tripsAvailability test1 = new tripsAvailability();
            test1.LaunchBrowser();
            //test1.Login();
            test1.GoToURL();
            test1.SelectTripType();
            //Thread.Sleep(1000);

            test1.CaptureDate();
            //test1.SearchDate();
            //Thread.Sleep(1000);

            //test1.SubmitSearch();
            //Thread.Sleep(1000);

            //test1.SelectTrip();
            //Thread.Sleep(1000);
        }
    }
}
