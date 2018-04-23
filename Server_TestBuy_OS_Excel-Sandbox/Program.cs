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


namespace Server_TestBuy_OS_Excel_Sandbox
{
    class Program
    {
        static void Main(string[] args)
        {
            TestBuyBus test1 = new TestBuyBus();
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
            string OSurl = test1.ScreenShotsOS();
            Console.WriteLine("OS url is : ");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(OSurl);
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
            string productType = test1.ProductName();
            string orderNo = test1.OrderNo();
            string CartID = test1.CartID();
            string Journey = test1.Journey();
            string PurchaseDate = test1.PurchaseDate();
            string departTime = test1.DepartTime();
            string passengerName = test1.PassengerName();
            string Company = test1.Company();
            test1.ExcelWrite(productType, orderNo, CartID, Journey, PurchaseDate, departTime, passengerName, Company);
            test1.CloseBrowser();

        }
    }
}
