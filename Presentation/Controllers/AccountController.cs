using Core.Entities;
using Core.Interfaces;

using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController(IAccountUseCase useCase) : ControllerBase
{
    private readonly IAccountUseCase _useCase = useCase;

    [HttpGet(Name = "GetAccounts")]
    public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
    {
        return Ok(await _useCase.GetAccountsAsync());
    }

    [HttpGet(Name = "GetAccountById")]
    [Route("{id}")]
    public async Task<ActionResult<Account>> GetAccountById(int id)
    {
        Account? account = await _useCase.GetAccountByIdAsync(id);
        return account == null ? NotFound() : Ok(account);
    }
}
