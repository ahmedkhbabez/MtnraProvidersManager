using MtnraProvidersManager_DAL.Contracts;
using MtnraProvidersManager_DAL.Data;
using MtnraProvidersManager_DAL.Models;
using System.Linq.Expressions;

namespace MtnraProvidersManager_DAL.Repositories
{
    public class MarketStateHistoryRepository : IRepository<MarketStateHistory>
    {
        private readonly AppDbContext _appDbContext;
        public MarketStateHistoryRepository(AppDbContext appDbContext) => _appDbContext = appDbContext;
        public MarketStateHistory? Create(MarketStateHistory stateHistory)
        {
            if (stateHistory != null)
            {
                var obj = _appDbContext.Add(stateHistory);
                _appDbContext.SaveChanges();
                return obj.Entity;
            }
            else
            {
                return null;
            }
        }
        public void DeleteManyByCondition(Expression<Func<MarketStateHistory, bool>> condition)
        {
            var collection = GetManyByCondition(condition);
            foreach (var item in collection)
            {
                Delete(item, false);
            }
        }
        public void Delete(MarketStateHistory user, bool save = true)
        {
            if (user != null)
            {
                _appDbContext.MarketsStateHistory!.Remove(user);
            }
        }

        public IEnumerable<MarketStateHistory> GetAll()
            => _appDbContext.MarketsStateHistory!.ToList();

        public IEnumerable<MarketStateHistory> GetManyByCondition(Expression<Func<MarketStateHistory, bool>> condition)
            => _appDbContext.MarketsStateHistory!.Where(condition);

        public MarketStateHistory? GetOne(Expression<Func<MarketStateHistory, bool>> condition)
            => _appDbContext.MarketsStateHistory!.FirstOrDefault(condition);
        public void Update(MarketStateHistory stateHistory)
        {
            if (stateHistory != null)
            {
                _appDbContext.MarketsStateHistory!.Update(stateHistory);
                _appDbContext.SaveChanges();
            }
        }
    }
}
