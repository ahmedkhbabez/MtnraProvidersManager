using Microsoft.EntityFrameworkCore;
using MtnraProvidersManager_DAL.Data;
using MtnraProvidersManager_DAL.Data.Triggers;

namespace MtnraProvidersManager_PAL.Extensions
{
    public static class DbContextExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services, ConfigurationManager configuration) =>
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection_azure"),
                b => b.MigrationsAssembly("MtnraProvidersManager_PAL"));
                options.UseTriggers(options =>
                {
                    options.AddTrigger<EnsureInterlocutorNameUniformity>();
                    options.AddTrigger<EnsureAbbreviationIsUpperCase>();
                    options.AddTrigger<UpdateMarketStateHistory>();
                });
            });
    }
}
