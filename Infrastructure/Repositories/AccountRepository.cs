using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class AccountRepository(LearnAspWebApiContext context) : IAccountRepository
{
    private readonly LearnAspWebApiContext _context = context;

    public async Task<IEnumerable<Account>> GetAccountsAsync()
    {
        return await (
            from accounts in _context.Accounts
            select new Account
            {
                AccountId = accounts.AccountId,
                Username = accounts.Username,
                Password = accounts.Password,
                EmployeeId = accounts.EmployeeId,
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
