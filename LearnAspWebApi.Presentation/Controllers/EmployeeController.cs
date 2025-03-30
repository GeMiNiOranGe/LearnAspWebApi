using LearnAspWebApi.Core.Entities;
using LearnAspWebApi.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LearnAspWebApi.Presentation.Controllers;

[Route("[controller]")]
[ApiController]
public class EmployeeController(
    ILogger<EmployeeController> logger,
    IEmployeeUseCase useCase
) : ControllerBase
{
    private readonly ILogger<EmployeeController> _logger = logger;
    private readonly IEmployeeUseCase _useCase = useCase;

    [HttpGet(Name = "GetEmployees")]
    public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
    {
        IEnumerable<Employee> accounts = await _useCase.GetEmployeesAsync();
        return Ok(accounts);
    }
}
