using DemoqaTest.Base;
using DemoqaTest.Browse;
using DemoqaTest.FrameWork.PageObject.ProgressBarPage;
using DemoqaTest.FrameWork.PageObject.SliderPage;
using DemoqaTest.PageObject;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoqaTest.Test
{
    [TestFixture]
    public class SliderTest : BaseTest
    {
        private MainPageObject _mainPage;
        private SliderPageObject _sliderPage;
        private ProgressBarPageObject _progressBarPage;
      

        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPageObject("MainPage");
            _mainPage.HomePageSectionsButton("Widgets").Click();
            _sliderPage = new SliderPageObject("SliderPage");
            _progressBarPage = new ProgressBarPageObject("ProgressBarPage");

        }

        [Test]

        public void Test1()
        {
            _mainPage.IsMainPageOpen();
            _sliderPage.AdCloseButton.Click();
            _sliderPage.SliderButtonClick();
            Assert.IsTrue(_sliderPage.IsSliderPageOpen());
            int RandomInt = _sliderPage.RandomText();
            Assert.AreEqual(_sliderPage.Increase_Slider(RandomInt), _sliderPage.SliderValueInt(), "Slider not Equals");
            _progressBarPage.ScrollToElementProgressBarButton();
            _progressBarPage.ProgressBarButtonClick();
            Assert.IsTrue(_progressBarPage.IsProgressBbarPageOpen());
            _progressBarPage.ScrollToElementStartStopButton();           
            _progressBarPage.StratStopButton.Click();
            Assert.AreNotEqual(_progressBarPage.ProgressBarLabel.GetText(), "0%", "The progress bar was not activated.");
            _progressBarPage.StopProgressBarOnSpecificPercent("22%");
            string stoppecrent = _progressBarPage.ProgressBarLabel.GetText();
            Assert.IsTrue(stoppecrent=="22%" || stoppecrent == "24%", "The progress bar not stopped.");
        }
     }
}
