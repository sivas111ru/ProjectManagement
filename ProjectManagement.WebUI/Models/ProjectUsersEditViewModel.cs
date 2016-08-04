using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.WebUI.Models
{

    public class ProjectUsersEditViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int UserId { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int ProjectId { get; set; }

        public string UserName { get; set; }

        public string ProjectName { get; set; }

        public string AccessLvl { get; set; }
    }
}