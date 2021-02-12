using CsvHelper.Configuration;
using Model_Object;
using System.Globalization;

namespace Data_Access.CSVHelpers.Mappers
{
    internal class AgeGrpWorkoutMap : ClassMap<AgeGrpWorkoutDO>
    {
        public AgeGrpWorkoutMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.Start_Age).Index(0);
            Map(m => m.End_Age).Index(1);
            Map(m => m.Workout_Plan).Index(2);
            Map(m => m.Calories).Index(3);
        }
    }
}
