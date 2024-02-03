using MtnraProvidersManager_DAL.Contracts;
using MtnraProvidersManager_DAL.Data;
using MtnraProvidersManager_DAL.Models;
using System.Linq.Expressions;

namespace MtnraProvidersManager_DAL.Repositories
{
    public class MarketRepository : IRepository<Market>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IRepository<MarketStateHistory> _stateHistoryService;

        public MarketRepository(
            AppDbContext appDbContext,
            IRepository<MarketStateHistory> stateHistoryService)
        {
            _appDbContext = appDbContext;
            _stateHistoryService = stateHistoryService;
        }

        public Market? Create(Market markets)
        {
            if (markets != null)
            {
                var obj = _appDbContext.Add(markets);
                _appDbContext.SaveChanges();
                return obj.Entity;
            }
            else
            {
                return null;
            }
        }

        public void DeleteManyByCondition(Expression<Func<Market, bool>> condition)
        {
            var collection = GetManyByCondition(condition);
            foreach (var item in collection)
            {
                Delete(item, false);
            }
        }

        public void Delete(Market market, bool save = true)
        {
            if (market != null)
            {
                _stateHistoryService.DeleteManyByCondition(h => h.MarketId == market.Id);
                _appDbContext.Markets!.Remove(market);
            }
        }

        public IEnumerable<Market> GetAll()
            => _appDbContext.Markets!.ToList();

        public IEnumerable<Market> GetManyByCondition(Expression<Func<Market, bool>> condition)
            => _appDbContext.Markets!.Where(condition);

        public Market? GetOne(Expression<Func<Market, bool>> condition)
            => _appDbContext.Markets!.FirstOrDefault(condition);
        public void Update(Market markets)
        {
            if (markets != null)
            {
                _appDbContext.Markets!.Update(markets);
                _appDbContext.SaveChanges();
            }
        }
    }
}
