namespace Model_Object
{
    //Data Object class to store the different workout plans for a user.
    public class AgeGrpWorkoutDO
    {
        public int Start_Age { get; set; }
        public int End_Age { get; set; }
        public string Workout_Plan { get; set; }
        public string Calories { get; set; }
    }
}
