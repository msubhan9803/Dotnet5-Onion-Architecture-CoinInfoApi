using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Persistence.Contracts;
using Service.Contracts;

namespace Service.Implementations
{
    public class CoinService : ICoinService
    {
        private readonly ILoggerService _logger;
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;

        public CoinService(IRepositoryWrapper repositoryWrapper, IMapper mapper)
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CoinReadDto>> GetAllCoinsAsync()
        {
            var coinEntities = await _repositoryWrapper.Coin.GetAllCoinsAsync();
            return _mapper.Map<IEnumerable<CoinReadDto>>(coinEntities);
        }

        public async Task<CoinReadDto> GetCoinByIdAsync(int coinId)
        {
            var coinEntity = await _repositoryWrapper.Coin.GetCoinByIdAsync(coinId);

            return _mapper.Map<CoinReadDto>(coinEntity);
        }

        public async Task<CoinReadDto> CreateCoinAsync(CoinCreateDto coin)
        {
            var coinEntity = _mapper.Map<Coin>(coin);
            _repositoryWrapper.Coin.CreateCoin(coinEntity);
            await _repositoryWrapper.SaveAsync();

            return _mapper.Map<CoinReadDto>(coinEntity);
        }

        public async Task<Coin> UpdateCoinAsync(int id, CoinUpdateDto coin)
        {
            var coinEntity = await _repositoryWrapper.Coin.GetCoinByIdAsync(id);

            if (coinEntity == null)
            {
                return null;
            }

            _mapper.Map(coin, coinEntity);
            _repositoryWrapper.Coin.UpdateCoin(coinEntity);
            await _repositoryWrapper.SaveAsync();

            return coinEntity;
        }

        public async Task<Coin> DeleteCoinAsync(int id)
        {
            var coinEntity = await _repositoryWrapper.Coin.GetCoinByIdAsync(id);
            if (coinEntity == null)
            {
                return null;
            }
            
            _repositoryWrapper.Coin.DeleteCoin(coinEntity);
            await _repositoryWrapper.SaveAsync();
            return coinEntity;
        }
    }
}