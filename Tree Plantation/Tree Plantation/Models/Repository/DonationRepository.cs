using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tree_Plantation.Models.Repository
{
    public class DonationRepository
    {
        static tree_plantation_dbEntities db;

        static DonationRepository()
        {
            db = new tree_plantation_dbEntities();
        }

        public static List<donation> GetAll()
        {
            var entity = db.donations.ToList();
            return entity;
        }

    }
}