using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common;
using BusinessLogic;
using Traders_Marketplace.Models;

namespace Traders_Marketplace.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Order()
        {
            return View();
        } 


        //
        // GET: /User
        [Authorize(Roles = "List Users")]
        public ActionResult Index()
        {
           
            var entities = new TradersMarketplaceDBEntities();

            return View(entities.Users.ToList());
            
        }

        //
        // GET: /User/Details/5
        [Authorize(Roles = "Read Users")]
        public ActionResult Details(string id)
        {
            User u = new UsersBL().GetUserByEmail(id);
            return View(new UserModel(u.Email));
        }

        //
        // GET: /User/Create
        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /User/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /User/Edit/5
        [Authorize(Roles = "Edit User")]
        public ActionResult Edit(string id)
        {
            User u = new UsersBL().GetUserByEmail(id);
            return View(new UserModel(u.Email));
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection, UserModel model)
        {
            try
            {
                User u = new UsersBL().GetUserByEmail(id);
                // TODO: Add update logic here
                new UsersBL().UpdateUser(model.Email,model.Password,model.Firstname,model.Lastname,model.Address,Convert.ToInt32(u.TownID), model.ContactNo) ;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Delete/5
        [Authorize(Roles = "Delete User")]
        public ActionResult Delete(string id)
        {
            try
            {
                new UsersBL().DeleteUser(id);
                ViewBag.Msg = "User was Deleted";
            }
            catch(Exception)
            {
                ViewBag.Msg = "Please Deallocate Roles First";

            }
            return View();
        }

        //
        // POST: /User/Delete/5

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
