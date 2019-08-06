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
            public string birthdate { get; set; }

            [Required]
            public string currWeight { get; set; }

            [Required]
            public string goalWeight { get; set; }

            [Required]
            public string height { get; set; }

            [Required]
            public string activityLevel { get; set; }



        public int id { get; set; }

    }

    }
