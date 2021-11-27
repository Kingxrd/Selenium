using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoqaTest.Browse;
using DemoqaTest.FrameWork.BaseElement.elements;
using DemoqaTest.Base;
using DemoqaTest.Utils;
using DemoqaTest.FrameWork.Utils;
using DemoqaTest.BaseElement.elements;


namespace DemoqaTest.FrameWork.PageObject.NestedFramesPage
{
    public class NestedFramesPageObject : BaseForm
    {
        private static Label _uniqueElement = new Label(By.XPath("//div[@class='main-header'][text()='Nested Frames']"), "Nested Frames Label");
        public Button NestedFramesButton => new Button(By.XPath("//span[text()='Nested Frames']"), "NestedFramesButton");
        private Iframe parentFrame => new Iframe(By.Id("frame1"), "ParentFrame Switch");
        private Iframe childFrame => new Iframe(By.TagName("iframe"), "ChildFrame Switch");
        private Window mainWindow => new Window(By.Name("mainwindow"),"Switch Window");
       
        private string parentFrameText;
        private string childFrameText;

        public NestedFramesPageObject(string namePage) :base(_uniqueElement,namePage)
        {
            FrameworkLogger.logger.Info($"Called ctor in BaseForm with params: Name Page - {namePage}");
        }
       

        public string SwitchFrameParent()
        {
            FrameworkLogger.logger.Info("Switch to parent frame");
            parentFrame.switchToFrame();
            return parentFrameText = Browser.GetDriver().FindElement(By.XPath("//body[text()='Parent frame']")).Text;
        }
        
        public string SwitchFrameChild()
        {
            FrameworkLogger.logger.Info("Switch to child frame");
            childFrame.switchToFrame();
             return childFrameText = Browser.GetDriver().FindElement(By.XPath("//p[text()='Child Iframe']")).Text;

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
        public bool IsNestedFramesPageOpen()
        {
            FrameworkLogger.logger.Info("Check uniq element on Page");
            Base.BaseElement uniqueElement = _uniqueElement;
            return uniqueElement.IsDisplayed();
        }
    }
}
