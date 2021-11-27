using System;
using System.Collections.ObjectModel;
using DemoqaTest.Browse;
using OpenQA.Selenium;
using DemoqaTest.Base;
using DemoqaTest.BaseElement.elements;
using DemoqaTest.Utils;


namespace DemoqaTest.FrameWork.PageObject.Browser_windows
{
    public class BrowserWindowPageObject : BaseForm
    {
        private static Label _uniqueElement = new Label(By.XPath("//div[@class='main-header'][text()='Browser Windows']"), "Browser Windows Label");

        public BrowserWindowPageObject(string namePage) : base(_uniqueElement, namePage)
        {
            FrameworkLogger.logger.Info($"Called ctor in BaseForm with params: Name Page - {namePage}");
        }
        public bool IsBrowserWindowPageOpen()
        {
            FrameworkLogger.logger.Info("Check uniq element on Page");
            Base.BaseElement uniqueElement = _uniqueElement;
            return uniqueElement.IsDisplayed();
        }
        
        
        public Button ElementsButton => new Button(By.XPath("//div[text()='Elements']"), "ElementsButton");
        public readonly By _links = By.XPath("//span[text()='Links']/ancestor::li[@id='item-5']");
        public Button LinksButton => new Button(_links, "LinksButton");
        public string Maintab()
        {
            FrameworkLogger.logger.Info("Window Get");
            return Browser.GetDriver().CurrentWindowHandle;
        }
        public void ClickButton_NewTab()
        {
            Browser.GetDriver().FindElement(By.Id("tabButton")).Click();
            ReadOnlyCollection<string> allTabs = Browser.GetDriver().WindowHandles;
            var createdTab = Browser.GetDriver().SwitchTo().Window(allTabs[1]);
            FrameworkLogger.logger.Info("Click NewTabButton");


        }
        public string CheckNewTab()
        {
            FrameworkLogger.logger.Info("Check element on page");
            return Browser.GetDriver().FindElement(By.Id("sampleHeading")).Text;
        }
        
        public void ReturnMain(string maintab)
        {
            Browser.GetDriver().SwitchTo().Window(maintab);
            FrameworkLogger.logger.Info("Browser switch");
        }
        
    }
}
