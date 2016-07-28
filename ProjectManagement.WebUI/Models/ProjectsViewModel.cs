using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagement.WebUI.Models
{
    public class ProjectsViewModel
    {
        [Display(Name = "ИН")]
        public int id { get; set; }
        [Display(Name = "Название проекта")]
        public string name { get; set; }
        [Display(Name = "Дата создания")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy H:mm:ss}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime createDate { get; set; }
        [Display(Name = "Инициатор")]
        public string Initiator { get; set; }
    }
}