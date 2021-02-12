using CsvHelper.Configuration;
using Model_Object;
using System.Globalization;

namespace Data_Access.CSVHelpers.Mappers
{
    class FoodItemsMap : ClassMap<FoodItemsDO>
    {
        public FoodItemsMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Amount).Ignore();
            Map(m => m.FoodItems).Index(0);
            Map(m => m.Calories).Index(1);
            Map(m => m.Nutrients).Index(2);
        }
    }
}
