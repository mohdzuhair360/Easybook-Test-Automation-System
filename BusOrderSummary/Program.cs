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

namespace BusOrderSummary
{
    public class OrderSummary
    {
        IWebDriver driver = new ChromeDriver();
        public void LaunchBrowser()
        {
            try
            {
                //Console.WriteLine("Enter URL : ");
                string url =
                    "https://test.easybook.com/en-my/payment/paymentresult?guid=BUS11ca856bb478406e8&source=PaypalEC_MYR&status=completed";
                string url1 =
                    "https://test.easybook.com/en-sg/payment/paymentresult?guid=BUS36573c11734e4113a&source=PaypalEC_SGD&status=completed";
                string url2 =
                    "https://www.easybook.com/en-sg/payment/paymentresult?guid=BUS7755b737f6034f19a&source=PaypalEC_SGD&status=completed";
                
                //url = Console.ReadLine();
                //driver.Navigate().GoToUrl(url);
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
        public void ProductName()
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
                string FrontTrim = Cluster1.Remove(0, 40);
                //Console.WriteLine(FrontTrim);
                string BackTrim = FrontTrim.Remove(21, 69);
                //Console.WriteLine(BackTrim);
                string PurchaseDate = BackTrim.Trim();
                //Console.WriteLine(PurchaseDate);
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
                string FrontTrim = Cluster1.Remove(0, 71);
                //Console.WriteLine(FrontTrim);
                //Console.WriteLine();
                //Console.WriteLine();
                string BackTrim = FrontTrim.Remove(21, 38);
                //Console.WriteLine(BackTrim);
                string CartID = BackTrim.Trim();
                //Console.WriteLine(CartID);
                Console.WriteLine("Cart ID : " + CartID);

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("CartID not found");

            }

        }

        public void DepartPlace()
        {
            try
            {
                //*[@id="print-content"]/table/tbody/tr/td/table[3]/tbody/tr[2]/td/table[1]/tbody/tr[2]/td[2]
                var DepartPlace = driver.FindElement(By.XPath("//div[@id='print-content']/table/tbody/tr/td/table[3]/tbody/tr[2]/td/table[1]/tbody/tr[2]/td[2]"));
                Console.WriteLine("Depart Place : " + DepartPlace.Text.ToString().Trim());
                //Console.WriteLine("Depart Place: " + DepartPlace.Text);

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Depart Place not found");

            }

        }

        public void ArrivePlace()
        {
            try
            {
                //*[@id="print-content"]/table/tbody/tr/td/table[3]/tbody/tr[2]/td/table[1]/tbody/tr[3]/td[2]
                var ArrivePlace = driver.FindElement(By.XPath("//div[@id='print-content']/table/tbody/tr/td/table[3]/tbody/tr[2]/td/table[1]/tbody/tr[3]/td[2]"));
                Console.WriteLine("Arrive Place : " + ArrivePlace.Text.ToString().Trim());
                //Console.WriteLine("Arrive Place: " + ArrivePlace.Text);

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Arrive Place not found");

            }

        }

        public void Journey()
        {
            try
            {
                var DepartPlace = driver.FindElement(By.XPath("//div[@id='print-content']/table/tbody/tr/td/table[3]/tbody/tr[2]/td/table[1]/tbody/tr[2]/td[2]"));
                var ArrivePlace = driver.FindElement(By.XPath("//div[@id='print-content']/table/tbody/tr/td/table[3]/tbody/tr[2]/td/table[1]/tbody/tr[3]/td[2]"));
                Console.WriteLine("Journey is : " + DepartPlace.Text.ToString().Trim() + " to " + ArrivePlace.Text.ToString().Trim());

            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Journey not found");

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

        public void Company()
        {
            try
            {
                //*[@id="print-content"]/table/tbody/tr/td/table[3]/tbody/tr[2]/td/table[1]/tbody/tr[6]/td[2]
                var Company = driver.FindElement(By.XPath("//div[@id='print-content']/table/tbody/tr/td/table[3]/tbody/tr[2]/td/table[1]/tbody/tr[6]/td[2]"));
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
                //*[@id="print-content"]/table/tbody/tr/td/table[3]/tbody/tr[2]/td/table[2]/tbody/tr[1]/td[2]
                var PassengerName = driver.FindElement(By.XPath("//div[@id='print-content']/table/tbody/tr/td/table[3]/tbody/tr[2]/td/table[2]/tbody/tr[1]/td[2]"));
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
    }

    class Program
    {
        static void Main(string[] args)
        {
            OrderSummary test1 = new OrderSummary();
           
           
            test1.LaunchBrowser();

            Console.WriteLine();
            Console.WriteLine();
            test1.ProductName();
            test1.OrderNo();
            test1.CartID();
            test1.DepartPlace();
            test1.ArrivePlace();
            test1.Journey();
            test1.PurchaseDate();
            test1.DepartTime();
            test1.PassengerName();
            test1.Company();
            test1.Server();
            test1.Platform();
            Console.WriteLine();
            Console.WriteLine();


            //test1.CloseBrowser();
            
        }
    }
}
