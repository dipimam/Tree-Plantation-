using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tree_Plantation.BModel
{
    public class Bvolunteer
    {
        public int v_id { get; set; }
        public string v_name { get; set; }
        public string v_email { get; set; }
        public Nullable<int> v_phone { get; set; }
        public string v_address { get; set; }
        public string v_image { get; set; }
    }
}