using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace DataAccess
{
    public class RolesRepository: ConnectionClass
    {
        public RolesRepository()
            : base()
        {
        }

        /// <summary>
        /// This method allow us to get a list of roles
        /// </summary>
        /// <returns>a list of roles</returns>
        public IEnumerable<Role> GetAllRoles()
        {
            return Entity.Roles.AsEnumerable();
        }


        /// <summary>
        /// This method allow us to add a role
        /// </summary>
        /// <param name="entry">an entry of type role</param>
        public void AddRole(Role entry)
        {
            bool valid = true;
            if (entry.Role1 == "" || entry.Role1.Length < 3)
            {
                valid = false;
            }

            foreach (char item in entry.Role1)
            {
                if (item == '0' || item == '1' || item == '2' || item == '3' || item == '4' || item == '5' || item == '6' || item == '7' || item == '8' || item == '9')
                {
                    valid = false;
                }

            }

            if (valid)
            {
                Entity.AddToRoles(entry);
                Entity.SaveChanges();
            }

        }


        /// <summary>
        /// this allow us to get a role by id
        /// </summary>
        /// <param name="id">id of a role PK</param>
        /// <returns>a single role entity</returns>
        public Role GetRoleByID(int id)
        {

            return Entity.Roles.SingleOrDefault(r => r.RoleID == id);

        }

        /// <summary>
        /// this method return a role with name
        /// </summary>
        /// <param name="name">name of role</param>
        /// <returns>a single role</returns>
        public Role GetRoleByName(string name)
        {
            return Entity.Roles.SingleOrDefault(r => r.Role1 == name);

        }


        /// <summary>
        /// This allow us to update a particular role
        /// </summary>
        /// <param name="r">role entity</param>
        public void UpdateRole(Role r)
        {
             bool valid = true;
            if (r.Role1 == "" || r.Role1.Length < 3)
            {
                valid = false;
            }

            foreach (char item in r.Role1)
            {
                if (item == '0' || item == '1' || item == '2' || item == '3' || item == '4' || item == '5' || item == '6' || item == '7' || item == '8' || item == '9')
                {
                    valid = false;
                }

            }

            if (valid)
            {
                Entity.Roles.Attach(GetRoleByID(r.RoleID));
                Entity.Roles.ApplyCurrentValues(r);

                Entity.SaveChanges();
            }
        }


        /// <summary>
        /// This is used to delete a role
        /// </summary>
        /// <param name="entry">role entry</param>
        public void DeleteRole(Role entry)
        {

            Entity.Roles.DeleteObject(entry);
            Entity.SaveChanges();

        }


    }
}
