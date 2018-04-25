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

namespace TestBuyCarLiveMYR
{

    public class car
    {
        public void LaunchBrowser()
        {
            try
            {
                string url = "https://www.easybook.com/en-my";
                driver.Navigate().GoToUrl(url);
                driver.Manage().Window.Maximize();
                //((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");
                //Thread.Sleep(2000);
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
                string urlKualaLumpur =
                   "https://www.easybook.com/en-my/car/booking/kualalumpurarea";
               
                driver.Navigate().GoToUrl(urlKualaLumpur);
                Console.WriteLine("Test Site - Car Test Buy");

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
                driver.FindElement(By.Id("ddPickUpDateCar")).Clear();
                driver.FindElement(By.Id("ddPickUpDateCar")).SendKeys("2046-03-08");

                driver.FindElement(By.Id("ddlPickUpTimeCar")).Click();
                driver.FindElement(By.XPath("//*[@id=\"ddlPickUpTimeCar\"]/option[1]")).Click();
                //*[@id="ddlPickUpTimeCar"]/option[1]
                //driver.FindElement(By.Id("ddlPickUpTimeCar")).SendKeys("2019 - 3 - 8");

                driver.FindElement(By.Id("ddReturnDateCar")).Click();
                driver.FindElement(By.Id("ddReturnDateCar")).Clear();
                driver.FindElement(By.Id("ddReturnDateCar")).SendKeys("2046-03-08");

                driver.FindElement(By.Id("ddlReturnTimeCar")).Click();
                driver.FindElement(By.XPath("//*[@id=\"ddlReturnTimeCar\"]/option[3]")).Click();
                //driver.FindElement(By.Id("ddReturnDateCar")).Click();
                //driver.FindElement(By.XPath("//div[8]/div/table/tbody/tr[2]/td[6]")).Click();
                //Thread.Sleep(2000);
                //driver.FindElement(By.Id("ddReturnDateCar")).Click();
                //driver.FindElement(By.XPath("//div[8]/div/table/tbody/tr[2]/td[7]")).Click();
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
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.XPath("(//button[@name='submit'])[2]")))).Click();
                //driver.FindElement(By.XPath("(//button[@name='submit'])[2]")).Click();
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
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementExists((By.Id("paymentPayPalEC_MYR")))).Click();
                //driver.FindElement(By.Id("paymentPayPalEC_MYR")).Click();
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
                //driver.Close();

            }

        }



        public void PayPalLogin()
        {
            try
            {
                /*Thread.Sleep(5000);
                driver.FindElement(By.LinkText("Log In")).Click();
                Thread.Sleep(8000);
                //Console.WriteLine("Login clicked");
                //Thread.Sleep(8000);

                driver.SwitchTo().Frame(driver.FindElement(By.TagName("iframe")));
                var emailAddressLogin = driver.FindElement(By.Id("email"));
                emailAddressLogin.SendKeys("ebvanhieptest1@gmail.com");
                var password = driver.FindElement(By.Id("password"));
                password.SendKeys("Ebtest@1133");

                IWebElement log = driver.FindElement(By.CssSelector("#btnLogin"));
                log.Click();
                //Console.WriteLine("Logged in");

                Thread.Sleep(6000);*/
                new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(ExpectedConditions.ElementExists(By.LinkText("Log In"))).Click();
                //Thread.Sleep(15000);
                //driver.FindElement(By.LinkText("Log In")).Click();
                Thread.Sleep(7000);

                //Thread.Sleep(6000);
                //driver.FindElement(By.LinkText("Log In")).Click();
                //Thread.Sleep(5000);
                //Console.WriteLine("Login clicked");
                //Thread.Sleep(8000);

                //driver.SwitchTo().Frame(driver.FindElement(By.TagName("iframe")));
                //var emailAddressLogin = driver.FindElement(By.Id("email"));
                //emailAddressLogin.SendKeys("ebvanhieptest1@gmail.com");
                driver.FindElement(By.Id("email")).SendKeys("ebvanhieptest1@gmail.com");

                driver.FindElement(By.XPath("//*[@id=\"btnNext\"]")).Click();
                // driver.FindElement(By.Id("#btnNext")).Click();


                //*[@id="password"]
                Thread.Sleep(4000);
                var password = driver.FindElement(By.Id("password"));
                password.SendKeys("Ebtest@1133");

                driver.FindElement(By.CssSelector("#btnLogin")).Click();

                //*[@id="btnLogin"]
                //Console.WriteLine("Logged in");

                Thread.Sleep(8000);

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
                new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists(By.XPath("//div[@id='button']/button"))).Click();

                new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(ExpectedConditions.ElementExists(By.Id("confirmButtonTop"))).Click();

                new WebDriverWait(driver, TimeSpan.FromSeconds(25)).Until(ExpectedConditions.ElementExists(By.Id("pay_now_button"))).Click();
                Thread.Sleep(15000);
                //driver.FindElement(By.XPath("//div[@id='button']/button")).Click();
                //Console.WriteLine("Pay now");
                //Thread.Sleep(1000);
                //driver.FindElement(By.Id("confirmButtonTop")).Click();
                //Console.WriteLine("Pay Now 2");
                //Thread.Sleep(5000);
                //driver.FindElement(By.Id("pay_now_button")).Click();
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

            }
        }
    }
}
