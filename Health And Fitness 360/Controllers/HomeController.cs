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
            Session["MedicalDetails"] = "";
            if (ModelState.IsValid && emailId.Length > 0 && password.Length > 0)
            {
                UserInfoBL userInfoBL = new UserInfoBL();
                UserInfoDO userInfo = userInfoBL.GetUser(emailId, GetMD5(password));
                if (userInfo!=null)
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
            Session["MedicalDetails"] = "";
            if (ModelState.IsValid)
            {
                // Add user info
                UserInfoBL userInfoBL = new UserInfoBL();
                userInfoDO.Password = GetMD5(userInfoDO.Password);
                CustomDO customDO = userInfoBL.AddUser(userInfoDO);

                // Add user health info
                UserHealthInfoBL userHealthInfo = new UserHealthInfoBL();
                UserHealthInfoDO userHealthInfoDO = new UserHealthInfoDO();
                userHealthInfoDO.EmailId = userInfoDO.EmailId;
                userHealthInfoDO.CurrentCalories = 0;
                userHealthInfoDO.MenstrualCycleDuration = 28;
                userHealthInfoDO.PeriodDate = DateTime.Today.Date;
                userHealthInfoDO.PregnancyDate = DateTime.Today.Date;
                userHealthInfoDO.StartDateM1 = DateTime.Today.Date;
                userHealthInfoDO.StartDateM2 = DateTime.Today.Date;
                CustomDO customDO1 = userHealthInfo.AddUserHealthInfo(userHealthInfoDO);
                
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
            this.MonitorHealthHelper();

            //Regular Fitness
            this.RegularFitnessHelper();

            //Energy Indicator
            this.EnergyIndicatorHelper();

            //Menstrual Cycle And Fertility Tracker
            this.MenstrualCycleAndFertilityTracker();

            //Pregnancy Tracker
            this.PregnancyTrackerHelper();

            //Search specific symptoms or diseases
            
            if (!(Session["MedicalDetails"].ToString().Equals("")))
            {
                string[] medicalDetails = Session["MedicalDetails"].ToString().Split(',');
                if (medicalDetails.Length > 1)
                {
                    ViewBag.SymptomName = medicalDetails[0];
                    ViewBag.Medication = medicalDetails[1];
                    ViewBag.Test = medicalDetails[2];
                    ViewBag.Cure = medicalDetails[3];
                }
                else
                {
                    ViewBag.SymptomName = "Unable to Find. Please try with some other Symptom/Disease";
                    ViewBag.Medication = "Unable to Find. Please try with some other Symptom/Disease";
                    ViewBag.Test = "Unable to Find. Please try with some other Symptom/Disease";
                    ViewBag.Cure = "Unable to Find. Please try with some other Symptom/Disease";
                }
            }

            //Medicine Tracker
            this.MedicineTrackingHelper();
                return View();
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HealthMonitor(FormCollection formCollection)
        {
            string height = formCollection["Height"];
            string weight = formCollection["Weight"];
            if (height.Length > 0 && weight.Length > 0)
            {

                UserInfoDO userInfo = Session["UserInfo"] as UserInfoDO;
                userInfo.UserHeight = height;
                userInfo.UserWeight = weight;
                UserInfoBL userInfoBL = new UserInfoBL();
                CustomDO customDO = userInfoBL.UpdateUserInfo(userInfo);
            }
            return RedirectToAction("DashBoard");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EnergyIndicator(FormCollection formCollection)
        {
            string amount = formCollection["Amount"];
            string item = formCollection["FoodItems"];
            UserInfoDO userInfo = Session["UserInfo"] as UserInfoDO;
            List<FoodItemsDO> FoodItemList = Session["foodItemList"] as List<FoodItemsDO>;
            UserHealthInfoBL userHealthInfo = new UserHealthInfoBL();
            UserHealthInfoDO userHealthInfoDO = userHealthInfo.GetUserHealthInfo(userInfo.EmailId);
            FoodItemsDO fooditem = FoodItemList.FirstOrDefault(x => x.FoodItems.Equals(item));
            userHealthInfoDO.CurrentCalories += fooditem.Calories * Convert.ToInt32(amount);
            CustomDO customDO = userHealthInfo.UpdateUserHealthInfo(userHealthInfoDO);
            return RedirectToAction("DashBoard");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MenstrualAndFertilityTracker(FormCollection formCollection)
        {
            DateTime StartDate = Convert.ToDateTime(formCollection["MenstrualStartDate"]);
            int monthlyCycle = Convert.ToInt32(formCollection["MonthlyCycle"]);
            UserInfoDO userInfo = Session["UserInfo"] as UserInfoDO;
            UserHealthInfoBL userHealthInfo = new UserHealthInfoBL();
            UserHealthInfoDO userHealthInfoDO = userHealthInfo.GetUserHealthInfo(userInfo.EmailId);
            userHealthInfoDO.PeriodDate = StartDate;
            userHealthInfoDO.MenstrualCycleDuration = monthlyCycle;
            CustomDO customDO = userHealthInfo.UpdateUserHealthInfo(userHealthInfoDO);
            return RedirectToAction("DashBoard");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PregnancyTracker(FormCollection formCollection)
        {
            DateTime StartDate = Convert.ToDateTime(formCollection["PregnancyDate"]);
            UserInfoDO userInfo = Session["UserInfo"] as UserInfoDO;
            UserHealthInfoBL userHealthInfo = new UserHealthInfoBL();
            UserHealthInfoDO userHealthInfoDO = userHealthInfo.GetUserHealthInfo(userInfo.EmailId);
            userHealthInfoDO.PregnancyDate = StartDate;
            CustomDO customDO = userHealthInfo.UpdateUserHealthInfo(userHealthInfoDO);
            return RedirectToAction("DashBoard");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchSymptom(FormCollection formCollection)
        {
            string symptom = formCollection["Symptoms"];
            UserInfoDO userInfo = Session["UserInfo"] as UserInfoDO;
            SymptomsOrDiseaseBL symptomsOrDisease = new SymptomsOrDiseaseBL();
            SymptomsOrDiseaseDO symptomsOrDiseaseDO = symptomsOrDisease.GetSymptomsOrDiseaseDetails(symptom);
            if (symptomsOrDiseaseDO !=null && symptomsOrDiseaseDO.SymptomsOrDiseaseName != null)
                Session["MedicalDetails"] = symptomsOrDiseaseDO.SymptomsOrDiseaseName + "," + symptomsOrDiseaseDO.Medication + "," + symptomsOrDiseaseDO.Tests + "," + symptomsOrDiseaseDO.Cure;
            else
                Session["MedicalDetails"] = "None";
            return RedirectToAction("DashBoard");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MedicationTracker(FormCollection formCollection)
        {
            string medicine1 = formCollection["Medication1"];
            string medicine2 = formCollection["Medication2"];
            UserInfoDO userInfo = Session["UserInfo"] as UserInfoDO;
            UserHealthInfoBL userHealthInfo = new UserHealthInfoBL();
            UserHealthInfoDO userHealthInfoDO = userHealthInfo.GetUserHealthInfo(userInfo.EmailId);
            if (medicine1 != null && medicine1.Length > 0)
            {
                userHealthInfoDO.Medication1 = medicine1;
                userHealthInfoDO.StartDateM1 = Convert.ToDateTime(formCollection["StartDateM1"]);
                userHealthInfoDO.DurationM1 = Convert.ToInt32(formCollection["DurationM1"]);
            }
            if (medicine2 != null && medicine2.Length > 0)
            {
                userHealthInfoDO.Medication2 = medicine2;
                userHealthInfoDO.StartDateM2 = Convert.ToDateTime(formCollection["StartDateM2"]);
                userHealthInfoDO.DurationM2 = Convert.ToInt32(formCollection["DurationM2"]);
            }
            CustomDO customDO = userHealthInfo.UpdateUserHealthInfo(userHealthInfoDO);
            return RedirectToAction("DashBoard");
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

        public void MonitorHealthHelper()
        {
            UserInfoBL userInfoBL = new UserInfoBL();
            UserInfoDO userInfo = Session["UserInfo"] as UserInfoDO;
            ViewBag.Name = userInfo.UserName;
            double height = Convert.ToDouble(userInfo.UserHeight);
            double weight = Convert.ToDouble(userInfo.UserWeight);
            int age = Convert.ToInt32(userInfo.UserAge);
            string StatusMonitorHealth = userInfoBL.BMICalculation(height, weight, age);
            String[] strlist = StatusMonitorHealth.Split();
            ViewBag.Status = strlist[0];
            ViewBag.BMI = strlist[1];

        }

        public void RegularFitnessHelper()
        {
            AgeGrpWorkoutBL ageGrpWorkoutBL = new AgeGrpWorkoutBL();
            AgeGrpWorkoutDO ageGrpWorkout = Session["ageGrpWorkout"] as AgeGrpWorkoutDO;
            int currentPlan = Convert.ToInt32(ageGrpWorkout.Workout_Plan.Last().ToString());
            string newPlanWorkout = ageGrpWorkoutBL.getModifiedPlan(0, Convert.ToInt32(ageGrpWorkout.Calories), currentPlan);
            ViewBag.Workout = "https://www.youtube.com/embed/" + newPlanWorkout;
        }

        public void EnergyIndicatorHelper()
        {
            UserInfoDO userInfo = Session["UserInfo"] as UserInfoDO;
            AgeGrpWorkoutDO ageGrpWorkout = Session["ageGrpWorkout"] as AgeGrpWorkoutDO;
            UserHealthInfoBL userHealthInfo = new UserHealthInfoBL();
            UserHealthInfoDO userHealthInfoDO = userHealthInfo.GetUserHealthInfo(userInfo.EmailId);
            int currentCalories = userHealthInfoDO.CurrentCalories ?? 0;
            int requiredCalories = Convert.ToInt32(ageGrpWorkout.Calories);
            double PercentageCalories = ((double)currentCalories / requiredCalories) * 100;
            double Calories = Math.Round(PercentageCalories);
            if (currentCalories <= requiredCalories)
            {
                ViewBag.Calories = Calories.ToString() + "%";
                ViewBag.NeedCalories = "You need to consume " + (requiredCalories - currentCalories).ToString() + " calories more to achieve daily goal.";
            }
            else
            {
                ViewBag.Calories = "100%";
                ViewBag.NeedCalories = "Congratulations you have completd your goal. Extra Calories :" + (currentCalories - requiredCalories).ToString() + " calories.";
            }
            FoodItemsBL foodItemsBL = new FoodItemsBL();
            List<FoodItemsDO> FoodItemList = foodItemsBL.GetFoodItems();
            List<string> items = new List<string>();

            List<SelectListItem> selectListItems1 = new List<SelectListItem>();
            List<SelectListItem> selectListItems2 = new List<SelectListItem>();
            int i = 1;
            foreach (FoodItemsDO foodItems in FoodItemList)
            {
                selectListItems1.Add(new SelectListItem { Text = foodItems.FoodItems, Value = foodItems.FoodItems });
                selectListItems2.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
                i++;
            }
            while (i <= 20)
            {
                selectListItems2.Add(new SelectListItem { Text = i.ToString(), Value = i.ToString() });
                i++;
            }
            selectListItems1.First().Selected = true;
            selectListItems2.First().Selected = true;

            ViewBag.FoodItems = selectListItems1;
            ViewBag.Amount = selectListItems2;
            Session["foodItemList"] = FoodItemList;
        }

        public void MenstrualCycleAndFertilityTracker()
        {
            UserInfoDO userInfo = Session["UserInfo"] as UserInfoDO;
            UserHealthInfoBL userHealthInfo = new UserHealthInfoBL();
            UserHealthInfoDO userHealthInfoDO = userHealthInfo.GetUserHealthInfo(userInfo.EmailId);
            DateTime MenstrualStartDate = (userHealthInfoDO.PeriodDate == null) ? DateTime.Today : ((DateTime)userHealthInfoDO.PeriodDate);
            int MensturalCycleDuration = (userHealthInfoDO.MenstrualCycleDuration == null) ? 28 : (int)userHealthInfoDO.MenstrualCycleDuration;
            ViewBag.MenstrualStartDate = MenstrualStartDate.ToShortDateString();
            ViewBag.MensturalCycleDuration = MensturalCycleDuration;
            DateTime EndDate = MenstrualStartDate.AddDays(MensturalCycleDuration);
            DateTime date1 = MenstrualStartDate.AddDays(MensturalCycleDuration - 16);
            DateTime date2 = MenstrualStartDate.AddDays(MensturalCycleDuration - 15);
            DateTime date3 = MenstrualStartDate.AddDays(MensturalCycleDuration-14);
            ViewBag.FertilityDays = date1.ToShortDateString() + ", " + date2.ToShortDateString() + " and " + date3.ToShortDateString();
            ViewBag.TodayDay = (DateTime.Today.Date - MenstrualStartDate.Date).TotalDays;
            ViewBag.LeftDay = MensturalCycleDuration - (DateTime.Today.Date - MenstrualStartDate.Date).TotalDays;
            
        }

        public void PregnancyTrackerHelper()
        {
            UserInfoDO userInfo = Session["UserInfo"] as UserInfoDO;
            UserHealthInfoBL userHealthInfo = new UserHealthInfoBL();
            UserHealthInfoDO userHealthInfoDO = userHealthInfo.GetUserHealthInfo(userInfo.EmailId);
            DateTime pregnancyDate = (userHealthInfoDO.PregnancyDate == null) ? DateTime.Today : ((DateTime)userHealthInfoDO.PregnancyDate);
            string[] pregnancyPlan = userHealthInfo.GetPregnancyPlan(pregnancyDate).Split();
            int week = Convert.ToInt32(pregnancyPlan[0]);
            ViewBag.PregnancyWorkout = "https://www.youtube.com/embed/" + pregnancyPlan[1];
            ViewBag.PregnancyWeek = week;
            ViewBag.PregnancyWeekLeft = 40 - week;
            
        }

        public void MedicineTrackingHelper()
        {
            UserInfoDO userInfo = Session["UserInfo"] as UserInfoDO;
            UserHealthInfoBL userHealthInfo = new UserHealthInfoBL();
            UserHealthInfoDO userHealthInfoDO = userHealthInfo.GetUserHealthInfo(userInfo.EmailId);
            string medication1 = userHealthInfoDO.Medication1;
            string medication2 = userHealthInfoDO.Medication2;
            int duration1 = userHealthInfoDO.DurationM1 ?? 0;
            int duration2 = userHealthInfoDO.DurationM2 ?? 0;
            DateTime startDateM1 = userHealthInfoDO.StartDateM1 ?? DateTime.Today;
            DateTime startDateM2 = userHealthInfoDO.StartDateM2 ?? DateTime.Today;
            ViewBag.Medication1 = "Congratulations you are safe. No medicines required.";
            string msg1 = "";
            string msg2 = "";
            if (medication1 !=null && medication1.Length>0 && duration1!= 0)
            {
                if(DateTime.Today.Date>startDateM1.AddDays(duration1))
                {
                    msg1 = "Congratulations you have completed your Medicine " + medication1 + ". You are now completely recovered.";
                }
                else
                {
                    double completedDays= (DateTime.Today.Date - startDateM1.Date).TotalDays;
                    string leftDays = (duration1- completedDays).ToString();
                    msg1 = "You have successfully completed medicine " + medication1 + " for " + completedDays.ToString() + " days and only " + leftDays + " days more to go.";
                }
            }
            if (medication2 != null && medication2.Length > 0 && duration2!=0)
            {
                if (DateTime.Today.Date > startDateM2.AddDays(duration2))
                {
                    msg2 = "Congratulations you have completed your Medicine "+ medication2+". You are now completely recovered.";
                }
                else
                {
                    double completedDays = (DateTime.Today.Date - startDateM2.Date).TotalDays;
                    string leftDays = (duration2 - completedDays).ToString();
                    msg2 = "You have successfully completed medicine " + medication2 + " for " + completedDays.ToString() + " days and only " + leftDays + " days more to go.";
                }
            }
            if (msg1.Length > 0 && msg2.Length>0)
            {
                ViewBag.Medication1 = msg1;
                ViewBag.Medication2 = msg2 + " Don't worry you will be fine.";
            }
            else if(msg1.Length > 0)
            {
                ViewBag.Medication1 = msg1 + " Don't worry you will be fine.";
            }
            else if (msg2.Length > 0)
            {
                ViewBag.Medication2 = msg2 + " Don't worry you will be fine.";
            }

        }
    }
}