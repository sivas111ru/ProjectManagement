using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagement.WebUI.Models
{
    public class ResetPassViewModel
    {
        [Required]
        public string Email { get; set; }
    }
}