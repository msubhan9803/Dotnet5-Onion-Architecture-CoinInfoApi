using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Dtos;
using Domain.Entities;

namespace Service.Contracts
{
    public interface ICoinService
    {
        Task<IEnumerable<CoinReadDto>> GetAllCoinsAsync();
        Task<CoinReadDto> GetCoinByIdAsync(int coinId);
        Task<CoinReadDto> CreateCoinAsync(CoinCreateDto coin);
        Task<Coin> UpdateCoinAsync(int id, CoinUpdateDto coin);
        Task<Coin> DeleteCoinAsync(int id);
    }
}