using Model_Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access
{
    public class UserHealthInfoDAL
    {
        private HealthAndFitnessDBEntities healthAndFitnessDBEntities;
        public UserHealthInfoDAL()
        {
            healthAndFitnessDBEntities = new HealthAndFitnessDBEntities();
        }

        public CustomDO AddUserHealthInfo(UserHealthInfoDO userHealthInfo)
        {
            CustomDO custom = new CustomDO();
            UserHealthInfo userHealth = new UserHealthInfo()
            {
            EmailId = userHealthInfo.EmailId,
            Calories_Day_1 = userHealthInfo.Calories_Day_1,
            Calories_Day_2 = userHealthInfo.Calories_Day_2,
            Calories_Day_3 = userHealthInfo.Calories_Day_3,
            Calories_Day_4 = userHealthInfo.Calories_Day_4,
            Calories_Day_5 = userHealthInfo.Calories_Day_5,
            Calories_Day_6 = userHealthInfo.Calories_Day_6,
            Calories_Day_7 = userHealthInfo.Calories_Day_7,
            CurrentCalories = userHealthInfo.CurrentCalories,
            PeriodDate = userHealthInfo.PeriodDate,
            FertilityDate = userHealthInfo.FertilityDate,
            Medication1 = userHealthInfo.Medication1,
            StartDateM1 = userHealthInfo.StartDateM1,
            DurationM1 = userHealthInfo.DurationM1,
            Medication2 = userHealthInfo.Medication2,
            StartDateM2 = userHealthInfo.StartDateM2,
            DurationM2 = userHealthInfo.DurationM2
            };
            healthAndFitnessDBEntities.UserHealthInfoes.Add(userHealth);
            int returnVal = healthAndFitnessDBEntities.SaveChanges();
            custom.CustomId = returnVal;
            if (returnVal > 0)
            {
                custom.CustomMessage = "Data Successfully Added";
            }
            else
            {
                custom.CustomMessage = "Unable to Add User";
            }
            return custom;
        }

        public UserHealthInfoDO GetUserHealthInfo(string emailId)
        {
            UserHealthInfoDO userHealthInfo = new UserHealthInfoDO();
            UserHealthInfo userHealth = healthAndFitnessDBEntities.UserHealthInfoes.FirstOrDefault(x => x.EmailId.Equals(emailId));
            if (userHealth != null)
            {
                userHealthInfo.EmailId = userHealth.EmailId;
                userHealthInfo.Calories_Day_1 = userHealth.Calories_Day_1;
                userHealthInfo.Calories_Day_2 = userHealth.Calories_Day_2;
                userHealthInfo.Calories_Day_3 = userHealth.Calories_Day_3;
                userHealthInfo.Calories_Day_4 = userHealth.Calories_Day_4;
                userHealthInfo.Calories_Day_5 = userHealth.Calories_Day_5;
                userHealthInfo.Calories_Day_6 = userHealth.Calories_Day_6;
                userHealthInfo.Calories_Day_7 = userHealth.Calories_Day_7;
                userHealthInfo.CurrentCalories = userHealth.CurrentCalories;
                userHealthInfo.PeriodDate = userHealth.PeriodDate;
                userHealthInfo.FertilityDate = userHealth.FertilityDate;
                userHealthInfo.Medication1 = userHealth.Medication1;
                userHealthInfo.StartDateM1 = userHealth.StartDateM1;
                userHealthInfo.DurationM1 = userHealth.DurationM1;
                userHealthInfo.Medication2 = userHealth.Medication2;
                userHealthInfo.StartDateM2 = userHealth.StartDateM2;
                userHealthInfo.DurationM2 = userHealth.DurationM2;
            }
            return userHealthInfo;
        }
    }
}