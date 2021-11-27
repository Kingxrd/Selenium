using DemoqaTest.Base;
using DemoqaTest.Browse;
using DemoqaTest.FrameWork.PageObject.AlertsFrameWindows;
using DemoqaTest.FrameWork.PageObject.Browser_windows;
using DemoqaTest.FrameWork.TestData;
using DemoqaTest.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading.Tasks;

namespace DemoqaTest.Test
{
    [TestFixture]
    public class BrowserWindowTest : BaseTest
    {
        private MainPageObject _mainPage;
        private string maintab;
        private BrowserWindowPageObject _browserWindowPage;
        private LinksPageObject _linksPage;

        [SetUp]
        public void SetUp()
        {

            _mainPage = new MainPageObject("MainPage");
            _mainPage.HomePageSectionsButton("Alerts, Frame & Windows").Click();
            _browserWindowPage = new BrowserWindowPageObject("BrowserWindowPage");
            _linksPage = new LinksPageObject("LinksPage");
        }


        [Test]

        public void Test1()
        {
            _mainPage.IsMainPageOpen();
            AlertsFrameWindowsPageObject.BrowserWindowButton.Click();
            Assert.IsTrue(_browserWindowPage.IsBrowserWindowPageOpen());
            maintab = _browserWindowPage.Maintab();
            _browserWindowPage.ClickButton_NewTab();
            Assert.AreEqual(_browserWindowPage.CheckNewTab(), "This is a sample page", "New tab not open");
            _browserWindowPage.ReturnMain(maintab);
            Assert.IsTrue(_browserWindowPage.IsBrowserWindowPageOpen());
            _browserWindowPage.ElementsButton.Click();
            Wait.WaitElement(Browser.GetDriver(), _browserWindowPage._links);
            _browserWindowPage.LinksButton.Click();
            maintab = _linksPage.Maintab();
            Assert.IsTrue(_linksPage.IsLinksPageOpen());
            _linksPage.HomeLink.Click();
            Assert.IsTrue(_linksPage.IsMainPageOpen());
            _linksPage.ReturnMain(maintab);
        }
    }
}
