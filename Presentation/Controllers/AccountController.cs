using Core.Entities;
using Core.Interfaces;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController(ILogger<AccountController> logger, IAccountUseCase useCase) : ControllerBase
{
    private readonly ILogger<AccountController> _logger = logger;
    private readonly IAccountUseCase _useCase = useCase;

    [HttpGet(Name = "GetAccounts")]
    public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
    {
        IEnumerable<Account> accounts = await _useCase.GetAccountsAsync();
        return Ok(accounts);
    }

    [HttpGet("{id}", Name = "GetAccountById")]
    public async Task<ActionResult<Account>> GetAccountById(int id)
    {
        Account? account = await _useCase.GetAccountByIdAsync(id);
        return account == null ? NotFound() : Ok(account);
    }
}
