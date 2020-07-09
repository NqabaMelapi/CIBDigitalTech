using System;
using Core.CIBDigitalTech.Selenium;
using NUnit.Framework;
using Test.CIBDigitalTech.Web.PageObject;

namespace Test.CIBDigitalTech.Web
{

    public class UserListTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void CleanUp()
        {
            WebDriver.CloseBrowser();
        }

        [Test]
        public void AddUsersToList_Chrome()
        {
            WebDriver.OpenBrowser("Chrome");
            WebDriver.NavigateToUrl("http://www.way2automation.com/angularjs-protractor/webtables/");

            Assert.IsTrue(UserTable.ValidateUserTableExist(), "User table not found");

            UserTable.AddUser();

            Assert.IsTrue(UserTable.CheckIfUserIsOnTheList(), "User is not on the list");

        }

        [Test]
        public void AddUsersToList_Firefox()
        {
            WebDriver.OpenBrowser("Firefox");
            WebDriver.NavigateToUrl("http://www.way2automation.com/angularjs-protractor/webtables/");

            Assert.IsTrue(UserTable.ValidateUserTableExist(), "User table not found");

            UserTable.AddUser();

            Assert.IsTrue(UserTable.CheckIfUserIsOnTheList(), "User is not on the list");

        }
    }
}
