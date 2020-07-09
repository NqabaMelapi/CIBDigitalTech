using System;
using OpenQA.Selenium;
using Core.CIBDigitalTech.Selenium;

namespace Test.CIBDigitalTech.Web.PageObject
{
    public class UserTable : Core.CIBDigitalTech.Selenium.WebDriver
    {
        public UserTable()
        {
        }

        static IWebElement userTable => remoteWebDriver.FindElement(By.ClassName("smart-table table table-striped"));
        static IWebElement addUser => remoteWebDriver.FindElement(By.ClassName("btn btn-link pull-right"));
        static IWebElement firstName => remoteWebDriver.FindElement(By.Name("FirstName"));
        static IWebElement lasttName => remoteWebDriver.FindElement(By.Name("LastName"));
        static IWebElement userName => remoteWebDriver.FindElement(By.Name("UserName"));
        static IWebElement password => remoteWebDriver.FindElement(By.Name("Password"));
        static IWebElement companyAAA => remoteWebDriver.FindElement(By.XPath("/html/body/div[3]/div[2]/form/table/tbody/tr[5]/td[2]/label[1]"));
        static IWebElement companyBBB => remoteWebDriver.FindElement(By.XPath("/html/body/div[3]/div[2]/form/table/tbody/tr[5]/td[2]/label[2]"));
        static IWebElement roleDropDown => remoteWebDriver.FindElement(By.Name("RoleId"));
        static IWebElement email => remoteWebDriver.FindElement(By.Name("Email"));
        static IWebElement cellPhone => remoteWebDriver.FindElement(By.Name("Mobilephone"));
        static IWebElement closeBtn => remoteWebDriver.FindElement(By.XPath("/html/body/div[3]/div[3]/button[1]"));
        static IWebElement saveBtn => remoteWebDriver.FindElement(By.XPath("/html/body/div[3]/div[3]/button[2]"));

        public static bool ValidateUserTableExist()
        {
            WaitForElementToBeDisplay(userTable);
            return userTable.Displayed;
        }

        public static bool CheckIfUserIsOnTheList()
        {
            return true;
        }

        public static void SelectCompany(string company)
        {
            if (company.Equals("companyAAA"))
                companyAAA.Click();
            else if (company.Equals("companyBBB"))
                companyBBB.Click();
        }

        public static void AddUser()
        {
            Click(addUser);
            EnterText(firstName, "FName1");
            EnterText(lasttName, "LName1");
            EnterText(userName, "User1");
            EnterText(password, "Pass1");
            SelectCompany("companyAAA");
            SelectDropdownByValue(roleDropDown, "Admin");
            EnterText(email, "");
            EnterText(cellPhone, "");
            Click(saveBtn);
            
        }


    }
}
