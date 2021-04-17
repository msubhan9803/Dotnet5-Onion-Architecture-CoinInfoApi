using System.Threading.Tasks;

namespace Persistence.Contracts
{
    public interface IRepositoryWrapper
    {
        ICoinRepository Coin { get; }
        Task SaveAsync();
    }
}