using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;
using System.Runtime.CompilerServices;
using static eCommerce_Mini_Project.Utilities.HelperLibrary;

namespace eCommerce_Mini_Project.Utilities {
    public static class HelperLibrary {
        public static void WaitForElement(IWebDriver driver, int timeoutInSeconds, By locator) {
            WebDriverWait myWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            myWait.Until(drv => drv.FindElement(locator).Displayed);
        }

        public static bool WaitForElementDisabled(IWebDriver driver, int timeoutInSeconds, By locator) {
            WebDriverWait myWait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            try {
                return myWait.Until(drv => {
                    try {
                        var element = drv.FindElement(locator);
                        return !element.Enabled; // Return true if element is disabled
                    } catch (NoSuchElementException) {
                        return true;
                    } catch (StaleElementReferenceException) {
                        return true;
                    }
                });
            } catch (WebDriverTimeoutException) {
                return false;
            }
        }


        public static decimal toDecimal(string str) {
            return decimal.Parse(str, NumberStyles.Currency);
        }

        public static void takeScreenshot(IWebDriver driver, string screenshotName) {
            ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            screenshot.SaveAsFile(@"C:\Users\KyleDhesi\source\repos\eCommerce Mini Project\eCommerce Mini Project\" + screenshotName);
        }
    }
}
