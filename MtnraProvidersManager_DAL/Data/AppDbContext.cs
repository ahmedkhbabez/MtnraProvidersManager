using Microsoft.EntityFrameworkCore;
using MtnraProvidersManager_DAL.Contracts;
using MtnraProvidersManager_DAL.Data.Configurations;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_DAL.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User>? Users { get; set; }
        public DbSet<Interlocutor>? Interlocutors { get; set; }
        public DbSet<Company>? Companies { get; set; }
        public DbSet<Direction>? Directions { get; set; }
        public DbSet<InvitationToTender>? InvitationsToTender { get; set; }
        public DbSet<PurchaseOrder>? PurchaseOrders { get; set; }
        public DbSet<CommonRightContract>? CommonRightContracts { get; set; }
        public DbSet<Market>? Markets { get; set; }
        public DbSet<MarketStateHistory>? MarketsStateHistory { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MockUsersConfiguration());
            modelBuilder.ApplyConfiguration(new InitialInterlocutors());
            modelBuilder.ApplyConfiguration(new InitialDirections());
        }
    }
}
