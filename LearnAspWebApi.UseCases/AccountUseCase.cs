using LearnAspWebApi.Core.Entities;
using LearnAspWebApi.Core.Interfaces;

namespace LearnAspWebApi.UseCases;

public class AccountUseCase(IAccountRepository repository) : IAccountUseCase
{
    private readonly IAccountRepository _repository = repository;

    public async Task<IEnumerable<Account>> GetAccountsAsync()
    {
        return await _repository.GetAccountsAsync();
    }

    public async Task<Account?> GetAccountByIdAsync(int id)
    {
        return await _repository.GetAccountByIdAsync(id);
    }
}
