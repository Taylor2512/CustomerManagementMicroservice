using CustomerManagement.BusinessLogic.Interfaces;
using CustomerManagement.BusinessLogic.Services;

using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

namespace CustomerManagement.BusinessLogic.Configuration
{
    public static class BusinessLogicConfig
    {
        public static IServiceCollection AddSerices(this IServiceCollection services)
        {
            services.AddScoped<IClienteServices, ClienteServices>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            return services;
        }
    }
}
