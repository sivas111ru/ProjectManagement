using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagement.WebUI.Helpers
{
    public class ClassedSelectListItem : SelectListItem
    {
        public string CssClass { get; set; }
    }
}