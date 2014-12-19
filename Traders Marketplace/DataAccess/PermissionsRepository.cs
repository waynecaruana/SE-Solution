using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace DataAccess
{
    public class PermissionsRepository : ConnectionClass
    {
        public PermissionsRepository()
            : base()
        {
        }

        /// <summary>
        /// This method allow us to get a list of Permissions
        /// </summary>
        /// <returns>a list of Permissions</returns>
        public IEnumerable<Permission> GetAllPermissions()
        {
            return Entity.Permissions.AsEnumerable();
        }


        /// <summary>
        /// This method allow us to add a Permission
        /// </summary>
        /// <param name="entry">an entry of type Permission</param>
        public void AddPermission(Permission entry)
        {

            Entity.AddToPermissions(entry);
            Entity.SaveChanges();

        }


        /// <summary>
        /// this allow us to get a Permission by id
        /// </summary>
        /// <param name="id">id of a Permission PK</param>
        /// <returns>a single Permission entity</returns>
        public Permission GetPermissionByID(int id)
        {

            return Entity.Permissions.SingleOrDefault(r => r.ID == id);

        }


        /// <summary>
        /// This allow us to update a particular Permission
        /// </summary>
        /// <param name="r">Permission entity</param>
        public void UpdatePermission(Permission r)
        {
            Entity.Permissions.Attach(GetPermissionByID(r.ID));
            Entity.Permissions.ApplyCurrentValues(r);

            Entity.SaveChanges();
        }


        /// <summary>
        /// This is used to delete a Permission
        /// </summary>
        /// <param name="entry">Permission entry</param>
        public void DeletePermission(Permission entry)
        {

            Entity.Permissions.DeleteObject(entry);
            Entity.SaveChanges();

        }

        /// <summary>
        /// this method one can allocate a permission
        /// </summary>
        /// <param name="user">user</param>
        /// <param name="role">permission of roles</param>
        public void AllocatePermission(Permission permission, Role role, string option)
        {
            //you have to add the role to the list of roles of that user
            try
            {

                if (option == "Allocate")
                {
                    role.Permissions.Add(permission);
                }
                else if (option == "Deallocate")
                {
                    role.Permissions.Remove(permission);
                }
                Entity.SaveChanges();
            }
            catch (Exception e)
            {

            }
        }
    }
}
