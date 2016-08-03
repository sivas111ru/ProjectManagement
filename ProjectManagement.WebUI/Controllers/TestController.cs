using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectManagement.Domain.Abstract;

namespace ProjectManagement.WebUI.Controllers
{
    // connection test
    [Authorize(Roles = "admin,user")]
    public class TestController : Controller
    {
       

    }
}