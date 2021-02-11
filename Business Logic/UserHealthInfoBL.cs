using Model_Object;
using Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic
{
    public class UserHealthInfoBL
    {
        public CustomDO AddUserHealthInfo(UserHealthInfoDO userHealthInfo)
        {
            userHealthInfo = this.UpdateCalorie(userHealthInfo);
            userHealthInfo.EmailId = UserInfoBL.EncodeItemToBase64(userHealthInfo.EmailId);
            CustomDO custom = new UserHealthInfoDAL().AddUserHealthInfo(userHealthInfo);
            userHealthInfo.EmailId = UserInfoBL.DecodeFrom64(userHealthInfo.EmailId);
            return custom;
        }
        public UserHealthInfoDO GetUserHealthInfo(string emailId)
        {
            emailId = UserInfoBL.EncodeItemToBase64(emailId);
            UserHealthInfoDO userHealthInfo = new UserHealthInfoDAL().GetUserHealthInfo(emailId);
            userHealthInfo.EmailId = UserInfoBL.DecodeFrom64(userHealthInfo.EmailId);
            return userHealthInfo;
        }
        public CustomDO UpdateUserHealthInfo(UserHealthInfoDO modifiedUserHealthInfo)
        {
            modifiedUserHealthInfo = this.UpdateCalorie(modifiedUserHealthInfo);
            modifiedUserHealthInfo.EmailId = UserInfoBL.EncodeItemToBase64(modifiedUserHealthInfo.EmailId);
            CustomDO custom = new UserHealthInfoDAL().UpdateUserHealthInfo(modifiedUserHealthInfo);
            modifiedUserHealthInfo.EmailId = UserInfoBL.DecodeFrom64(modifiedUserHealthInfo.EmailId);
            return custom;
        }

        public UserHealthInfoDO UpdateCalorie(UserHealthInfoDO userHealthInfo)
        {
            if (DateTime.Today.DayOfWeek == DayOfWeek.Sunday)
            {
                userHealthInfo.Calories_Day_1 = userHealthInfo.CurrentCalories;
            }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Monday)
            {
                userHealthInfo.Calories_Day_2 = userHealthInfo.CurrentCalories;
            }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Tuesday)
            {
                userHealthInfo.Calories_Day_3 = userHealthInfo.CurrentCalories;
            }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Wednesday)
            {
                userHealthInfo.Calories_Day_4 = userHealthInfo.CurrentCalories;
            }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Thursday)
            {
                userHealthInfo.Calories_Day_5 = userHealthInfo.CurrentCalories;
            }
            else if (DateTime.Today.DayOfWeek == DayOfWeek.Friday)
            {
                userHealthInfo.Calories_Day_6 = userHealthInfo.CurrentCalories;
            }
            else
            {
                userHealthInfo.Calories_Day_7 = userHealthInfo.CurrentCalories;
            }
            return userHealthInfo;
        }
        public string GetPregnancyPlan(DateTime pregnancyDate)
        {
            int totalDays = (int)(DateTime.Today.Date - pregnancyDate).TotalDays;
            int week = 0;
            double totalWeek = (double)totalDays / 7;
            if (totalDays % 7 == 0)
                week = (int)totalWeek;
            else
                week = (int)totalWeek + 1;

            string pregnancyWorkout = week.ToString() + " ";
            if (week >=0 && week <=12)
                pregnancyWorkout += "1vjezAe_oCs";
            else if (week >= 13 && week <= 26)
                pregnancyWorkout += "6H5BP4QF_v8";
            else
                pregnancyWorkout += "BzANj0vepxI";

            return pregnancyWorkout;
        }
    }
}
