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

namespace ManualDateSandbox
{
    public class ManualDate
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
            /*Console.WriteLine("Enter date : ");
            string date = Console.ReadLine();
            Console.WriteLine("Enter month (digit): ");
            int month = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter year : ");
            string year = Console.ReadLine();*/

            string[] date3 = { "2020", "3", "8" };

            string date1 = "8";
            int month1 = 3;
            string year1 ="2020";

            try
            {
                Thread.Sleep(1000);
                driver.FindElement(By.Id("dpDepartureDate_Bus")).Click();
                driver.FindElement(By.Id("dpDepartureDate_Bus")).Clear();
                driver.FindElement(By.Id("dpDepartureDate_Bus")).SendKeys(date3[0]+" - "+ date3[1] + " - "+ date3[2]);
                //html/body/div[12]/div[1]/table/thead/tr[2]/th[2]
                
                /*Thread.Sleep(1000);
                driver.FindElement(By.XPath("//div[1]/table/thead/tr[2]/th[2]")).Click();
                //html/body/div[12]/div[2]/table/thead/tr[2]/th[2]

                //click year
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//div[2]/table/thead/tr[2]/th[2]")).Click();

                //choose year
                Thread.Sleep(1000);
                //driver.FindElement(By.XPath("//div[3]/table/tbody/tr/td/span[11]")).Click();
              
                for (int j = 1; j <= 12; j++)
                {
                    //div[1]/table/tbody/tr[1]/td[1]
                    var year2 = driver.FindElement(By.XPath("//div[3]/table/tbody/tr/td/span["+j+"]"));
                    string chooseYear = year2.Text.ToString().Trim();
                    //Console.WriteLine("Year : "+chooseYear);
                    if (year == chooseYear)
                    {
                        driver.FindElement(By.XPath("//div[3]/table/tbody/tr/td/span["+j+"]")).Click();
                        break;

                    }

                    
                }
                //driver.FindElement(By.LinkText("2019")).Click();

                //choose month
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//div[2]/table/tbody/tr/td/span["+month+"]")).Click();
                //driver.FindElement(By.LinkText("March")).Click();

                //choose day
                Thread.Sleep(1000);
                
                for (int i = 1; i<=6; i++)
                {
                    for(int j = 1; j<=7; j++)
                    {
                        //div[1]/table/tbody/tr[1]/td[1]
                        var date2 = driver.FindElement(By.XPath("//div[12]/div/table/tbody/tr["+i+"]/td["+j+"]"));
                        string chooseDate = date2.Text.ToString().Trim();
                        //Console.WriteLine("Date : "+chooseDate);
                        if (date == chooseDate)
                        {
                            driver.FindElement(By.XPath("//div[12]/div/table/tbody/tr["+i+"]/td["+j+"]")).Click();
                            break;

                        }

                    }
                }*/




            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Current date not found");
                //driver.Close();

            }


        }
        public void SubmitSearch()
        {
            try
            {
                driver.FindElement(By.XPath("//button[@value='Submit']")).Click();
                //Console.WriteLine("Search trip");
                //Thread.Sleep(5000);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Submit button not found");
                driver.Close();

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
            ManualDate test1 = new ManualDate();
            test1.LaunchBrowser();
            //test1.Login();
            test1.GoToURL();
            test1.SelectTripType();
            //Thread.Sleep(1000);

            test1.CaptureDate();
            //test1.SearchDate();
            //Thread.Sleep(1000);

            test1.SubmitSearch();
            //Thread.Sleep(1000);

            //test1.SelectTrip();
            //Thread.Sleep(1000);
        }
    }
}
