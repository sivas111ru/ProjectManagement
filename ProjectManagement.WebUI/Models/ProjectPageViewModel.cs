using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.WebUI.Models
{
    public class ProjectPageViewModel
    {
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public List<User> UsersInvolved { get; set; }
    }
}