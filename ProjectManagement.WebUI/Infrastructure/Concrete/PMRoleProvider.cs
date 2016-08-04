using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using ProjectManagement.Domain.Abstract;
using ProjectManagement.Domain.Concrete;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.WebUI.Infrastructure.Concrete
{
    public class PMRoleProvider: RoleProvider
    {
        private IUserRepository repository = new UserRepository(); // OMG!

        public override string[] GetRolesForUser(string email)
        {
            string[] role = new string[] { };
                try
                {
                    // Get user
                    var user = repository.Users.FirstOrDefault(u => u.email.Equals(email));

                    if (user != null)
                    {
                        // Get role
                        role = new string[] {user.role};
                    }
                }
                catch
                {
                    role = new string[] { };
                }
            
            return role;
        }

        public override bool IsUserInRole(string email, string roleName)
        {
            bool outputResult = false;
            try
            {
                // Get user
                var user = repository.Users.FirstOrDefault(u => u.email.Equals(email));

                // Get Role
                var userRole = user?.role;

                //compare
                if (userRole != null && userRole == roleName)
                {
                    outputResult = true;
                }
            }
            catch
            {
                outputResult = false;
            }

            return outputResult;
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

    }
}