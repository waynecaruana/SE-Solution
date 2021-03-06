﻿using System;
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
                rr.AllocateRole(u, r, "Allocate");
            
        }

        /// <summary>
        /// This email us used for login
        /// </summary>
        /// <param name="email">email</param>
        /// <param name="password">password</param>
        /// <returns>a user or null if does not exist</returns>
        public User AuthenticateUserByUsernameAndPassword(string email, string password)
        {
            return new UsersRepository().AuthenticateUserByUsernameAndPassword(email, password);
        }

        /// <summary>
        /// this method allow us to get all user roles
        /// </summary>
        /// <param name="email">user email</param>
        /// <returns>a list of roles</returns>
        public IEnumerable<Role> GetUserRoles(string email)
        {
            return new UsersRepository().GetUserRoles(email);
        }


        /// <summary>
        /// This email will return a list of permissions based on a user email  
        /// </summary>
        /// <param name="email">user email address</param>
        /// <returns>a list of permissions</returns>
        public IEnumerable<Permission> GetUserPermissions(string email)
        {

            return new UsersRepository().GetUserPermissions(email);
        }

        public void AllocateRole(int roleID, string email, string option)
        {
            UsersRepository ur = new UsersRepository();
            UsersRepository rr = new UsersRepository();

            ur.Entity = rr.Entity;

            //get all user details
            User u = ur.GetUserByUsername(email);
            Role r = ur.GetRoleByID(roleID);//get role by id

            rr.AllocateRole(u, r, option);

        }

        /// <summary>
        /// this method is used to get a user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public User GetUserByEmail(string email)
        {
            return new UsersRepository().GetUserByUsername(email);
        }


        /// <summary>
        /// this is used to update a user
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="address"></param>
        /// <param name="townid"></param>
        /// <param name="contact"></param>
        /// <param name="roleid"></param>
        public void UpdateUser(string email, string password, string name, string surname, string address,int townid, string contact)
        {
            User u = new User();
            //get all user details
            u.Email = email;
            u.Password = password;
            u.Firstname = name;
            u.Lastname = surname;
            u.Address = address;
            u.ContactNo = contact;
            u.TownID = townid;

            new UsersRepository().UpdateUser(u);
        }


        /// <summary>
        /// This method is used to delete a user
        /// </summary>
        /// <param name="email"></param>
        public void DeleteUser(string email)
        {
            UsersRepository u = new UsersRepository();

            User user = u.GetUserByUsername(email);//get the user by username
            
            u.DeleteUser(user);
        }

        

       

    }
}
