using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Edge;
using eCommerce_Mini_Project.PageObjects;
using OpenQA.Selenium.Firefox;

namespace eCommerce_Mini_Project.Utilities {
    public class TestBase {
#pragma warning disable NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method
        protected IWebDriver driver;
#pragma warning restore NUnit1032 // An IDisposable field/property should be Disposed in a TearDown method

        [SetUp]
        public void Setup() { 

            String browserType = "Firefox";
            switch (browserType) {
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;
                case "Edge":
                    driver = new EdgeDriver();
                    break;
            }
            
            driver.Url = "https://www.edgewordstraining.co.uk/demo-site/my-account/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
            LoginMyAccount loginMyAccount = new LoginMyAccount(driver);
            loginMyAccount.LoginToAccount("kyle123@nfocus.co.uk", "Password1234567!");
            loginMyAccount.ClickLoginButton();

            Console.WriteLine("Successfully logged in - Begin Test!");
        }

        [TearDown]
        public void Teardown() {
            MyAccount myAccount = new(driver);
            myAccount.Logout();

            Thread.Sleep(2000);
            driver.Quit();
            Console.WriteLine("Successfully logged out - Test complete!");
        }
    }
}