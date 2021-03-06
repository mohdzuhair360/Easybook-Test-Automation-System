﻿using OpenQA.Selenium;
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

namespace TestBuyCarTestMYRWithOS
{

    public class car
    {
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
        public void GoToURL()
        {
            try
            {
                string urlBukitBintang =
                   "https://test.easybook.com/en-my/car/booking/bukitbintangarea";
                string urlKualaLumpur =
                   "https://test.easybook.com/en-my/car/booking/kualarlumpurarea";

                driver.Navigate().GoToUrl(urlBukitBintang);
                Console.WriteLine("Test Site - Car Test Buy");
                //Thread.Sleep(2000);

            }
            catch (Exception e)
            {
                Console.WriteLine("URL not found", e);

            }

        }

        public void SelectDate()
        {
            try
            {

                driver.FindElement(By.Id("ddPickUpDateCar")).Click();
                driver.FindElement(By.XPath("//tr[2]/th[2]")).Click();
                driver.FindElement(By.XPath("//div[2]/table/thead/tr[2]/th[2]")).Click();
                driver.FindElement(By.XPath("//div[3]/table/tbody/tr/td/span[11]")).Click();
                driver.FindElement(By.XPath("//td/span[3]")).Click();
                driver.FindElement(By.XPath("//div[8]/div/table/tbody/tr[2]/td[6]")).Click();
                //Thread.Sleep(2000);
                driver.FindElement(By.Id("ddReturnDateCar")).Click();
                driver.FindElement(By.XPath("//div[8]/div/table/tbody/tr[2]/td[7]")).Click();
                //Thread.Sleep(2000);

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Date not found");

            }


        }

        public void SubmitSearch()
        {
            try
            {
                //Thread.Sleep(2000);
                driver.FindElement(By.Name("submit")).Click();
                Thread.Sleep(2000);

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Submit button not found");
                //driver.Close();

            }

        }

        public void SelectCar()
        {
            try
            {
                //Thread.Sleep(3000);
                driver.FindElement(By.XPath("(//button[@name='submit'])[2]")).Click();
                //Console.WriteLine("Select trip");
                //Thread.Sleep(1000);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Car not found");

            }

        }
        public void Nationality()
        {
            try
            {

                var Malaysia = driver.FindElement(By.Id("ddlNationalityCar"));
                var selectElement = new SelectElement(Malaysia);
                selectElement.SelectByText("Malaysia");
                // Console.WriteLine("Select Paypal");
                Thread.Sleep(2000);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Nationality not found");
                //driver.Close();

            }

        }
        public void PaymentGate()
        {
            try
            {

                driver.FindElement(By.Id("paymentPayPalEC_MYR")).Click();
                // Console.WriteLine("Select Paypal");
                Thread.Sleep(2000);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Paypal element not found");
                //driver.Close();

            }

        }

        public void goToCaptcha()
        {
            try
            {

                driver.FindElement(By.Id("CaptchaCode")).Click();
                //driver.FindElement(By.XPath("//*[@id=\"CaptchaCode\"]")).Click();

                //Console.WriteLine("Captcha found");
                Thread.Sleep(8000);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Captcha not found");
                driver.Close();

            }

        }


        public void PayNow()
        {
            try
            {

                var payNow = driver.FindElement(By.Id("payNowBtn"));
                Actions actionsPay = new Actions(driver);
                actionsPay.MoveToElement(payNow);
                actionsPay.Perform();
                //Thread.Sleep(8000);
                IWebElement element = driver.FindElement(By.Id("payNowBtn"));


                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);
                IAlert confirmationAlert = driver.SwitchTo().Alert();
                String alertText = confirmationAlert.Text;
                confirmationAlert.Accept();
                //Console.WriteLine("Alert clicked");
                //Thread.Sleep(3000);

                Thread.Sleep(5000);
                //driver.FindElement(By.Id("payNowBtn")).Click();
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Pay now proceed not found");
                driver.Close();

            }

        }



