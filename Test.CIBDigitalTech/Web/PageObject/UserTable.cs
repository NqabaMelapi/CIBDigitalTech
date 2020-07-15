using System;
using OpenQA.Selenium;
using Core.CIBDigitalTech.Selenium;
using System.Collections;
using System.Collections.Generic;
using Core.CIBDigitalTech.Model;

namespace Test.CIBDigitalTech.Web.PageObject
{
    public class UserTable : Core.CIBDigitalTech.Selenium.WebDriver
    {
        public UserTable()
        {
        }

        static IWebElement userTable => remoteWebDriver.FindElement(By.XPath("/html/body/table/tbody"));
        static IWebElement addUser => remoteWebDriver.FindElement(By.XPath("/html/body/table/thead/tr[2]/td/button"));
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

        public static bool CheckIfUserIsAddedOnTheList(IList<UserTestData> userTestData)
        {
            ValidateUserTableExist();



            IList<IWebElement> userList = userTable.FindElements(By.TagName("tr"));
            IList<IWebElement> userData;

            int checkCount = 0;
            bool userExists = false;

            foreach (UserTestData expectedData in userTestData )
            {
                foreach (IWebElement row in userList)
                {
                    userData = row.FindElements(By.TagName("td"));

                    string firstName = userData[0].Text;
                    string lasttName = userData[1].Text;
                    string userName = userData[2].Text;
                    string customerName = userData[4].Text;
                    string role = userData[5].Text;
                    string email = userData[6].Text;
                    string cellPhone = userData[7].Text;

                    if (userName == expectedData.UserName)
                    {

                        checkCount++;
                        if (checkCount == userTestData.Count)
                        {
                            userExists = true;
                            break;
                        }

                        break;
                    }
                }
            }



            return userExists;
        }

        public static void SelectCompany(string company)
        {
            if (company.Equals("CompanyAAA"))
                companyAAA.Click();
            else if (company.Equals("CompanyBBB"))
                companyBBB.Click();
        }

        public static void AddUser(IList<UserTestData> userTestData)
        {

            foreach (UserTestData data in userTestData)
            {
                Click(addUser);
                EnterText(firstName, data.FirstName);
                EnterText(lasttName, data.LastName);
                EnterText(userName, data.UserName);
                EnterText(password, data.Password);
                SelectCompany(data.Customer);
                SelectDropdownByText(roleDropDown, data.Role);
                EnterText(email, data.Email);
                EnterText(cellPhone, data.CellPhone);
                Click(saveBtn);
            }
        }

    }
}
