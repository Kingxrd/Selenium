using DemoqaTest.FrameWork.PageObject.WebTablesPage;
using DemoqaTest.FrameWork.UserModels;
using DemoqaTest.PageObject;
using NUnit.Framework;
using DemoqaTest.FrameWork.PageObject.ElementsPage;
using DemoqaTest.Base;
using DemoqaTest.FrameWork.TestData;

namespace DemoqaTest.Test
{
    [TestFixture]
    class WebTablesTest : BaseTest
    {
        private MainPageObject _mainPage;
        private WebTablesPageObject _webTablesPage;
        private TestData _testData;



        [SetUp]
        public void SetUp()
        {
            _mainPage = new MainPageObject("MainPage");
            _mainPage.HomePageSectionsButton("Elements").Click();
            _testData = new TestData();
        }


        [Test]
        public void Test1()
        {
            
            _mainPage.IsMainPageOpen();
            ExcelLib.PopulateInCollection(_testData.TestDataExcel);
            ElementsPageObject.WebTablesButton.Click();
            _webTablesPage = new WebTablesPageObject("WebTablesPage");
            _webTablesPage.IsWebTablesPageOpen();
            _webTablesPage.AddButton.Click();
            Assert.IsTrue(_webTablesPage.TextForm());
            _webTablesPage.FillUserData();
            _webTablesPage.SubmitButton.Click();
            Assert.AreEqual(_webTablesPage.UserData().FirstName, _webTablesPage.ActualFirstName());
            Assert.AreEqual(_webTablesPage.UserData().LastName, _webTablesPage.ActualLastName());
            Assert.AreEqual(_webTablesPage.UserData().Age, _webTablesPage.ActualAge());
            Assert.AreEqual(_webTablesPage.UserData().Email, _webTablesPage.ActualEmail());
            Assert.AreEqual(_webTablesPage.UserData().Salary, _webTablesPage.ActualSalary());
            Assert.AreEqual(_webTablesPage.UserData().Department, _webTablesPage.ActualDepartment());

            _webTablesPage.AddButton.Click();
            Assert.IsTrue(_webTablesPage.TextForm());
            _webTablesPage.FillUserDataSecond();
            _webTablesPage.SubmitButton.Click();
            Assert.AreEqual(_webTablesPage.UserData().FirstName, _webTablesPage.ActualFirstName());
            Assert.AreEqual(_webTablesPage.UserData().LastName, _webTablesPage.ActualLastName());
            Assert.AreEqual(_webTablesPage.UserData().Age, _webTablesPage.ActualAge());
            Assert.AreEqual(_webTablesPage.UserData().Email, _webTablesPage.ActualEmail());
            Assert.AreEqual(_webTablesPage.UserData().Salary, _webTablesPage.ActualSalary());
            Assert.AreEqual(_webTablesPage.UserData().Department, _webTablesPage.ActualDepartment());
            
            _webTablesPage.DeleteExistingEntry();
            _webTablesPage.DeleteExistingEntrySecond();
            Assert.IsFalse(_webTablesPage.FindFirstsAdd());
            Assert.IsFalse(_webTablesPage.findSecondAdd());
            
        }
    }
}
