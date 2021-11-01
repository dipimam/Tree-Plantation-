using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tree_Plantation.BModel
{
    public class ArrangeCampaign
    {
        public int a_id { get; set; }
        [Required]
        public int amount { get; set; }
        [Required]
        public string deadline { get; set; }
        [Required]
        public int tree_number { get; set; }
      
       
      
    }
}