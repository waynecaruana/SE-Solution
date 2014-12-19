using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DataAccess;
using System.Web;


namespace BusinessLogic
{
    public class RolesBL
    {

        /// <summary>
        /// This is used to get a list of roles
        /// </summary>
        /// <returns>a list of roles</returns>
        public IEnumerable<Role> GetAllRoles()
        {
            return new RolesRepository().GetAllRoles();
        }


        /// <summary>
        /// This is used to add a role to DB
        /// </summary>
        /// <param name="roleName">role name</param>
        public void AddRole(string roleName)
        {
            Role r = new Role();
            r.Role1 = roleName;

            new RolesRepository().AddRole(r);

        }


        /// <summary>
        /// This is used to get a role by id
        /// </summary>
        /// <param name="id">role id</param>
        /// <returns>a single role by id</returns>
        public Role GetRoleByID(int id)
        {
            return new RolesRepository().GetRoleByID(id);
        }


        /// <summary>
        /// this is used to update role
        /// </summary>
        /// <param name="id">role id</param>
        /// <param name="roleName"> role name</param>
        public void UpdateRole(int id, string roleName)
        {
            Role r = new Role();
            r.RoleID = id;
            r.Role1 = roleName;
            
            new RolesRepository().UpdateRole(r);
        }


        /// <summary>
        /// this method is used to delete a single role
        /// </summary>
        /// <param name="id">role id</param>
        public void DeleteRole(int id)
        {
            RolesRepository r = new RolesRepository();
            Role role = r.GetRoleByID(id);//get the user by username
            r.DeleteRole(role);
        }

    }
}
