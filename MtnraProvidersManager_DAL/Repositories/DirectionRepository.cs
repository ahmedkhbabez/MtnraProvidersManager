using MtnraProvidersManager_DAL.Contracts;
using MtnraProvidersManager_DAL.Data;
using MtnraProvidersManager_DAL.Models;
using System.Linq.Expressions;

namespace MtnraProvidersManager_DAL.Repositories
{
    public class DirectionRepository : IRepository<Direction>
    {
        private readonly AppDbContext _appDbContext;
        private readonly IRepository<CommonRightContract> _commonRightContractRepository;
        private readonly IRepository<InvitationToTender> _invitationToTenderRepository;
        private readonly IRepository<Market> _marketRepository;
        private readonly IRepository<PurchaseOrder> _purchaseOrderRepository;
        public DirectionRepository(
            AppDbContext appDbContext,
            IRepository<CommonRightContract> commonRightContractRepository,
            IRepository<InvitationToTender> invitationToTenderRepository,
            IRepository<Market> marketRepository,
            IRepository<PurchaseOrder> purchaseOrderRepository)
        {
            _appDbContext = appDbContext;
            _commonRightContractRepository = commonRightContractRepository;
            _invitationToTenderRepository = invitationToTenderRepository;
            _marketRepository = marketRepository;
            _purchaseOrderRepository = purchaseOrderRepository;
        }

        public Direction? Create(Direction direction)
        {
            if (direction != null)
            {
                var obj = _appDbContext.Add(direction);
                _appDbContext.SaveChanges();
                return obj.Entity;
            }
            else
            {
                return null;
            }
        }

        public void DeleteManyByCondition(Expression<Func<Direction, bool>> condition)
        {
            var collection = GetManyByCondition(condition);
            foreach (var item in collection)
            {
                Delete(item, false);
            }
        }

        public void Delete(Direction direction, bool save = true)
        {
            if (direction != null)
            {
                _commonRightContractRepository.DeleteManyByCondition(x => x.DirectionId == direction.Id);
                _invitationToTenderRepository.DeleteManyByCondition(x => x.DirectionId == direction.Id);
                _marketRepository.DeleteManyByCondition(x => x.DirectionId == direction.Id);
                _purchaseOrderRepository.DeleteManyByCondition(x => x.DirectionId == direction.Id);
                _appDbContext.Directions!.Remove(direction);
            }
        }

        public IEnumerable<Direction> GetAll()
            => _appDbContext.Directions!.ToList();

        public IEnumerable<Direction> GetManyByCondition(Expression<Func<Direction, bool>> condition)
            => _appDbContext.Directions!.Where(condition);

        public Direction? GetOne(Expression<Func<Direction, bool>> condition)
            => _appDbContext.Directions!.FirstOrDefault(condition);
        public void Update(Direction direction)
        {
            if (direction != null)
            {
                _appDbContext.Directions!.Update(direction);
                _appDbContext.SaveChanges();
            }
        }
    }
}
