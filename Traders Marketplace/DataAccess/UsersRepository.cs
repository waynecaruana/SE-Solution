using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace DataAccess
{
    public class UsersRepository : ConnectionClass
    {
        public UsersRepository()
            : base()
        {
        }


        /// <summary>
        /// This gives you a list of all users
        /// </summary>
        /// <returns>a list of all users in the database</returns>
        public IEnumerable<User> GetUsers()
        {
            return Entity.Users;
        }
    }
}
