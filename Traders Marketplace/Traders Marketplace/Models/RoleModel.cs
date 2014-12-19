using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Common;
using BusinessLogic;
using System.Web.Mvc;


namespace Traders_Marketplace.Models
{
    public class RoleModel
    {

        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Roles: ")]
        public IEnumerable<SelectListItem> Roles { get; set; }
        public int SelectedRole { get; set; }

        [Display(Name = "Users: ")]
        public IEnumerable<SelectListItem> Users { get; set; }
        public string SelectedUser { get; set; }

        public string SelectedOption { get; set; }

        public RoleModel(int id)
        {
            Role r = new RolesBL().GetRoleByID(id);

            ID = r.RoleID;
            Name = r.Role1;
            
        }

        public RoleModel()
        {
        }
    }

    public class AllocateRoleModel
    {
    }

    
}