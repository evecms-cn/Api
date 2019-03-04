using System;
using System.Threading.Tasks;
using User;

namespace Application
{
    public interface IAuthorizationService
    {
        Task<string> GetAcceessToken(string userName, string password,string clientIp);
        Task<LoginUser> GetLoginUser(string token);
    }
}
