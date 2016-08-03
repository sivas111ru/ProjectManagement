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
        public List<SelectListItem> StatusAll { get; set; }
        public List<string> UsersToTask { get; set; }

        public Task Task { get; set; }
        public int SelectedStatus { get; set; }
    }
}