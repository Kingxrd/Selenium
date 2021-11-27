using System;
using System.IO;
using DemoqaTest;
using DemoqaTest.FrameWork.BrowserSettings;
using DemoqaTest.FrameWork.Utils;
using Newtonsoft.Json;

namespace DemoqaTest.Utils
{
    
    public class ConfigManager
    {

        public static string MainUrl { get; private set; } = "https://demoqa.com/";
        public static string AlertsUrl { get; private set; } = "https://demoqa.com/alerts";
        public static int ExplicitWaitSec;
        public ConfigManager()
        {
            
        }
        public static int ExplicitWait()
        {
            return ExplicitWaitSec = 10;
        }
        public enum BrowserType
        {
            Chrome,
            Firefox
        }

    }
    

}
