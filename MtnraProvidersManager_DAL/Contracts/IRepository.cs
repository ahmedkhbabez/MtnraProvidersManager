using System.Linq.Expressions;

namespace MtnraProvidersManager_DAL.Contracts
{
    public interface IRepository<T>
    {
        public T? Create(T _object);
        public void Delete(T _object, bool save = true);
        public void Update(T _object);
        public IEnumerable<T> GetAll();
        public T? GetOne(Expression<Func<T, bool>> condition);
        public IEnumerable<T> GetManyByCondition(Expression<Func<T, bool>> condition);
        public void DeleteManyByCondition(Expression<Func<T, bool>> condition);
    }
}
