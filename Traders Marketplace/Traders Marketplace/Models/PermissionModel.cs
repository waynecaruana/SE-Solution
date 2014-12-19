using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Common;
using BusinessLogic;

namespace Traders_Marketplace.Models
{
    public class PermissionModel
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Display(Name = "Permissions: ")]
        public IEnumerable<SelectListItem> Permissions { get; set; }
        public int SelectedPermission { get; set; }

        [Display(Name = "Users: ")]
        public IEnumerable<SelectListItem> Roles { get; set; }
        public int SelectedRole { get; set; }

        public string SelectedOption { get; set; }

        public PermissionModel(int id)
        {
            Permission r = new PermissionsBL().GetPermissionByID(id);

            ID = r.ID;
            Name = r.Name;
            Description = r.Description;
        }

        public PermissionModel()
        {
        }
    }
}