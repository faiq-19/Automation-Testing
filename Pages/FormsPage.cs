using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace ST_Project.Pages
{
    public class FormsPage : BasePage
    {
        public FormsPage(IWebDriver driver) : base(driver) { }

        // Practice Form Test
        public void TestPracticeForm()
        {
            RemoveAdOverlays();

            var practiceFormMenu = By.XPath("//span[contains(text(), 'Practice Form')]");
            Wait.Until(d => d.FindElement(practiceFormMenu)).Click();

            // Personal Information
            Driver.FindElement(By.Id("firstName")).SendKeys("John");
            Driver.FindElement(By.Id("lastName")).SendKeys("Doe");
            Driver.FindElement(By.Id("userEmail")).SendKeys("johndoe@example.com");

            // Gender - Use JavaScript Click with additional handling
            var maleGenderRadio = By.XPath("//label[@for='gender-radio-1']");
            var maleGenderInput = By.Id("gender-radio-1");

            // Method 1: JavaScript Click
            var radioElement = Driver.FindElement(maleGenderRadio);
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", radioElement);

            // Alternative Method 2: If JavaScript click fails
            if (!IsElementSelected(maleGenderInput))
            {
                try
                {
                    // Scroll into view first
                    var element = Driver.FindElement(maleGenderRadio);
                    ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);

                    // Try clicking the input directly
                    Driver.FindElement(maleGenderInput).Click();
                }
                catch
                {
                    // Last resort: use Actions class
                    var actions = new OpenQA.Selenium.Interactions.Actions(Driver);
                    actions.MoveToElement(Driver.FindElement(maleGenderRadio)).Click().Perform();
                }
            }

            // Mobile Number
            Driver.FindElement(By.Id("userNumber")).SendKeys("1234567890");

            // Date of Birth
            Driver.FindElement(By.Id("dateOfBirthInput")).Click();
            var monthDropdown = By.XPath("//select[@class='react-datepicker__month-select']");
            var yearDropdown = By.XPath("//select[@class='react-datepicker__year-select']");

            var selectMonth = new SelectElement(Driver.FindElement(monthDropdown));
            selectMonth.SelectByValue("5"); // June

            var selectYear = new SelectElement(Driver.FindElement(yearDropdown));
            selectYear.SelectByValue("1990");

            var dateSelect = By.XPath("//div[@class='react-datepicker__day react-datepicker__day--015']");
            Driver.FindElement(dateSelect).Click();

            // Subjects (uses autocomplete)
            var subjectInput = By.Id("subjectsInput");
            Driver.FindElement(subjectInput).SendKeys("Computer Science");
            Driver.FindElement(subjectInput).SendKeys(Keys.Enter);

            // Hobbies
            var sportsHobby = By.XPath("//label[@for='hobbies-checkbox-1']");
            Driver.FindElement(sportsHobby).Click();

            // Submit
            var submitButton = By.Id("submit");
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", Driver.FindElement(submitButton));
        }
        private void RemoveAdOverlays()
        {
            try
            {
                // Remove iframes that might be blocking interactions
                var script = @"
                var iframes = document.querySelectorAll('iframe');
                iframes.forEach(iframe => {
                    if (iframe.id.includes('ad') || iframe.src.includes('ad')) {
                        iframe.remove();
                    }
                });
                
                // Remove any fixed position elements that might be overlays
                var overlays = document.querySelectorAll('[style*=""position: fixed""]');
                overlays.forEach(overlay => {
                    if (overlay.id.includes('ad') || overlay.className.includes('ad')) {
                        overlay.remove();
                    }
                });
            ";

                ((IJavaScriptExecutor)Driver).ExecuteScript(script);
            }
            catch
            {
                // Ignore if removal fails
            }
        }

        // Utility method to check if element is selected
        private bool IsElementSelected(By locator)
        {
            try
            {
                return Driver.FindElement(locator).Selected;
            }
            catch
            {
                return false;
            }
        }
    }
}