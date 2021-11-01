using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Tree_Plantation.BModel;
using Tree_Plantation.Models;
using Tree_Plantation.Models.Repository;

namespace Tree_Plantation.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
       
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(AdminLogin admin)
        {
            if (ModelState.IsValid)
            {
               var entity= AdminRepository.Authenticaion(admin.a_email, admin.a_password);

                if(entity !=null)
                {
                    FormsAuthentication.SetAuthCookie(admin.a_email, false);
                    var v = AdminRepository.Get(admin.a_email);

                    Session["name"] = v.a_name;
                    Session["image"] = v.a_image;

                    return RedirectToAction("Index");
                }
                ViewBag.error = "Email not found or Incorrect Password";

                return View();
               
            }
            return View();
        }

        public ActionResult ChangePicture()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePicture(ChangePicture imageModel)
        {
           if(imageModel.ImageFile!=null)
            {
                string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
                string extension = Path.GetExtension(imageModel.ImageFile.FileName);

                if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
                {
                    fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                    imageModel.ImagePath = "~/Image/" + fileName;
                    fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
                    imageModel.ImageFile.SaveAs(fileName);

                    AdminRepository.ChangePicture(HttpContext.User.Identity.Name, imageModel.ImagePath);
                    Session["image"] = imageModel.ImagePath;

                    ModelState.Clear();

                    return RedirectToAction("Index");
                }


                ViewBag.error = "Please choose a file jpg,png,jpeg format";

                return View();
               
            }
            ViewBag.error = "Please choose an image first";
            return View();
        }


        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public  ActionResult ChangePassword(ChangePassword password)
        {
            if(ModelState.IsValid)
            {
                var entity = AdminRepository.Authenticaion(HttpContext.User.Identity.Name,password.r_password);

              

                if (entity!=null)
                {
                    if(password.n_password == password.c_password)
                    {
                        AdminRepository.ChangePassword(HttpContext.User.Identity.Name, password.n_password);

                        Session.Clear();
                        FormsAuthentication.SignOut();


                        return RedirectToAction("Login");
                    }
                    ViewBag.c_password = "New Password and Confrim Password have to be same";
                    return View();
                }

               
                ViewBag.r_password = "Wrong Password";
                return View();
            }
            return View();
        }

        public ActionResult ChangeInformation()
        {
            var entity= AdminRepository.Get(HttpContext.User.Identity.Name);

            return View(entity);
        }
        [HttpPost]
        public ActionResult ChangeInformation(admin entity)
        {
            ChangeInformation changeInformation = new ChangeInformation();
            changeInformation.a_name = entity.a_name;
            changeInformation.a_phone = Convert.ToInt32(entity.a_phone);
            changeInformation.a_address = entity.a_address;

            AdminRepository.ChangeInformation(HttpContext.User.Identity.Name, changeInformation);

            return RedirectToAction("Index");
        }
        public ActionResult SignOut()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            

            return RedirectToAction("Login");
        }
    }
}