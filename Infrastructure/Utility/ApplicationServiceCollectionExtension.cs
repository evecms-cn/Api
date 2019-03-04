using System;
using Application;
using Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace Utility
{
    public static class ApplicationServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IAuthorizationService, AuthorizationService>();
        }
    }
}
