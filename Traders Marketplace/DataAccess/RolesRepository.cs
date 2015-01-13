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


            foreach (char item in entry.Role1)
            {
                if (item == '0' || item == '1' || item == '2' || item == '3' || item == '4' || item == '5' || item == '6' || item == '7' || item == '8' || item == '9')
                {
                    valid = false;
                    break;
                }
            }

            

            try
            {
                //if (entry.Role1 == string.Empty) //Changed Code 
                if(entry.Role1 != string.Empty) //Original Code
                {
                    if (valid == true)
                    {
                        Entity.AddToRoles(entry);
                        Entity.SaveChanges();
                    }
                    else throw new ArgumentException();
                 
                }
                else throw new ArgumentException();
                
            }
            catch
            {
                throw new ArgumentException();
            }
            //}

        }


        /// <summary>
        /// this allow us to get a role by id
        /// </summary>
        /// <param name="id">id of a role PK</param>
        /// <returns>a single role entity</returns>
        public Role GetRoleByID(int id)
        {
            try
            {
                if (id != -1)
                {
                    return Entity.Roles.SingleOrDefault(r => r.RoleID == id);
                }
                else throw new ArgumentException();
            }
            catch
            {
                throw new ArgumentException();
            }
    

        }

        /// <summary>
        /// this method return a role with name
        /// </summary>
        /// <param name="name">name of role</param>
        /// <returns>a single role</returns>
        public Role GetRoleByName(string name)
        {
            try
            {
                return Entity.Roles.SingleOrDefault(r => r.Role1 == name);
            }
            catch
            {
                throw new ArgumentException();
            }

        }


        /// <summary>
        /// This allow us to update a particular role
        /// </summary>
        /// <param name="r">role entity</param>
        public void UpdateRole(Role r)
        {
            bool valid = true;
           

            foreach (char item in r.Role1)
            {
                if (item == '0' || item == '1' || item == '2' || item == '3' || item == '4' || item == '5' || item == '6' || item == '7' || item == '8' || item == '9')
                {
                    valid = false;
                }

            }

            try
            {
                //if(!valid)//changed code
                if (valid) //orginal code
                {
                    Entity.Roles.Attach(GetRoleByID(r.RoleID));
                    Entity.Roles.ApplyCurrentValues(r);

                    Entity.SaveChanges();
                }
                else throw new ArgumentException();
            }
            catch
            {
                throw new ArgumentException();
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
