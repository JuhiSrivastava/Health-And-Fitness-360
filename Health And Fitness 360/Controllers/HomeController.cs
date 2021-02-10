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
                UserInfoBL userInfoBL = new UserInfoBL();
                UserInfoDO userInfo = userInfoBL.GetUser(emailId, GetMD5(password));
                if (userInfo.EmailId != null)
                {
                    Session["UserInfo"] = userInfo;
                    AgeGrpWorkoutDO ageGrpWorkout = this.HelperRegularFitness(userInfo.UserAge);
                    Session["ageGrpWorkout"] = ageGrpWorkout;
                    return RedirectToAction("DashBoard");
                }
                else
                {
                    ViewBag.ErrorMessage = "Login failed";
                    return View();
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
                Session["UserInfo"] = userInfoDO;
                AgeGrpWorkoutDO ageGrpWorkout = this.HelperRegularFitness(userInfoDO.UserAge);
                Session["ageGrpWorkout"] = ageGrpWorkout;
                return RedirectToAction("DashBoard");
            }
            return View(userInfoDO);
        }


        //GET: DashBoard

        public ActionResult DashBoard()
        {
            //Monitor Health
            UserInfoBL userInfoBL = new UserInfoBL();
            UserInfoDO userInfo = Session["UserInfo"] as UserInfoDO;
            double height = Convert.ToDouble(userInfo.UserHeight);
            double weight = Convert.ToDouble(userInfo.UserWeight);
            int age = Convert.ToInt32(userInfo.UserAge);
            string StatusMonitorHealth = userInfoBL.BMICalculation(height,weight,age);
            String[] strlist = StatusMonitorHealth.Split();
            ViewBag.Status = strlist[0];
            ViewBag.BMI = strlist[1];

            //Regular Fitness
            AgeGrpWorkoutBL ageGrpWorkoutBL = new AgeGrpWorkoutBL();
            AgeGrpWorkoutDO ageGrpWorkout = Session["ageGrpWorkout"] as AgeGrpWorkoutDO;
            int currentPlan = Convert.ToInt32(ageGrpWorkout.Workout_Plan.Last().ToString());
            string newPlanWorkout = ageGrpWorkoutBL.getModifiedPlan(0, Convert.ToInt32(ageGrpWorkout.Calories), currentPlan);
            ViewBag.Workout = "https://www.youtube.com/embed/" + newPlanWorkout;

            //Energy Indicator
            int currentCalories = 0;
            int requiredCalories = Convert.ToInt32(ageGrpWorkout.Calories);
            double PercentageCalories = (currentCalories/ requiredCalories)*100;
            double Calories = Math.Round(PercentageCalories);
            //ProgressText.InnerText = Calories.ToString() + "%";
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

        public AgeGrpWorkoutDO HelperRegularFitness(int age)
        {
            //Regular Fitness
            AgeGrpWorkoutBL ageGrpWorkoutBL = new AgeGrpWorkoutBL();
            AgeGrpWorkoutDO ageGrpWorkout = ageGrpWorkoutBL.GetAgrGrpWorkout(age);
            return ageGrpWorkout;
        }
    }
}