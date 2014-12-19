using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Traders_Marketplace.Models;
using BusinessLogic;
using Common;

namespace Traders_Marketplace.Controllers
{
    public class PermissionController : Controller
    {
        //
        // GET: /Permission/
         [Authorize(Roles = "List Permissions")]
        public ActionResult Index(PermissionModel model)
        {
            return View(new PermissionsBL().GetAllPermissions());
        }

         [Authorize(Roles = "Allocate Permissions")]
         public ActionResult AllocatePermissions()
         {
             PermissionModel permissionModel = new PermissionModel();
             permissionModel.Roles = new SelectList(new RolesBL().GetAllRoles(), "RoleID", "Role1");
             permissionModel.Permissions = new SelectList(new PermissionsBL().GetAllPermissions(), "ID", "Name");
             return View(permissionModel);
         }

         [HttpPost]
         public ActionResult AllocatePermissions(PermissionModel model)
         {
             int role = model.SelectedRole;
             int permission = model.SelectedPermission;

             new PermissionsBL().AllocatePermission(role, permission, model.SelectedOption);
             

             PermissionModel permissionModel = new PermissionModel();
             permissionModel.Roles = new SelectList(new RolesBL().GetAllRoles(), "RoleID", "Role1");
             permissionModel.Permissions = new SelectList(new PermissionsBL().GetAllPermissions(), "ID", "Name");
             return View(permissionModel);
         }

        //
        // GET: /Permission/Details/5
        [Authorize(Roles = "Read Permissions")]
        public ActionResult Details(int id)
        {
            Permission p = new PermissionsBL().GetPermissionByID(id);
            return View(new PermissionModel(p.ID));
        }

        //
        // GET: /Permission/Create
        [Authorize(Roles = "Add Permissions")]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Permission/Create

        [HttpPost]
        public ActionResult Create(PermissionModel model)
        {
            try
            {
                // TODO: Add insert logic here
                new PermissionsBL().AddPermission(model.Name, model.Description);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Permission/Edit/5
        [Authorize(Roles = "Edit Permission")]
        public ActionResult Edit(int id)
        {
            Permission p = new PermissionsBL().GetPermissionByID(id);
            return View(new PermissionModel(p.ID));
        }

        //
        // POST: /Permission/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, PermissionModel model)
        {
            try
            {
                // TODO: Add update logic here

                new PermissionsBL().UpdatePermission(model.ID, model.Name, model.Description);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Permission/Delete/5
        [Authorize(Roles = "Delete Permission")]
        public ActionResult Delete(int id)
        {
            new PermissionsBL().DeletePermission(id);
            return RedirectToAction("Index", "Permission");
        }

        //
        // POST: /Permission/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
