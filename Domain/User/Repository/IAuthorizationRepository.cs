using System;
using System.Threading.Tasks;

namespace User.Repository
{
    public interface IAuthorizationRepository
    {
        Task<string> GenerateAccessToken(string userName,string clientIp);
        Task<bool> VerifyAccessToken(string token,int expireTimeSpan);
        Task ClearAccessToken(string token,string eventName);
        Task RefreshToken(string token);
    }
}
