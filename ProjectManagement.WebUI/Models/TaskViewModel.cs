using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.WebUI.Models
{
    public class TaskViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public List<User> UsersToTask { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public byte Priority { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public List<SelectListItem> StatusAll { get; set; }
    }
}