using LearnAspWebApi.Core.Entities;
using LearnAspWebApi.Core.Interfaces;
using LearnAspWebApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LearnAspWebApi.Infrastructure.Repositories;

public class AccountRepository(LearnAspWebApiContext context)
    : IAccountRepository
{
    private readonly LearnAspWebApiContext _context = context;

    public async Task<IEnumerable<Account>> GetAccountsAsync()
    {
        IQueryable<Account> queryable = _context.Accounts.Select(
            account => new Account
            {
                AccountId = account.AccountId,
                Username = account.Username,
                Password = account.Password,
                EmployeeId = account.EmployeeId,
            }
        );
        return await queryable.ToListAsync();
    }

    public async Task<Account?> GetAccountByIdAsync(int id)
    {
        IQueryable<Account> queryable = _context
            .Accounts.Where(account => account.AccountId == id)
            .Select(account => new Account
            {
                AccountId = account.AccountId,
                Username = account.Username,
                Password = account.Password,
                EmployeeId = account.EmployeeId,
            });
        return await queryable.FirstOrDefaultAsync();
    }
}
