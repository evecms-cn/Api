using System;
using System.Data;
using System.Threading.Tasks;
using User.Repository;
using Dapper;

namespace Repository.User
{
    public class AuthorizationRepository:IAuthorizationRepository
    {
        private readonly IDbConnection dbConnection;
        public AuthorizationRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public async Task ClearAccessToken(string token,string eventName)
        {
            string strSql = @"update evecms.Authorization set Valid=0,LastEditDate=current_timestamp,LastEventName=@EventName where Token=@Token limit 1";
            var param = new { Token = token ,EventName = eventName};
            await this.dbConnection.ExecuteAsync(strSql, param);
        }

        public async Task<string> GenerateAccessToken(string userName,string clientIp)
        {
            string token = Guid.NewGuid().ToString();
            string strSql = @"update evecms.Authorization set Valid=0,LastEditDate=current_timestamp,LastEventName='Relogin' where UserName=@UserName and Valid=1;
                                insert into evecms.Authorization(UserName, Token, InUser, LastEventName,ClientIp)
                             values(@UserName, @Token, @UserName, 'Login',@ClientIp);";
            var param = new
            {
                UserName = userName,
                Token = token,
                ClientIp=clientIp,
            };
            await this.dbConnection.ExecuteAsync(strSql, param);
            return token;
        }

        public async Task RefreshToken(string token)
        {
            string strSql = @"update evecms.Authorization set LastEditDate=current_timestamp,LastEventName='RefreshToken' where Token=@Token and Valid=1 limit 1";
            var param = new { Token = token };
            await this.dbConnection.ExecuteAsync(strSql, param);
        }

        public async Task<bool> VerifyAccessToken(string token,int expireTimeSpan)
        {
            string strSql = @"select 1 from evecms.Authorization where Token=@Token and Valid=1 and current_timestamp-LastEditDate>@ExpireTimeSpan limit 1";
            var param = new
            {
                Token = token,
                ExpireTimeSpan = expireTimeSpan
            };
            int? result = await this.dbConnection.ExecuteScalarAsync<int?>(strSql, param);
            return result.HasValue;
        }
    }
}
