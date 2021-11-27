using DemoqaTest.BaseElement.elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using DemoqaTest.Browse;
namespace DemoqaTest.Base
{
    public abstract class BaseForm
    {

        private BaseElement _uniqueElement;
        private string _namePage;

        public BaseForm(BaseElement element, string namePage)
        {
            _uniqueElement = element;
            _namePage = namePage;
        } 

        public bool IsDisplayed()
        {
            return _uniqueElement.IsDisplayed();
        }
    }
}
