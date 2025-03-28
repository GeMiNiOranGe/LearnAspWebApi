using Core.Entities;

namespace Core.Interfaces;

public interface IAccountUseCase
{
    Task<IEnumerable<Account>> GetAccountsAsync();

    Task<Account?> GetAccountByIdAsync(int id);
}
