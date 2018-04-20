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

namespace TestBuyTrainTestMYR
{

    public class train
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
                string urlJBWoodland = "https://test.easybook.com/en-my/train/booking/jbsentral-to-woodland";
                string urlKepongKL = "https://test.easybook.com/en-my/train/booking/kepong-to-terminalktm";
                driver.Navigate().GoToUrl(urlJBWoodland);
                Console.WriteLine("Test Site - Train Test Buy");
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

        public void SelectDate()
        {
            try
            {
                driver.FindElement(By.Id("dpDepartureDate_Train")).Click();
                //17-5-2018
                driver.FindElement(By.XPath("//tr[2]/th[3]")).Click();
                driver.FindElement(By.XPath("//div[13]/div/table/tbody/tr[3]/td[5]")).Click();
                //31-5-2018
                //driver.FindElement(By.XPath("//tr[2]/th[3]")).Click();
                //driver.FindElement(By.XPath("//div[13]/div/table/tbody/tr[5]/td[5]")).Click();
                //driver.FindElement(By.XPath("//button[@value='Submit']")).Click();


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
               
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Submit button not found");
                driver.Close();

            }


        }


        public void SelectTrip()
        {
            try
            {
                //Thread.Sleep(8000);
                //*[@id="SG-ext-web-116-0-2-185-2-305-20180419-9031-ETS2"]/td[8]/div/div[1]/a
                //*[@id="SG-ext-web-116-817126-15-364-2-1158-20180429-9421-ETS2"]/td[8]/div/div[1]/a
                //trip 30/5/18
                //*[@id="SG-ext-web-116-0-2-185-2-305-20180530-9021-ETS2"]/td[8]/div/div[1]/a
                //trip 31/5/18
                //*[@id="SG-ext-web-116-0-2-185-2-305-20180531-9021-ETS2"]/td[8]/div/div[1]/a
                //*[@id="coach-A"]/table/tbody/tr[1]/td[1]/a/div
                //*[@id="SG-ext-web-116-0-2-185-2-305-20180531-9023-ETS2"]/td[8]/div/div[1]/a
                //*[@id="coach-A"]/table/tbody/tr[1]/td[1]/a/div
                //*[@id="SG-ext-web-116-0-2-185-2-305-20180531-9025-ETS2"]/td[8]/div/div[1]/a
                //driver.FindElement(By.LinkText("Select Seats/Berths")).Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.LinkText("Select Seats/Berths")))).Click();
                //driver.FindElement(By.XPath("//*[@id=\"SG-ext-web-116-0-2-185-2-305-20180531-9021-ETS2\"]/td[8]/div/div[1]/a")).Click();
                // Thread.Sleep(1000);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Select seat element not found");

            }



        }


        public void SelectSeat()
        {
            //Thread.Sleep(7000);


            // driver.FindElement(By.XPath("//div[@id='coach-1']/table/tbody/tr[13]/td[2]/a/div")).Click();
            //driver.FindElement(By.Id("btnProceedToPassengerDetail")).Click();

            //kepong-kl
            //new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath("//*[@id=\"coach-A\"]/table/tbody/tr[1]/td[1]/a/div"))));
            // driver.FindElement(By.XPath("//*[@id=\"coach-A\"]/table/tbody/tr[]/td[2]/a/div")).Click();

            //jb-woodland
            Thread.Sleep(8000);
            //new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath("//div[@id='coach-1']/table/tbody/tr[15]/td/a/div"))));
            //*[@id="coach-1"]/table/tbody/tr[14]/td[2]/a/div
            //driver.FindElement(By.XPath("//div[@id='coach-1']/table/tbody/tr[15]/td/a/div")).Click();
            driver.FindElement(By.Id("btnProceedToPassengerDetail")).Click();
            /*for (int Tr = 1; Tr < 4; Tr++)
            {
                for (int Td = 1; Td < 4; Td++)
                {
                    try
                    {
                        //new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath("//*[@id=\"coach-A\"]/table/tbody/tr[1]/ td[1]/a/div"))));
                        Thread.Sleep(2000);
                        driver.FindElement(By.XPath("//*[@id=\"coach-A\"]/table/tbody/tr/td[" + (Td) + "]/a/div")).Click();
                        // driver.FindElement(By.XPath("//div[@id='coach-1']/table/tbody/tr[3]/td/table/tbody/tr[" + (Tr) + "]/td[" + (Td) + "]/a/div")).Click();//WORKING
                        driver.FindElement(By.Id("btnProceedToPassengerDetail")).Click();
                        Console.WriteLine("Seat Td: {0} - Tr: {1} tested", Td, Tr);
                       
                        try
                        {
                            IAlert simpleAlert = driver.SwitchTo().Alert();
                            //Console.WriteLine("Popup found");

                            String alertText = simpleAlert.Text;
                            //Console.WriteLine("Alert text is " + alertText);

                            simpleAlert.Accept();
                            //Console.WriteLine("Popup clicked");
                            //new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.LinkText("Select Seats/Berths"))));
                            Thread.Sleep(2000);
                            //driver.FindElement(By.XPath("//*[@id=\"SG-ext-web-116-0-2-185-2-305-20180531-9021-ETS2\"]/td[8]/div/div[1]/a")).Click();
                            //*[@id="SG-ext-web-116-0-2-185-2-305-20180531-9021-ETS2"]/td[8]/div/div[1]/a
                           // driver.FindElement(By.LinkText("Select Seats/Berths")).Click();
                           // Console.WriteLine("Select seat again");
                            continue;
                        }

                        catch (NoAlertPresentException)
                        {
                            Console.WriteLine("No alert found");

                        }
                       driver.FindElement(By.LinkText("Select Seats/Berths")).Click();
                       Console.WriteLine("Select seat again");

                    }
                    catch (NoSuchElementException)
                    {
                        //Console.WriteLine("No seat found");
                        continue;
                    }
                    
                }
            }*/
            //Console.WriteLine("Empty seat found");
        }




