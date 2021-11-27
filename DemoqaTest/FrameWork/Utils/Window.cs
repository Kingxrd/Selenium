using DemoqaTest.Browse;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoqaTest.FrameWork.Utils
{
    public class Window : Base.BaseElement
    {
        public Window(By by, string name) : base(by, name)
        {
            
        }
        public void SwitchtoWindow(string window)
        {
            Browser.GetDriver().SwitchTo().Window(window);
        }
    }
}
