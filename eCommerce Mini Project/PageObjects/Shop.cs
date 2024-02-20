using eCommerce_Mini_Project.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static eCommerce_Mini_Project.Utilities.HelperLibrary;


namespace eCommerce_Mini_Project.PageObjects {
    internal class Shop {

        private IWebDriver _driver;

        public Shop(IWebDriver driver) {
            this._driver = driver;
        }
        public IWebElement AddItemToCart => _driver.FindElement(By.XPath("//*[@id=\"main\"]/ul/li[2]/a[2]"));
        
        public void AddToCart() {
            WaitForElement(_driver, 5, By.XPath("//*[@id=\"main\"]/ul/li[2]/a[2]"));
            AddItemToCart.Click();
            
        }
    }
}
