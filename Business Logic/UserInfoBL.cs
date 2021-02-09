using Data_Access;
using Model_Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic
{
    public class UserInfoBL
    {
        public CustomDO AddUser(UserInfoDO userInfo)
        {
            return new UserInfoDAL().AddUser(userInfo);
        }
        public UserInfoDO GetUser(string emailId, string password)
        {
            return new UserInfoDAL().GetUser(emailId, password);
        }
        public string BMICalculation(double height, double weight, int age)
        {
            double bmi = (weight / (height * height));
            string healthMonitor = "";
            if (age < 18)
            {
                healthMonitor += "4";
            }
            else
            {
                if (bmi < 16)
                    healthMonitor += "1";
                else if (bmi >= 16 && bmi < 17)
                    healthMonitor += "2";
                else if (bmi >=17 && bmi < 18.5)
                    healthMonitor += "3";
                else if (bmi >=18.5 && bmi < 25)
                    healthMonitor += "4";
                else if (bmi >=25 && bmi < 30)
                    healthMonitor += "5";
                else if (bmi >= 30 && bmi < 35)
                    healthMonitor += "6";
                else if (bmi >= 35 && bmi < 40)
                    healthMonitor += "7";
                else
                    healthMonitor += "8";
            }
            healthMonitor += " " + bmi.ToString();
            return healthMonitor;
        }
    }
}
