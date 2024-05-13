using CustomerManagement.DataAccess.Context;
using CustomerManagement.DataAccess.Interfaces;
using CustomerManagement.DataAccess.Repository;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace CustomerManagement.DataAccess.Configurations
{
    public static class DataAccessConfiguration
    {
        public static IServiceCollection AddRepositoryConfig(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CustomerDbContext>(options =>
            {
                string? connectionString = configuration.GetConnectionString("DefaultConnection");
                options.UseNpgsql(connectionString, sql =>
                {
                    sql.MigrationsAssembly(typeof(CustomerDbContext).Assembly.FullName);
                });
            });

            //services.AddScoped(typeof(BaseRepository<>), typeof(IBaseRepository<>));
            services.AddScoped<IClienteRepository, ClienteRepository>();

            return services;
        }
    }
}
