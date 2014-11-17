using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using Common;

namespace Traders_Marketplace.Models
{
    public class ProductModel
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Desc { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string Email { get; set; }

        public TradersMarketplaceDBEntities myProducts { get; set; }

        //constructor
        public ProductModel()
        {
            Email = HttpContext.Current.User.Identity.Name;
        }
    }
}