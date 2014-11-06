using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;
using System.ComponentModel.DataAnnotations;

namespace Traders_Marketplace.Models
{
    public class UserModel
    {
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid e-mail adress")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(10, ErrorMessage = "Password Must between 6 and 10 characters long", MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Invalid Name")]
        public string Firstname { get; set; }

        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Invalid Name")]
        [DataType(DataType.Text)]
        public string Lastname { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Town")]
        public int TownID { get; set; }


        [Required]
        [RegularExpression(@"^[0-9]{8,10}$", ErrorMessage = "Invalid Phone number")]
        public string ContactNo { get; set; }

        public TradersMarketplaceDBEntities myUsers { get; set; }
    }
}