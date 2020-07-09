using System;
using System.Collections;
using System.Collections.Generic;
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
        }

        public void AddUser(User user)
        {     
            context.User.Add(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            var results = context.User;
            return results;             
        }


    }
}
