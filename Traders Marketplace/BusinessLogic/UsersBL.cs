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

        /// <summary>
        /// this will get all towns in db
        /// </summary>
        /// <returns>a list of towns</returns>
        public IEnumerable<Town> GetTowns()
        {
            return new UsersRepository().GetTowns();
        }

        /// <summary>
        /// This method get all roles
        /// </summary>
        /// <returns>all roles in db</returns>
        public IEnumerable<Role> GetRoles()
        {
            return new UsersRepository().GetRoles();
        }

        /// <summary>
        /// this method will get all roles excluding the admin role
        /// </summary>
        /// <returns>all roles excluding admin</returns>
        public IEnumerable<Role> GetAllRolesExcludingAdmin()
        {
            List<Role> roles = new List<Role>();
            foreach (Role r in GetRoles())
            {
                if (r.Role1 != "Admin")
                {
                    roles.Add(r);
                }

            }
            return roles;
        }

        public void Register(string email, string password, string name, string surname, string address, int townid, string contact, int roleid)
        {

           
                UsersRepository ur = new UsersRepository();
                UsersRepository rr = new UsersRepository();

                ur.Entity = rr.Entity;

                //get all user details
                User u = new User();
                u.Email = email;
                u.Password = password;
                u.Firstname = name;
                u.Lastname = surname;
                u.Address = address;
                u.TownID = townid;
                u.ContactNo = contact;

                Role r = ur.GetRoleByID(roleid);//get role by id

                ur.AddUser(u);
                rr.AllocateRole(u, r);
            
           
  

        }
    }
}
