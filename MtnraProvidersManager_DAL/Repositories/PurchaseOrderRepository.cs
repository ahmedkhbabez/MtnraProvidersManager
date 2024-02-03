using MtnraProvidersManager_DAL.Contracts;
using MtnraProvidersManager_DAL.Data;
using MtnraProvidersManager_DAL.Models;
using System.Linq.Expressions;

namespace MtnraProvidersManager_DAL.Repositories
{
    public class PurchaseOrderRepository : IRepository<PurchaseOrder>
    {
        private readonly AppDbContext _appDbContext;
        public PurchaseOrderRepository(AppDbContext appDbContext) => _appDbContext = appDbContext;
        public PurchaseOrder? Create(PurchaseOrder order)
        {
            if (order != null)
            {
                var obj = _appDbContext.Add(order);
                _appDbContext.SaveChanges();
                return obj.Entity;
            }
            else
            {
                return null;
            }
        }

        public void Delete(PurchaseOrder user, bool save = true)
        {
            if (user != null)
            {
                _appDbContext.PurchaseOrders!.Remove(user);
            }
        }

        public IEnumerable<PurchaseOrder> GetAll()
            => _appDbContext.PurchaseOrders!.ToList();

        public void DeleteManyByCondition(Expression<Func<PurchaseOrder, bool>> condition)
        {
            var collection = GetManyByCondition(condition);
            foreach (var item in collection)
            {
                Delete(item, false);
            }
        }
        public IEnumerable<PurchaseOrder> GetManyByCondition(Expression<Func<PurchaseOrder, bool>> condition)
             => _appDbContext.PurchaseOrders!.Where(condition);

        public PurchaseOrder? GetOne(Expression<Func<PurchaseOrder, bool>> condition)
            => _appDbContext.PurchaseOrders!.FirstOrDefault(condition);
        public void Update(PurchaseOrder PurchaseOrder)
        {
            if (PurchaseOrder != null)
            {
                _appDbContext.PurchaseOrders!.Update(PurchaseOrder);
                _appDbContext.SaveChanges();
            }
        }
    }
}
