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
        public String Status { get; set; }
        public byte Priority { get; set; }
        public string PriorityCssClass { get; set; }
    }
}