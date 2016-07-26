using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using ProjectManagement.Domain.Abstract;
using ProjectManagement.WebUI.Infrastructure.Abstract;

namespace ProjectManagement.WebUI.Infrastructure.Concrete
{
    public class FormsAuthProvider: IAuthProvider
    {
        private IDataRepository repository;

        public FormsAuthProvider(IDataRepository data)
        {
            repository = data;
        }
        public bool Authenticate(string email, string password)
        {
            if (repository.Users.FirstOrDefault(x => x.email.Equals(email) && x.password.Equals(password)) != null)
            {
                FormsAuthentication.SetAuthCookie(email, false);
                return true;
            }
            return false;
        }
    }
}