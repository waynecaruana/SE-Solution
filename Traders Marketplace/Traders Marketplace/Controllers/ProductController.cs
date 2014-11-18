using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogic;
using Traders_Marketplace.Models;
using System.IO;
using System.Web.UI.WebControls;
using Common;
using DataAccess;

namespace Traders_Marketplace.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        public ActionResult Index(ProductModel model)
        {
            List<Product> products = new List<Product>();

            User u = new UsersRepository().GetUserByUsername(model.Email);
            if (u != null)
            {

                foreach (var item in u.Roles)
                {
                    if (item.RoleID == 1)
                    {
                        products = new ProductsBL().GetAllProducts().ToList();
                    }
                    else if (item.RoleID == 3)
                    {
                        products = new ProductsBL().GetSellerProducts(model.Email).ToList();
                    }
                    else
                    {
                        products = new ProductsBL().GetAllProducts().ToList();
                    }
                }
            }
            else
            {
                products = new ProductsBL().GetAllProducts().ToList();
            }

           
            
            return View(products);
        }

        //
        // GET: /Product/Details/5

        public ActionResult Details(int id)
        {

            Product p = new ProductsBL().GetProductByID(id);
            return View(new ProductModel(p.ID));
        }

        //
        // GET: /Product/Create
        [Authorize(Roles = "Add Product")]
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
        [Authorize(Roles = "Edit Product")]
        public ActionResult Edit(int id)
        {
            Product p = new ProductsBL().GetProductByID(id);
            return View(new ProductModel(p.ID));
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, ProductModel model)
        {
            try
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
                // TODO: Add update logic here
                //Product p = new ProductsBL().GetProductByID(id);
                //new ProductModel(id);
                new ProductsBL().UpdateProduct(model.ID, model.Name, model.Desc, "/Content/Images/" + image.ToString(), Convert.ToInt32(model.Stock), Convert.ToDecimal(model.Price), model.Email);
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Product/Delete/5

        [Authorize(Roles = "Delete Product")]
        public ActionResult Delete(int id)
        {
            new ProductsBL().DeleteProduct(id);
            return RedirectToAction("Index","Product");
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
