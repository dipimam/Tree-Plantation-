using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tree_Plantation.BModel;
using Tree_Plantation.Models.Repository;

namespace Tree_Plantation.Controllers
{

    [Authorize]
    public class VolunteerController : Controller
    {
        // GET: Volunteer
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddVolunteer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddVolunteer(AddVolunteer volunteer)
        {
            if(ModelState.IsValid)
            {
                VolunteerRepository.AddVolunteer(volunteer);
                return RedirectToAction("Index","Admin");
            }
            return View();
        }
    }
}