using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Models.Account
{
    public class foodItem
    {
     
        [Required]
        public string ndbno { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public double fat { get; set; }

        [Required]
        public double pro { get; set; }

        [Required]
        public double carb { get; set; }

        [Required]
        public int cal { get; set; }

    }
}
