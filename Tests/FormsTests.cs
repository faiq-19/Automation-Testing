using NUnit.Framework;
using OpenQA.Selenium;
using ST_Project.Pages;

namespace ST_Project.Tests
{
    [TestFixture]
    public class FormsTests
    {
        private IWebDriver _driver;
        private FormsPage _formsPage;

        [SetUp]
        public void Setup()
        {
            _driver = Utilities.BrowserSetup.InitializeDriver();
            _formsPage = new FormsPage(_driver);
            _formsPage.NavigateTo("https://demoqa.com/forms");
        }

        [Test]
        public void TestPracticeForm()
        {
            _formsPage.TestPracticeForm();
        }

        [TearDown]
        public void Cleanup()
        {
            _driver.Quit();
        }
    }
}