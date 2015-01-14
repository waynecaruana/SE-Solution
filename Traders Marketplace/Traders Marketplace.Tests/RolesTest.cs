using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Traders_Marketplace.Controllers;
using System.Web.Mvc;
using Traders_Marketplace.Models;
using Common;
using BusinessLogic;
using System.Data.Common;
using DataAccess;

namespace Traders_Marketplace.Tests
{
    /// <summary>
    /// Summary description for RolesTest
    /// </summary>
    [TestClass]
    public class RolesTest
    {
        TradersMarketplaceDBEntities Entity;
        RolesRepository r;
        DbTransaction trancaction;

        [TestInitialize]
        public void Setup()
        {
            Entity = new TradersMarketplaceDBEntities();
            r = new RolesRepository();
            r.Entity.Connection.Open();
            trancaction = r.Entity.Connection.BeginTransaction();
        }

        /// <summary>
        ///ex. "a"
        /// </summary>
        [TestMethod]
        public void AddRoleTest1()
        {


            //the expected result is going to be all the roles found + the adde role in this case "Test Role"
            List<Role> expectedResult = Entity.Roles.ToList();//Restult before creating role

            Role roleToAdd = new Role();//create a new role
            roleToAdd.Role1 = "a";//give role a name
            expectedResult.Add(roleToAdd);//add role to the expected result

            r.AddRole(roleToAdd);//add role to database

            //List<Role> actualResult = new RolesBL().GetAllRoles().ToList();//get roles after creating role
            List<Role> actualResult = r.GetAllRoles().ToList();
            if (expectedResult.Count != actualResult.Count)
            {
                Assert.Fail("Role was not added");
            }

            Assert.AreEqual(expectedResult.Count, actualResult.Count, "Invalid Count");//check count of two list are equals
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].Role1, actualResult[i].Role1, "Not The same");//check each value
            }

        }

        /// <summary>
        /// “aa…a” (length 254)
        /// </summary>
        [TestMethod]
        public void AddRoleTest2()
        {
            string input = "";
            for (int i = 0; i < 50; i++)
            {
                input += "a";
                
            }

            int test = input.Length;//this is tested on 50 characters because of the databas varchar(50)

            //the expected result is going to be all the roles found + the adde role in this case "Test Role"
            List<Role> expectedResult = Entity.Roles.ToList();//Restult before creating role

            Role roleToAdd = new Role();//create a new role
            roleToAdd.Role1 = input;//give role a name
            expectedResult.Add(roleToAdd);//add role to the expected result

            r.AddRole(roleToAdd);//add role to database

            //List<Role> actualResult = new RolesBL().GetAllRoles().ToList();//get roles after creating role
            List<Role> actualResult = r.GetAllRoles().ToList();
            if (expectedResult.Count != actualResult.Count)
            {
                Assert.Fail("Role was not added");
            }

            Assert.AreEqual(expectedResult.Count, actualResult.Count, "Invalid Count");//check count of two list are equals
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].Role1, actualResult[i].Role1, "Not The same");//check each value
            }

        }

        /// <summary>
        ///  “aa…a” (length 255)
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddRoleTest3()
        {
            string input = "";
            for (int i = 0; i < 255; i++)
            {
                input += "a";

            }

            //the expected result is going to be all the roles found + the adde role in this case "Test Role"
            List<Role> expectedResult = Entity.Roles.ToList();//Restult before creating role

            Role roleToAdd = new Role();//create a new role
            roleToAdd.Role1 = input;//give role a name
            expectedResult.Add(roleToAdd);//add role to the expected result

            r.AddRole(roleToAdd);//add role to database

            //List<Role> actualResult = new RolesBL().GetAllRoles().ToList();//get roles after creating role
            List<Role> actualResult = r.GetAllRoles().ToList();
            if (expectedResult.Count != actualResult.Count)
            {
                Assert.Fail("Role was not added");
            }

            Assert.AreEqual(expectedResult.Count, actualResult.Count, "Invalid Count");//check count of two list are equals
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].Role1, actualResult[i].Role1, "Not The same");//check each value
            }

        }

        /// <summary>
        ///  “aa…a” (length 256)
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddRoleTest4()
        {
            string input = "";
            for (int i = 0; i < 256; i++)
            {
                input += "a";

            }

            //the expected result is going to be all the roles found + the adde role in this case "Test Role"
            List<Role> expectedResult = Entity.Roles.ToList();//Restult before creating role

            Role roleToAdd = new Role();//create a new role
            roleToAdd.Role1 = input;//give role a name
            expectedResult.Add(roleToAdd);//add role to the expected result

            r.AddRole(roleToAdd);//add role to database

            //List<Role> actualResult = new RolesBL().GetAllRoles().ToList();//get roles after creating role
            List<Role> actualResult = r.GetAllRoles().ToList();
            if (expectedResult.Count != actualResult.Count)
            {
                Assert.Fail("Role was not added");
            }

            Assert.AreEqual(expectedResult.Count, actualResult.Count, "Invalid Count");//check count of two list are equals
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].Role1, actualResult[i].Role1, "Not The same");//check each value
            }

        }

        /// <summary>
        /// NULL
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddRoleTest5()
        {
            //the expected result is going to be all the roles found + the adde role in this case "Test Role"
            List<Role> expectedResult = Entity.Roles.ToList();//Restult before creating role

            //---------------------------------------------------------------
            Role roleToAdd = new Role();
            roleToAdd.Role1 = "";
            r.AddRole(roleToAdd);//add role to database

            List<Role> actualResult = r.GetAllRoles().ToList();//get roles after creating role

            if (expectedResult.Count != actualResult.Count)
            {
                Assert.Fail("Role was Added");
            }

            Assert.AreEqual(expectedResult.Count, actualResult.Count, "Invalid Count");//check count of two list are equals

            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].Role1, actualResult[i].Role1, "Not The same");
            }



        }

        /// <summary>
        /// "Test Role 123"
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddRoleTest6()
        {
            //the expected result is going to be all the roles found + the adde role in this case "Test Role"
            List<Role> expectedResult = Entity.Roles.ToList();//Restult before creating role

            //---------------------------------------------------------------
            Role roleToAdd = new Role();
            roleToAdd.Role1 = "Test Role 123";
            expectedResult.Add(roleToAdd);
            r.AddRole(roleToAdd);//add role to database

            List<Role> actualResult = r.GetAllRoles().ToList();//get roles after creating role

            if (expectedResult.Count != actualResult.Count)
            {
                Assert.Fail("Role was Added");
            }

            Assert.AreEqual(expectedResult.Count, actualResult.Count, "Invalid Count");//check count of two list are equals

            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].Role1, actualResult[i].Role1, "Not The same");
            }



        }

        /// <summary>
        /// String.Empty
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddRoleTest7()
        {
            //the expected result is going to be all the roles found + the adde role in this case "Test Role"
            List<Role> expectedResult = Entity.Roles.ToList();//Restult before creating role

            //---------------------------------------------------------------
            Role roleToAdd = new Role();
            roleToAdd.Role1 = string.Empty;
            r.AddRole(roleToAdd);//add role to database

            List<Role> actualResult = r.GetAllRoles().ToList();//get roles after creating role

            if (expectedResult.Count != actualResult.Count)
            {
                Assert.Fail("Role was Added");
            }

            Assert.AreEqual(expectedResult.Count, actualResult.Count, "Invalid Count");//check count of two list are equals

            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].Role1, actualResult[i].Role1, "Not The same");
            }



        }


        /// <summary>
        /// 1
        /// </summary>
        [TestMethod]
        public void ReadRoleTest1()
        {
            
            Role expectedResult = Entity.Roles.Where(x => x.RoleID.Equals(1)).Single<Role>();//get role by name using linq

            Role actualResult = r.GetRoleByID(1);

            

            if (expectedResult.Role1 != actualResult.Role1 && expectedResult.RoleID != actualResult.RoleID)
            {
                Assert.Fail("Role not found");
            }

            Assert.AreEqual(expectedResult.Role1, actualResult.Role1, "The are not the same");//check count of two list are equals
            Assert.AreEqual(expectedResult.RoleID, actualResult.RoleID, "The are not the same");//check count of two list are equals
            Assert.IsNotNull(expectedResult);
            Assert.IsNotNull(actualResult);
           
        }

        /// <summary>
        /// -1
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ReadRoleTest2()
        {
            Role expectedResult;

            try
            {
                expectedResult = Entity.Roles.Where(x => x.RoleID.Equals(-1)).Single<Role>();//get role by name using linq
            }
            catch 
            {
                expectedResult = null;
            }
           

            if (expectedResult != null)
            {
                Assert.Fail("It Exist");
            }

            Role actualResult = r.GetRoleByID(-1);

            if (actualResult != null)
            {
                Assert.Fail("It Exist");
            }

            Assert.IsNull(expectedResult);
            Assert.IsNull(actualResult);

        }

        /// <summary>
        /// Name = Null, ID = -1
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateRoleTest1()
        {
            //the expected result is going to be all the roles found + the adde role in this case "Test Role"
            List<Role> expectedResult = Entity.Roles.ToList();//Restult before creating role

            
            Role roleToUpdate = new Role();//get role to update
            roleToUpdate.RoleID = r.GetRoleByID(-1).RoleID;
            roleToUpdate.Role1 = null;//change name
            r.UpdateRole(roleToUpdate);//update role
            
            


            List<Role> actualResult = r.GetAllRoles().ToList();
            if (expectedResult.Count != actualResult.Count)
            {
                Assert.Fail("Role was not Updated");
            }

            Assert.AreEqual(expectedResult.Count, actualResult.Count, "Invalid Count");//check count of two list are equals
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].Role1, actualResult[i].Role1, "Not The same");//check each value
            }

        }

        /// <summary>
        /// Name = string.empty, ID = -1
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateRoleTest2()
        {
            //the expected result is going to be all the roles found + the adde role in this case "Test Role"
            List<Role> expectedResult = Entity.Roles.ToList();//Restult before creating role


            Role roleToUpdate = new Role();//get role to update
            roleToUpdate.RoleID = r.GetRoleByID(-1).RoleID;
            roleToUpdate.Role1 = string.Empty;//change name
            r.UpdateRole(roleToUpdate);//update role




            List<Role> actualResult = r.GetAllRoles().ToList();
            if (expectedResult.Count != actualResult.Count)
            {
                Assert.Fail("Role was not Updated");
            }

            Assert.AreEqual(expectedResult.Count, actualResult.Count, "Invalid Count");//check count of two list are equals
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].Role1, actualResult[i].Role1, "Not The same");//check each value
            }

        }

        /// <summary>
        /// Name = "a", ID = 1
        /// </summary>
        [TestMethod]
        public void UpdateRoleTest3()
        {
            //the expected result is going to be all the roles found + the adde role in this case "Test Role"
            List<Role> expectedResult = Entity.Roles.ToList();//Restult before creating role
            expectedResult.RemoveAt(3);
            Role ur = new Role();
            ur.Role1 = "a";
            expectedResult.Add(ur);

            Role roleToUpdate = new Role();//get role to update
            roleToUpdate.RoleID = r.GetRoleByID(108).RoleID;//108 was used instead of 1 because of used data
            roleToUpdate.Role1 = "a";//change name
            r.UpdateRole(roleToUpdate);//update role

            List<Role> actualResult = r.GetAllRoles().ToList();
            if (expectedResult.Count != actualResult.Count)
            {
                Assert.Fail("Role was not Updated");
            }

            Assert.AreEqual(expectedResult.Count, actualResult.Count, "Invalid Count");//check count of two list are equals
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].Role1, actualResult[i].Role1, "Not The same");//check each value
            }

        }

        /// <summary>
        /// Name = “aa…a” (length 254), ID = -1
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateRoleTest4()
        {
            //the expected result is going to be all the roles found + the adde role in this case "Test Role"
            List<Role> expectedResult = Entity.Roles.ToList();//Restult before creating role

            string input = "";
            for (int i = 0; i < 254; i++)
            {
                input += "a";
            }

            Role roleToUpdate = new Role();//get role to update
            roleToUpdate.RoleID = r.GetRoleByID(-1).RoleID;//91 was used instead of 1 because of used data
            roleToUpdate.Role1 = input;//change name
            r.UpdateRole(roleToUpdate);//update role

            List<Role> actualResult = r.GetAllRoles().ToList();
            if (expectedResult.Count != actualResult.Count)
            {
                Assert.Fail("Role was not Updated");
            }

            Assert.AreEqual(expectedResult.Count, actualResult.Count, "Invalid Count");//check count of two list are equals
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].Role1, actualResult[i].Role1, "Not The same");//check each value
            }

        }

        /// <summary>
        /// Name = “aa…a” (length 255), ID = 1
        /// </summary>
        [TestMethod]
        public void UpdateRoleTest5()
        {
            //the expected result is going to be all the roles found + the adde role in this case "Test Role"
            List<Role> expectedResult = Entity.Roles.ToList();//Restult before creating role
            expectedResult.RemoveAt(3);

            string input = "";
            for (int i = 0; i < 49; i++)//49 insetad of 255 because of the dv varchar(50) 
            {
                input += "a";
            }
            Role ur = new Role();
            ur.Role1 = input;
            expectedResult.Add(ur);

            Role roleToUpdate = new Role();//get role to update
            roleToUpdate.RoleID = r.GetRoleByID(108).RoleID;//108 was used instead of 1 because of used data
            roleToUpdate.Role1 = input;//change name
            r.UpdateRole(roleToUpdate);//update role

            List<Role> actualResult = r.GetAllRoles().ToList();
            if (expectedResult.Count != actualResult.Count)
            {
                Assert.Fail("Role was not Updated");
            }

            Assert.AreEqual(expectedResult.Count, actualResult.Count, "Invalid Count");//check count of two list are equals
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].Role1, actualResult[i].Role1, "Not The same");//check each value
            }

        }

        /// <summary>
        /// Name = “Role Test 123, ID = 1
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateRoleTest6()
        {
            //the expected result is going to be all the roles found + the adde role in this case "Test Role"
            List<Role> expectedResult = Entity.Roles.ToList();//Restult before creating role
 
           

            Role roleToUpdate = new Role();//get role to update
            roleToUpdate.RoleID = r.GetRoleByID(108).RoleID;//108 was used instead of 1 because of used data
            roleToUpdate.Role1 = "Test Role 123";//change name
            r.UpdateRole(roleToUpdate);//update role

            List<Role> actualResult = r.GetAllRoles().ToList();
            if (expectedResult.Count != actualResult.Count)
            {
                Assert.Fail("Role was not Updated");
            }

            Assert.AreEqual(expectedResult.Count, actualResult.Count, "Invalid Count");//check count of two list are equals
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].Role1, actualResult[i].Role1, "Not The same");//check each value
            }

        }

        /// <summary>
        /// Name = “aa…a” (length 256), ID = -1
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateRoleTest7()
        {
            //the expected result is going to be all the roles found + the adde role in this case "Test Role"
            List<Role> expectedResult = Entity.Roles.ToList();//Restult before creating role

            string input = "";
            for (int i = 0; i < 256; i++)//49 insetad of 255 because of the dv varchar(50) 
            {
                input += "a";
            }


            Role roleToUpdate = new Role();//get role to update
            roleToUpdate.RoleID = r.GetRoleByID(-1).RoleID;//91 was used instead of 1 because of used data
            roleToUpdate.Role1 = input;//change name
            r.UpdateRole(roleToUpdate);//update role

            List<Role> actualResult = r.GetAllRoles().ToList();
            if (expectedResult.Count != actualResult.Count)
            {
                Assert.Fail("Role was not Updated");
            }

            Assert.AreEqual(expectedResult.Count, actualResult.Count, "Invalid Count");//check count of two list are equals
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].Role1, actualResult[i].Role1, "Not The same");//check each value
            }

        }




        /// <summary>
        /// 1
        /// </summary>
        [TestMethod]
        public void DeleteRoleTest1()
        {

            List<Role> expectedResult = Entity.Roles.ToList();//Restult before creating role
            expectedResult.RemoveAt(3);


            r.DeleteRole(r.GetRoleByID(108));

            List<Role> actualResult = r.GetAllRoles().ToList();

            if (expectedResult.Count != actualResult.Count)
            {
                Assert.Fail("Role was not Updated");
            }

            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].Role1, actualResult[i].Role1, "Not The same");//check each value
            }

            Assert.AreEqual(expectedResult.Count, actualResult.Count, "The are not the same");//check count of two list are equals
           
            Assert.IsNotNull(expectedResult);
            Assert.IsNotNull(actualResult);

        }

        /// <summary>
        /// -1
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteRoleTest2()
        {

            List<Role> expectedResult = Entity.Roles.ToList();//Restult before creating role


            r.DeleteRole(r.GetRoleByID(-1));

            List<Role> actualResult = r.GetAllRoles().ToList();

            if (expectedResult.Count != actualResult.Count)
            {
                Assert.Fail("Role was not Updated");
            }

            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].Role1, actualResult[i].Role1, "Not The same");//check each value
            }

            Assert.AreEqual(expectedResult.Count, actualResult.Count, "The are not the same");//check count of two list are equals

            Assert.IsNotNull(expectedResult);
            Assert.IsNotNull(actualResult);

        }

        /// <summary>
        /// Add role - Independant path 1 -	1, 2, 3, 4, 5, 6, 3, 7, 8, 9, 10
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddRole_IndependentPath1()
        {
            //1. read role name *
            //2. set valid = true *
            //3. foreach char in role name *
            //4.    if char is a number *
            //5.        set valid to false *
            //6.    end if *
            //7. end loop *
            //8. if role name is not null and valid *
            //9.    Add role to db *
            //10. end if *

            string roleName = "TestIP123";
            bool valid = true;

            foreach (char item in roleName)
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
                    Role role = new Role();
                    role.Role1 = roleName;
                    r.AddRole(role);
                }
                else throw new ArgumentException();
            }
            catch
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Add role - Independant path 2 -	1, 2, 3, 4, 5, 6, 3, 7, 8, 10
        /// </summary>
        [TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        public void AddRole_IndependentPath2()
        {
            //1. read role name *
            //2. set valid = true *
            //3. foreach char in role name *
            //4.    if char is a number *
            //5.        set valid to false *
            //6.    end if *
            //7. end loop *
            //8. if role name is not null and valid *
            //9.    Add role to db -
            //10. end if *

            string roleName = "TestIP";
            bool valid = true;

            foreach (char item in roleName)
            {
                if (item == '0' || item == '1' || item == '2' || item == '3' || item == '4' || item == '5' || item == '6' || item == '7' || item == '8' || item == '9')
                {
                    valid = false;
                }

            }

            try
            {
                if (valid) //orginal code
                {
                    Role role = new Role();
                    role.Role1 = roleName;
                   // r.AddRole(role);
                }
                else throw new ArgumentException();
            }
            catch
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Add role - Independant path 3 -	1, 2, 3, 4, 6, 3, 7, 8, 9, 10
        /// </summary>
        [TestMethod]
        public void AddRole_IndependentPath3()
        {
            //1. read role name *
            //2. set valid = true *
            //3. foreach char in role name *
            //4.    if char is a number *
            //5.        set valid to false -
            //6.    end if *
            //7. end loop *
            //8. if role name is not null and valid *
            //9.    Add role to db *
            //10. end if *

            string roleName = "TestIP";
            bool valid = true;

            foreach (char item in roleName)
            {
                if (item == '0' || item == '1' || item == '2' || item == '3' || item == '4' || item == '5' || item == '6' || item == '7' || item == '8' || item == '9')
                {
                    //valid = false;
                }

            }

            try
            {
                if (valid) //orginal code
                {
                    Role role = new Role();
                    role.Role1 = roleName;
                    r.AddRole(role);
                }
                else throw new ArgumentException();
            }
            catch
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Add role - Independant path 4 -	1, 2, 3, 4, 6, 3, 7, 8, 10
        /// </summary>
        [TestMethod]
        public void AddRole_IndependentPath4()
        {
            //1. read role name *
            //2. set valid = true *
            //3. foreach char in role name *
            //4.    if char is a number *
            //5.        set valid to false -
            //6.    end if *
            //7. end loop *
            //8. if role name is not null and valid *
            //9.    Add role to db -
            //10. end if *

            string roleName = "TestIP";
            bool valid = true;

            foreach (char item in roleName)
            {
                if (item == '0' || item == '1' || item == '2' || item == '3' || item == '4' || item == '5' || item == '6' || item == '7' || item == '8' || item == '9')
                {
                    //valid = false;
                }

            }

            try
            {
                if (valid) //orginal code
                {
                    Role role = new Role();
                    role.Role1 = roleName;
                    //r.AddRole(role);
                }
                else throw new ArgumentException();
            }
            catch
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Delete role - Independant path 1 -	1, 2, 3, 6
        /// </summary>
        [TestMethod]
        public void DeleteRole_IndependentPath1()
        {
            //1. read role id *
            //2. if role exist *
            //3. delete role *
            //4. else 
            //5. throw exception
            //6. end*


            Role role = new Role();
            role = r.GetRoleByID(108);

            if (role != null)
            {
                r.DeleteRole(role);
            }
            else
            {
                throw new ArgumentException();
            }
           
        }

        /// <summary>
        /// Delete role - Independant path 1 -	1, 2, 5, 6
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteRole_IndependentPath2()
        {
            //1. read role id *
            //2. if role exist *
            //3. delete role *
            //4. else 
            //5. throw exception*
            //6. end*


            Role role = new Role();
            role = r.GetRoleByID(-1);

            if (role != null)
            {
                r.DeleteRole(role);
            }
            else
            {
                throw new ArgumentException();
            }

        }

        /// <summary>
        /// Read role - Independant path 1 -	1, 2, 3, 6
        /// </summary>
        [TestMethod]
        public void ReadRole_IndependentPath1()
        {
            //1. read role id *
            //2. if role exist *
            //3. update role *
            //4. else 
            //5. throw exception
            //6. end*


            Role role = new Role();
            role = r.GetRoleByID(108);

            if (role == null)
            {
                throw new ArgumentException();
            }

        }

        /// <summary>
        /// Read role - Independant path 1 -	1, 2, 5, 6
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ReadRole_IndependentPath2()
        {
            //1. read role id *
            //2. if role exist *
            //3. update role *
            //4. else 
            //5. throw exception*
            //6. end*


            Role role = new Role();
            role = r.GetRoleByID(-1);

            if (role == null)
            {
                throw new ArgumentException();
            }

        }

        /// <summary>
        /// Update role - Independant path 1 -	1, 2, 3, 4, 5, 6, 3, 7, 8, 9, 10
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateRole_IndependentPath1()
        {
            //1. read role name *
            //2. set valid = true *
            //3. foreach char in role name *
            //4.    if char is a number *
            //5.        set valid to false *
            //6.    end if *
            //7. end loop *
            //8. if role name is not null and valid *
            //9.    update role to db *
            //10. end if *

            string roleName = "TestIP";
            bool valid = true;

            foreach (char item in roleName)
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
                    Role role = new Role();
                    role.Role1 = roleName;
                    r.UpdateRole(role);
                }
                else throw new ArgumentException();
            }
            catch
            {
                throw new ArgumentException();
            }
        }


        /// <summary>
        /// Update role - Independant path 2 -	1, 2, 3, 4, 5, 6, 3, 7, 8, 10
        /// </summary>
        [TestMethod]
        public void UpdateRole_IndependentPath2()
        {
            //1. read role name *
            //2. set valid = true *
            //3. foreach char in role name *
            //4.    if char is a number *
            //5.        set valid to false *
            //6.    end if *
            //7. end loop *
            //8. if role name is not null and valid *
            //9.    update role to db -
            //10. end if *

            string roleName = "TestIP";
            bool valid = true;

            foreach (char item in roleName)
            {
                if (item == '0' || item == '1' || item == '2' || item == '3' || item == '4' || item == '5' || item == '6' || item == '7' || item == '8' || item == '9')
                {
                    valid = false;
                }

            }

            try
            {
                if (valid) //orginal code
                {
                    Role role = new Role();
                    role.Role1 = roleName;
                    // r.UpdateRole(role);
                }
                else throw new ArgumentException();
            }
            catch
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Update role - Independant path 3 -	1, 2, 3, 4, 6, 3, 7, 8, 9, 10
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateRole_IndependentPath3()
        {
            //1. read role name *
            //2. set valid = true *
            //3. foreach char in role name *
            //4.    if char is a number *
            //5.        set valid to false -
            //6.    end if *
            //7. end loop *
            //8. if role name is not null and valid *
            //9.    update role to db *
            //10. end if *

            string roleName = "TestIP";
            bool valid = true;

            foreach (char item in roleName)
            {
                if (item == '0' || item == '1' || item == '2' || item == '3' || item == '4' || item == '5' || item == '6' || item == '7' || item == '8' || item == '9')
                {
                    //valid = false;
                }

            }

            try
            {
                if (valid) //orginal code
                {
                    Role role = new Role();
                    role.Role1 = roleName;
                    r.UpdateRole(role);
                }
                else throw new ArgumentException();
            }
            catch
            {
                throw new ArgumentException();
            }
        }

        /// <summary>
        /// Update role - Independant path 4 -	1, 2, 3, 4, 6, 3, 7, 8, 10
        /// </summary>
        [TestMethod]
        public void UpdateRole_IndependentPath4()
        {
            //1. read role name *
            //2. set valid = true *
            //3. foreach char in role name *
            //4.    if char is a number *
            //5.        set valid to false -
            //6.    end if *
            //7. end loop *
            //8. if role name is not null and valid *
            //9.    update role to db -
            //10. end if *

            string roleName = "TestIP";
            bool valid = true;

            foreach (char item in roleName)
            {
                if (item == '0' || item == '1' || item == '2' || item == '3' || item == '4' || item == '5' || item == '6' || item == '7' || item == '8' || item == '9')
                {
                    //valid = false;
                }

            }

            try
            {
                if (valid) //orginal code
                {
                    Role role = new Role();
                    role.Role1 = roleName;
                    //r.UpdateRole(role);
                }
                else throw new ArgumentException();
            }
            catch
            {
                throw new ArgumentException();
            }
        }

      
        [TestCleanup]
        public void CleanUp()
        {
            //trancaction.Commit();
            trancaction.Rollback();
            r.Entity.Connection.Close();
        }
        
    }
}
