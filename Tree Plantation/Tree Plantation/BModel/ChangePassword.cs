using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tree_Plantation.BModel
{
    public class ChangePassword
    {
        [Required]
        public string r_password { get; set; }
        [Required]
        public string n_password { get; set; }
        [Required]
        public string c_password { get; set; }

    }
}