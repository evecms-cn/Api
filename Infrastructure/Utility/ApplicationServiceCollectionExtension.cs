using System;
using Application;
using Authorization;
using EVEDataProvider;
using Microsoft.Extensions.DependencyInjection;

namespace Utility
{
    public static class ApplicationServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAuthorizationService, AuthorizationService>();
            serviceCollection.AddTransient<IEVEDataService, EVEDataService>();
        }
    }
}
