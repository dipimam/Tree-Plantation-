using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using Tree_Plantation.BModel;

namespace Tree_Plantation.Models.Repository
{
    public class AdminRepository
    {
        static tree_plantation_dbEntities db;

        static AdminRepository()
        {
            db = new tree_plantation_dbEntities();
        }

        public static authentication Authenticaion(string email, string password)
        {
            var entity = db.authentications.FirstOrDefault(a => a.a_email == email && a.a_password == password);

            return entity;
        }
        public static void ChangePassword(string email,string password)
        {
            var entity = db.authentications.FirstOrDefault(a => a.a_email == email);

            if (entity != null)
            {
                entity.a_password = password;
                db.SaveChanges();
            }
        }

        public static admin Get(string email)
        {
            var entity = db.admins.FirstOrDefault(a => a.a_email == email);

            return entity;
        }

        public static void ChangePicture(string email,string image)
        {
            var entity = db.admins.FirstOrDefault(a => a.a_email == email);

            if (entity != null)
            {
                entity.a_image = image;
                db.SaveChanges();
            }
            
        }

        public static void ChangeInformation(string email, ChangeInformation entity)
        {
            var x = db.admins.FirstOrDefault(a => a.a_email == email);

            if (x != null)
            {
                x.a_name = entity.a_name;
                x.a_phone = entity.a_phone;
                x.a_address= entity.a_address;
                

                try
                {
                    // Your code...
                    // Could also be before try if you know the exception occurs in SaveChanges

                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }

        }
    }
}



//D:\\Semester\\Nineth semester\\Asp.net project\\Tree plantation\\Tree Plantation\\Tree Plantation\\Image\\_107317099_blooddonor976214411443.jpg