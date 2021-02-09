using Model_Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access
{
    public class AgeGrpWorkoutDAL
    {
        private HealthAndFitnessDBEntities healthAndFitnessDBEntities;
        public AgeGrpWorkoutDAL()
        {
            healthAndFitnessDBEntities = new HealthAndFitnessDBEntities();
        }
        
        public AgeGrpWorkoutDO GetAgrGrpWorkout(int age)
        {
            AgeGrpWorkoutDO ageGrpWorkout = new AgeGrpWorkoutDO();
            AgeGrpWorkout ageGrpDetails = healthAndFitnessDBEntities.AgeGrpWorkouts.FirstOrDefault(x => x.Start_Age <= age && x.End_Age >= age);
            if (ageGrpDetails != null)
            {
                ageGrpWorkout.Start_Age = ageGrpDetails.Start_Age;
                ageGrpWorkout.End_Age = ageGrpDetails.End_Age;
                ageGrpWorkout.Workout_Plan = ageGrpDetails.Workout_Plan;
                ageGrpWorkout.Calories = ageGrpDetails.Calories;
            }
            return ageGrpWorkout;
        }
    }
}

