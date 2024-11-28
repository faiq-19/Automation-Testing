using NUnit.Framework;
using OpenQA.Selenium;
using ST_Project.Pages;

namespace ST_Project.Tests
{
    [TestFixture]
    public class ElementsTests
    {
        private IWebDriver _driver;
        private ElementsPage _elementsPage;

        [SetUp]
        public void Setup()
        {
            _driver = Utilities.BrowserSetup.InitializeDriver();
            _elementsPage = new ElementsPage(_driver);
            _elementsPage.NavigateTo("https://demoqa.com/elements");
        }

        [Test]
        public void TestTextBox()
        {
            _elementsPage.TestTextBox();
        }

        [Test]
        public void TestCheckBox()
        {
            _elementsPage.TestCheckBox();
        }

        [Test]
        public void TestRadioButton()
        {
            _elementsPage.TestRadioButton();
        }

        [TearDown]
        public void Cleanup()
        {
            _driver.Quit();
        }
    }
}