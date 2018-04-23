using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.IO;
using System.Text;
using System.Threading;
using Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace Server_TestBuy_OS_Excel_Sandbox
{
    class TestBuyBus
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
                    TestBuyBus server1 = new TestBuyBus();
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
                    TestBuyBus server2 = new TestBuyBus();
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
                TestBuyBus server1 = new TestBuyBus();
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
                TestBuyBus server2 = new TestBuyBus();
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
                string urlSgNibongMelaka =
                    "https://test.easybook.com/en-my/bus/booking/sungainibong-to-melakasentral";
                string urlMelakaSgNibong =
                    "https://test.easybook.com/en-my/bus/booking/melakasentral-to-sungainibong";
                string urlKovanMelaka =
                   "https://test.easybook.com/en-my/bus/booking/kovanhub206-to-melakasentral";
                string urlMelakaKovan =
                  "https://test.easybook.com/en-my/bus/booking/melakasentral-to-kovanhub206";

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

                driver.FindElement(By.Id("dpDepartureDate_Bus")).Click();
                driver.FindElement(By.XPath("//tr[2]/th[2]")).Click();
                driver.FindElement(By.XPath("//div[2]/table/thead/tr[2]/th[2]")).Click();
                driver.FindElement(By.XPath("//div[3]/table/tbody/tr/td/span[12]")).Click();
                driver.FindElement(By.XPath("//td/span[3]")).Click();
                driver.FindElement(By.XPath("//div[12]/div/table/tbody/tr[3]/td")).Click();
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
                driver.Close();

            }


        }


        public void SelectTrip()
        {
            try
            {
                Thread.Sleep(5000);
                driver.FindElement(By.LinkText("Select")).Click();
                //Console.WriteLine("Select trip");
                /* bus test2 = new bus();
                // bool trip = test2.IsElementPresent("//*[@id=\"btnProceedToPassengerDetail\"]");



                 //*[@id="btnProceedToPassengerDetail"]
                 while (trip == true)
                 {
                     driver.FindElement(By.XPath("//*[@id=\"btnProceedToPassengerDetail\"]")).Click();
                 }*/
                Thread.Sleep(1000);
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Select seat element not found");

            }



        }



        private bool IsElementPresent(String by)
        {
            try
            {
                driver.FindElement(By.XPath(by));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void SelectSeat()
        {
            for (int Tr = 1; Tr < 11; Tr++)
            {
                for (int Td = 1; Td < 5; Td++)
                {
                    try
                    {
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
            }
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
                OpenQA.Selenium.Interactions.Actions actionsPay = new OpenQA.Selenium.Interactions.Actions(driver);
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

                Thread.Sleep(10000);
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
                Thread.Sleep(4000);
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
                driver.FindElement(By.XPath("//div[@id='button']/button")).Click();
                //Console.WriteLine("Pay now");
                Thread.Sleep(2000);
                driver.FindElement(By.Id("confirmButtonTop")).Click();
                //Console.WriteLine("Pay Now 2");
                Thread.Sleep(5000);
                driver.FindElement(By.Id("pay_now_button")).Click();
                //Console.WriteLine("Pay Now 3");
                Thread.Sleep(10000);


            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Cannot proceed to pay");
            }

        }

        public string ScreenShotsOS()
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
                //Console.WriteLine("OS URL is : ");
                Console.WriteLine();
                //Console.WriteLine(url);
                Console.WriteLine();
                Console.WriteLine();
                var OS = driver.FindElement(By.Id("print-content"));
                OpenQA.Selenium.Interactions.Actions actionsPay = new OpenQA.Selenium.Interactions.Actions(driver);
                actionsPay.MoveToElement(OS);
                actionsPay.Perform();
                Screenshot ss1 = ((ITakesScreenshot)driver).GetScreenshot();
                ss1.SaveAsFile("D:/Screenshots\\" + currentDate + " (OS).png", OpenQA.Selenium.ScreenshotImageFormat.Png);
                return url;
                //Console.WriteLine("SS OS done");
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("OS not found");
                return null;
            }
        }

        public string ProductName()
        {
            try
            {
                var Div1 = driver.FindElement(By.XPath("//div[@id='print-content']/table/tbody/tr/td/table/tbody/tr[2]/td"));
                string Cluster1 = Div1.Text.ToString();
                //Console.WriteLine(Cluster1);
                string FrontTrim = Cluster1.Remove(0, 71);
                //Console.WriteLine(FrontTrim);
                //Console.WriteLine();
                //Console.WriteLine();
                string BackTrim = FrontTrim.Remove(21, 38);
                //Console.WriteLine(BackTrim);
                string CartID = BackTrim.Trim();
                //Console.WriteLine(CartID);
                //Console.WriteLine("Cart ID : " + CartID);
                //string product = CartID.Remove(3, 10);
                string product = CartID;
                //Console.WriteLine(product);

                if (product.Contains("FR"))
                {
                    string productName = "Ferry";
                    //Console.WriteLine("Product : " + productName);
                    return productName;


                }
                else if (product.Contains("TR"))
                {
                    string productName = "Train";
                    //Console.WriteLine("Product : " + productName);
                    return productName;

                }
                else if (product.Contains("BUS"))
                {
                    string productName = "Bus";
                    //Console.WriteLine("Product : " + productName);
                    return productName;

                }
                else if (product.Contains("CR"))
                {
                    string productName = "Car";
                    //Console.WriteLine("Product : " + productName);
                    return productName;

                }
                else
                {
                    Console.WriteLine("Cannot identify product name");
                    return null;

                }

                

                //Console.WriteLine("Cart ID : " + CartID2);
                //Console.WriteLine("Product : " + product);

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Product Name not found");
                return null;

            }

        }
        public string OrderNo()
        {
            try
            {
                var OrderNo = driver.FindElement(By.XPath("//div[@id='print-content']/table/tbody/tr/td/table/tbody/tr[2]/td/strong/span"));
                string orderNo1 = OrderNo.Text.ToString().Trim();
                //Console.WriteLine("Order no : " + orderNo1);
                //Console.WriteLine("Order no : "+ OrderNo.Text);
                return orderNo1;

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Order No not found");
                return null;
            }

        }

        public string PurchaseDate()
        {
            try
            {
                var Div1 = driver.FindElement(By.XPath("//div[@id='print-content']/table/tbody/tr/td/table/tbody/tr[2]/td"));
                string Cluster1 = Div1.Text.ToString();
                //Console.WriteLine(Cluster1);
                string FrontTrim = Cluster1.Remove(0, 40);
                //Console.WriteLine(FrontTrim);
                string BackTrim = FrontTrim.Remove(21, 69);
                //Console.WriteLine(BackTrim);
                string PurchaseDate = BackTrim.Trim();
                //Console.WriteLine(PurchaseDate);
               // Console.WriteLine("Purchase date : " + PurchaseDate);
                return PurchaseDate;
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Purchase date not found");
                return null;

            }

        }

        public string CartID()
        {
            try
            {
                var Div1 = driver.FindElement(By.XPath("//div[@id='print-content']/table/tbody/tr/td/table/tbody/tr[2]/td"));
                string Cluster1 = Div1.Text.ToString();
                //Console.WriteLine(Cluster1);
                string FrontTrim = Cluster1.Remove(0, 71);
                //Console.WriteLine(FrontTrim);
                //Console.WriteLine();
                //Console.WriteLine();
                string BackTrim = FrontTrim.Remove(21, 38);
                //Console.WriteLine(BackTrim);
                string CartID = BackTrim.Trim();
                //Console.WriteLine(CartID);
                //Console.WriteLine("Cart ID : " + CartID);
                return CartID;

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("CartID not found");
                return null;

            }

        }

        public string DepartPlace()
        {
            try
            {
                //*[@id="print-content"]/table/tbody/tr/td/table[3]/tbody/tr[2]/td/table[1]/tbody/tr[2]/td[2]
                var DepartPlace = driver.FindElement(By.XPath("//div[@id='print-content']/table/tbody/tr/td/table[3]/tbody/tr[2]/td/table[1]/tbody/tr[2]/td[2]"));
                string departPlace1 = DepartPlace.Text.ToString().Trim();
                //Console.WriteLine("Depart Place : " + departPlace1);
                //Console.WriteLine("Depart Place: " + DepartPlace.Text);
                return departPlace1;

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Depart Place not found");
                return null;

            }

        }

        public string ArrivePlace()
        {
            try
            {
                //*[@id="print-content"]/table/tbody/tr/td/table[3]/tbody/tr[2]/td/table[1]/tbody/tr[3]/td[2]
                var ArrivePlace = driver.FindElement(By.XPath("//div[@id='print-content']/table/tbody/tr/td/table[3]/tbody/tr[2]/td/table[1]/tbody/tr[3]/td[2]"));
                string arrPlace = ArrivePlace.Text.ToString().Trim();
                //Console.WriteLine("Arrive Place : " + arrPlace);
                //Console.WriteLine("Arrive Place: " + ArrivePlace.Text);
                return arrPlace;


            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Arrive Place not found");
                return null;

            }

        }

        public string Journey()
        {
            try
            {
                var DepartPlace = driver.FindElement(By.XPath("//div[@id='print-content']/table/tbody/tr/td/table[3]/tbody/tr[2]/td/table[1]/tbody/tr[2]/td[2]"));
                var ArrivePlace = driver.FindElement(By.XPath("//div[@id='print-content']/table/tbody/tr/td/table[3]/tbody/tr[2]/td/table[1]/tbody/tr[3]/td[2]"));
                string departPlace1 = DepartPlace.Text.ToString().Trim();
                string arrPlace = ArrivePlace.Text.ToString().Trim();
                //Console.WriteLine("Journey is : " + DepartPlace.Text.ToString().Trim() + " to " + ArrivePlace.Text.ToString().Trim());
                return departPlace1 + " to " + arrPlace;

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Journey not found");
                return null;
            }

        }

        public string DepartTime()
        {
            try
            {
                //*[@id="print-content"]/table/tbody/tr/td/table[3]/tbody/tr[2]/td/table[1]/tbody/tr[5]/td[2]
                var DepartTime = driver.FindElement(By.XPath(" //*[@id=\"print-content\"]/table/tbody/tr/td/table[3]/tbody/tr[2]/td/table[1]/tbody/tr[5]/td[2]"));
                string departTime1 = DepartTime.Text.ToString().Trim();
               // Console.WriteLine("Depart Time : " + departTime1);
                //Console.WriteLine("Depart Time: " + DepartTime.Text);
                return departTime1;

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Depart Time not found");
                return null;
            }

        }

        public string Company()
        {
            try
            {
                //*[@id="print-content"]/table/tbody/tr/td/table[3]/tbody/tr[2]/td/table[1]/tbody/tr[6]/td[2]
                var Company = driver.FindElement(By.XPath("//div[@id='print-content']/table/tbody/tr/td/table[3]/tbody/tr[2]/td/table[1]/tbody/tr[6]/td[2]"));
                string Company1 = Company.Text.ToString().Trim();
               // Console.WriteLine("Company : " + Company1);
                //Console.WriteLine("Company: " + Company.Text);
                return Company1;

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Company not found");
                return null;

            }

        }

        public string PassengerName()
        {
            try
            {
                //*[@id="print-content"]/table/tbody/tr/td/table[3]/tbody/tr[2]/td/table[2]/tbody/tr[1]/td[2]
                var PassengerName = driver.FindElement(By.XPath("//div[@id='print-content']/table/tbody/tr/td/table[3]/tbody/tr[2]/td/table[2]/tbody/tr[1]/td[2]"));
                string passName = PassengerName.Text.ToString().Trim();
               // Console.WriteLine("Passenger Name : " + passName);
                //Console.WriteLine("Passenger Name: " + PassengerName.Text);
                return passName;

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Passenger Name not found");
                return null;

            }

        }

        public void Server()
        {
            try
            {
                var ServPlat = driver.FindElement(By.XPath("//div[@id='print-content']/table/tbody/tr/td/table[5]/tbody/tr[8]/td"));
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
                var ServPlat = driver.FindElement(By.XPath("//div[@id='print-content']/table/tbody/tr/td/table[5]/tbody/tr[8]/td"));
                string strServPlat = ServPlat.Text.ToString();
                string platTrim = strServPlat.Trim().ToLower();
                //string plat = strServPlat.Remove(0, 18);
                //string platform = plat.Trim();
                //Console.WriteLine("Platform : " + platform);
                //Console.WriteLine(strServPlat);

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

        public void ExcelWrite(string productType, string orderNo, string CartID,
          string carDetail, string PurchaseDate, string rentDuration, string passengerName, string Company)
        {
            string file = "D:\\Product Purchase Log Sandbox1.xlsx";
            File.SetAttributes(file, File.GetAttributes(file) & ~FileAttributes.ReadOnly);

            int i = 0;
            string[] orderDetail = {productType,  orderNo,  CartID, "",
             carDetail,  PurchaseDate,  rentDuration,  passengerName, Company };

            Microsoft.Office.Interop.Excel.Application ExcelObj = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Worksheet WSheet;

            try
            {
                //Start Excel and get Application object.

                object oMissing = Missing.Value;
                ExcelObj.Visible = true;
                Console.WriteLine(i);
                i++;
                if (!File.Exists(file))
                {
                    Console.WriteLine("File do not exist");
                }
                Microsoft.Office.Interop.Excel.Workbook xlWorkbook;
                xlWorkbook = ExcelObj.Workbooks.Open(file);

                // open the existing sheet

                WSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelObj.Sheets.get_Item(1);
                for (int col = 2; col < 11; col++)
                {
                    for (int row = 3; row < 4; row++)
                    {

                        WSheet.Cells[row, col] = orderDetail[col - 2];
                    }
                }


                xlWorkbook.Save();
                //xlWorkbook.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Excel cannot open", e);

            }

        }

    }
}
