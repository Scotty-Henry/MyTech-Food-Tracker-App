using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Models
{
    public class DayNutrientAggModel
    {
        [Required]
        public string Date { get; set; }

        [Required]
        public int SUM_Cal { get; set; }

        [Required]
        public int SUM_Pro { get; set; }

        [Required]
        public int SUM_Carb { get; set; }

        [Required]
        public int SUM_Fat { get; set; }
    }
}
