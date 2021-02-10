using Model_Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access
{
    public class FoodItemsDAL
    {
        private HealthAndFitnessDBEntities healthAndFitnessDBEntities;
        public FoodItemsDAL()
        {
            healthAndFitnessDBEntities = new HealthAndFitnessDBEntities();
        }

        public List<FoodItemsDO> GetFoodItems()
        {
            List<FoodItemsDO> foodItemsDOs = new List<FoodItemsDO>();
            foreach (FoodItem foodItem in healthAndFitnessDBEntities.FoodItems)
            {
                FoodItemsDO foodItemsDO = new FoodItemsDO();
                foodItemsDO.FoodItems = foodItem.FoodItems;
                foodItemsDO.Calories = foodItem.Calories;
                foodItemsDO.Nutrients = foodItem.Nutrients;
                foodItemsDOs.Add(foodItemsDO);
            }
            
            return foodItemsDOs;
        }
    }

}
