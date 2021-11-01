using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tree_Plantation.BModel
{
    public class AdminLogin
    {
        [Required(ErrorMessage ="Please input the email first")]
        public string a_email { get; set; }

        [Required(ErrorMessage = "Please input the password")]
        public string a_password { get; set; }
       
    }
}