using MtnraProvidersManager_BAL.Contracts;
using MtnraProvidersManager_BAL.Services;
using MtnraProvidersManager_DAL.Contracts;
using MtnraProvidersManager_DAL.Data;
using MtnraProvidersManager_DAL.Models;
using MtnraProvidersManager_DAL.Repositories;

namespace MtnraProvidersManager_PAL.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void AddRepositories(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepository<Interlocutor>, InterlocutorRepository>();
            services.AddTransient<IRepository<Direction>, DirectionRepository>();
            services.AddTransient<IRepository<Company>, CompanyRepository>();
            services.AddTransient<IRepository<InvitationToTender>, InvitationToTenderRepository>();
            services.AddTransient<IRepository<Market>, MarketRepository>();
            services.AddTransient<IRepository<MarketStateHistory>, MarketStateHistoryRepository>();
            services.AddTransient<IRepository<CommonRightContract>, CommonRightContractRepository>();
            services.AddTransient<IRepository<PurchaseOrder>, PurchaseOrderRepository>();
            services.AddTransient<IChangesHandler, ChangesHandler>();
        }
        public static void AddServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IInterlocutorService, InterlocutorService>();
            services.AddScoped<IDirectionService, DirectionService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IInvitationToTenderService, InvitationToTenderService>();
            services.AddScoped<IMarketService, MarketService>();
            services.AddScoped<IMarketStateHistoryService, MarketStateHistoryService>();
            services.AddScoped<ICommonRightContractService, CommonRightContractService>();
            services.AddScoped<IPurchaseOrderService, PurchaseOrderService>();
        }
    }
}
