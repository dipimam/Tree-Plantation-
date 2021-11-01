using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tree_Plantation.BModel;

namespace Tree_Plantation.Models.Repository
{
    public class AssignmentRepository
    {
        static tree_plantation_dbEntities db;

        static AssignmentRepository()
        {
            db = new tree_plantation_dbEntities();
        }

        public static List<volunteer> GetAll()
        {
            var entity = db.volunteers.ToList();

            return entity;
        }

        public static volunteer Get(int id)
        {
            var entity = db.volunteers.FirstOrDefault(v=> v.v_id==id);

            return entity;
        }

        public static void ArrangeCampaign(ArrangeCampaign entity,string time)
        {
            var a = new assignment();

           
            a.amount = entity.amount;
            a.deadline = entity.deadline;
            a.tree_number = entity.tree_number;
            a.a_id = 1;
            a.status = "processing";
            a.time= time;
            db.assignments.Add(a);
            db.SaveChanges();



        }

        public static void AssignedVolunteer(List<volunteer> volunteers, string time)
        {
            var volunteeradd = db.assignments.FirstOrDefault(v => v.time == time);

            assigned assin = null;

            foreach (var item in volunteers)
            {
                assin = new assigned();
                assin.v_id = item.v_id;
                assin.ass_id = volunteeradd.ass_id;
                db.assigneds.Add(assin);
                db.SaveChanges();

            }
            
        }
    }
}