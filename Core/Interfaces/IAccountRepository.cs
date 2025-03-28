using Core.Entities;

namespace Core.Interfaces;

public interface IAccountRepository
{
    Task<IEnumerable<Account>> GetAccountsAsync();

    Task<Account?> GetAccountByIdAsync(int id);
}
