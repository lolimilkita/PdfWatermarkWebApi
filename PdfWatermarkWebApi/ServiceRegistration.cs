using PdfWatermarkWebApi.Repository;
using PdfWatermarkWebApi.Service;

namespace PdfWatermarkWebApi
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //SQL Connection
            services.AddScoped<IDatabaseConnectionFactory>(e =>
            {
                return new SqlConnectionFactory(configuration.GetConnectionString("DefaultConnection"));
            });

            //Dapper
            services.AddScoped<IDapper, Repository.Dapper>();

            //Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Services
            services.AddScoped<IUserService, UserService>();
        }
    }
}
