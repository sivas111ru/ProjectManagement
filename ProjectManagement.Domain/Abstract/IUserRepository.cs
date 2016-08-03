using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Domain.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }

        User GetUserById(int id);

        User GetUserByName(string name);

        User GetUserByEmail(string email);

        bool DeleteUserById(int id);

        bool AddUser(User user);

        bool EditUser(User user);
    }
}
