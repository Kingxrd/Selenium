using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoqaTest.Base;
using DemoqaTest.BaseElement.elements;
using DemoqaTest.Browse;
using DemoqaTest.FrameWork.BaseElement.elements;
using DemoqaTest.FrameWork.Utils;
using DemoqaTest.Utils;
using OpenQA.Selenium;


namespace DemoqaTest.FrameWork.PageObject.IframePageObject.FramePage
{
    public class FramePageObject : BaseForm
    {
        private static Label _uniqueElement = new Label(By.XPath("//div[@class='main-header'][text()='Frames']"), "Frames Label");


        private Iframe parentFrame => new Iframe(By.Id("frame1"), "ParentFrame Switch");
        private Iframe childFrame => new Iframe(By.Id("frame2"), "ChildFrame Switch");
        private Window mainWindow => new Window(By.Name("mainwindow"), "Switch Window");
        private string parentFrameText;
        private string childFrameText;
        public FramePageObject(string namePage):base(_uniqueElement, namePage)
        {
            FrameworkLogger.logger.Info($"Called ctor in BaseForm with params: Name Page - {namePage}");
        }


        public string SwitchFrameParent()
        {
            FrameworkLogger.logger.Info("Switch to parent frame");
            parentFrame.switchToFrame();
            return parentFrameText = Browser.GetDriver().FindElement(By.XPath("//h1[@id='sampleHeading']")).Text;
        }

        public string SwitchFrameChild()
        {
            FrameworkLogger.logger.Info("Switch to child frame");
            childFrame.switchToFrame();
            return childFrameText = Browser.GetDriver().FindElement(By.XPath("//h1[@id='sampleHeading']")).Text;

        }
        public void ReturnMain(string maintab)
        {
            FrameworkLogger.logger.Info("Switch to main window");
            mainWindow.SwitchtoWindow(maintab);
        }
        public string Maintab()
        {
            FrameworkLogger.logger.Info("Get current window");
            return Browser.GetDriver().CurrentWindowHandle;
        }
    }
}
