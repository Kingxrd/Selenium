using DemoqaTest.BaseElement.elements;
using DemoqaTest.FrameWork.BrowserSettings;
using DemoqaTest.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoqaTest.Base
{
    public static class Wait
    {
        

        public static void WaitElements(IWebDriver webDriver, By locator)
        {
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(ConfigManager.ExplicitWait())).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
            
        }
        public static void WaitValue(IWebDriver webDriver, By locator,string text)
        {
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(ConfigManager.ExplicitWait())).Until(ExpectedConditions.TextToBePresentInElementValue(locator,text));

        }

        public static void WaitElement(IWebDriver webDriver, By locator)
        {
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(ConfigManager.ExplicitWait())).Until(ExpectedConditions.ElementIsVisible(locator));
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(ConfigManager.ExplicitWait())).Until(ExpectedConditions.ElementToBeClickable(locator));
        }
        public static IAlert WaitGetAlert(this IWebDriver driver)
        {
            IAlert alert = null;

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(ConfigManager.ExplicitWait()));

            try
            {
                alert = wait.Until(d =>
                {
                    try
                    {
                        // Attempt to switch to an alert
                        return driver.SwitchTo().Alert();
                    }
                    catch (NoAlertPresentException)
                    {
                        // Alert not present yet
                        return null;
                    }
                });
            }
            catch (WebDriverTimeoutException) { alert = null; }

            return alert;
        }
        
    }
}
