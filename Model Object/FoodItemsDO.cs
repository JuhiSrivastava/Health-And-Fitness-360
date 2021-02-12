using System.ComponentModel.DataAnnotations;

namespace Model_Object
{
    //Data Object class to store the different food items along with its details.
    public class FoodItemsDO
    {
        [Display(Name = "Food Items")]
        public string FoodItems { get; set; }
        
        public int Calories { get; set; }
        
        public string Nutrients { get; set; }
        
        public int Amount { get; set; }
    }
}
