using System;
using System.Threading.Tasks;

namespace User.Repository
{
    public interface IUserRepository
    {
        Task<bool> VerifyUser(string userName, string password);
        Task<LoginUser> GetLoginUser(string token);
    }
}