        public void PayPalLogin()
        {
            try
            {
                Thread.Sleep(5000);
                driver.FindElement(By.LinkText("Log In")).Click();
                Thread.Sleep(6000);
                //Console.WriteLine("Login clicked");
                //Thread.Sleep(8000);

                /*driver.SwitchTo().Frame(driver.FindElement(By.TagName("iframe")));
                var emailAddressLogin = driver.FindElement(By.Id("email"));
                emailAddressLogin.SendKeys("ebvanhieptest1@gmail.com");
                var password = driver.FindElement(By.Id("password"));
                password.SendKeys("Ebtest@1133");

                IWebElement log = driver.FindElement(By.CssSelector("#btnLogin"));
                log.Click();
                //Console.WriteLine("Logged in");

                Thread.Sleep(6000);*/

                driver.FindElement(By.Id("email")).SendKeys("ebvanhieptest1@gmail.com");

                driver.FindElement(By.XPath("//*[@id=\"btnNext\"]")).Click();
                // driver.FindElement(By.Id("#btnNext")).Click();


                //*[@id="password"]
                Thread.Sleep(3000);
                var password = driver.FindElement(By.Id("password"));
                password.SendKeys("Ebtest@1133");

                driver.FindElement(By.CssSelector("#btnLogin")).Click();

                //*[@id="btnLogin"]
                //Console.WriteLine("Logged in");

                Thread.Sleep(10000);

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Cannot login");
            }

        }


        public void PayProcess()
        {
            try
            {
                //driver.FindElement(By.XPath("//div[@id='button']/button")).Click();
                driver.FindElement(By.XPath("//div[@id='button']/button")).Click();
                //Console.WriteLine("Pay now");
                Thread.Sleep(1000);
                driver.FindElement(By.Id("confirmButtonTop")).Click();
                //Console.WriteLine("Pay Now 2");
                Thread.Sleep(8000);
                driver.FindElement(By.Id("pay_now_button")).Click();
                //Console.WriteLine("Pay Now 3");
                Thread.Sleep(12000);


            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Cannot proceed to pay");
            }

        }

        public void ScreenShotsOS()
        {
            StringBuilder TimeAndDate = new StringBuilder(DateTime.Now.ToString("h:mm:ss:tt  d/MMMM/y"));
            TimeAndDate.Replace("/", " ");
            TimeAndDate.Replace(":", ".");
            string currentDate = Convert.ToString(TimeAndDate);

            try
            {
                //Thread.Sleep(3000);
                string url = driver.Url;
                Console.WriteLine();
                Console.WriteLine("OS URL is : ");
                Console.WriteLine();
                Console.WriteLine(url);
                Console.WriteLine();
                Console.WriteLine();
                var OS = driver.FindElement(By.Id("print-content"));
                Actions actionsPay = new Actions(driver);
                actionsPay.MoveToElement(OS);
                actionsPay.Perform();
                Screenshot ss1 = ((ITakesScreenshot)driver).GetScreenshot();
                ss1.SaveAsFile("D:/Screenshots\\" + currentDate + " (OS).png", OpenQA.Selenium.ScreenshotImageFormat.Png);
                //Console.WriteLine("SS OS done");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("OS not found");

            }
        }

      
        public void ProductName()
        {
            try
            {
                var Div1 = driver.FindElement(By.XPath("//div[@id='print-content']/table/tbody/tr/td/table/tbody/tr[2]/td"));
                string Cluster1 = Div1.Text.ToString();
                //Console.WriteLine(Cluster1);
                //Console.WriteLine();
                //Console.WriteLine();
                string FrontTrim = Cluster1.Remove(0, 73);
                //Console.WriteLine(FrontTrim);
                //Console.WriteLine();
                //Console.WriteLine();
                string BackTrim = FrontTrim.Remove(23, 36);
                //Console.WriteLine(BackTrim);
                //Console.WriteLine();
                //Console.WriteLine();
                string CartID = BackTrim.Trim();
                //Console.WriteLine(PurchaseDate);
                //Console.WriteLine();
                //Console.WriteLine();
                //Console.WriteLine("Cart ID : " + CartID);
                string product = CartID;
                // Console.WriteLine(product);

                if (product.Contains("FR"))
                {
                    string productName = "Ferry";
                    Console.WriteLine("Product : " + productName);

                }
                else if (product.Contains("TR"))
                {
                    string productName = "Train";
                    Console.WriteLine("Product : " + productName);

                }
                else if (product.Contains("BUS"))
                {
                    string productName = "Bus";
                    Console.WriteLine("Product : " + productName);

                }
                else if (product.Contains("CR"))
                {
                    string productName = "Car";
                    Console.WriteLine("Product : " + productName);

                }
                else
                {
                    Console.WriteLine("Cannot identify product name");

                }



                //Console.WriteLine("Cart ID : " + CartID2);
                //Console.WriteLine("Product : " + product);

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Product Name not found");

            }

        }
        public void OrderNo()
        {
            try
            {
                var OrderNo = driver.FindElement(By.XPath("//div[@id='print-content']/table/tbody/tr/td/table/tbody/tr[2]/td/strong/span"));
                Console.WriteLine("Order no : " + OrderNo.Text.ToString().Trim());
                //Console.WriteLine("Order no : "+ OrderNo.Text);

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Order No not found");

            }

        }

