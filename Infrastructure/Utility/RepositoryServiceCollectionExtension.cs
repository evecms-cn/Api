using System;
using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using Repository.User;
using User.Repository;

namespace Utility
{
    public static class RepositoryServiceCollectionExtension
    {
        public static void AddRepository(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            string dbConnectionString = configuration.GetConnectionString("default");
            IDbConnection dbConnection = new MySqlConnection(dbConnectionString);
            serviceCollection.AddSingleton<IDbConnection>(dbConnection);
            serviceCollection.AddTransient<IUserRepository, UserRepository>();
            serviceCollection.AddTransient<IAuthorizationRepository, AuthorizationRepository>();
        }
    }
}
