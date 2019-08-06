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
            public string Name { get; set; }

        }

    }
