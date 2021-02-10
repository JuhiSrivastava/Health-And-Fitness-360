using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_Object
{
    public class UserHealthInfoDO
    {
        public string EmailId { get; set; }
        public int? Calories_Day_1 { get; set; }
        public int? Calories_Day_2 { get; set; }
        public int? Calories_Day_3 { get; set; }
        public int? Calories_Day_4 { get; set; }
        public int? Calories_Day_5 { get; set; }
        public int? Calories_Day_6 { get; set; }
        public int? Calories_Day_7 { get; set; }
        public int? CurrentCalories { get; set; }
        [DisplayName("Menstrual Start Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? PeriodDate { get; set; }
        public DateTime? FertilityDate { get; set; }
        public string Medication1 { get; set; }
        public DateTime? StartDateM1 { get; set; }
        public int? DurationM1 { get; set; }
        public string Medication2 { get; set; }
        public DateTime? StartDateM2 { get; set; }
        public int? DurationM2 { get; set; }
        [DisplayName("Menstrual Cycle Duration")]
        public int? MenstrualCycleDuration { get; set; }
        [DisplayName("Pregnancy Start Date")]
        public DateTime? PregnancyDate { get; set; }
    }
}
