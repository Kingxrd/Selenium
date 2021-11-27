using OpenQA.Selenium;
using DemoqaTest.Browse;
using DemoqaTest.BaseElement.elements;
using DemoqaTest.Utils;


namespace DemoqaTest.PageObject 
{
    public class MainPageObject : Base.BaseForm
    {
        public static Label _uniqueElement = new Label(By.XPath("//div[@class='home-banner']"), "Main Page Label");
        public MainPageObject(string namePage):base(_uniqueElement,namePage)
        {
            FrameworkLogger.logger.Info($"Called ctor in BaseForm with params: Name Page - {namePage}");
        }
        public IWebElement HomePageSectionsButton(string sectionName) =>
        Browser.GetDriver().FindElement(By.XPath($"//*[normalize-space(text())='{sectionName}']/ancestor::div[contains(@class, 'top-card')]"));
        public bool IsMainPageOpen()
        {
            FrameworkLogger.logger.Info("Check uniq element on Page");
            Base.BaseElement uniqueElement = _uniqueElement;
            return uniqueElement.IsDisplayed();
        }
    }
}

