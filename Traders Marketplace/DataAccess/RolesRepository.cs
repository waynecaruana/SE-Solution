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

            Entity.AddToRoles(entry);
            Entity.SaveChanges();

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
        /// This allow us to update a particular role
        /// </summary>
        /// <param name="r">role entity</param>
        public void UpdateRole(Role r)
        {
            Entity.Roles.Attach(GetRoleByID(r.RoleID));
            Entity.Roles.ApplyCurrentValues(r);

            Entity.SaveChanges();
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
