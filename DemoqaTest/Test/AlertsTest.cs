using DemoqaTest.Base;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Configuration;
using System.Threading;
using DemoqaTest.Utils;
using DemoqaTest.PageObject;
using DemoqaTest.FrameWork.PageObject.AlertsFrameWindows;
using DemoqaTest.Browse;

namespace DemoqaTest
{
    [TestFixture]
    public class AlertsTest : BaseTest
    {
        private MainPageObject _mainPage;
        private AlertPage _alertPage;
        private AlertUtil _alertUtil;


        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPageObject("MainPage");
            _mainPage.HomePageSectionsButton("Alerts, Frame & Windows").Click();

            _alertUtil = new AlertUtil("Alerts Util");
            _alertPage = new AlertPage("Alerts Page");
           
        }


        [Test]

        public void Test1()
        {
            _mainPage.IsMainPageOpen();
            _alertPage.GoToPage();
            
            //AlertsFrameWindowsPageObject.GroupButtonClick();
            Assert.IsTrue(_alertUtil.IsAlertPageOpen());
            _alertPage.AlertButtonClick();
            Wait.WaitGetAlert(Browser.GetDriver());
            Assert.AreEqual(_alertUtil.getText(),"You clicked a button","Alert no Open");
            _alertUtil.AlertAccept();
            Assert.IsTrue(_alertUtil.IsAlertClosed(),"Assert not closed");

            _alertPage.ConfirmAlertButtonClick();
            Wait.WaitGetAlert(Browser.GetDriver());
            Assert.AreEqual(_alertUtil.getText(), "Do you confirm action?", "Alert no Open");
            _alertUtil.AlertAccept();
            Assert.IsTrue(_alertUtil.IsAlertClosed(), "Assert not closed");
            _alertPage.GetConfirmResultClear();
            Assert.AreEqual(_alertPage.GetConfirmResult(), "You selected Ok", "Result not found");
            string ConfirmResult = _alertPage.GetConfirmResultClear();
            Assert.IsTrue(_alertPage.GetConfirmResultClear() == ConfirmResult,"Confirm result not equals");

            _alertPage.PromptBoxButtonClick();
            Wait.WaitGetAlert(Browser.GetDriver());
            Assert.AreEqual(_alertUtil.getText(), "Please enter your name", "Alert no Open");
            string randomText = _alertUtil.RandomText();
            _alertUtil.AlertSend(randomText);
            _alertUtil.AlertAccept();
            Assert.IsTrue(_alertUtil.IsAlertClosed(), "Assert not closed");
            _alertPage.GetPromptResult();
            Assert.IsTrue(_alertPage.GetPromptResult() == randomText, "Promt result not equals");
        }
    }
}