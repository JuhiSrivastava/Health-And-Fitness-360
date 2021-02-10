using Data_Access;
using Model_Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic
{
    public class FoodItemsBL
    {
        public List<FoodItemsDO> GetFoodItems()
        {
            return new FoodItemsDAL().GetFoodItems();
        }
    }
}
