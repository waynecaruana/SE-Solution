using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using Traders_Marketplace.Models;
using System.IO;
using System.Web.UI.WebControls;

namespace Traders_Marketplace.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            var products = new ProductsBL().GetAllProducts();
            return View(products);
        }

        //
        // GET: /Product/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Product/Create

        [HttpPost]
        public ActionResult Create(ProductModel model)
        {

            HttpPostedFileBase file = Request.Files[0];
            byte[] imageSize = new byte[file.ContentLength];
            file.InputStream.Read(imageSize, 0, (int)file.ContentLength);
            string image = file.FileName.Split('\\').Last();
            int size = file.ContentLength;

            if (size > 0)
            {
                file.SaveAs(Server.MapPath("~/Content/images/" + image.ToString()));
                //Save image url to database
            }
            else
            {
                image = "na.jpg";
            }

            try
            {
                new ProductsBL().AddProduct(model.Name, model.Desc, "/Content/Images/"+image.ToString(), model.Stock, model.Price, model.Email);

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                string ex = e.Message;
                return View();
            }
        }
        
        //
        // GET: /Product/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Product/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Product/Delete/5

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
