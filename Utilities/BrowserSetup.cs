using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace ST_Project.Utilities
{
    public class BrowserSetup
    {
        public static IWebDriver InitializeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-ads");
            options.AddArgument("--disable-popup-blocking");
            return new ChromeDriver(options);
        }

        public static WebDriverWait CreateWait(IWebDriver driver, int timeoutSeconds = 10)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutSeconds));
        }
    }
}