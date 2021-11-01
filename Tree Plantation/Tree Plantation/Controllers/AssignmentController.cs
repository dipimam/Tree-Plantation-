using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Tree_Plantation.BModel;
using Tree_Plantation.Models;
using Tree_Plantation.Models.Repository;

namespace Tree_Plantation.Controllers
{
    [Authorize]
    public class AssignmentController : Controller
    {
        // GET: Assignment
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ArrangeCampaign()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ArrangeCampaign(ArrangeCampaign campaign)
        {
            if(ModelState.IsValid)
            {
            
                var json = new JavaScriptSerializer().Serialize(campaign);
                Session["assignment"] = json;
                return RedirectToAction("AssignedVolunteer");
            }
            return View();
        }

        public ActionResult AssignedVolunteer()
        {
            var entity = AssignmentRepository.GetAll();

            return View(entity);
        }

        public ActionResult AddtoCampaign(int id)
        {
            var entity = AssignmentRepository.Get(id);

            Bvolunteer v = new Bvolunteer();
            v.v_id = entity.v_id;
            v.v_name = entity.v_name;
            v.v_email = entity.v_email;
            v.v_address = entity.v_address;
            v.v_image = entity.v_image;
            v.v_phone = entity.v_phone;

            bool flag = false;

               if (Session["volunteer"] == null)
               {

                   List<Bvolunteer> cartvolunteer= new List<Bvolunteer>();
                    cartvolunteer.Add(v);
                   var json = new JavaScriptSerializer().Serialize(cartvolunteer);
                   Session["volunteer"] = json;
                   return RedirectToAction("AssignedVolunteer");
               }
               else
               {
                   var cart = Session["volunteer"];
                   var cartvolunteer = new JavaScriptSerializer().Deserialize<List<Bvolunteer>>(cart.ToString());
                   foreach(var item in cartvolunteer)
                {
                    if(item.v_id==v.v_id)
                    {
                        flag = true;
                    }
                }
                   if(flag==false)
                {
                    cartvolunteer.Add(v);
                }
                    
                   var json = new JavaScriptSerializer().Serialize(cartvolunteer);
                   Session["volunteer"] = json;
                   return RedirectToAction("AssignedVolunteer");

               }
        }

        public ActionResult ShowCart()
        {
            if (Session["volunteer"] != null)
            {
                var cart = Session["volunteer"];
                var cartvolunteer = new JavaScriptSerializer().Deserialize<List<volunteer>>(cart.ToString());
                return View(cartvolunteer);
            }
            else
            {
                return View();
            }
        }

        public ActionResult ConfirmCampaign()
        {
            if (Session["volunteer"]!=null)
            {
                if(Session["assignment"]!=null)
                {
                    var time = DateTime.Now.ToString("h:mm:ss tt");

                    var cart = Session["volunteer"];
                    var cartvolunteer = new JavaScriptSerializer().Deserialize<List<volunteer>>(cart.ToString());

                    var assignment = Session["assignment"];
                    var cartassignment = new JavaScriptSerializer().Deserialize<ArrangeCampaign>(assignment.ToString());

                    AssignmentRepository.ArrangeCampaign(cartassignment, time);
                    AssignmentRepository.AssignedVolunteer(cartvolunteer, time);

                    return RedirectToAction("Index", "Admin");
                }
            }
            return RedirectToAction("Index", "Admin");
        }
    }
}