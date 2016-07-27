using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace ProjectManagement.WebUI.Infrastructure.Abstract
{
    public interface IResetPass
    {
        bool Reset(string email);

    }
}