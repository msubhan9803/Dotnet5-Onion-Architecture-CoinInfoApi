using Domain.Dtos;
using FluentValidation;

namespace Infrastructure.Validators
{
    public class CoinCreateDtoValidator : AbstractValidator<CoinCreateDto>
    {
        public CoinCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required");
            
            RuleFor(x => x.Symbol)
                .NotEmpty().WithMessage("Symbol is required");
        }
    }
}