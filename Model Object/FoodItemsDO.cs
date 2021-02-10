﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_Object
{
    public class FoodItemsDO
    {
        [Display(Name = "Food Items")]
        public string FoodItems { get; set; }
        
        public int Calories { get; set; }
        
        public string Nutrients { get; set; }
        
        public int Amount { get; set; }
    }
}