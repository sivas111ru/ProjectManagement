using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagement.WebUI.Models
{
    public class UserPageViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsNotification { get; set; }

        public bool IsPageOwner { get; set; }

        public List<TaskViewModel> Tasks { get; set; }
    }
}