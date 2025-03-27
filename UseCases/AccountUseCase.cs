using Core.Entities;
using Core.Interfaces;

namespace UseCases;

public class AccountUseCase(IAccountRepository repository) : IAccountUseCase
{
    private readonly IAccountRepository _repository = repository;

    public async Task<IEnumerable<Account>> GetAccountsAsync()
    {
        return await _repository.GetAccountsAsync();
    }
}
