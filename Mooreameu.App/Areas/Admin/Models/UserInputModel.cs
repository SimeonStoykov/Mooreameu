using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Mooreameu.Model;

namespace Mooreameu.App.Areas.Admin.Models
{
    public class UserInputModel
    {
        [Required]
        [MinLength(6), MaxLength(10)]
        [RegularExpression("([0-9a-zA-Z\\D\\W]+)", ErrorMessage = "Should contain digit, capital letter and non letter/digit symbol")]
        public string Password { get; set; }

        public UserStatus Status { get; set; }
    }
}