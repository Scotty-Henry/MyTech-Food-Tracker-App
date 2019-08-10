using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Models.Account
{
    public class Meal
    {
        public FoodItem[] foods { get; set; }

        public int meal { get; set; }

        public DateTime date { get; set; }

        public int userID { get; set; }
    }
}
