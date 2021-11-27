using DemoqaTest.Base;
using DemoqaTest.BaseElement.elements;
using OpenQA.Selenium;
using DemoqaTest.Utils;
using DemoqaTest.FrameWork.TestData;


namespace DemoqaTest.PageObject
{
    public class AlertPage : AlertUtil
    {
       
        
        private readonly Button _alertButton = new Button(By.XPath("//*[@class ='col']/button[@id = 'alertButton']"), "AlertButton");
        private readonly Button _confirmAlertButton = new Button(By.XPath("//*[@class ='col']/button[@id = 'confirmButton']"), "ConfirmAlertButton");
        private readonly Button _promptBoxButton = new Button(By.XPath("//*[@class ='col']/button[@id = 'promtButton']"), "PromtButton");
        private readonly SpanPage _confirmResult = new SpanPage(By.XPath("//span[@id ='confirmResult']"), "ConfirmResult");
        private readonly SpanPage _promptResult = new SpanPage(By.XPath("//span[@id ='promptResult']"), "PromptResult");
        

        public AlertPage(string namePage): base(namePage)
        {
            FrameworkLogger.logger.Info($"Called ctor in BaseForm with params: Name Page - {namePage}");
        }

        
        public void AlertButtonClick()
        {
            _alertButton.Click();
            FrameworkLogger.logger.Info("alertButton Click");

        }
        public void ConfirmAlertButtonClick()
        {
            _confirmAlertButton.Click();
            FrameworkLogger.logger.Info("confirmAlertButton Click");
        }

        public void PromptBoxButtonClick()
        {
            _promptBoxButton.Click();
            FrameworkLogger.logger.Info("promptBoxButton Click");
        }
        public string GetConfirmResult()
        {
            return _confirmResult.GetText();

        }
        public string GetConfirmResultClear()
        {
            return _confirmResult.GetText().Remove(0, 12);
        }

        public string GetPromptResult()
        {
            return _promptResult.GetText().Remove(0, 12);
        }

        public void GoToPage()
        {
            FrameworkLogger.logger.Info($"Called GoToPage() method in JSAlertPage");

            Browse.Browser.GetDriver().Navigate().GoToUrl(ConfigManager.MainUrl+"alerts");
        }
    }
}
