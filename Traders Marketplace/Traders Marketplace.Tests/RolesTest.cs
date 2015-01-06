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
        /// This test case is used when a user enters a valid role ex. Test Role
        /// </summary>
        [TestMethod]
        public void AddRoleTest1()
        {


            //the expected result is going to be all the roles found + the adde role in this case "Test Role"
            List<Role> expectedResult = Entity.Roles.ToList();//Restult before creating role

            Role roleToAdd = new Role();//create a new role
            roleToAdd.Role1 = "Test Role";//give role a name
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
        /// This test case is going to test when the user enters a null value
        /// </summary>
        [TestMethod]
        public void AddRoleTest2()
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
        /// This test case is going to test when the user enters a role with numbers ex. Test Role 123
        /// </summary>
        [TestMethod]
        public void AddRoleTest3()
        {
            //the expected result is going to be all the roles found + the adde role in this case "Test Role"
            List<Role> expectedResult = Entity.Roles.ToList();//Restult before creating role

            //---------------------------------------------------------------
            Role roleToAdd = new Role();
            roleToAdd.Role1 = "Test Role 123";
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
        /// This test case is going to test when the user enters a value smaller than 3 characters in length ex. Aa
        /// </summary>
        [TestMethod]
        public void AddRoleTest4()
        {
            //the expected result is going to be all the roles found + the adde role in this case "Test Role"
            List<Role> expectedResult = Entity.Roles.ToList();//Restult before creating role

            //---------------------------------------------------------------
            Role roleToAdd = new Role();
            roleToAdd.Role1 = "Aa";
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
        /// This method is going to test a role that exist
        /// </summary>
        [TestMethod]
        public void ReadRoleTest1()
        {
            
            Role expectedResult = Entity.Roles.Where(x => x.Role1.Equals("Admin")).Single<Role>();//get role by name using linq

            Role actualResult = r.GetRoleByName("Admin");

            

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
        /// This method trying to read a role that does not exist
        /// </summary>
        [TestMethod]
        public void ReadRoleTest2()
        {
            Role expectedResult;
            try
            {
                expectedResult = Entity.Roles.Where(x => x.Role1.Equals("Admin2")).Single<Role>();//get role by name using linq
            }
            catch
            {
                expectedResult = null;
            }

            if (expectedResult != null)
            {
                Assert.Fail("It Exist");
            }

            Role actualResult = r.GetRoleByName("Admin2");

            if (actualResult != null)
            {
                Assert.Fail("It Exist");
            }

            Assert.IsNull(expectedResult);
            Assert.IsNull(actualResult);

        }

        /// <summary>
        /// This method is going to test the possibility of updating a role from Test Role to Test Update Role
        /// </summary>
        [TestMethod]
        public void UpdateRoleTest1()
        {
            //the expected result is going to be all the roles found + the adde role in this case "Test Role"
            List<Role> expectedResult = Entity.Roles.ToList();//Restult before creating role
            //add role to expected result
            Role role = new Role();
            role.Role1 = "Test RoleToUpdate2";
            expectedResult.RemoveAt(3);
            expectedResult.Add(role);


            Role roleToUpdate = new Role();//get role to update
            roleToUpdate.RoleID = r.GetRoleByName("Test RoleToUpdate").RoleID;
            roleToUpdate.Role1 = "Test RoleToUpdate2";//change name
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
        /// This test method is used to try and update a role with a null value
        /// </summary>
        [TestMethod]
        public void UpdateRoleTest2()
        {
            //the expected result is going to be all the roles found + the adde role in this case "Test Role"
            List<Role> expectedResult = Entity.Roles.ToList();//Result before creating role

            Role roleToUpdate = new Role();//get role to update
            roleToUpdate.RoleID = r.GetRoleByName("Test RoleToUpdate").RoleID;
            roleToUpdate.Role1 = "";//change name
            r.UpdateRole(roleToUpdate);//update role

            List<Role> actualResult = r.GetAllRoles().ToList();
            if (expectedResult.Count != actualResult.Count)
            {
                Assert.Fail("Role Updated");
            }

            Assert.AreEqual(expectedResult.Count, actualResult.Count, "Invalid Count");//check count of two list are equals
            for (int i = 0; i < expectedResult.Count; i++)
            {
                Assert.AreEqual(expectedResult[i].Role1, actualResult[i].Role1, "Not The same");//check each value
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
