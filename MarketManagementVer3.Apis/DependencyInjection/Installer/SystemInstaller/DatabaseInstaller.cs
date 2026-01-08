
using MarketManagement.Apis.DependencyInjection.Options;
using MarketManagement.Core.DataContext;
using Microsoft.EntityFrameworkCore;

namespace MarketManagement.Apis.DependencyInjection.Installer.SystemInstaller
{
    public class DatabaseInstaller : IInstaller
    {
        public void InstallService(IServiceCollection services, IConfiguration configuration)
        {
            var dbConfig = new DatabaseConfig();
            configuration.GetSection(nameof(DatabaseConfig)).Bind(dbConfig);

            services.Configure<DatabaseConfig>(configuration.GetSection(nameof(DatabaseConfig)));

            // Add DbContext
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(dbConfig.DefaultConnection);
            });
        }
    }
}
