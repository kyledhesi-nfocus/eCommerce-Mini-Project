using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static eCommerce_Mini_Project.Utilities.HelperLibrary;

namespace eCommerce_Mini_Project.PageObjects {
    internal class MyAccount {

        private IWebDriver _driver;

        public MyAccount(IWebDriver driver) {
            this._driver = driver;
        }

        public IWebElement logoutLink => _driver.FindElement(By.LinkText("Logout"));
        public IWebElement ordersLink => _driver.FindElement(By.LinkText("Orders"));

        public string orderNumber => _driver.FindElement(By.XPath("//*[@id=\"post-7\"]/div/div/div/table/tbody/tr[1]/td[1]/a")).Text;

        public void logout() {
            WaitForElement(_driver, 5, By.LinkText("Logout"));
            logoutLink.Click();
        }

        public void viewOrders() {
            ordersLink.Click();
        }

        public string getOrderNumber() {
            WaitForElement(_driver, 5, By.XPath("//*[@id=\"post-7\"]/div/div/div/table/tbody/tr[1]/td[1]/a"));
            return orderNumber;
        }
    }
}
