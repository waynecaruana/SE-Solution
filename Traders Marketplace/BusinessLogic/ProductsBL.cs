using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using DataAccess;
using System.Web;



namespace BusinessLogic
{
    public class ProductsBL
    {

        /// <summary>
        /// this method will return a list of products
        /// </summary>
        /// <returns>a list of products</returns>
        public IEnumerable<Product> GetAllProducts()
        {
            return new ProductsRepository().GetAllProducts();
        }


        /// <summary>
        /// This method will add a product to DB
        /// </summary>
        /// <param name="name">product name</param>
        /// <param name="desc">product description</param>
        /// <param name="image">product image</param>
        /// <param name="stock">product quantity in stock</param>
        /// <param name="price">product price</param>
        public void AddProduct(string name, string desc, string image, int stock, decimal price, string email)
        {
       

            User u = new UsersRepository().GetUserByUsername(email);
            
            Product p =  new Product();
            p.Name = name;
            p.Description = desc;
            p.ImagePath = image;
            p.Stock = stock;
            p.Price = price;
            p.DateListed = DateTime.Now.Date;
            p.UserEmail = u.Email;

            new ProductsRepository().AddProduct(p);

        }

        /// <summary>
        /// Get a Product By id
        /// </summary>
        /// <param name="id">product id</param>
        /// <returns>a single product</returns>
        public Product GetProductByID(int id)
        {
            return new ProductsRepository().GetProductByID(id);
        }

        /// <summary>
        /// A method to update a product
        /// </summary>
        /// <param name="name">product name</param>
        /// <param name="desc">product description</param>
        /// <param name="image">product image</param>
        /// <param name="stock">product stock</param>
        /// <param name="price">product price</param>
        /// <param name="email">user email</param>
        public void UpdateProduct(int id, string name, string desc, string image, int stock, decimal price, string email)
        {
            User u = new UsersRepository().GetUserByUsername(email);

            Product p = new Product();
            p.ID = id;
            p.Name = name;
            p.Description = desc;
            p.ImagePath = image;
            p.Stock = stock;
            p.Price = price;
            p.DateListed = DateTime.Now.Date;
            p.UserEmail = email;

            new ProductsRepository().UpdateProduct(p);
        }

        /// <summary>
        /// This method is used to delete a product
        /// </summary>
        /// <param name="id">product id</param>
        public void DeleteProduct(int id)
        {
            ProductsRepository pr = new ProductsRepository();
            Product product = pr.GetProductByID(id);//get the user by username
            pr.DeleteProduct(product);
        }


        /// <summary>
        /// this method is used to get all products for a seller
        /// </summary>
        /// <param name="email">seller email</param>
        /// <returns>a list of products</returns>
        public IEnumerable<Product> GetSellerProducts(string email)
        {
            return new ProductsRepository().GetSellerProducts(email);
        }
    }
}
