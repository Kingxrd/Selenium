using DemoqaTest.Base;
using DemoqaTest.BaseElement.elements;
using DemoqaTest.Browse;
using DemoqaTest.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoqaTest.FrameWork.PageObject.Browser_windows
{
    public class LinksPageObject : BaseForm
    {
        private static Label _uniqueElement = new Label(By.XPath("//div[@class='main-header'][text()='Links']"), "Links Label");
        private Label _uniqueElementMainPage = new Label(By.XPath("//div[@class='main-header'][text()='Links']"), "Links Label");
        public LinksPageObject(string namePage):base(_uniqueElement, namePage)
        {
            FrameworkLogger.logger.Info($"Called ctor in BaseForm with params: Name Page - {namePage}");
        }

        public bool IsMainPageOpen()
        {
            FrameworkLogger.logger.Info("Check uniq element on Page");
            Base.BaseElement uniqueElement = _uniqueElementMainPage;
            return uniqueElement.IsDisplayed();
        }


        public IWebElement HomeLink => Browser.GetDriver().FindElement(By.XPath("//a[@id='simpleLink']"));
        public bool IsLinksPageOpen()
        {
            FrameworkLogger.logger.Info("Check uniq element on Page");
            Base.BaseElement uniqueElement = _uniqueElement;
            return uniqueElement.IsDisplayed();
        }
        public string Maintab()
        {
            FrameworkLogger.logger.Info("Window Get");
            return Browser.GetDriver().CurrentWindowHandle;
        }
        public void ReturnMain(string maintab)
        {
            FrameworkLogger.logger.Info("Window Switch");
            Browser.GetDriver().SwitchTo().Window(maintab);
        }

    }
}
