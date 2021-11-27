using OpenQA.Selenium;
using DemoqaTest.Browse;
using DemoqaTest.FrameWork.UserModels;
using System.Collections.Generic;
using OfficeOpenXml;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoqaTest.BaseElement.elements;
using DemoqaTest.Base;
using DemoqaTest.Utils;
using DemoqaTest.FrameWork.BaseElement.elements;

namespace DemoqaTest.FrameWork.PageObject.WebTablesPage
{
    
    public class WebTablesPageObject : BaseForm
    {
        public WebTablesPageObject WebTables;
        private ExcelLib _excelLib;
        private static Label _uniqueElement = new Label(By.XPath("//div[@class='main-header'][text()='Web Tables']"), "Web Tabels Label");
        public WebTablesPageObject(string namePage) : base(_uniqueElement,namePage)
        {
            _excelLib = new ExcelLib();
        }
        public bool IsWebTablesPageOpen()
        {
            Base.BaseElement uniqueElement = _uniqueElement;
            return uniqueElement.IsDisplayed();
        }
 

        public bool TextForm()
        {
            try
            {
                FrameworkLogger.logger.Info("Find ElementonPage");
                Browser.GetDriver().FindElement(By.XPath("//div[@class='fade modal-backdrop show']"));
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
           
        }
       
        public Button AddButton => new Button(By.XPath("//button[contains(text(),'Add')]"), "AddButton");
        public TextField FirstName => new TextField(By.XPath("//input[@id='firstName']"), "FirstNameField");
        public TextField LasttName => new TextField(By.XPath("//input[@id='lastName']"), "LasttNameField");
        public TextField Email => new TextField(By.XPath("//input[@id='userEmail']"), "EmailField");
        public TextField Age => new TextField(By.XPath("//input[@id='age']"), "AgeField");
        public TextField Salary => new TextField(By.XPath("//input[@id='salary']"), "SalaryField");
        public TextField Department => new TextField(By.XPath("//input[@id='department']"), "DepartmentField");
        public Button SubmitButton => new Button(By.XPath("//button[@id='submit']"), "SubmitButton");
        
        public string ActualFirstName()
        {
            FrameworkLogger.logger.Info("Find ActualFirstName");
            return Browser.GetDriver().FindElement(By.XPath($"//div[@class='rt-tbody']//div[contains(text(),'{UserData().FirstName}')]")).Text;
        }
        public string ActualLastName()
        {
            FrameworkLogger.logger.Info("Find ActualLastName");
            return Browser.GetDriver().FindElement(By.XPath($"//div[@class='rt-tbody']//div[contains(text(),'{UserData().LastName}')]")).Text;
        }
        public string ActualAge()
        {
            FrameworkLogger.logger.Info("Find ActualAge");
            return Browser.GetDriver().FindElement(By.XPath($"//div[@class='rt-tbody']//div[contains(text(),'{UserData().Age}')]")).Text;
        }
        public string ActualEmail()
        {
            FrameworkLogger.logger.Info("Find ActualEmail");
            return Browser.GetDriver().FindElement(By.XPath($"//div[@class='rt-tbody']//div[contains(text(),'{UserData().Email}')]")).Text;
        }
        public string ActualSalary()
        {
            FrameworkLogger.logger.Info("Find ActualSalary");
            return Browser.GetDriver().FindElement(By.XPath($"//div[@class='rt-tbody']//div[contains(text(),'{UserData().Salary}')]")).Text;
        }
        public string ActualDepartment()
        {
            FrameworkLogger.logger.Info("Find ActualDepartment");
            return Browser.GetDriver().FindElement(By.XPath($"//div[@class='rt-tbody']//div[contains(text(),'{UserData().Department}')]")).Text;
        }

        public void FillUserDataSecond()
        {
            FirstName.SendKeys(_excelLib.ReadData(2, "FirstName"));
            LasttName.SendKeys(_excelLib.ReadData(2, "LastName"));
            Email.SendKeys(_excelLib.ReadData(2, "Email"));
            Age.SendKeys(_excelLib.ReadData(2, "Age"));
            Salary.SendKeys(_excelLib.ReadData(2, "Salary"));
            Department.SendKeys(_excelLib.ReadData(2, "Department"));
            FrameworkLogger.logger.Info("FillUserDataExcelSecond");
        }


        public void FillUserData()
        {
            FirstName.SendKeys(_excelLib.ReadData(1, "FirstName"));
            LasttName.SendKeys(_excelLib.ReadData(1, "LastName"));
            Email.SendKeys(_excelLib.ReadData(1, "Email"));
            Age.SendKeys(_excelLib.ReadData(1, "Age"));
            Salary.SendKeys(_excelLib.ReadData(1, "Salary"));
            Department.SendKeys(_excelLib.ReadData(1, "Department"));
            FrameworkLogger.logger.Info("FillUserDataExcelFirst");
        }
        public  WebTablesModel UserData()
        {
            return new WebTablesModel
            {
                FirstName = _excelLib.ReadData(1, "FirstName"),

                LastName = _excelLib.ReadData(1, "LastName"),

                Age = _excelLib.ReadData(1, "Age"),

                Email = _excelLib.ReadData(1, "Email"),

                Salary = _excelLib.ReadData(1, "Salary"),

                Department = _excelLib.ReadData(1, "Department"),

            };
        }
       
        public bool FindFirstsAdd()
        {
            try
            {
                FrameworkLogger.logger.Info("Find ElementonPage");
                Browser.GetDriver().FindElement(By.XPath("//div[@class='rt-tr-group'][4]/div[@class='rt-tr -even']"));
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
            
        }
        public bool findSecondAdd()
        {
            try
            {
                FrameworkLogger.logger.Info("Find ElementonPage");
                Browser.GetDriver().FindElement(By.XPath("//div[@class='rt-tr-group'][5]/div[@class='rt-tr -even']"));
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        public void DeleteExistingEntry()
        {
            FrameworkLogger.logger.Info("Delete User in Table");
            Browser.GetDriver().FindElement(By.XPath("//span[@id='delete-record-4']")).Click();         
        }
        public void DeleteExistingEntrySecond()
        {
            FrameworkLogger.logger.Info("Delete User in Table");
            Browser.GetDriver().FindElement(By.XPath("//span[@id='delete-record-5']")).Click();
        }
    }
}
