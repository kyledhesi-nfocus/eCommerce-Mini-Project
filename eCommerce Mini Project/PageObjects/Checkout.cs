using eCommerce_Mini_Project.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
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

        public void EnterBillingDetails(BillingDetails billingDetails) {
            FirstNameInput.Clear();
            FirstNameInput.SendKeys(billingDetails.FirstName);
            LastNameInput.Clear();
            LastNameInput.SendKeys(billingDetails.LastName);
            StreetNameInput.Clear();
            StreetNameInput.SendKeys(billingDetails.StreetName);
            CityInput.Clear();
            CityInput.SendKeys(billingDetails.City);
            PostcodeInput.Clear();
            PostcodeInput.SendKeys(billingDetails.Postcode);
            PhoneNumberInput.Clear();
            PhoneNumberInput.SendKeys(billingDetails.PhoneNumber);
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

        public void OrderRecieved() {
            WaitForElement(_driver, 5, By.XPath("//*[@id=\"post-6\"]/div/div/div/ul/li[1]"));
        }
        
    }
}
