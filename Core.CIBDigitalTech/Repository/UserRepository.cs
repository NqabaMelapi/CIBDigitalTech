using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Core.CIBDigitalTech.DBContext;
using Core.CIBDigitalTech.Model;

namespace Core.CIBDigitalTech.Repository
{
    public class UserRepository
    {
        private CIBDigitalTechContext context;

        public UserRepository()
        {
            context = new CIBDigitalTechContext();
            context.Database.EnsureCreated();
        }

        public void AddUser(IList<UserTestData> userTestData)
        {
            User user;

            foreach (UserTestData testData in userTestData)
            {
                user = new User

                {
                    FirstName = testData.FirstName,
                    LastName = testData.LastName,
                    UserName = testData.UserName,
                    Password = testData.Password,
                    Customer = testData.Customer,
                    Role = testData.Role,
                    Email = testData.Email,
                    CellPhone = testData.CellPhone

                };

                context.User.Add(user);
                context.SaveChanges();
            }
        }

        public IEnumerable<UserTestData> GetTestData()
        {
            var usernames = GenerateUsername();
            var userTestData = context.UserTestData.ToList();

            userTestData[0].UserName = usernames.Item1;
            userTestData[1].UserName = usernames.Item2;

            return userTestData.ToList();             
        }

        private (string, string) GenerateUsername()
        {
            int rowCount = context.User.ToList().Count();

            if (rowCount == 0)
            {
                return ("User1", "User2");
            }

            return ("User" + (rowCount + 1).ToString(), "User" + (rowCount + 2).ToString());
        }
    }
}