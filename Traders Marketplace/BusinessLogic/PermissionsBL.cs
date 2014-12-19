using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DataAccess;
using System.Web;

namespace BusinessLogic
{
    public class PermissionsBL
    {
        /// <summary>
        /// This is used to get a list of Permissions
        /// </summary>
        /// <returns>a list of Permissions</returns>
        public IEnumerable<Permission> GetAllPermissions()
        {
            return new PermissionsRepository().GetAllPermissions();
        }


        /// <summary>
        /// This is used to add a Permission to DB
        /// </summary>
        /// <param name="PermissionName">Permission name</param>
        public void AddPermission(string PermissionName, string Desc)
        {
            Permission r = new Permission();
            r.Name = PermissionName;
            r.Description = Desc;
            new PermissionsRepository().AddPermission(r);

        }


        /// <summary>
        /// This is used to get a Permission by id
        /// </summary>
        /// <param name="id">Permission id</param>
        /// <returns>a single Permission by id</returns>
        public Permission GetPermissionByID(int id)
        {
            return new PermissionsRepository().GetPermissionByID(id);
        }


        /// <summary>
        /// this is used to update Permission
        /// </summary>
        /// <param name="id">Permission id</param>
        /// <param name="PermissionName"> Permission name</param>
        public void UpdatePermission(int id, string PermissionName, string desc)
        {
            Permission r = new Permission();
            r.ID = id;
            r.Name = PermissionName;
            r.Description = desc;
            new PermissionsRepository().UpdatePermission(r);
        }


        /// <summary>
        /// this method is used to delete a single Permission
        /// </summary>
        /// <param name="id">Permission id</param>
        public void DeletePermission(int id)
        {
            PermissionsRepository r = new PermissionsRepository();
            Permission Permission = r.GetPermissionByID(id);//get the user by username
            r.DeletePermission(Permission);
        }

        public void AllocatePermission(int roleID, int permissionID, string option)
        {
            PermissionsRepository ur = new PermissionsRepository();
            RolesRepository rr = new RolesRepository();

            ur.Entity = rr.Entity;

            //get all user details
            Permission p = ur.GetPermissionByID(permissionID);
            Role r = rr.GetRoleByID(roleID);//get role by id

            ur.AllocatePermission(p, r, option);

        }
    }
}