        public void PurchaseDate()
        {
            try
            {
                var Div1 = driver.FindElement(By.XPath("//div[@id='print-content']/table/tbody/tr/td/table/tbody/tr[2]/td"));
                string Cluster1 = Div1.Text.ToString();
                //Console.WriteLine(Cluster1);
                //Console.WriteLine();
                //Console.WriteLine();
                string FrontTrim = Cluster1.Remove(0, 42);
                //Console.WriteLine(FrontTrim);
                //Console.WriteLine();
                //Console.WriteLine();
                string BackTrim = FrontTrim.Remove(21, 69);
                //Console.WriteLine(BackTrim);
                //Console.WriteLine();
                //Console.WriteLine();
                string PurchaseDate = BackTrim.Trim();
                //Console.WriteLine(PurchaseDate);
                //Console.WriteLine();
                //Console.WriteLine();
                Console.WriteLine("Purchase date : " + PurchaseDate);

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Purchase date not found");

            }

        }

        public void CartID()
        {
            try
            {
                var Div1 = driver.FindElement(By.XPath("//div[@id='print-content']/table/tbody/tr/td/table/tbody/tr[2]/td"));
                string Cluster1 = Div1.Text.ToString();
                //Console.WriteLine(Cluster1);
                //Console.WriteLine();
                //Console.WriteLine();
                string FrontTrim = Cluster1.Remove(0, 73);
                //Console.WriteLine(FrontTrim);
                //Console.WriteLine();
                //Console.WriteLine();
                string BackTrim = FrontTrim.Remove(23, 36);
                //Console.WriteLine(BackTrim);
                //Console.WriteLine();
                //Console.WriteLine();
                string CartID = BackTrim.Trim();
                //Console.WriteLine(PurchaseDate);
                //Console.WriteLine();
                //Console.WriteLine();
                Console.WriteLine("Cart ID : " + CartID);

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("CartID not found");

            }

        }

        public void PickupLocation()
        {
            try
            {
                //*[@id="print-content"]/table[1]/tbody/tr/td/table[2]/tbody/tr[2]/td/table[2]/tbody/tr[5]/td[2]
                var PickupLocation = driver.FindElement(By.XPath("//*[@id=\"print-content\"]/table[1]/tbody/tr/td/table[2]/tbody/tr[2]/td/table[2]/tbody/tr[5]/td[2]"));
                Console.WriteLine("Pickup location : " + PickupLocation.Text.ToString().Trim());


            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Pickup cocation not found");

            }

        }

        public void ReturnLocation()
        {
            try
            {
                //*[@id="print-content"]/table[1]/tbody/tr/td/table[2]/tbody/tr[2]/td/table[2]/tbody/tr[6]/td[2]
                var ReturnLocation = driver.FindElement(By.XPath("//*[@id=\"print-content\"]/table[1]/tbody/tr/td/table[2]/tbody/tr[2]/td/table[2]/tbody/tr[6]/td[2]"));
                Console.WriteLine("Return location : " + ReturnLocation.Text.ToString().Trim());


            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Return location not found");

            }

        }

        public void RentDuration()
        {
            try
            {
                //*[@id="print-content"]/table[1]/tbody/tr/td/table[2]/tbody/tr[2]/td/table[2]/tbody/tr[7]/td[2]
                var RentDuration = driver.FindElement(By.XPath("//*[@id=\"print-content\"]/table[1]/tbody/tr/td/table[2]/tbody/tr[2]/td/table[2]/tbody/tr[7]/td[2]"));
                Console.WriteLine("Rent duration is : " + RentDuration.Text.ToString().Trim());

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Rent duration not found");

            }

        }

        public void DepartTime()
        {
            try
            {
                //*[@id="print-content"]/table/tbody/tr/td/table[3]/tbody/tr[2]/td/table[1]/tbody/tr[5]/td[2]
                var DepartTime = driver.FindElement(By.XPath(" //*[@id=\"print-content\"]/table/tbody/tr/td/table[3]/tbody/tr[2]/td/table[1]/tbody/tr[5]/td[2]"));
                Console.WriteLine("Depart Time : " + DepartTime.Text.ToString().Trim());
                //Console.WriteLine("Depart Time: " + DepartTime.Text);

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Depart Time not found");

            }

        }

