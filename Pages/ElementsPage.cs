using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ST_Project.Pages
{
    public class ElementsPage : BasePage
    {
        public ElementsPage(IWebDriver driver) : base(driver) { }

        // Text Box Test
        public void TestTextBox()
        {
            var textBoxMenu = By.XPath("//span[contains(text(), 'Text Box')]");
            Wait.Until(d => d.FindElement(textBoxMenu)).Click();

            var fullNameInput = By.Id("userName");
            var emailInput = By.Id("userEmail");
            var currentAddressInput = By.Id("currentAddress");
            var permanentAddressInput = By.Id("permanentAddress");
            var submitButton = By.Id("submit");

            Driver.FindElement(fullNameInput).SendKeys("John Doe");
            Driver.FindElement(emailInput).SendKeys("johndoe@example.com");
            Driver.FindElement(currentAddressInput).SendKeys("123 Test Street");
            Driver.FindElement(permanentAddressInput).SendKeys("456 Permanent Avenue");

            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", Driver.FindElement(submitButton));
        }

        // Check Box Test
        public void TestCheckBox()
        {
            var checkBoxMenu = By.XPath("//span[contains(text(), 'Check Box')]");
            Wait.Until(d => d.FindElement(checkBoxMenu)).Click();

            var expandAllButton = By.XPath("//button[@title='Expand all']");
            Driver.FindElement(expandAllButton).Click();

            var homeCheckbox = By.XPath("//label[@for='tree-node-home']//span[@class='rct-checkbox']");
            Driver.FindElement(homeCheckbox).Click();
        }

        // Radio Button Test
        public void TestRadioButton()
        {
            var radioButtonMenu = By.XPath("//span[contains(text(), 'Radio Button')]");
            Wait.Until(d => d.FindElement(radioButtonMenu)).Click();

            var impressiveRadio = By.XPath("//label[@for='impressiveRadio']");
            Driver.FindElement(impressiveRadio).Click();
        }
    }
}