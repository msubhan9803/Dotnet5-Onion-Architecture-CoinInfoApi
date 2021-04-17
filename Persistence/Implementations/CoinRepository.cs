using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Persistence.Implementations
{
    public class CoinRepository: RepositoryBase<Coin>, ICoinRepository
    {
        public CoinRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Coin>> GetAllCoinsAsync()
        {
            return await GetAll().OrderBy(coin => coin.Name).ToListAsync();
        }

        public async Task<Coin> GetCoinByIdAsync(int coinId)
        {
            return await FindByCondition(coin => coin.ID.Equals(coinId)).FirstOrDefaultAsync();
        }

        public void CreateCoin(Coin coin)
        {
            Create(coin);
        }

        public void UpdateCoin(Coin coin)
        {
            Update(coin);
        }

        public void DeleteCoin(Coin coin)
        {
            Delete(coin);
        }
    }
}