        public void CarDetail()
        {
            try
            {

                //*[@id="print-content"]/table[1]/tbody/tr/td/table[2]/tbody/tr[2]/td/table[2]/tbody/tr[1]/td[2]
                var CarDetail = driver.FindElement(By.XPath(" //*[@id=\"print-content\"]/table[1]/tbody/tr/td/table[2]/tbody/tr[2]/td/table[2]/tbody/tr[1]/td[2]"));
                Console.WriteLine("Car Detail : " + CarDetail.Text.ToString().Trim());


            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Car detail not found");

            }

        }
        public void Company()
        {
            try
            {
                //*[@id="print-content"]/table[1]/tbody/tr/td/table[2]/tbody/tr[2]/td/table[2]/tbody/tr[2]/td[2]
                var Company = driver.FindElement(By.XPath("//*[@id=\"print-content\"]/table[1]/tbody/tr/td/table[2]/tbody/tr[2]/td/table[2]/tbody/tr[2]/td[2]"));
                Console.WriteLine("Company : " + Company.Text.ToString().Trim());
                //Console.WriteLine("Company: " + Company.Text);

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Company not found");

            }

        }

        public void PassengerName()
        {
            try
            {
                //*[@id="print-content"]/table[1]/tbody/tr/td/table[2]/tbody/tr[2]/td/table[1]/tbody/tr[1]/td[2]
                var PassengerName = driver.FindElement(By.XPath("//*[@id=\"print-content\"]/table[1]/tbody/tr/td/table[2]/tbody/tr[2]/td/table[1]/tbody/tr[1]/td[2]"));
                Console.WriteLine("Passenger Name : " + PassengerName.Text.ToString().Trim());
                //Console.WriteLine("Passenger Name: " + PassengerName.Text);

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Passenger Name not found");

            }

        }

        public void Server()
        {
            try
            {
                //*[@id="print-content"]/table[1]/tbody/tr/td/table[4]/tbody/tr[8]/td/text()[1]
                //*[@id="print-content"]/table[1]/tbody/tr/td/table[4]/tbody/tr[8]/td
                var ServPlat = driver.FindElement(By.XPath("//*[@id=\"print-content\"]/table[1]/tbody/tr/td/table[4]/tbody/tr[8]/td"));
                string strServPlat = ServPlat.Text.ToString();
                string serverTrim = strServPlat.Trim();

                //string Server = strServPlat.Remove(0, 9);
                //string Server1 = Server.Remove(9, 17);
                //string server2 = Server1.Trim();
                //+strServPlat.Remove(18,);
                //Console.WriteLine("Server name : " + server2);
                //Console.WriteLine(strServPlat);
                if (serverTrim.Contains("G3ASPRO01"))
                {
                    string serverName = "Server 1";
                    string serverName2 = "G3ASPRO01";
                    Console.WriteLine("Server : " + serverName + " - " + serverName2);
                }
                else if (serverTrim.Contains("G3ASPRO02"))
                {
                    string serverName = "Server 2";
                    string serverName2 = "G3ASPRO02";
                    Console.WriteLine("Server : " + serverName + " - " + serverName2);
                }
                else
                {
                    Console.WriteLine("Server name not found");
                }


            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Server Name not found");

            }

        }

        public void Platform()
        {
            try
            {
                var ServPlat = driver.FindElement(By.XPath("//*[@id=\"print-content\"]/table[1]/tbody/tr/td/table[4]/tbody/tr[8]/td"));
                string strServPlat = ServPlat.Text.ToString();
                string platTrim = strServPlat.Trim().ToLower();
                //string plat = strServPlat.Remove(0, 18);
                //string platform = plat.Trim();
                //Console.WriteLine("Platform : " + platform);
                // Console.WriteLine(platTrim);

                if (platTrim.Contains("mobile"))
                {
                    string platName = "Mobile Browser";
                    Console.WriteLine("Platform : " + platName);
                }
                else if (platTrim.Contains("desktop"))
                {
                    string platName = "Desktop Browser";
                    Console.WriteLine("Platform : " + platName);
                }
                else
                {
                    Console.WriteLine("Platform name not found");
                }

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Platform Name not found");

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


        class Program
        {
            static void Main(string[] args)
            {
                car test1 = new car();
                test1.LaunchBrowser();
                test1.Login();
                test1.GoToURL();
                test1.SelectDate();
                //Thread.Sleep(2000);
                test1.SubmitSearch();
                test1.SelectCar();
                test1.Nationality();
                test1.PaymentGate();
                test1.goToCaptcha();
                test1.PayNow();
                test1.PayPalLogin();
                test1.PayProcess();
                test1.ScreenShotsOS();
                Console.WriteLine();
                Console.WriteLine();
                test1.ProductName();
                test1.OrderNo();
                test1.CartID();
                test1.PickupLocation();
                test1.ReturnLocation();
                test1.RentDuration();
                test1.CarDetail();
                test1.PurchaseDate();
                test1.PassengerName();
                test1.Company();
                test1.Server();
                test1.Platform();
                Console.WriteLine();
                Console.WriteLine();

            }
        }
    }
}
