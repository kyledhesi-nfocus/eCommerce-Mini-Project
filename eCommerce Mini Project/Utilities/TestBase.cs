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

            string browser = Environment.GetEnvironmentVariable("BROWSER");
            
            Console.WriteLine("Browser set to: " + browser);

            if (browser == null) {
                browser = "firefox";
                Console.WriteLine("Browser environment not set: Setting to Firefox");
            }

            switch (browser) {
                case "edge":
                    driver = new EdgeDriver();
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
            }

            string startUrl = TestContext.Parameters["WebAppURL"];
            driver.Url = startUrl;

            LoginMyAccount loginMyAccount = new LoginMyAccount(driver);

            string username = Environment.GetEnvironmentVariable("SECRET_USERNAME");
            string password = Environment.GetEnvironmentVariable("SECRET_PASSWORD");
            loginMyAccount.LoginToAccount(username, password);
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