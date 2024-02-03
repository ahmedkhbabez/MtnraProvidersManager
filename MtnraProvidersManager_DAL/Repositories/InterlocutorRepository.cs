using MtnraProvidersManager_DAL.Contracts;
using MtnraProvidersManager_DAL.Data;
using MtnraProvidersManager_DAL.Models;
using System.Linq.Expressions;

namespace MtnraProvidersManager_DAL.Repositories
{
    public class InterlocutorRepository : IRepository<Interlocutor>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IRepository<Direction> _directionRepository;
        public InterlocutorRepository(
            AppDbContext appDbContext,
            IRepository<Direction> directionRepository)
        {
            _appDbContext = appDbContext;
            _directionRepository = directionRepository;
        }

        public Interlocutor? Create(Interlocutor interlocutor)
        {
            if (interlocutor != null)
            {
                var obj = _appDbContext.Add(interlocutor);
                _appDbContext.SaveChanges();
                return obj.Entity;
            }
            else
            {
                return null;
            }
        }

        public void DeleteManyByCondition(Expression<Func<Interlocutor, bool>> condition)
        {
            var collection = GetManyByCondition(condition);
            foreach (var item in collection)
            {
                Delete(item, false);
            }
        }

        public void Delete(Interlocutor interlocutor, bool save = true)
        {
            if (interlocutor != null)
            {
                _directionRepository.DeleteManyByCondition(x => x.InterlocutorId == interlocutor.Id);
                _appDbContext.Interlocutors!.Remove(interlocutor);
            }
        }

        public IEnumerable<Interlocutor> GetAll()
            => _appDbContext.Interlocutors!.ToList();

        public IEnumerable<Interlocutor> GetManyByCondition(Expression<Func<Interlocutor, bool>> condition)
                => _appDbContext.Interlocutors!.Where(condition);

        public Interlocutor? GetOne(Expression<Func<Interlocutor, bool>> condition)
            => _appDbContext.Interlocutors!.FirstOrDefault(condition);
        public void Update(Interlocutor interlocutor)
        {
            if (interlocutor != null)
            {
                _appDbContext.Interlocutors!.Update(interlocutor);
                _appDbContext.SaveChanges();
            }
        }
    }
}
