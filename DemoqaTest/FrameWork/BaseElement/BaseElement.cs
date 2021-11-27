using DemoqaTest.Browse;
using DemoqaTest.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;


namespace DemoqaTest.Base
{
    public abstract class BaseElement 
    {
        private readonly By _locator;
        private readonly string Name;
        protected BaseElement(By locator, string name = "")
        {
            _locator = locator;
            Name = name;

        }

        protected IWebElement FindElement()
        {
            FrameworkLogger.logger.Info("BaseElementCreateMethod");
            return Browser.GetDriver().FindElement(_locator);
        }

        protected IList<IWebElement> FindElements()
        {
            FrameworkLogger.logger.Info("BaseElementCreateMethod");
            return Browser.GetDriver().FindElements(_locator);
        }

        public bool IsDisplayed()
        {
            FrameworkLogger.logger.Info("BaseElementCreateMethod");
            return FindElements().Count > 0;
        }
        public string GetText()
        {
            FrameworkLogger.logger.Info("BaseElementCreateMethod");
            return FindElement().Text;
        }
        public void Clear()
        {
            FrameworkLogger.logger.Info("BaseElementCreateMethod");
            Clear();
        }
        
        public void Click()
        {
            FrameworkLogger.logger.Info("BaseElementCreateMethod");
            FindElement().Click();
        }

        public void SendKeys(string text)
        {
            FrameworkLogger.logger.Info("BaseElementCreateMethod");
            FindElement().SendKeys(text);
        }

        public void Submit()
        {
            FrameworkLogger.logger.Info("BaseElementCreateMethod");
            Submit();
        }

        
    }
}
