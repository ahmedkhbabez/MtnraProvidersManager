using EntityFrameworkCore.Triggered;
using MtnraProvidersManager_DAL.Models;

namespace MtnraProvidersManager_DAL.Data.Triggers
{
    public class EnsureInterlocutorNameUniformity : IBeforeSaveTrigger<Interlocutor>
    {
        private readonly AppDbContext _dbContext;
        public EnsureInterlocutorNameUniformity(AppDbContext context)
        {
            _dbContext = context;
        }
        public Task BeforeSave(ITriggerContext<Interlocutor> context, CancellationToken cancellationToken)
        {
            if (context.ChangeType == ChangeType.Added || context.ChangeType == ChangeType.Modified)
            {
                string firstName = context.Entity.FirstName, lastName = context.Entity.LastName;
                if (firstName.Length > 1 && lastName.Length > 1)
                {
                    context.Entity.FirstName = char.ToUpper(firstName[0]) + firstName[1..].ToLower();
                    context.Entity.LastName = lastName.ToUpper();
                }
                else
                {
                    if (context.ChangeType == ChangeType.Added)
                    {
                        _dbContext.Interlocutors?.Remove(context.Entity);
                    }
                    if (context.ChangeType == ChangeType.Modified)
                    {
                        _dbContext.Entry(context.Entity).Property(x => x.FirstName).IsModified = false;
                        _dbContext.Entry(context.Entity).Property(x => x.LastName).IsModified = false;
                    }
                }
            }
            return Task.CompletedTask;
        }
    }
}
