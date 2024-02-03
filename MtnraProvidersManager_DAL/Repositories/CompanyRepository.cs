using MtnraProvidersManager_DAL.Contracts;
using MtnraProvidersManager_DAL.Data;
using MtnraProvidersManager_DAL.Models;
using System.Linq.Expressions;

namespace MtnraProvidersManager_DAL.Repositories
{
    public class CompanyRepository : IRepository<Company>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IRepository<CommonRightContract> _commonRightContractRepository;
        private readonly IRepository<Market> _marketRepository;
        private readonly IRepository<PurchaseOrder> _purchaseOrderRepository;
        public CompanyRepository(
            AppDbContext appDbContext, IRepository<CommonRightContract> commonRightContractRepository, IRepository<Market> marketRepository, IRepository<PurchaseOrder> purchaseOrderRepository)
        {
            _appDbContext = appDbContext;
            _commonRightContractRepository = commonRightContractRepository;
            _marketRepository = marketRepository;
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        public Company? Create(Company company)
        {
            if (company != null)
            {
                var obj = _appDbContext.Add(company);
                _appDbContext.SaveChanges();
                return obj.Entity;
            }
            else
            {
                return null;
            }
        }
        public void Delete(Company company, bool save = true)
        {
            if (company != null)
            {
                _commonRightContractRepository.DeleteManyByCondition(x => x.CompanyId == company.Id);
                _marketRepository.DeleteManyByCondition(x => x.CompanyId == company.Id);
                _purchaseOrderRepository.DeleteManyByCondition(x => x.CompanyId == company.Id);
                _appDbContext.Companies!.Remove(company);
            }
        }

        public void DeleteManyByCondition(Expression<Func<Company, bool>> condition)
        {
            var collection = GetManyByCondition(condition);
            foreach (var item in collection)
            {
                Delete(item, false);
            }

        }
        public IEnumerable<Company> GetAll()
            => _appDbContext.Companies!.ToList();

        public IEnumerable<Company> GetManyByCondition(Expression<Func<Company, bool>> condition)
            => _appDbContext.Companies!.Where(condition);

        public Company? GetOne(Expression<Func<Company, bool>> condition)
            => _appDbContext.Companies!.FirstOrDefault(condition);
        public void Update(Company company)
        {
            if (company != null)
            {
                _appDbContext.Companies!.Update(company);
                _appDbContext.SaveChanges();
            }
        }
    }
}
