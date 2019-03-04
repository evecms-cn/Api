using System;
using System.Data;
using User.Repository;
using Dapper;
using System.Threading.Tasks;
using User;

namespace Repository.User
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection dbConnection;
        public UserRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        public async Task<LoginUser> GetLoginUser(string token)
        {
            string strSql = @"select UserName,NickName from evecms.User
                                where UserName=(select UserName from evecms.Authorization where Token=@Token limit 1)
                                limit 1";
            var param = new
            {
                Token = token
            };
            LoginUser loginUser = await this.dbConnection.QuerySingleAsync<LoginUser>(strSql, param);
            return loginUser;
        }

        public async Task<bool> VerifyUser(string userName, string password)
        {
            string strSql = @"select 1 from evecms.User where UserName=@UserName and PassWord=@Password limit 1";
            var param = new
            {
                UserName = userName,
                Password = password
            };
            int? result = await dbConnection.ExecuteScalarAsync<int?>(strSql, param);
            return result.HasValue;
        }
    }
}
