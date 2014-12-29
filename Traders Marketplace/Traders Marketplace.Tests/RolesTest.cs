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

namespace Traders_Marketplace.Tests
{
    /// <summary>
    /// Summary description for RolesTest
    /// </summary>
    [TestClass]
    public class RolesTest
    {
        [TestMethod]
        public void ListRoles()
        {
            //Setup
            TradersMarketplaceDBEntities Entity = new TradersMarketplaceDBEntities();
                       
            // Act
            List<Role> expectedResult = Entity.Roles.ToList();

            List<Role> actualResult = new RolesBL().GetAllRoles().ToList();

            // Assert
            Assert.AreEqual(expectedResult.Count,actualResult.Count);
            
        }

        [TestMethod]
        public void CreateRoles()
        {
            bool valid = false;
            //Setup
            TradersMarketplaceDBEntities Entity = new TradersMarketplaceDBEntities();

            //Restult before creating role
            List<Role> expectedResult = Entity.Roles.ToList();

            new RolesBL().AddRole("Test");

            //roles after creating role
            List<Role> actualResult = Entity.Roles.ToList();

            // Assert
            foreach (var item in actualResult)
            {
                if (item.Role1 == "Test")
                {
                    Assert.AreNotEqual(expectedResult.Count, actualResult.Count);
                    valid = true;
                }
               
            }

            if (!valid)
            {
                Assert.Fail("Role was Not Created");
            }

        }

        [TestMethod]
        public void DeleteRoles()
        {
            bool valid = false;
            //Setup
            TradersMarketplaceDBEntities Entity = new TradersMarketplaceDBEntities();

            //Restult before deleting role
            List<Role> expectedResult = Entity.Roles.ToList();

            foreach (Role r in expectedResult)
            {
                if (r.Role1 == "TestTest")
                {
                    new RolesBL().DeleteRole(r.RoleID);
                    valid = true;
                }


            }


            //roles after deleteing role
            List<Role> actualResult = Entity.Roles.ToList();

            if (!valid)
            {
                Assert.Fail("Role was Not Deleted");
            }
            else
            {
                Assert.AreNotEqual(expectedResult.Count, actualResult.Count);
            }

        }

        [TestMethod]
        public void EditRoles()
        {
            //Setup
            TradersMarketplaceDBEntities Entity = new TradersMarketplaceDBEntities();

            //Restult before editing role
            List<Role> expectedResult = Entity.Roles.ToList();

            foreach (Role r in expectedResult)
            {
                if (r.Role1 == "Test")
                {
                    new RolesBL().UpdateRole(r.RoleID, "TestTest");
                }
            }

            //roles after editing role
            List<Role> actualResult = Entity.Roles.ToList();

            foreach (Role r in expectedResult)
            {
                if (r.Role1 == "Test")
                {
                    foreach (Role r2 in actualResult)
                    {
                        if (r2.RoleID == r.RoleID)
                        {
                            Assert.AreEqual(r.RoleID, r2.RoleID);
                        }
                    }
                }
                
            }

        }


        [TestMethod]
        public void ReadRoles()
        {

            //Setup
            TradersMarketplaceDBEntities Entity = new TradersMarketplaceDBEntities();

            //Restult before deleting role
            List<Role> list = Entity.Roles.ToList();
            string expectedResult = "Admin";
            string actualResult = "";
            foreach (Role r in list)
            {
                if (r.Role1 == "Admin")
                {
                    Role role = new RolesBL().GetRoleByID(r.RoleID);
                    actualResult = role.Role1;
      
                }


            }

            
            Assert.AreEqual(expectedResult, actualResult);
            

        }





        
    }
}
