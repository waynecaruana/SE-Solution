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
    }
}
