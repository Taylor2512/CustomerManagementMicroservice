using CustomerManagement.BusinessLogic.Interfaces;
using CustomerManagement.BusinessLogic.Services;

using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.BusinessLogic.Configuration
{
    public static class BusinessLogicConfig
    {
        public static IServiceCollection AddSerices(this IServiceCollection services)
        {
            services.AddScoped<IClienteServices,ClienteServices>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());


            return services;
        }
    }
}
