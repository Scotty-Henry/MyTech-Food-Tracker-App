using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Models.Account
{
    /// <summary>
    /// Represents a User profile request.
    /// </summary>
    /// 
    public class UserProfileModel
    {
            /// <summary>
            /// The user's username.
            /// </summary>
            [Required]
            public string name { get; set; }

            [Required]
            public DateTime birthdate { get; set; }

            [Required]
            public int currWeight { get; set; }

            [Required]
            public int goalWeight { get; set; }

            [Required]
            public int height { get; set; }

            [Required]
            public string activityLevel { get; set; }

            public int id { get; set; }

            

    }

}
