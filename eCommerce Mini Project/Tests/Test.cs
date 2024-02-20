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
            Navigation navigation = new Navigation(driver);
            Shop shop = new Shop(driver);
            Cart cart = new Cart(driver);
            MyAccount myAccount = new MyAccount(driver);

            navigation.clickLink("Shop"); // Navigate to shop page
            Console.WriteLine("Successfully entered shop");


            shop.addToCart(); // Add item to cart
            Console.WriteLine("Successfully added item to cart");

            navigation.clickLink("Cart"); // Navigate to cart page
            HelperLibrary.takeScreenshot(driver, "Add item to cart.jpg");
            Console.WriteLine("Successfully entered cart");
            

            cart.enterCouponCode(); // Apply coupon
            HelperLibrary.takeScreenshot(driver, "Apply coupon.jpg");
            Console.WriteLine("Successfully applied coupon");

            decimal originalPrice = cart.getOriginalPrice(); // Get orignal price
            decimal reducedAmount = cart.getReducedAmount(); // Get reduced amount
            decimal shippingPrice = cart.getShippingPrice(); // Get shipping price
            decimal totalPrice = cart.getTotalPrice(); // Get total price 

            decimal discountAmount = originalPrice - (originalPrice * 0.85M); // Value to be compared with reducedAmount
            decimal total = (originalPrice - reducedAmount) + shippingPrice; // Value to be compared with totalPrice
            
            Assert.That(discountAmount, Is.EqualTo(reducedAmount), "Coupon has ");
            Console.WriteLine("Successfully reduced 15% from original price");

            Assert.That(total, Is.EqualTo(totalPrice), "Incorrect");
            Console.WriteLine("Successfully calculated total after coupon & shippping");

            navigation.clickLink("My account");
            Console.WriteLine("Sucessfully entered My account");
            
            myAccount.logout();
            Console.WriteLine("Successfully logged out");

        }

        /*
         * Testing functionality of completing an order 
         */

        [Test, Category("Smoke Test"), Order(2)]
        public void TestCase2() {

            Navigation navigation = new Navigation(driver);
            Shop shop = new Shop(driver);
            Cart cart = new Cart(driver);
            MyAccount myAccount = new MyAccount(driver);
            Checkout checkout = new Checkout(driver);

            navigation.clickLink("Shop"); // Navigate to shop page
            Console.WriteLine("Successfully entered shop");


            shop.addToCart(); // Add item to cart
            Console.WriteLine("Successfully added item to cart");

            navigation.clickLink("Cart"); // Navigate to cart page
            HelperLibrary.takeScreenshot(driver, "Add item to cart.jpg");
            Console.WriteLine("Successfully entered cart");

            cart.checkout();
            Console.WriteLine("Successfully entered checkout");

            checkout.enterDetails();
            checkout.placeOrder();

            string orderNumber = checkout.getOrderNumber();
 
            navigation.clickLink("My account");
            myAccount.viewOrders();

            string myAccountOrderNumber = myAccount.getOrderNumber();

            Assert.That(orderNumber, Is.EqualTo(myAccountOrderNumber.TrimStart('#')).IgnoreCase);

            myAccount.logout();
        }
    }
}
