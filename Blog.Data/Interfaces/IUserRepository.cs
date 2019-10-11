using Blog.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Data.Interfaces
{
    public interface IUserRepository : IEntityBaseRepository<User>
    {
        bool IsUsernameUniq(string username);
        bool isEmailUniq(string email);
    }
}
