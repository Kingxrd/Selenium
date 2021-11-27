using DemoqaTest.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DemoqaTest.Browse
{
    abstract class Browser
    {
        internal static IWebDriver Driver;
        public static IWebDriver GetDriver()
        {
            FrameworkLogger.logger.Info("Browser Initial");
            if (Driver == null)
            {
                Driver = BrowseFactory.InitializeWebDriver(ConfigManager.BrowserType.Chrome);
            }
            return Driver;
        }
        public static void WindowSize()
        {
            Driver.Manage().Window.Maximize();
        }

        public static void NavigateToUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }
        public static void EndTest()
        {
            BrowseFactory.CloseBrowser();
            FrameworkLogger.logger.Info("Browser Close");
        }

    }
}
