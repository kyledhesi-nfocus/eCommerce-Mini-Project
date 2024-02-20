using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static eCommerce_Mini_Project.Utilities.HelperLibrary;

namespace eCommerce_Mini_Project.PageObjects {
    internal class Cart {

        private IWebDriver _driver;


        public Cart(IWebDriver driver) {
            this._driver = driver;
        }

        public IWebElement couponCodeInput => _driver.FindElement(By.Id("coupon_code"));
        public IWebElement addressInputLink => _driver.FindElement(By.CssSelector("#post-5 > div > div > div.cart-collaterals > div > table > tbody > tr.woocommerce-shipping-totals.shipping > td > form > a"));
        
        public string originalPrice => _driver.FindElement(By.XPath("//*[@id=\"post-5\"]/div/div/div[2]/div/table/tbody/tr[1]/td/span")).Text;
        public string reducedAmount => _driver.FindElement(By.XPath("//*[@id=\"post-5\"]/div/div/div[2]/div/table/tbody/tr[2]/td/span")).Text;
        public string shippingPrice => _driver.FindElement(By.XPath("//*[@id=\"shipping_method\"]/li/label/span")).Text;
        public string totalPrice => _driver.FindElement(By.XPath("//*[@id=\"post-5\"]/div/div/div[2]/div/table/tbody/tr[4]/td/strong/span")).Text;


        public void enterCouponCode() {
            couponCodeInput.SendKeys("edgewords");
            couponCodeInput.SendKeys(Keys.Enter);
        }

        public decimal getOriginalPrice() {
            WaitForElement(_driver, 5, By.XPath("//*[@id=\"post-5\"]/div/div/div[2]/div/table/tbody/tr[1]/td/span"));
            return toDecimal(originalPrice);
        }

        public decimal getReducedAmount() {
            WaitForElement(_driver, 5, By.XPath("//*[@id=\"post-5\"]/div/div/div[2]/div/table/tbody/tr[2]/td/span"));
            return toDecimal(reducedAmount);
        }

        public decimal getShippingPrice() {
            WaitForElement(_driver, 5, (By.XPath("//*[@id=\"shipping_method\"]/li/label/span")));
            return toDecimal(shippingPrice);
        }

        public decimal getTotalPrice() {
            WaitForElement(_driver, 5, By.XPath("//*[@id=\"post-5\"]/div/div/div[2]/div/table/tbody/tr[4]/td/strong/span"));
            return toDecimal(totalPrice);
        }
    }
}
