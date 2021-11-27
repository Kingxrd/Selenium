using DemoqaTest.Base;
using DemoqaTest.BaseElement.elements;
using DemoqaTest.Browse;
using DemoqaTest.Test;
using DemoqaTest.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoqaTest.FrameWork.PageObject.SliderPage
{
    public  class SliderPageObject : Base.BaseForm
    {
        private static Label _uniqueElement = new Label(By.XPath("//div[@class='main-header'][text()='Slider']"), "Slider Page Label");
        private SliderTest sliderTest = new SliderTest();
        private int _sliderValue;
        public SliderPageObject(string namePage) : base(_uniqueElement, namePage)
        {
             FrameworkLogger.logger.Info($"Called ctor in BaseForm with params: Name Page - {namePage}");
        }

        public Button SliderButton => new Button(By.XPath("//span[text()='Slider']"), "Slider Button");
        public Button AdCloseButton => new Button(By.XPath("//a[@id='close-fixedban']"), "AdCloseButton close Button");
        public IWebElement SliderValue => Browser.GetDriver().FindElement(By.XPath("//input[@id='sliderValue']"));
        public void SliderButtonClick()
        {
            SliderButton.Click();
            FrameworkLogger.logger.Info("slider Button Click");

        }
        public int SliderValueInt()
        {
            var slider = Browser.GetDriver().FindElement(By.ClassName("form-control")); 
            return Convert.ToInt32(slider.GetAttribute("value"));
        }
        public int Increase_Slider(int randomInt)
        {

            //Find the slide and create an instance of Actions.
            var slider = Browse.Browser.GetDriver().FindElement(By.ClassName("range-slider"));
            Actions action = new Actions(Browse.Browser.GetDriver());

            //Increase the slider.
            action.ClickAndHold(slider);
            action.MoveByOffset(randomInt, 0);
            action.Release();
            action.Perform();

            //Validate that sliders value increased.
            return _sliderValue = Convert.ToInt32(slider.GetAttribute("value"));
          
        }
        public bool IsSliderPageOpen()
        {
            FrameworkLogger.logger.Info("Check uniq element on Page");
            Base.BaseElement uniqueElement = _uniqueElement;
            return uniqueElement.IsDisplayed();
        }
        public int RandomText()
        {
            Random rnd = new Random();
            int randomInt = 0;
            for (int i = 0; i < 5; i++)
            {
                 randomInt = rnd.Next(0, 25);
            }
            return randomInt;
        }
    }

}
