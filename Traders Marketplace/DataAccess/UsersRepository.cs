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

        /// <summary>
        /// This method is used to register a user
        /// </summary>
        /// <param name="entry">user details</param>
        public void AddUser(User entry)
        {

            Entity.AddToUsers(entry);
            Entity.SaveChanges();

        }

        /// <summary>
        /// This will get all towns in db
        /// </summary>
        /// <returns> a list of towns</returns>
        public IEnumerable<Town> GetTowns()
        {
            return Entity.Towns;
        }


        /// <summary>
        /// This methd will get all roles
        /// </summary>
        /// <returns>a list of tyoe roles</returns>
        public IEnumerable<Role> GetRoles()
        {
            return Entity.Roles;
        }

        /// <summary>
        /// this method one can allocate a role
        /// </summary>
        /// <param name="user">user</param>
        /// <param name="role">role of user</param>
        public void AllocateRole(User user, Role role)
        {
            //you have to add the role to the list of roles of that user
            user.Roles.Add(role);
            Entity.SaveChanges();
        }

        /// <summary>
        /// This method get role with role id
        /// </summary>
        /// <param name="roleId">role id</param>
        /// <returns>a single row</returns>
        public Role GetRoleByID(int roleId)
        {

            return Entity.Roles.SingleOrDefault(r => r.RoleID == roleId);

        }

        /// <summary>
        /// This method will check if email exists
        /// </summary>
        /// <param name="email">email address</param>
        /// <returns>a user if exist, otherwise null</returns>
        public User CheckIfEmailExists(string email)
        {

            return Entity.Users.SingleOrDefault(u => u.Email == email);

        }

    }
}
