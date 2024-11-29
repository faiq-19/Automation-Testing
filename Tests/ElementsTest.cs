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
            _elementsPage.TestTextBoxInput("John Doe", "johndoe@example.com", "123 Test Street", "456 Permanent Avenue");
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

        [Test]
        public void TestWebTables()
        {
            _elementsPage.TestWebTables_AddEntry("John", "Doe", "johndoe@example.com", 30, 50000, "IT");
        }

        [Test]
        public void TestButtons()
        {
            _elementsPage.TestButtons();
        }

        [Test]
        public void TestLinks()
        {
            _elementsPage.TestLinks();
        }

        [Test]
        public void TestBrokenLinksImages()
        {
            _elementsPage.TestBrokenLinksImages();
        }

        [Test]
        public void TestUploadAndDownload()
        {
            string filePath = @"F:\Study\ST\ST_Project\Assets\testfile.txt";
            _elementsPage.TestUploadAndDownload(filePath);
        }

        [Test]
        public void TestDynamicProperties()
        {
            _elementsPage.TestDynamicProperties();
        }

        [TearDown]
        public void Cleanup()
        {
            _driver.Quit();
        }
    }
}
