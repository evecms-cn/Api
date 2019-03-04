using System;
using System.Threading.Tasks;
using Application;
using Microsoft.Extensions.Configuration;
using User;
using User.Repository;

namespace Authorization
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IUserRepository userRepository;
        private readonly IAuthorizationRepository authorizationRepository;
        private readonly IConfiguration configuration;
        public AuthorizationService(IUserRepository userRepository,IAuthorizationRepository authorizationRepository,IConfiguration configuration)
        {
            this.userRepository = userRepository;
            this.authorizationRepository = authorizationRepository;
            this.configuration = configuration;
        }
        public async Task<string> GetAcceessToken(string userName, string password,string clientIp)
        {
            bool result = await this.userRepository.VerifyUser(userName, password);
            if (!result)
            {
                throw new Exception("Authorization failed");
            }
            string token = await this.authorizationRepository.GenerateAccessToken(userName, clientIp);
            return token;
        }

        public async Task<LoginUser> GetLoginUser(string token)
        {
            LoginUser user= await this.userRepository.GetLoginUser(token);
            return user;
        }
    }
}
