using Business_Logic;
using Model_Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Health_And_Fitness_360.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.ErrorMessage = "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string emailId, string password)
        {
            if (ModelState.IsValid && emailId.Length > 0 && password.Length > 0)
            {
                var f_password = GetMD5(password);

                //var data = _db.Users.Where(s => s.Email.Equals(email) && s.Password.Equals(f_password)).ToList();
                if (true)//data.Count() > 0)
                {
                    //add session
                    //Session["FullName"] = data.FirstOrDefault().FirstName + " " + data.FirstOrDefault().LastName;
                    //Session["Email"] = data.FirstOrDefault().Email;
                    //Session["idUser"] = data.FirstOrDefault().idUser;
                    return RedirectToAction("DashBoard");
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Login failed";
                return View();
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserInfoDO userInfoDO)
        {
            if(ModelState.IsValid)
            {
                UserInfoBL userInfoBL = new UserInfoBL();
                userInfoDO.Password = GetMD5(userInfoDO.Password);
                CustomDO customDO = userInfoBL.AddUser(userInfoDO);
                return RedirectToAction("DashBoard");
            }
            return View(userInfoDO);
        }


        //GET: DashBoard

        public ActionResult DashBoard()
        {
            return View();
        }
        
        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Index");
        }

        
        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

    }
}