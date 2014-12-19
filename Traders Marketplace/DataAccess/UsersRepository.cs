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
        public void AllocateRole(User user, Role role, string option)
        {
            //you have to add the role to the list of roles of that user
            try
            {
                
                if (option == "Allocate")
                {
                    user.Roles.Add(role);
                }
                else if (option == "Deallocate")
                {
                    user.Roles.Remove(role);
                }
                Entity.SaveChanges();
            }
            catch (Exception e)
            {
                
            }
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

        /// <summary>
        /// this method will check if user exists in order to login
        /// </summary>
        /// <param name="username">email</param>
        /// <param name="password">password</param>
        /// <returns>null or a user</returns>
        public User AuthenticateUserByUsernameAndPassword(string email, string password)
        {
            return Entity.Users.SingleOrDefault(x => x.Email == email && x.Password == password);

        }

        /// <summary>
        /// this will get user by email
        /// </summary>
        /// <param name="email">user email</param>
        /// <returns>a user</returns>
        public User GetUserByUsername(string email)
        {
            return Entity.Users.SingleOrDefault(x => x.Email == email);
        }


        /// <summary>
        /// this allow us to get all roles for a user
        /// </summary>
        /// <param name="username">user email</param>
        /// <returns>a list of roles</returns>
        public IEnumerable<Role> GetUserRoles(string email)
        {

            User u = GetUserByUsername(email);//get user
            return u.Roles.ToList();//get the list of users
        }


        /// <summary>
        /// this method will give a list of permissions for a user
        /// </summary>
        /// <param name="email">user email</param>
        /// <returns>a list of permissions</returns>
        public IEnumerable<Permission> GetUserPermissions(string email)
        {

            User u = GetUserByUsername(email);//get user
            List<Role> roles = u.Roles.ToList();//get the list of users

            List<Permission> permissions =  new List<Permission>();
            foreach (Role r in roles)
            {
                foreach (Permission p in r.Permissions)
                {
                    permissions.Add(p);
                }
            }

            return permissions;
        }



       

    }
}
