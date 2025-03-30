using LearnAspWebApi.Core.Entities;

namespace LearnAspWebApi.Core.Interfaces;

public interface IAccountRepository
{
    Task<IEnumerable<Account>> GetAccountsAsync();

    Task<Account?> GetAccountByIdAsync(int id);
}
