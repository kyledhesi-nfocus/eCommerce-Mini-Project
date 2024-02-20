using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static eCommerce_Mini_Project.Utilities.HelperLibrary;

namespace eCommerce_Mini_Project.PageObjects {
    internal class Navigation {

        private IWebDriver _driver;

        public Navigation(IWebDriver driver) {
            this._driver = driver;
        }
        public IWebElement HomeLink => _driver.FindElement(By.LinkText("Home"));
        public IWebElement ShopLink => _driver.FindElement(By.LinkText("Shop"));
        public IWebElement CartLink => _driver.FindElement(By.LinkText("Cart"));
        public IWebElement CheckoutLink => _driver.FindElement(By.LinkText("Checkout"));
        public IWebElement MyAccountLink => _driver.FindElement(By.LinkText("My account"));
        public IWebElement BlogLink => _driver.FindElement(By.LinkText("Blog"));
        
        public void ClickLink(string link) {
            Thread.Sleep(1000);

            WaitForElement(_driver, 5, By.LinkText(link));
            if (link == "Home") {
                HomeLink.Click();
            } else if (link == "Shop") {   
                ShopLink.Click();
            } else if (link == "Cart") {
                CartLink.Click();
            } else if (link == "Checkout") {
                CheckoutLink.Click();
            } else if (link == "My account") {
                MyAccountLink.Click();
            } else if (link == "Blog") {
                BlogLink.Click();
            }
        }

    }
}

