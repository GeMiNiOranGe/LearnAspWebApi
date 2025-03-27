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
}
