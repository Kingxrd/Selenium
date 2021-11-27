using DemoqaTest.BaseElement.elements;
using DemoqaTest.Browse;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoqaTest.Base
{
    public class AlertUtil 
    {
        private IAlert alert;
        private Label _uniqueElement = new Label(By.XPath("//div[@class='main-header'][text()='Alerts']"), "Alerts Label");
        private string _namePage;

        public AlertUtil(string namePage)
        {
            _namePage = namePage;
        }

        public bool IsAlertPageOpen()
        {
            BaseElement uniqueElement = _uniqueElement;
            return uniqueElement.IsDisplayed();
        }
        public string RandomText()
        {
            Random rnd = new Random();
            char[] letters = "qwertyuiopasdfghjklzxcvbnm".ToCharArray();
            string randomText = string.Empty;
            for (int i = 0; i < 8; i++)
            {
                randomText += letters[rnd.Next(0, 25)].ToString();
            }
            return randomText;
        }

        public void AlertSend(string randomText)
        {

            alert = Browser.GetDriver().SwitchTo().Alert();
            alert.SendKeys(randomText);
            alert = null;
        }
        public void AlertAccept()
        {
            alert = Browser.GetDriver().SwitchTo().Alert();
            alert.Accept();
            alert = null;
        }

        public void AlertEnter(string enter)
        {
            alert = Browser.GetDriver().SwitchTo().Alert();
            if (alert != null)
            {
                alert.SendKeys(enter);
            }
        }
        public bool IsAlertClosed()
        {
            try
            {
                Browser.GetDriver().SwitchTo().Alert();
                return false;
            }
            catch (NoAlertPresentException)
            {
                return true;
            }
        }
       
        public void AlertDismiss()
        {
            alert = Browser.GetDriver().SwitchTo().Alert();
            alert.Dismiss();
            alert = null;
        }
        public string getText()
        {
            alert = Browser.GetDriver().SwitchTo().Alert();
            return alert.Text;
            
        }
       
    }
}
