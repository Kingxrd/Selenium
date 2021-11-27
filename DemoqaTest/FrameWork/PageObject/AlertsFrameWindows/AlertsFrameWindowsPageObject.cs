using DemoqaTest.Base;
using DemoqaTest.BaseElement.elements;
using DemoqaTest.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoqaTest.FrameWork.PageObject.AlertsFrameWindows
{
    public class AlertsFrameWindowsPageObject
    {
        private static Label _uniqueElement = new Label(By.XPath("//div[@class='main-header'][text()='Alerts, Frame & Windows']"), "Browser Windows Label");
        private static Button _groupButton = new Button(By.XPath("//span[text()='Alerts']"), "Alerts Button");
        public static Button BrowserWindowButton => new Button(By.XPath("//span[text()='Browser Windows']"), "BrowserWindowButton");
        public static void GroupButtonClick()
        {
            _groupButton.Click();
            FrameworkLogger.logger.Info("groupButton Click");
        }
        public static bool IsAlertWindowPageOpen()
        {
            FrameworkLogger.logger.Info("Check uniq element on Page");
            Base.BaseElement uniqueElement = _uniqueElement;
            return uniqueElement.IsDisplayed();
        }
    }
}
