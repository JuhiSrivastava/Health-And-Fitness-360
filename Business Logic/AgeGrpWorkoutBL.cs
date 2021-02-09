using Data_Access;
using Model_Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic
{
    public class AgeGrpWorkoutBL
    {

        public AgeGrpWorkoutDO GetAgrGrpWorkout(int age)
        {
            return new AgeGrpWorkoutDAL().GetAgrGrpWorkout(age);
        }

        public string getModifiedPlan(int currentCalories, int requiredCalories, int currentPlan)
        {
            int newPlan = currentPlan;
            string workout = "";
            if (currentCalories > requiredCalories)
            {
                if (currentPlan != 1)
                    newPlan -= 1;
            }
            if (currentCalories < requiredCalories)
            {
                if (currentPlan != 5)
                    newPlan += 1;
            }
            if (newPlan == 1)
                workout = "oc4QS2USKmk";
            else if (newPlan == 2)
                workout = "pj4TVbnIEgk";
            else if (newPlan == 3)
                workout = "5swqLti2KUg";
            else if (newPlan == 4)
                workout = "Ev6yE55kYGw";
            else
                workout = "8BcPHWGQO44";
            return workout;
        }
        
    }
}
