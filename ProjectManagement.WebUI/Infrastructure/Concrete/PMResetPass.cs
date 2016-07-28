using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectManagement.WebUI.Infrastructure.Abstract;

namespace ProjectManagement.WebUI.Infrastructure.Concrete
{
    public class PMResetPass: IResetPass
    {
        public bool Reset(string email)
        {
            return true; // to do
        }
    }
}