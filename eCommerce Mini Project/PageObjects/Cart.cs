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

        public IWebElement CouponCodeInput => _driver.FindElement(By.Id("coupon_code"));    
        public IWebElement AddressInputLink => _driver.FindElement(By.CssSelector("#post-5 > div > div > div.cart-collaterals > div > table > tbody > tr.woocommerce-shipping-totals.shipping > td > form > a"));
        public IWebElement CheckoutButton => _driver.FindElement(By.XPath("//*[@id=\"post-5\"]/div/div/div[2]/div/div/a"));
        public IWebElement RemoveItemButton => _driver.FindElement(By.XPath("//*[@id=\"post-5\"]/div/div/form/table/tbody/tr[1]/td[1]/a"));
        public string OriginalPrice => _driver.FindElement(By.XPath("//*[@id=\"post-5\"]/div/div/div[2]/div/table/tbody/tr[1]/td/span")).Text;
        public string ReducedAmount => _driver.FindElement(By.XPath("//*[@id=\"post-5\"]/div/div/div[2]/div/table/tbody/tr[2]/td/span")).Text;
        public string ShippingPrice => _driver.FindElement(By.XPath("//*[@id=\"shipping_method\"]/li/label/span")).Text;
        public string TotalPrice => _driver.FindElement(By.XPath("//*[@id=\"post-5\"]/div/div/div[2]/div/table/tbody/tr[4]/td/strong/span")).Text;

        public void EnterCouponCode() {
            WaitForElement(_driver, 5, By.Id("coupon_code"));
            CouponCodeInput.Clear();
            CouponCodeInput.SendKeys("edgewords");
            CouponCodeInput.SendKeys(Keys.Enter);
        }

        public decimal GetOriginalPrice() {
            WaitForElement(_driver, 5, By.XPath("//*[@id=\"post-5\"]/div/div/div[2]/div/table/tbody/tr[1]/td/span"));
            return ToDecimal(OriginalPrice);
        }

        public decimal GetReducedAmount() {
            WaitForElement(_driver, 5, By.XPath("//*[@id=\"post-5\"]/div/div/div[2]/div/table/tbody/tr[2]/td/span"));
            return ToDecimal(ReducedAmount);
        }

        public decimal GetShippingPrice() {
            WaitForElement(_driver, 5, (By.XPath("//*[@id=\"shipping_method\"]/li/label/span")));
            return ToDecimal(ShippingPrice);
        }

        public decimal GetTotalPrice() {
            WaitForElement(_driver, 5, By.XPath("//*[@id=\"post-5\"]/div/div/div[2]/div/table/tbody/tr[4]/td/strong/span"));
            return ToDecimal(TotalPrice);
        }

        public void RemoveItem() {
            WaitForElement(_driver, 5, By.XPath("//*[@id=\"post-5\"]/div/div/form/table/tbody/tr[1]/td[1]/a"));
            WaitForElementDisabled(_driver, 2, By.CssSelector("blockUI.blockOverlay"));
            RemoveItemButton.Click();
        }
        public void Checkout() {
            WaitForElement(_driver, 5, By.XPath("//*[@id=\"post-5\"]/div/div/div[2]/div/div/a"));
            CheckoutButton.Click();
        }

        public void WaitForAlert() {
            WaitForElement(_driver, 5, By.CssSelector("#post-5 > div > div > div.woocommerce-notices-wrapper > div")); // Wait for coupon applied
        }
    }
}
