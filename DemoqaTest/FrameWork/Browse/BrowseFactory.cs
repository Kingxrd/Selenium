using DemoqaTest.Base;
using DemoqaTest.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Configuration;
using System.Collections.Specialized;

namespace DemoqaTest.Browse
{
    public class BrowseFactory
    {
        private static IWebDriver _driver;
        private static string _nameWebDriver;
        public static ConfigManager _config;
      
        public static IWebDriver InitializeWebDriver(ConfigManager.BrowserType browserType)
        {
            
            FrameworkLogger.logger.Info("Called InitializeWebDriver() method in BrowserFactory");

            switch (browserType)
            {
                case ConfigManager.BrowserType.Chrome:
                    new DriverManager().SetUpDriver(new ChromeConfig());
                    _driver = new ChromeDriver();
                    break;
                case ConfigManager.BrowserType.Firefox:
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    _driver = new FirefoxDriver();
                    break;
                default:
                    BaseTest.DownTest();
                    throw new ArgumentException($"{_nameWebDriver} does not support by Selenium");
            }
            return _driver;
        }

        internal static void CloseBrowser()
        {
            _driver.Quit();
            _driver = null;
            Browser.Driver = null;
        }

    }
}

