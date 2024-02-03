using MtnraProvidersManager_DAL.Contracts;
using MtnraProvidersManager_DAL.Data;
using MtnraProvidersManager_DAL.Models;
using System.Linq.Expressions;

namespace MtnraProvidersManager_DAL.Repositories
{
    public class InvitationToTenderRepository : IRepository<InvitationToTender>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IRepository<Market> _marketRepository;
        public InvitationToTenderRepository(
            AppDbContext appDbContext,
            IRepository<Market> marketRepository)
        {
            _appDbContext = appDbContext;
            _marketRepository = marketRepository;
        }

        public InvitationToTender? Create(InvitationToTender invitations)
        {
            if (invitations != null)
            {
                var obj = _appDbContext.Add(invitations);
                _appDbContext.SaveChanges();
                return obj.Entity;
            }
            else
            {
                return null;
            }
        }

        public void DeleteManyByCondition(Expression<Func<InvitationToTender, bool>> condition)
        {
            var collection = GetManyByCondition(condition);
            foreach (var item in collection)
            {
                Delete(item, false);
            }
        }

        public void Delete(InvitationToTender invitation, bool save = true)
        {
            if (invitation != null)
            {
                _marketRepository.DeleteManyByCondition(m => m.OriginalInvitationToTenderId == invitation.Id);
                _appDbContext.InvitationsToTender!.Remove(invitation);
            }
        }

        public IEnumerable<InvitationToTender> GetAll()
            => _appDbContext.InvitationsToTender!.ToList();

        public IEnumerable<InvitationToTender> GetManyByCondition(Expression<Func<InvitationToTender, bool>> condition)
                    => _appDbContext.InvitationsToTender!.Where(condition);

        public InvitationToTender? GetOne(Expression<Func<InvitationToTender, bool>> condition)
            => _appDbContext.InvitationsToTender!.FirstOrDefault(condition);
        public void Update(InvitationToTender invitations)
        {
            if (invitations != null)
            {
                _appDbContext.InvitationsToTender!.Update(invitations);
                _appDbContext.SaveChanges();
            }
        }
    }
}
