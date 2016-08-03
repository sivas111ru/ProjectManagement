using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Domain.Abstract;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Domain.Concrete
{
    public class UserRepository: BaseRepository, IUserRepository
    {
        public IQueryable<User> Users => dbContext.Users.AsQueryable();

        public User GetUserById(int id)
        {
            return base.dbContext.Users.FirstOrDefault(u => u.id.Equals(id));
        }

        public User GetUserByName(string name)
        {
            return base.dbContext.Users.FirstOrDefault(u => u.active && u.name.Equals(name));
        }

        public User GetUserByEmail(string email)
        {
            return base.dbContext.Users.FirstOrDefault(u => u.active && u.email.Equals(email));
        }

        public bool DeleteUserById(int id)
        {
            var user = base.dbContext.Users.FirstOrDefault(u => u.id.Equals(id));

            if (user == null)
                return false;

            user.active = false;
            base.dbContext.Users.AddOrUpdate(user);

            return true;
        }

        public bool AddUser( User user )
        {
            base.dbContext.Users.AddOrUpdate(user);
            return true;
        }

        public bool EditUser(User user)
        {
            base.dbContext.Users.AddOrUpdate(user);

            return true;
        }
    }
}
