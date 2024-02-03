using MtnraProvidersManager_DAL.Contracts;

namespace MtnraProvidersManager_DAL.Data
{
    public class ChangesHandler : IChangesHandler
    {
        private readonly AppDbContext _appDbContext;
        public ChangesHandler(AppDbContext appDbContext) => _appDbContext = appDbContext;

        public void Save() => _appDbContext.SaveChanges();
    }
}
