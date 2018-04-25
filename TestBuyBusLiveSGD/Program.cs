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

namespace TestBuyBusLiveSGD
{

    public class bus
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
                string url = "https://www.easybook.com/en-my";
                driver.Navigate().GoToUrl(url);
                driver.Manage().Window.Maximize();
                //Console.WriteLine("Chrome open");
                //Thread.Sleep(2000);

            }
            catch (Exception e)
            {
                Console.WriteLine("Homepage not found", e);

            }

        }

        public void ChangeCountry()
        {
            try
            {

                driver.FindElement(By.XPath("//div[@id='bs-example-navbar-collapse-1']/ul/li[2]/a/img")).Click();
                driver.FindElement(By.LinkText("Singapore")).Click();
                //Thread.Sleep(2000);

            }
            catch (Exception e)
            {
                Console.WriteLine("Country not found");

            }

        }


        public void GoToURL()
        {
            try
            {
                string urlSgNibongMelaka =
                    "https://www.easybook.com/en-sg/bus/booking/sungainibong-to-melakasentral";
                string urlMelakaSgNibong =
                    "https://www.easybook.com/en-sg/bus/booking/melakasentral-to-sungainibong";
                string urlKovanMelaka =
                   "https://www.easybook.com/en-sg/bus/booking/kovanhub206-to-melakasentral";
                

                driver.Navigate().GoToUrl(urlSgNibongMelaka);
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
                //driver.FindElement(By.Id("TripType")).Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id("radioOneWay")))).Click();
               // new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id("TripType")))).Click();
                //Console.WriteLine("Select one way");
                //Thread.Sleep(1000);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Trip type not found");
                //driver.Close();

            }


        }

        public void SelectDate()
        {
            try
            {
                driver.FindElement(By.Id("dpDepartureDate_Bus")).Click();
                driver.FindElement(By.Id("dpDepartureDate_Bus")).Clear();
                driver.FindElement(By.Id("dpDepartureDate_Bus")).SendKeys("2020 - 3 - 8");

               /* driver.FindElement(By.Id("dpDepartureDate_Bus")).Click();
                driver.FindElement(By.XPath("//tr[2]/th[2]")).Click();
                driver.FindElement(By.XPath("//div[2]/table/thead/tr[2]/th[2]")).Click();
                driver.FindElement(By.XPath("//div[3]/table/tbody/tr/td/span[12]")).Click();
                driver.FindElement(By.XPath("//td/span[3]")).Click();
                driver.FindElement(By.XPath("//div[12]/div/table/tbody/tr[3]/td")).Click();*/
                //Console.WriteLine("Date Selected");
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
                driver.FindElement(By.XPath("//button[@value='Submit']")).Click();
                //Console.WriteLine("Search trip");
                //Thread.Sleep(5000);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Submit button not found");
               // driver.Close();

            }


        }


        public void SelectTrip()
        {
            try
            {
                //*[@id="MY-int-21237652-616423e5-43c2-4d63-aab1-d3f554b08abb"]/td[9]/div[1]/a
                //Thread.Sleep(3000);
                //driver.FindElement(By.LinkText("Select Seats")).Click();

                //driver.FindElement(By.LinkText("(Select Seats)[3]")).Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath("//*[@id=\"MY-int-21237652-616423e5-43c2-4d63-aab1-d3f554b08abb\"]/div[1]/div[5]/a")))).Click();
                //new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.LinkText("Select")))).Click();
                //*[@id="MY-int-21237652-616423e5-43c2-4d63-aab1-d3f554b08abb"]/div[1]/div[5]/a
                //*[@id="MY-int-21237652-616423e5-43c2-4d63-aab1-d3f554b08abb"]/div[1]/div[5]/a
                //*[@id="MY-int-21237652-616423e5-43c2-4d63-aab1-d3f554b08abb"]/div[1]/div[4]/div[1]/a/text()
                //*[@id="MY-int-21237652-616423e5-43c2-4d63-aab1-d3f554b08abb"]/div[1]/div[5]/a
                //*[@id="MY-int-21237652-616423e5-43c2-4d63-aab1-d3f554b08abb"]



                //new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath("//*[@id=\"MY-int-21237652-616423e5-43c2-4d63-aab1-d3f554b08abb\"]/td[9]/div[1]/a")))).Click();
                //driver.FindElement(By.XPath("//*[@id=\"MY-int-21237652-616423e5-43c2-4d63-aab1-d3f554b08abb\"]/td[9]/div[1]/a")).Click();
                //Console.WriteLine("Select trip");
                /* bus test2 = new bus();
                // bool trip = test2.IsElementPresent("//*[@id=\"btnProceedToPassengerDetail\"]");



                 //*[@id="btnProceedToPassengerDetail"]
                 while (trip == true)
                 {
                     driver.FindElement(By.XPath("//*[@id=\"btnProceedToPassengerDetail\"]")).Click();
                 }*/
                //Thread.Sleep(1000);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Select seat element not found");

            }



        }



     
        public void SelectSeat()
        {
           
            driver.FindElement(By.XPath("//*[@id=\"coach-lower\"]/table/tbody/tr[3]/td/table/tbody:contains (seat-cell available)")).Click();
            
            /*for (int Tr = 1; Tr < 11; Tr++)
            {
                for (int Td = 1; Td < 5; Td++)
                {
                    try
                    {
                        //*[@id="coach-lower"]/table/tbody/tr[3]/td/table/tbody/tr[1]/td[2]/a/div
                        //Thread.Sleep(1000);
                        driver.FindElement(By.XPath("//div[@id='coach-lower']/table/tbody/tr[3]/td/table/tbody/tr[" + (Tr) + "]/td[" + (Td) + "]/a/div")).Click();//WORKING
                        driver.FindElement(By.Id("btnProceedToPassengerDetail")).Click();
                        //Console.WriteLine("Continue Pax detail clicked");
                        //Console.WriteLine("Seat Td: {0} - Tr: {1} tested", Td,Tr);

                        try
                        {
                            IAlert simpleAlert = driver.SwitchTo().Alert();
                            //Console.WriteLine("Popup found");

                            String alertText = simpleAlert.Text;
                            //Console.WriteLine("Alert text is " + alertText);

                            simpleAlert.Accept();
                            //Console.WriteLine("Popup clicked");

                            continue;
                        }
                        catch (NoAlertPresentException)
                        {
                            Console.WriteLine("No alert found");
                        }

                    }
                    catch (NoSuchElementException)
                    {
                        continue;
                    }
                }
            }*/
            //Console.WriteLine("Empty seat found");
        }



        public void Insurance()
        {
            try
            {
                IWebElement element = driver.FindElement(By.ClassName("cbInsurance_MobileViewOnly"));
                //Console.WriteLine("Insurance found");

                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);

                // Switch the control of 'driver' to the Alert from main window
                IAlert confirmationAlert = driver.SwitchTo().Alert();
                //Console.WriteLine("Found alert");

                // Get the Text of Alert
                String alertText = confirmationAlert.Text;

                //Console.WriteLine("Alert text is " + alertText);

                //'.Dismiss()' is used to cancel the alert '(click on the Cancel button)'
                confirmationAlert.Accept();
                //Console.WriteLine("Alert clicked");

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Insurance not found");
               // driver.Close();

            }

        }

        public void PaymentGate()
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id("paymentPayPalEC_SGD")))).Click();
                //driver.FindElement(By.Id("paymentPayPalEC_SGD")).Click();
                // Console.WriteLine("Select Paypal");
                //Thread.Sleep(2000);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Paypal element not found");
               // driver.Close();

            }

        }

        public void goToCaptcha()
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id("CaptchaCode")))).Click();
                //driver.FindElement(By.Id("CaptchaCode")).Click();
                //driver.FindElement(By.XPath("//*[@id=\"CaptchaCode\"]")).Click();

                //Console.WriteLine("Captcha found");
                Thread.Sleep(8000);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Captcha not found");
                //driver.Close();

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
               // driver.Close();

            }

        }

        public void PayPalLogin()
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementExists(By.LinkText("Log In"))).Click();
                /*new WebDriverWait(driver, TimeSpan.FromSeconds(25)).Until(ExpectedConditions.ElementExists(By.Id("email"))).SendKeys("ebvanhieptest1@gmail.com");
                driver.FindElement(By.XPath("//*[@id=\"btnNext\"]")).Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(25)).Until(ExpectedConditions.ElementExists(By.Id("password"))).SendKeys("Ebtest@1133");
                driver.FindElement(By.CssSelector("#btnLogin")).Click();*/
                Thread.Sleep(5000);
                //driver.FindElement(By.LinkText("Log In")).Click();
                //Thread.Sleep(6000);
                //Console.WriteLine("Login clicked");
                //Thread.Sleep(8000);

                /* driver.SwitchTo().Frame(driver.FindElement(By.TagName("iframe")));
                 var emailAddressLogin = driver.FindElement(By.Id("email"));
                 emailAddressLogin.SendKeys("ebvanhieptest1@gmail.com");
                 var password = driver.FindElement(By.Id("password"));
                 password.SendKeys("Ebtest@1133");

                 IWebElement log = driver.FindElement(By.CssSelector("#btnLogin"));
                 log.Click();
                 //Console.WriteLine("Logged in");

                 Thread.Sleep(6000);

                 Thread.Sleep(6000);
                 driver.FindElement(By.LinkText("Log In")).Click();
                 Thread.Sleep(5000);
                 //Console.WriteLine("Login clicked");
                 //Thread.Sleep(8000);*/

                //driver.SwitchTo().Frame(driver.FindElement(By.TagName("iframe")));
                //var emailAddressLogin = driver.FindElement(By.Id("email"));
                //emailAddressLogin.SendKeys("ebvanhieptest1@gmail.com");
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

                //Thread.Sleep(8000);

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
                new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementExists(By.Id("confirmButtonTop"))).Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(25)).Until(ExpectedConditions.ElementExists(By.Id("pay_now_button"))).Click();

                //driver.FindElement(By.XPath("//div[@id='button']/button")).Click();
                //Console.WriteLine("Pay now");
                //Thread.Sleep(1000);
                //driver.FindElement(By.Id("confirmButtonTop")).Click();
                //Console.WriteLine("Pay Now 2");
                //Thread.Sleep(5000);
                //driver.FindElement(By.Id("pay_now_button")).Click();
                //Console.WriteLine("Pay Now 3");
               // Thread.Sleep(8000);


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

    }


    class Program
    {


        static void Main(string[] args)
        {


            bus test1 = new bus();
            test1.LaunchBrowser();
            test1.Login();
            test1.ChangeCountry();
            test1.GoToURL();
            test1.SelectTripType();
            //Thread.Sleep(1000);

            test1.SelectDate();
            //Thread.Sleep(1000);

            test1.SubmitSearch();
            //Thread.Sleep(1000);

            test1.SelectTrip();
            //Thread.Sleep(1000);

            test1.SelectSeat();
            //Thread.Sleep(1000);

            test1.Insurance();
            Thread.Sleep(1000);

            test1.PaymentGate();
            //Thread.Sleep(1000);

            test1.goToCaptcha();
            //Thread.Sleep(1000);

            test1.PayNow();
            //Thread.Sleep(1000);

            test1.PayPalLogin();
            //Thread.Sleep(1000);

            test1.PayProcess();
            //Thread.Sleep(1000);

            test1.ScreenShotsOS();
            //test1.ScreenShotsOS1();

        }
    }
}
