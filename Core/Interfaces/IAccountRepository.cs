using Core.Entities;

namespace Core.Interfaces;

public interface IAccountRepository
{
    public Task<IEnumerable<Account>> GetAccountsAsync();
}
