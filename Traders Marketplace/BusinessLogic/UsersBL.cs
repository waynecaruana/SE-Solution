using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DataAccess;

namespace BusinessLogic
{
    public class UsersBL
    {
        /// <summary>
        /// This gives you all users
        /// </summary>
        /// <returns>a list of all users</returns>
        public IEnumerable<User> GetUsers()
        {
            return new UsersRepository().GetUsers();
        }
    }
}
