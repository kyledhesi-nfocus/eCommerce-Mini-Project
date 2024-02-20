using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static eCommerce_Mini_Project.Utilities.HelperLibrary;

namespace eCommerce_Mini_Project.PageObjects {
    internal class Checkout {

        private IWebDriver _driver;

        public Checkout(IWebDriver driver) {
            this._driver = driver;
        }

        public IWebElement firstNameInput => _driver.FindElement(By.Id("billing_first_name"));
        public IWebElement lastNameInput => _driver.FindElement(By.Id("billing_last_name"));
        public IWebElement streetNameInput => _driver.FindElement(By.Id("billing_address_1"));
        public IWebElement cityInput => _driver.FindElement(By.Id("billing_city"));
        public IWebElement postcodeInput => _driver.FindElement(By.Id("billing_postcode"));
        public IWebElement phoneNumberInput => _driver.FindElement(By.Id("billing_phone"));
        public IWebElement emailInput => _driver.FindElement(By.Id("billing_email"));
        public IWebElement checkPaymentsLink => _driver.FindElement(By.CssSelector("#payment > ul > li.wc_payment_method.payment_method_cheque > label"));
        public IWebElement placeOrderButton => _driver.FindElement(By.Id("place_order"));
        public string orderNumber => _driver.FindElement(By.XPath("//*[@id=\"post-6\"]/div/div/div/ul/li[1]/strong")).Text;

        public void enterDetails() {
            firstNameInput.Clear();
            firstNameInput.SendKeys("King");
            lastNameInput.Clear();
            lastNameInput.SendKeys("Charles");
            streetNameInput.Clear();
            streetNameInput.SendKeys("Buckingham Palace Road");
            cityInput.Clear();
            cityInput.SendKeys("London");
            postcodeInput.Clear();
            postcodeInput.SendKeys("SW1A 1AA");
            phoneNumberInput.Clear();
            phoneNumberInput.SendKeys("0798347190321");
        }
        public void placeOrder() {
            WaitForElementDisabled(_driver, 2, By.CssSelector("#payment > ul > li.wc_payment_method.payment_method_cheque > label"));
            WaitForElementDisabled(_driver, 2, By.CssSelector("blockUI.blockOverlay"));

            checkPaymentsLink.Click();
            placeOrderButton.Click();
        }

        public string getOrderNumber() {
            WaitForElement(_driver, 5, By.XPath("//*[@id=\"post-6\"]/div/div/div/ul/li[1]/strong"));
            return orderNumber;
        }
        
    }
}
