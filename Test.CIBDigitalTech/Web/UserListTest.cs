using System;
using Core.CIBDigitalTech.Selenium;
using NUnit.Framework;
using Test.CIBDigitalTech.Web.PageObject;
using Core.CIBDigitalTech.Repository;
using Core.CIBDigitalTech.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Test.CIBDigitalTech.Web
{

    public class UserListTest
    {
        User user;
        IList<UserTestData> userTestData;
        UserRepository userRepository;

        [SetUp]
        public void Setup()
        {
            userRepository = new UserRepository();

            userTestData = userRepository.GetTestData().ToList();
            
        }

        [TearDown]
        public void CleanUp()
        {
            WebDriver.CloseBrowser();
        }

        [Test]
        public void AddUsersToList_Chrome()
        {
            bool userExists = false;

            WebDriver.OpenBrowser("Chrome");
            WebDriver.NavigateToUrl("http://www.way2automation.com/angularjs-protractor/webtables/");

            Assert.IsTrue(UserTable.ValidateUserTableExist(), "User table not found");

            UserTable.AddUser(userTestData);

            userExists = UserTable.CheckIfUserIsAddedOnTheList(userTestData);

            Assert.IsTrue(userExists, "User is not on the list");

            if (userExists)
                userRepository.AddUser(userTestData);
        }

        [Test]
        public void AddUsersToList_Firefox()
        {
            bool userExists = false;

            WebDriver.OpenBrowser("Firefox");
            WebDriver.NavigateToUrl("http://www.way2automation.com/angularjs-protractor/webtables/");

            Assert.IsTrue(UserTable.ValidateUserTableExist(), "User table not found");

            UserTable.AddUser(userTestData);

            userExists = UserTable.CheckIfUserIsAddedOnTheList(userTestData);

            Assert.IsTrue(userExists, "User is not on the list");

            if (userExists)
                userRepository.AddUser(userTestData);

        }
    }
}
