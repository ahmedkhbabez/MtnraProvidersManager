using MtnraProvidersManager_DAL.Contracts;
using MtnraProvidersManager_DAL.Data;
using MtnraProvidersManager_DAL.Models;
using System.Linq.Expressions;

namespace MtnraProvidersManager_DAL.Repositories
{
    public class CommonRightContractRepository : IRepository<CommonRightContract>
    {
        private readonly AppDbContext _appDbContext;
        public CommonRightContractRepository(AppDbContext appDbContext) => _appDbContext = appDbContext;
        public CommonRightContract? Create(CommonRightContract commonRightContract)
        {
            if (commonRightContract != null)
            {
                var obj = _appDbContext.Add(commonRightContract);
                _appDbContext.SaveChanges();
                return obj.Entity;
            }
            else
            {
                return null;
            }
        }
        public void Delete(CommonRightContract commonRightContract, bool save = true)
        {
            if (commonRightContract != null)
            {
                _appDbContext.CommonRightContracts!.Remove(commonRightContract);
            }
        }

        public void DeleteManyByCondition(Expression<Func<CommonRightContract, bool>> condition)
        {
            var collection = GetManyByCondition(condition);
            foreach (var item in collection)
            {
                Delete(item, false);
            }
        }

        public IEnumerable<CommonRightContract> GetAll()
            => _appDbContext.CommonRightContracts!.ToList();
        public IEnumerable<CommonRightContract> GetManyByCondition(Expression<Func<CommonRightContract, bool>> condition)
            => _appDbContext.CommonRightContracts!.Where(condition);
        public CommonRightContract? GetOne(Expression<Func<CommonRightContract, bool>> condition)
            => _appDbContext.CommonRightContracts!.FirstOrDefault(condition);
        public void Update(CommonRightContract commonRightContract)
        {
            if (commonRightContract != null)
            {
                _appDbContext.CommonRightContracts!.Update(commonRightContract);
                _appDbContext.SaveChanges();
            }
        }
    }
}
