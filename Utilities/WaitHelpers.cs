using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace ST_Project.Utilities
{
    public class WaitHelpers
    {
        public static IWebElement WaitAndFindElement(WebDriverWait wait, By locator)
        {
            return wait.Until(driver => driver.FindElement(locator));
        }

        public static bool WaitForElementToBeClickable(WebDriverWait wait, By locator)
        {
            return wait.Until(driver =>
            {
                try
                {
                    var element = driver.FindElement(locator);
                    return element.Enabled && element.Displayed;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }
    }
}