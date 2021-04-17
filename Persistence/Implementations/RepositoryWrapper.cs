using System.Threading.Tasks;
using Persistence.Contracts;

namespace Persistence.Implementations
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private AppDbContext _context;
        private ICoinRepository _coin;
        
        public RepositoryWrapper(AppDbContext context)
        {
            _context = context;
        }
        
        public ICoinRepository Coin {
            get {
                if(_coin == null)
                {
                    _coin = new CoinRepository(_context);
                }
                return _coin;
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}