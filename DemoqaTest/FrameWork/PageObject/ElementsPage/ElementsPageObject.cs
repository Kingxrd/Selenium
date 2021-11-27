using DemoqaTest.Base;
using DemoqaTest.Browse;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoqaTest.FrameWork.PageObject.ElementsPage
{
    public class ElementsPageObject 
    {
       
        public static Button WebTablesButton => new Button(By.XPath("//span[text()='Web Tables']"), "WebTablesButton");
        public static Button FrameButton => new Button(By.XPath("//span[text()='Frames']"), "Frame Button");
    }
}
