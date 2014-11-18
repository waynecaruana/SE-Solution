using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace DataAccess
{
    public class ProductsRepository : ConnectionClass
    {
        public ProductsRepository(): base()
        {
        }

        /// <summary>
        /// This method is used to list all products
        /// </summary>
        /// <returns>a list of products</returns>
        public IEnumerable<Product> GetAllProducts()
        {
            return Entity.Products.AsEnumerable();
        }


        /// <summary>
        /// This method is used to add a product
        /// </summary>
        /// <param name="entry">a product enrty</param>
        public void AddProduct(Product entry)
        {

            Entity.AddToProducts(entry);
            Entity.SaveChanges();

        }


        /// <summary>
        /// This will get all product deatils by his id
        /// </summary>
        /// <param name="id">product id</param>
        /// <returns>a single product</returns>
        public Product GetProductByID(int id)
        {

            return Entity.Products.SingleOrDefault(p => p.ID == id);

        }

        /// <summary>
        /// get all products that belongs to a seller
        /// </summary>
        /// <param name="email">seller email</param>
        /// <returns>a list of products for a seller</returns>
        public IEnumerable<Product> GetSellerProducts(string email)
        {
            return Entity.Products.Where(p =>p.UserEmail == email);
        }

        /// <summary>
        /// This method allow us to update a product
        /// </summary>
        /// <param name="p">product</param>
        public void UpdateProduct(Product p)
        {
            Entity.Products.Attach(GetProductByID(p.ID));
            Entity.Products.ApplyCurrentValues(p);

            Entity.SaveChanges();
        }

        /// <summary>
        /// this method is used to delete a product
        /// </summary>
        /// <param name="entry">product</param>
        public void DeleteProduct(Product entry)
        {

            Entity.Products.DeleteObject(entry);
            Entity.SaveChanges();

        }
    }
}
