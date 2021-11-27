using DemoqaTest.Base;
using DemoqaTest.Browse;
using DemoqaTest.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoqaTest.FrameWork.BaseElement.elements
{
    public class Iframe : Base.BaseElement
    {
        private IWebElement IframeSwitch;
        public Iframe(By by, string name) : base(by, name)
        {
            
        }
        public void switchToFrame()
        {
            FrameworkLogger.logger.Info("Switch frame initial");
            IframeSwitch = FindElement();
           
            Browser.GetDriver().SwitchTo().Frame(IframeSwitch);

        }
        public void switchToDefault()
        {
            FrameworkLogger.logger.Info("Switch to default initial");
            Browser.GetDriver().SwitchTo().DefaultContent();
        }
       
    }
}
