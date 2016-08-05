using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagement.WebUI.Models
{
    public class TaskViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public UserPageViewModel UserViewModel { get; set; }
    }
}