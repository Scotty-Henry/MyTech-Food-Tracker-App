using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Models.Account
{
    public class Meal
    {
     
        public List<FoodItem> foods { get; set; }

      
        public string meal_category { get; set; }

      
        public DateTime date { get; set; }

        public int userID { get; set; }
    }
}
