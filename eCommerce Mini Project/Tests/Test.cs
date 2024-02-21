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

        [Test, Category("Smoke"), Order(1)]
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
            
            Console.WriteLine("Successfully applied coupon");

            cart.WaitForAlert(); 
            HelperLibrary.TakeScreenshot(driver, "Coupon Alert.jpg");
            TestContext.WriteLine("Attacthing coupon applied screenshot to report");
            TestContext.AddTestAttachment(@"C:\Users\KyleDhesi\source\repos\eCommerce Mini Project\eCommerce Mini Project\Screenshots\Coupon Alert.jpg", "Coupon has been added to cart");

            decimal originalPrice = cart.GetOriginalPrice(); // Get orignal price
            decimal reducedAmount = cart.GetReducedAmount(); // Get reduced amount
            decimal shippingPrice = cart.GetShippingPrice(); // Get shipping price
            decimal totalPrice = cart.GetTotalPrice(); // Get total price 

            decimal discountAmount = originalPrice - (originalPrice * 0.85M); // Value to be compared with reducedAmount
            decimal total = (originalPrice - reducedAmount) + shippingPrice; // Value to be compared with totalPrice
            
            try {
                Assert.That(discountAmount, Is.EqualTo(reducedAmount));
                Console.WriteLine("Successfully reduced 15% from original price");
                TestContext.WriteLine($"Subtotal price displayed {originalPrice}, Reduced amount displayed {reducedAmount}");
            } catch {
                Assert.Fail("Unsuccessfully reduced 15% from original price");
            }
            
            try {
                Assert.That(total, Is.EqualTo(totalPrice));
                Console.WriteLine("Successfully calculated total after coupon & shippping");
                TestContext.WriteLine($"Total price displayed {totalPrice}, Original price displayed {originalPrice} - reduced amount displayed {reducedAmount} + shipping cost {shippingPrice}");
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

        [Test, Category("Smoke"), Order(2)]
        public void TestCase2() {

            Navigation navigation = new Navigation(driver);
            Shop shop = new (driver);
            Cart cart = new (driver);
            MyAccount myAccount = new (driver);
            Checkout checkout = new(driver);

            BillingDetails billingDetails = new(firstName: "King", lastName: "Charles", streetName: "Buckingham Palace Road", city: "London", postcode: "SW1A 1AA", phoneNumber: "0798347190321", email: "example@email.co.uk");

            navigation.ClickLink("Shop"); // Navigate to shop page
            Console.WriteLine("Successfully entered shop");


            shop.AddToCart(); // Add item to cart
            Console.WriteLine("Successfully added item to cart");

            navigation.ClickLink("Cart"); // Navigate to cart page
            Console.WriteLine("Successfully entered cart");

            cart.Checkout(); // Navigate to checkout page
            Console.WriteLine("Successfully entered checkout");

            checkout.EnterBillingDetails(billingDetails); // Enter billing details
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
            HelperLibrary.TakeScreenshot(driver, "All Orders.jpg");
            TestContext.WriteLine("Attacthing All Orders screenshot to report");
            TestContext.AddTestAttachment(@"C:\Users\KyleDhesi\source\repos\eCommerce Mini Project\eCommerce Mini Project\Screenshots\All Orders.jpg", "All Orders");

            try {
                Assert.That(orderNumber, Is.EqualTo(myAccountOrderNumber.TrimStart('#')).IgnoreCase);
                Console.WriteLine("Successfully displayed latest order");
                TestContext.WriteLine($"Order number displayed {orderNumber}, Most recent order on My account {myAccountOrderNumber}");
            } catch {
                Assert.Fail("Unsuccessfully displayed latest order");
            }
            
        }
    }
}
