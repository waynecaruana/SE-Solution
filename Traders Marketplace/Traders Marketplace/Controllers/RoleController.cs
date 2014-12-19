using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using DataAccess;
using Traders_Marketplace.Models;
using BusinessLogic;


namespace Traders_Marketplace.Controllers
{
    public class RoleController : Controller
    {
        //
        // GET: /Role/
        [Authorize(Roles = "List Roles")]
        public ActionResult Index(RoleModel model)
        {
            return View(new RolesRepository().GetAllRoles());          
        }

        [Authorize(Roles = "Allocate Roles")]
        public ActionResult AllocateRoles()
        {
            RoleModel roleModel = new RoleModel();
            roleModel.Roles = new SelectList(new RolesBL().GetAllRoles(), "RoleID", "Role1");
            roleModel.Users = new SelectList(new UsersBL().GetUsers(), "Email", "Email");
            return View(roleModel);
        }

        [HttpPost]
        public ActionResult AllocateRoles(RoleModel model)
        {
            int role = model.SelectedRole;
            string email = model.SelectedUser;

            new UsersBL().AllocateRole(role, email, model.SelectedOption);

            RoleModel roleModel = new RoleModel();
            roleModel.Roles = new SelectList(new RolesBL().GetAllRoles(), "RoleID", "Role1");
            roleModel.Users = new SelectList(new UsersBL().GetUsers(), "Email", "Email");
            return View(roleModel);
        }

        //
        // GET: /Role/Details/5
        [Authorize(Roles = "Read Roles")]
        public ActionResult Details(int id)
        {
            Role r = new RolesBL().GetRoleByID(id);
            return View(new RoleModel(r.RoleID));
        }
       

        //
        // GET: /Role/Create
        [Authorize(Roles = "Add Roles")]
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Role/Create

        [HttpPost]
        public ActionResult Create(RoleModel model)
        {
            try
            {
                new RolesBL().AddRole(model.Name);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Role/Edit/5
        [Authorize(Roles = "Edit Role")]
        public ActionResult Edit(int id)
        {
            Role r = new RolesBL().GetRoleByID(id);
            return View(new RoleModel(r.RoleID));
        }

        //
        // POST: /Role/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, RoleModel model)
        {
            try
            {
                // TODO: Add update logic here

                new RolesBL().UpdateRole(model.ID, model.Name);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Role/Delete/5
        [Authorize(Roles = "Delete Role")]
        public ActionResult Delete(int id)
        {
            new RolesBL().DeleteRole(id);
            return RedirectToAction("Index", "Role");
        }

        //
        // POST: /Role/Delete/5

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
