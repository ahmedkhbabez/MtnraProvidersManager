using EntityFrameworkCore.Triggered;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_DAL.Data.Triggers
{
    public class UpdateMarketStateHistory : IAfterSaveTrigger<Market>
    {
        private readonly AppDbContext _context;

        public UpdateMarketStateHistory(AppDbContext context)
        {
            _context = context;
        }
        public Task AfterSave(ITriggerContext<Market> context, CancellationToken cancellationToken)
        {
            if (context.ChangeType == ChangeType.Added || context.ChangeType == ChangeType.Modified)
            {
                if (context.ChangeType == ChangeType.Modified && context.UnmodifiedEntity!.State == context.Entity.State)
                {
                    return Task.CompletedTask;
                }
                var marketState = new MarketStateHistory
                {
                    Id = Guid.NewGuid(),
                    MarketId = context.Entity.Id,
                    State = context.Entity.State,
                    Date = DateTime.Now,
                    AddedBy = context.Entity.AddedBy
                };
                _context.MarketsStateHistory!.Add(marketState);
                _context.SaveChanges();
            }
            return Task.CompletedTask;
        }
    }
}
