using Business_Logic;
using Model_Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Health_And_Fitness_360.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(UserInfoDO userInfoDO)
        {
            if(ModelState.IsValid)
            {
                UserInfoBL userInfoBL = new UserInfoBL();
                CustomDO customDO = userInfoBL.AddUser(userInfoDO);
                return RedirectToAction("Index");
            }
            return View(userInfoDO);
        }
    }
}