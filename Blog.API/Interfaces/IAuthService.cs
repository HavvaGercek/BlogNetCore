using Blog.API.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.API.Interfaces
{
    public interface IAuthService
    {
        string HashPassword(string password);
        bool VerifyPassword(string actualPassword, string hashedPassword);
        AuthData GetAuthData(string id);
    }
}
