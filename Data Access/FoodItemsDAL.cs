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

        public List<FoodItemsDO> GetFoodItems(List<string> foodItemsList)
        {
            List<FoodItemsDO> foodItemsDOs = new List<FoodItemsDO>();
            foreach (string s in foodItemsList)
            {
                FoodItem foodItem = healthAndFitnessDBEntities.FoodItems.FirstOrDefault(x => x.FoodItems.Equals(s));
                FoodItemsDO foodItemsDO = new FoodItemsDO();
                if (foodItem != null)
                {
                    foodItemsDO.FoodItems = foodItem.FoodItems;
                    foodItemsDO.Calories = foodItem.Calories;
                    foodItemsDO.Nutrients = foodItem.Nutrients;
                    foodItemsDOs.Add(foodItemsDO);
                }
            }
            return foodItemsDOs;
        }
    }

}
