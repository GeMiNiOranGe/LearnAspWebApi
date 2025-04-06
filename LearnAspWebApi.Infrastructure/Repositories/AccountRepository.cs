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
        return await (
            from account in _context.Accounts
            select new Account
            {
                AccountId = account.AccountId,
                Username = account.Username,
                Password = account.Password,
                EmployeeId = account.EmployeeId,
            }
        ).ToListAsync();
    }

    public async Task<Account?> GetAccountByIdAsync(int id)
    {
        IQueryable<Account> query =
            from account in _context.Accounts
            where account.AccountId == id
            select new Account
            {
                AccountId = account.AccountId,
                Username = account.Username,
                Password = account.Password,
                EmployeeId = account.EmployeeId,
            };

        return await query.FirstOrDefaultAsync();
    }
}
