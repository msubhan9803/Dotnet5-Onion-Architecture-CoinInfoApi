using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Infrastructure.Profiles
{
    public class CoinsProfile : Profile
    {
        public CoinsProfile()
        {
            // Source -> Target
            CreateMap<Coin, CoinReadDto>();
            CreateMap<CoinCreateDto, Coin>();
            CreateMap<CoinUpdateDto, Coin>();
        }
    }
}