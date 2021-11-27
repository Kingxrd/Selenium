using DemoqaTest.Base;
using DemoqaTest.FrameWork.PageObject.ElementsPage;
using DemoqaTest.FrameWork.PageObject.IframePageObject.FramePage;
using DemoqaTest.FrameWork.PageObject.NestedFramesPage;
using DemoqaTest.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoqaTest.Test
{
    [TestFixture]
    class TestNestedFrames : BaseTest
    {
        private MainPageObject _mainPage;
        private NestedFramesPageObject _nestedFramesPage;
        private FramePageObject _framePage;
        [SetUp]
        public void SetUp()
        {

            _mainPage = new MainPageObject("MainPage");
            _mainPage.HomePageSectionsButton("Alerts, Frame & Windows").Click();
            _nestedFramesPage = new NestedFramesPageObject("NestedFramesPag");
           
        }


        [Test]
        public void Test1()
        {
            _mainPage.IsMainPageOpen();
            string mainTabNested = _nestedFramesPage.Maintab();
            _nestedFramesPage.NestedFramesButton.Click();
            
            Assert.IsTrue(_nestedFramesPage.IsNestedFramesPageOpen());
            Assert.AreEqual(_nestedFramesPage.SwitchFrameParent(), "Parent frame", "Frame not displayed");
            Assert.AreEqual(_nestedFramesPage.SwitchFrameChild(), "Child Iframe", "Frame not displayed");
            _nestedFramesPage.ReturnMain(mainTabNested);

            ElementsPageObject.FrameButton.Click();
            _framePage = new FramePageObject("FramePage");
            string maintab = _framePage.Maintab();
            string parentFrameText = _framePage.SwitchFrameParent();
            _framePage.ReturnMain(maintab);
            string ChildFrameText = _framePage.SwitchFrameChild();
            Assert.AreEqual(parentFrameText, ChildFrameText, "Frame not displayed");
           
        }
    }
}
