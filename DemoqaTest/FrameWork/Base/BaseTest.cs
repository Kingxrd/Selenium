using DemoqaTest.Browse;
using DemoqaTest.FrameWork.TestData;
using DemoqaTest.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DemoqaTest.Base
{
    public abstract class BaseTest
    {
        [SetUp]
        protected void BeforeEach()
        {
            FrameworkLogger.logger.Info("Base Test Initial");
            Browser.GetDriver();
            Browser.WindowSize();
            Browser.NavigateToUrl(ConfigManager.MainUrl);
        }
        [TearDown]
        protected static void AfterEach()
        {
            FrameworkLogger.logger.Info("Test is downed");

            BrowseFactory.CloseBrowser();
        }
        
        public static void DownTest()
        {
            AfterEach();
        }
    }
}
