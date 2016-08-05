using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.WebUI.Models
{
    public class ProjectPageViewModel
    {
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public List<Tuple<Task,User>> TasksInvolved { get; set; }
        public List<UserViewModel> UsersInvolved { get; set; }


        public List<TaskViewModel> Tasks { get; set; }
    }
}