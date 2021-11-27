using DemoqaTest.Base;
using DemoqaTest.BaseElement.elements;
using DemoqaTest.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoqaTest.FrameWork.PageObject.ProgressBarPage
{
    public class ProgressBarPageObject : Base.BaseForm
    {
        
        private static Label _uniqueElement = new Label(By.XPath("//div[@class='main-header'][text()='Progress Bar']"), "ProgressBar Page Label");
        public ProgressBarPageObject(string namePage) : base(_uniqueElement, namePage)
        {
            FrameworkLogger.logger.Info($"Called ctor in BaseForm with params: Name Page - {namePage}");
        }
        public Button ProgressBarButton => new Button(By.XPath("//span[text()='Progress Bar']"), "ProgressBar Button");
        public Label ProgressBarLabel => new Label(By.XPath("//div[@id='progressBar']/div[@role='progressbar']"), "ProgressBarLabel");
        public Button AdCloseButton => new Button(By.XPath("//a[@id='close-fixedban']"), "AdCloseButton close Button");
        public Button StratStopButton => new Button(By.XPath("//button[@id='startStopButton']"), "startStopButton");
        public void ProgressBarButtonClick()
        {
            ProgressBarButton.Click();
            FrameworkLogger.logger.Info("alertButton Click");

        }
        private WebDriverWait Waits()
        {
            return new WebDriverWait(Browse.Browser.GetDriver(), TimeSpan.FromSeconds(20));
        }

        public void ScrollToElementProgressBarButton()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Browse.Browser.GetDriver();
            js.ExecuteScript("arguments[0].scrollIntoView();",Browse.Browser.GetDriver().FindElement(By.XPath("//span[text()='Progress Bar']")));
        }
        public void ScrollToElementStartStopButton()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)Browse.Browser.GetDriver();
            js.ExecuteScript("arguments[0].scrollIntoView();", Browse.Browser.GetDriver().FindElement(By.XPath("//div[@class='main-header'][text()='Progress Bar']")));
        }
        public bool IsProgressBbarPageOpen()
        {
            FrameworkLogger.logger.Info("Check uniq element on Page");
            Base.BaseElement uniqueElement = _uniqueElement;
            return uniqueElement.IsDisplayed();
        }

        // Assert.True(wasActivated, "The progress bar was not activated.");


        public void StopProgressBarOnSpecificPercent(string a)
        {

            int i = 1;
            while (i == 1)
            {
                string b = ProgressBarLabel.GetText();
                if (a.Equals(b))
                {
                    ProgressBarButton.Click();
                    i++;
                }
            }
        }
    }
}
