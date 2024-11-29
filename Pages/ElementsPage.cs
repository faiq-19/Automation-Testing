using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace ST_Project.Pages
{
    public class ElementsPage : BasePage
    {
        public ElementsPage(IWebDriver driver) : base(driver) { }

        // Expanded Text Box Tests
        public void TestTextBoxInput(string name, string email, string currentAddress, string permanentAddress)
        {
            var textBoxMenu = By.XPath("//span[contains(text(), 'Text Box')]");
            Wait.Until(d => d.FindElement(textBoxMenu)).Click();

            Driver.FindElement(By.Id("userName")).SendKeys(name);
            Driver.FindElement(By.Id("userEmail")).SendKeys(email);
            Driver.FindElement(By.Id("currentAddress")).SendKeys(currentAddress);
            Driver.FindElement(By.Id("permanentAddress")).SendKeys(permanentAddress);

            Driver.FindElement(By.Id("submit")).Click();
        }

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

        // WebTables Tests
        public void TestWebTables_AddEntry(string firstName, string lastName, string email, int age, int salary, string department)
        {
            var webTablesMenu = By.XPath("//span[contains(text(), 'Web Tables')]");
            Wait.Until(d => d.FindElement(webTablesMenu)).Click();

            var addButton = By.Id("addNewRecordButton");
            Driver.FindElement(addButton).Click();

            Driver.FindElement(By.Id("firstName")).SendKeys(firstName);
            Driver.FindElement(By.Id("lastName")).SendKeys(lastName);
            Driver.FindElement(By.Id("userEmail")).SendKeys(email);
            Driver.FindElement(By.Id("age")).SendKeys(age.ToString());
            Driver.FindElement(By.Id("salary")).SendKeys(salary.ToString());
            Driver.FindElement(By.Id("department")).SendKeys(department);
            Driver.FindElement(By.Id("submit")).Click();
        }

        // Buttons Tests
        public void TestButtons()
        {
            var buttonsMenu = By.XPath("//span[contains(text(), 'Buttons')]");
            Wait.Until(d => d.FindElement(buttonsMenu)).Click();

            Actions Action = new Actions(Driver);

            // Double click
            var doubleClickButton = By.Id("doubleClickBtn");
            Action.DoubleClick(Driver.FindElement(doubleClickButton)).Perform();

            // Right click
            var rightClickButton = By.Id("rightClickBtn");
            Action.ContextClick(Driver.FindElement(rightClickButton)).Perform();

            // Click me
            var clickMeButton = By.XPath("//button[text()='Click Me']");
            Driver.FindElement(clickMeButton).Click();
        }

        // Links Tests
        public void TestLinks()
        {
            var linksMenu = By.XPath("//span[contains(text(), 'Links')]");
            Wait.Until(d => d.FindElement(linksMenu)).Click();

            // Test each link
            Driver.FindElement(By.Id("simpleLink")).Click();
            Driver.FindElement(By.Id("dynamicLink")).Click();
        }

        // Broken Links/Images Tests
        public void TestBrokenLinksImages()
        {
            // Navigate to the "Broken Links - Images" page
            var brokenLinksMenu = Driver.FindElement(By.XPath("//span[contains(text(), 'Broken Links - Images')]"));
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", brokenLinksMenu);
            brokenLinksMenu.Click();

            // Verify Valid Image
            var validImage = Driver.FindElement(By.XPath("//img[@src='/images/Toolsqa.jpg']"));
            Assert.That(validImage.Displayed, Is.True, "Valid image is not displayed.");

            // Verify Broken Image
            var brokenImage = Driver.FindElement(By.XPath("//img[@src='/images/Toolsqa_1.jpg']"));
            Assert.That(brokenImage.GetAttribute("naturalWidth"), Is.EqualTo("0"), "Broken image is not broken.");

            // Verify Valid Link
            var validLink = Driver.FindElement(By.XPath("//a[text()='Click Here for Valid Link']"));
            validLink.Click();
            Assert.That(Driver.Url, Is.EqualTo("https://demoqa.com/"), "Valid link did not redirect correctly.");
            Driver.Navigate().Back();

            // Verify Broken Link
            var brokenLink = Driver.FindElement(By.XPath("//a[text()='Click Here for Broken Link']"));
            brokenLink.Click();
            Assert.That(Driver.Url, Is.EqualTo("https://the-internet.herokuapp.com/status_codes/500"), "Broken link did not lead to a 404 page.");
            Driver.Navigate().Back();
        }


        // Upload and Download Tests
        public void TestUploadAndDownload(string filePath)
        {
            var uploadDownloadMenu = By.XPath("//span[contains(text(), 'Upload and Download')]");
            Wait.Until(d => d.FindElement(uploadDownloadMenu)).Click();

            // File upload
            var uploadInput = By.Id("uploadFile");
            Driver.FindElement(uploadInput).SendKeys(filePath);

            // File download
            Driver.FindElement(By.Id("downloadButton")).Click();
        }

        // Dynamic Properties Tests
        public void TestDynamicProperties()
        {
            var dynamicPropertiesMenu = By.XPath("//span[contains(text(), 'Dynamic Properties')]");
            Wait.Until(d => d.FindElement(dynamicPropertiesMenu)).Click();

            // Wait for color change
            var colorChangeButton = Driver.FindElement(By.Id("colorChange"));
            Wait.Until(d => colorChangeButton.GetCssValue("color") != "rgba(255, 0, 0, 1)");

            // Wait for button to be enabled
            var enableButton = Driver.FindElement(By.Id("enableAfter"));
            Wait.Until(d => enableButton.Enabled);
        }
    }
}
