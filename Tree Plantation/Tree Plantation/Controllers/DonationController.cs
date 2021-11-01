using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tree_Plantation.Models.Repository;

namespace Tree_Plantation.Controllers
{
    [Authorize]
    public class DonationController : Controller
    {
        // GET: Donation
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SeeDonations()
        {
            var entity = DonationRepository.GetAll();

            return View(entity);
        }
    }

}