using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce_Mini_Project.PageObjects {
    internal class MyAccount {

        private IWebDriver _driver;

        public MyAccount(IWebDriver driver) {
            this._driver = driver;
        }

        public IWebElement logoutLink => _driver.FindElement(By.LinkText("Log out"));

        public void logout() {
            logoutLink.Click();
        }
    }
}
