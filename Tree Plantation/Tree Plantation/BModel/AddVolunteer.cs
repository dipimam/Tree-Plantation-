using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tree_Plantation.BModel
{
    public class AddVolunteer
    {
        [Required]
        public string v_name { get; set; }
        [Required]
        public string v_email { get; set; }
        [Required]
        public Nullable<int> v_phone { get; set; }
        [Required]
        public string v_address { get; set; }

        [Required]
        public string n_password { get; set; }
        [Required]
        [Compare("n_password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string c_password { get; set; }


    }
}