using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tree_Plantation.BModel;

namespace Tree_Plantation.Models.Repository
{
    public class VolunteerRepository
    {
        static tree_plantation_dbEntities db;

        static VolunteerRepository()
        {
            db = new tree_plantation_dbEntities();
        }

        public static void AddVolunteer(AddVolunteer volunteer)
        {
            var entity = new volunteer();
            var authen = new authentication();


            entity.v_name = volunteer.v_name;
            entity.v_phone = volunteer.v_phone;
            entity.v_email = volunteer.v_email;
            entity.v_address = volunteer.v_address;


            authen.a_email = volunteer.v_email;
            authen.a_password = volunteer.c_password;
            authen.a_type = "volunteer";

            db.volunteers.Add(entity);
            db.authentications.Add(authen);
            db.SaveChanges();
        }
    }
}