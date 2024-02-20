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

        [Test, Order(1)]
        public void checkCoupon() {
            Navigation navigation = new Navigation(driver);
            navigation.clickLink("Shop");

            Shop shop = new Shop(driver);     
            shop.addToCart();

            

            navigation.clickLink("Cart");

            Cart cart = new Cart(driver);
            cart.enterCouponCode();

            decimal originalPrice = cart.getOriginalPrice();
            decimal reducedAmount = cart.getReducedAmount();
            decimal shippingPrice = cart.getShippingPrice();

            decimal discountAmount = originalPrice - (originalPrice * 0.85M); // Calculate 15% off, check 


            decimal total = (originalPrice - reducedAmount) + shippingPrice; // Calculated total - value to be compared
            decimal totalPrice = cart.getTotalPrice(); // total price displayed 

            Assert.That(discountAmount, Is.EqualTo(reducedAmount), "Coupon has ");
            Assert.That(total, Is.EqualTo(totalPrice), "Incorrect");

            navigation.clickLink("My account");

            MyAccount myAccount = new MyAccount(driver);
            myAccount.logout();

        }
    }
}
