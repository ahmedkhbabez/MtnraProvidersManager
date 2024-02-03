using MtnraProvidersManager_DAL.Contracts;
using MtnraProvidersManager_DAL.Data;
using MtnraProvidersManager_DAL.Models;
using System.Linq.Expressions;

namespace MtnraProvidersManager_DAL.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext) => _appDbContext = appDbContext;

        public void DeleteManyByCondition(Expression<Func<User, bool>> condition)
        {
            var collection = GetManyByCondition(condition);
            foreach (var item in collection)
            {
                Delete(item, false);
            }
        }
        public User? GetOne(Expression<Func<User, bool>> condition)
            => _appDbContext.Users!.FirstOrDefault(condition);

        public User? Create(User user)
        {
            if (user != null)
            {
                var obj = _appDbContext.Add(user);
                _appDbContext.SaveChanges();
                return obj.Entity;
            }
            else
            {
                return null;
            }
        }

        public void Delete(User user, bool save = true)
        {
            if (user != null)
            {
                _appDbContext.Users!.Remove(user);
            }
        }
        public void Update(User user)
        {
            if (user != null)
            {
                _appDbContext.Users!.Update(user);
                _appDbContext.SaveChanges();
            }
        }

        public IEnumerable<User> GetAll()
            => _appDbContext.Users!.ToList();

        public IEnumerable<User> GetManyByCondition(Expression<Func<User, bool>> condition)
            => _appDbContext.Users!.Where(condition);
    }
}
