using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Persistence.Contracts
{
    public interface ICoinRepository : IRepositoryBase<Coin>
    {
        Task<IEnumerable<Coin>> GetAllCoinsAsync();
        Task<Coin> GetCoinByIdAsync(int coinId);
        void CreateCoin(Coin coin);
        void UpdateCoin(Coin coin);
        void DeleteCoin(Coin coin);
    }
}