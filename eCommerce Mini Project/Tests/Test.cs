using eCommerce_Mini_Project.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerce_Mini_Project.PageObjects;



namespace eCommerce_Mini_Project.Tests {

    [TestFixture]
    public class Test : Utilities.TestBase {

        /*
         * Testing functionality of coupon application
         */

        [Test, Category("Smoke Test"), Order(1)]
        public void TestCase1() {
            Navigation navigation = new(driver);
            Shop shop = new(driver);
            Cart cart = new(driver);
            MyAccount myAccount = new(driver);

            navigation.ClickLink("Shop"); // Navigate to shop page
            Console.WriteLine("Successfully entered shop");


            shop.AddToCart(); // Add item to cart
            Console.WriteLine("Successfully added item to cart");

            navigation.ClickLink("Cart"); // Navigate to cart page
            Console.WriteLine("Successfully entered cart");
            

            cart.EnterCouponCode(); // Apply coupon
            
            
            // HelperLibrary.takeScreenshot(driver, "Coupon Application.jpg");
            Console.WriteLine("Successfully applied coupon");

            Thread.Sleep(2000);
            HelperLibrary.TakeScreenshot(driver, "Coupon applied.jpg");
            TestContext.WriteLine("Attacthing coupon applied scrennshot to report");
            TestContext.AddTestAttachment(@"C:\Users\KyleDhesi\source\repos\eCommerce Mini Project\eCommerce Mini Project\Screenshots\Coupon applied.jpg", "Coupon has been added to cart");

            decimal originalPrice = cart.GetOriginalPrice(); // Get orignal price
            decimal reducedAmount = cart.GetReducedAmount(); // Get reduced amount
            decimal shippingPrice = cart.GetShippingPrice(); // Get shipping price
            decimal totalPrice = cart.GetTotalPrice(); // Get total price 

            decimal discountAmount = originalPrice - (originalPrice * 0.85M); // Value to be compared with reducedAmount
            decimal total = (originalPrice - reducedAmount) + shippingPrice; // Value to be compared with totalPrice
            
            try {
                Assert.That(discountAmount, Is.EqualTo(reducedAmount));
                Console.WriteLine("Successfully reduced 15% from original price");
            } catch {
                Assert.Fail("Unsuccessfully reduced 15% from original price");
            }
            
            try {
                Assert.That(total, Is.EqualTo(totalPrice));
                Console.WriteLine("Successfully calculated total after coupon & shippping");
            } catch {
                Assert.Fail("Unsuccessfully calculated total after coupon & shipping");
            }

            cart.RemoveItem();
            Console.WriteLine("Successfully removed items");


            navigation.ClickLink("My account");
            Console.WriteLine("Successfully entered My account");
        }

        /*
         * Testing functionality of completing an order 
         */

        [Test, Category("Smoke Test"), Order(2)]
        public void TestCase2() {

            Navigation navigation = new Navigation(driver);
            Shop shop = new (driver);
            Cart cart = new (driver);
            MyAccount myAccount = new (driver);
            Checkout checkout = new(driver);

            navigation.ClickLink("Shop"); // Navigate to shop page
            Console.WriteLine("Successfully entered shop");


            shop.AddToCart(); // Add item to cart
            Console.WriteLine("Successfully added item to cart");

            navigation.ClickLink("Cart"); // Navigate to cart page
            Console.WriteLine("Successfully entered cart");

            cart.Checkout(); // Navigate to checkout page
            Console.WriteLine("Successfully entered checkout");

            checkout.EnterBillingDetails(); // Enter billing details
            Console.WriteLine("Successfully entered billing details");

            checkout.PlaceOrder(); // Submit order
            Console.WriteLine("Successfully placed order");
            
            checkout.OrderRecieved();
            HelperLibrary.TakeScreenshot(driver, "Order Recieved.jpg");
            TestContext.WriteLine("Attacthing Order Confirmation screenshot to report");
            TestContext.AddTestAttachment(@"C:\Users\KyleDhesi\source\repos\eCommerce Mini Project\eCommerce Mini Project\Screenshots\Order recieved.jpg", "Order Confirmation");


            string orderNumber = checkout.GetOrderNumber(); // Get order number
 
            navigation.ClickLink("My account"); // Navigate to My account
            Console.WriteLine("Successfully entered My account");

            myAccount.ViewOrders(); // View all orders

            string myAccountOrderNumber = myAccount.GetOrderNumber(); // Get latest order number

            try {
                Assert.That(orderNumber, Is.EqualTo(myAccountOrderNumber.TrimStart('#')).IgnoreCase);
                Console.WriteLine("Successfully displayed latest order");
            } catch {
                Assert.Fail("Unsuccessfully displayed latest order");
            }
            
        }
    }
}
