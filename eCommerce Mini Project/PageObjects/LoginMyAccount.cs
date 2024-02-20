using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce_Mini_Project.PageObjects {
    class LoginMyAccount {

        private IWebDriver _driver;

        public LoginMyAccount(IWebDriver driver) {
            this._driver = driver;
        }

        public IWebElement usernameField => _driver.FindElement(By.Id("username"));
        public IWebElement passwordField => _driver.FindElement(By.Id("password"));
        public IWebElement loginButton => _driver.FindElement(By.CssSelector("#customer_login > div.u-column1.col-1 > form > p:nth-child(3) > button"));
        public IWebElement dismiss => _driver.FindElement(By.ClassName("woocommerce-store-notice__dismiss-link"));

        public void LoginToAccount(string username, string password) {
            usernameField.Clear();
            usernameField.Click();
            usernameField.SendKeys(username);

            passwordField.Clear();
            passwordField.Click();
            passwordField.SendKeys(password);
        }

        public void ClickLoginButton() {
            dismiss.Click();
            loginButton.Click();
        }
    }
}