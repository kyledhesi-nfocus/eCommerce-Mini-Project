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

        public IWebElement UsernameField => _driver.FindElement(By.Id("username"));
        public IWebElement PasswordField => _driver.FindElement(By.Id("password"));
        public IWebElement LoginButton => _driver.FindElement(By.CssSelector("#customer_login > div.u-column1.col-1 > form > p:nth-child(3) > button"));
        public IWebElement Dismiss => _driver.FindElement(By.ClassName("woocommerce-store-notice__dismiss-link"));

        public void LoginToAccount(string username, string password) {
            UsernameField.Clear();
            UsernameField.Click();
            UsernameField.SendKeys(username);

            PasswordField.Clear();
            PasswordField.Click();
            PasswordField.SendKeys(password);
        }

        public void ClickLoginButton() {
            Dismiss.Click();
            LoginButton.Click();
        }
    }
}