        public void SelectGender()
        {
            try
            {
                //Thread.Sleep(7000);
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id("PassengerInfoList_1__PassengerGender")))).Click();
                driver.FindElement(By.Id("PassengerInfoList_1__PassengerGender")).Click();
                new SelectElement(driver.FindElement(By.Id("PassengerInfoList_1__PassengerGender"))).SelectByText("Male");
                //driver.FindElement(By.Id("PassengerInfoList_1__PassengerGender")).Click();

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Gender not found");
                driver.Close();

            }

        }

        public void EnterICPassport()
        {
            try
            {
                driver.FindElement(By.Id("txtPassengerIcOrPassport_1")).Click();
                driver.FindElement(By.Id("txtPassengerIcOrPassport_1")).Clear();
                driver.FindElement(By.Id("txtPassengerIcOrPassport_1")).SendKeys("94100000000");

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("IC/Passport not found");
                driver.Close();

            }

        }

        public void PaymentGate()
        {
            try
            {

                driver.FindElement(By.Id("paymentPayPalEC_MYR")).Click();
                // Console.WriteLine("Select Paypal");
                //Thread.Sleep(2000);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Paypal element not found");
                driver.Close();

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
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.LinkText("Log In"))));//.Click();
                //Thread.Sleep(5000);
                driver.FindElement(By.LinkText("Log In")).Click();
                Thread.Sleep(5000);
                //new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id("email"))));//.SendKeys("ebvanhieptest1@gmail.com");
                driver.FindElement(By.Id("email")).SendKeys("ebvanhieptest1@gmail.com");

                driver.FindElement(By.XPath("//*[@id=\"btnNext\"]")).Click();
                // driver.FindElement(By.Id("#btnNext")).Click();


                //*[@id="password"]
                Thread.Sleep(3000);
                //new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id("password"))));//.SendKeys("Ebtest@1133");
                var password = driver.FindElement(By.Id("password"));
                password.SendKeys("Ebtest@1133");

                driver.FindElement(By.CssSelector("#btnLogin")).Click();

                //Thread.Sleep(10000);

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
                //driver.FindElement(By.Id("confirmButtonTop")).Click();
                //driver.FindElement(By.Id("pay_now_button")).Click();
                //*[@id="button"]/button
                Thread.Sleep(10000);
                //new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath("//div[@id='button']/button"))));//.Click();
                driver.FindElement(By.XPath("//div[@id='button']/button")).Click();
                //Console.WriteLine("Pay now");
                //Thread.Sleep(2000);
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id("confirmButtonTop"))));//.Click();
                //driver.FindElement(By.XPath("//div[@id='button']/button")).Click();
                driver.FindElement(By.Id("confirmButtonTop")).Click();
                //Console.WriteLine("Pay Now 2");
                //Thread.Sleep(5000);
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id("pay_now_button"))));//.Click();
                driver.FindElement(By.Id("pay_now_button")).Click();
                //Console.WriteLine("Pay Now 3");
                //Thread.Sleep(10000);


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
                var OS = new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id("print-content"))));
                //var OS = driver.FindElement(By.Id("print-content"));
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


            train test1 = new train();
            test1.LaunchBrowser();
            test1.Login();
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

            test1.SelectGender();
            //Thread.Sleep(1000);

            test1.EnterICPassport();
            //Thread.Sleep(1000);

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
