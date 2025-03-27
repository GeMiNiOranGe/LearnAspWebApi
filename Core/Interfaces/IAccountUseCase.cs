using Core.Entities;

namespace Core.Interfaces;

public interface IAccountUseCase
{
    public Task<IEnumerable<Account>> GetAccountsAsync();
}
