using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce_Mini_Project.Utilities {
    public static class HelperLibrary {
        public static void WaitForElement(IWebDriver driver, int timeoutInSeconds, By locator) {
            WebDriverWait myWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            myWait.Until(drv => drv.FindElement(locator).Displayed);
        }

        public static void WaitForElementClickable(IWebDriver driver, int timeoutInSeconds, By locator) {
            WebDriverWait myWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            
        }

        public static decimal toDecimal(string str) {
            return decimal.Parse(str, NumberStyles.Currency);
        }
    }
}
