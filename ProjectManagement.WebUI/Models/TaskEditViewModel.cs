using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagement.Domain.Entities;
using ProjectManagement.WebUI.Helpers;

namespace ProjectManagement.WebUI.Models
{
    public class TaskEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public List<User> UsersToTask { get; set; } // DELETE ME
        public string Name { get; set; }
        public int Status { get; set; }
        public byte Priority { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public List<SelectListItem> StatusAll { get; set; }
        public List<ClassedSelectListItem> PriorityAll { get; set; }

        public List<int> UsersToAdd { get; set; }
        public List<int> UsersToRemove { get; set; }
    }
}