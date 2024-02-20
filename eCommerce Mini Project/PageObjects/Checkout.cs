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

        public IWebElement FirstNameInput => _driver.FindElement(By.Id("billing_first_name"));
        public IWebElement LastNameInput => _driver.FindElement(By.Id("billing_last_name"));
        public IWebElement StreetNameInput => _driver.FindElement(By.Id("billing_address_1"));
        public IWebElement CityInput => _driver.FindElement(By.Id("billing_city"));
        public IWebElement PostcodeInput => _driver.FindElement(By.Id("billing_postcode"));
        public IWebElement PhoneNumberInput => _driver.FindElement(By.Id("billing_phone"));
        public IWebElement EmailInput => _driver.FindElement(By.Id("billing_email"));
        public IWebElement CheckPaymentsLink => _driver.FindElement(By.CssSelector("#payment > ul > li.wc_payment_method.payment_method_cheque > label"));
        public IWebElement PlaceOrderButton => _driver.FindElement(By.Id("place_order"));
        public string OrderNumber => _driver.FindElement(By.XPath("//*[@id=\"post-6\"]/div/div/div/ul/li[1]/strong")).Text;

        public void EnterBillingDetails() {
            FirstNameInput.Clear();
            FirstNameInput.SendKeys("King");
            LastNameInput.Clear();
            LastNameInput.SendKeys("Charles");
            StreetNameInput.Clear();
            StreetNameInput.SendKeys("Buckingham Palace Road");
            CityInput.Clear();
            CityInput.SendKeys("London");
            PostcodeInput.Clear();
            PostcodeInput.SendKeys("SW1A 1AA");
            PhoneNumberInput.Clear();
            PhoneNumberInput.SendKeys("0798347190321");
        }
        public void PlaceOrder() {
            WaitForElementDisabled(_driver, 2, By.CssSelector("#payment > ul > li.wc_payment_method.payment_method_cheque > label"));
            WaitForElementDisabled(_driver, 2, By.CssSelector("blockUI.blockOverlay"));

            CheckPaymentsLink.Click();
            PlaceOrderButton.Click();
        }

        public string GetOrderNumber() {
            WaitForElement(_driver, 5, By.XPath("//*[@id=\"post-6\"]/div/div/div/ul/li[1]/strong"));
            return OrderNumber;
        }
        
    }
}
