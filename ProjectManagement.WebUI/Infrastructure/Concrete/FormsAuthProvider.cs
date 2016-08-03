﻿using System;
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
        private IUserRepository repository;

        public FormsAuthProvider(IUserRepository data)
        {
            repository = data;
        }

        public bool Authenticate(string email, string password)
        {
            var user = repository.GetUserByEmail(email);

            if (user == null)
                return false;

            if (!user.password.Equals(password))
                return false;

            FormsAuthentication.SetAuthCookie(email, false);

            return true;
        }
    }
}