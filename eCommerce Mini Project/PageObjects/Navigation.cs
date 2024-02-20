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
        public IWebElement homeLink => _driver.FindElement(By.LinkText("Home"));
        public IWebElement shopLink => _driver.FindElement(By.LinkText("Shop"));
        public IWebElement cartLink => _driver.FindElement(By.LinkText("Cart"));

        public IWebElement checkoutLink => _driver.FindElement(By.LinkText("Checkout"));
        public IWebElement myAccountLink => _driver.FindElement(By.LinkText("My account"));
        public IWebElement blogLink => _driver.FindElement(By.LinkText("Blog"));
        public void clickLink(string link) {
            WaitForElement(_driver, 5, By.LinkText(link));
            
            if (link == "Home") {
                homeLink.Click();
            } else if (link == "Shop") {   
                shopLink.Click();
            } else if (link == "Cart") {
                cartLink.Click();
            } else if (link == "Checkout") {
                checkoutLink.Click();
            } else if (link == "My account") {
                myAccountLink.Click();
            } else if (link == "Blog") {
                blogLink.Click();
            }
        }

    }
}

