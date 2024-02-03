using EntityFrameworkCore.Triggered;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_DAL.Data.Triggers
{
    public class EnsureAbbreviationIsUpperCase : IBeforeSaveTrigger<Direction>
    {
        private readonly AppDbContext _dbContext;
        public EnsureAbbreviationIsUpperCase(AppDbContext context)
        {
            _dbContext = context;
        }
        public Task BeforeSave(ITriggerContext<Direction> context, CancellationToken cancellationToken)
        {
            if (context.ChangeType == ChangeType.Added || context.ChangeType == ChangeType.Modified)
            {
                string abbreviation = context.Entity.Abbreviation;
                if (abbreviation.Length > 0)
                {
                    context.Entity.Abbreviation = abbreviation.ToUpper();
                }
                else
                {
                    if (context.ChangeType == ChangeType.Added)
                    {
                        _dbContext.Directions?.Remove(context.Entity);
                    }
                    if (context.ChangeType == ChangeType.Modified)
                    {
                        _dbContext.Entry(context.Entity).Property(x => x.Abbreviation).IsModified = false;
                    }
                }
            }
            return Task.CompletedTask;
        }
    }
}
