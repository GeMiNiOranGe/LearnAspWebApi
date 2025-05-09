using LearnAspWebApi.Core.Entities;
using LearnAspWebApi.Core.Interfaces;
using LearnAspWebApi.DTOs;
using Microsoft.AspNetCore.Http;
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
    [ProducesResponseType<Employee>(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
    {
        IEnumerable<Employee> employees = await _useCase.GetEmployeesAsync();
        return Ok(employees);
    }

    [HttpGet("{id}", Name = "GetEmployeeById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Employee>> GetEmployeeById(int id)
    {
        Employee? employee = await _useCase.GetEmployeeByIdAsync(id);
        return employee == null ? NotFound() : Ok(employee);
    }

    [HttpPost(Name = "CreateEmployee")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Employee>> CreateEmployee(EmployeeDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        Employee createdEmployee = await _useCase.CreateEmployeeAsync(dto);
        return CreatedAtRoute(
            "GetEmployeeById",
            new { id = createdEmployee.EmployeeId },
            createdEmployee
        );
    }

    [HttpPut("{id}", Name = "UpdateEmployee")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateEmployee(int id, EmployeeDto dto)
    {
        bool updatedEmployee = await _useCase.UpdateEmployeeAsync(id, dto);
        return updatedEmployee ? NoContent() : NotFound();
    }

    [HttpPatch("{id}", Name = "PatchEmployee")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> PatchEmployee(int id, PatchEmployeeDto dto)
    {
        bool deletedEmployee = await _useCase.PatchEmployeeAsync(id, dto);
        return deletedEmployee ? NoContent() : NotFound();
    }

    [HttpDelete("{id}", Name = "DeleteEmployee")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        bool deletedEmployee = await _useCase.DeleteEmployeeAsync(id);
        return deletedEmployee ? NoContent() : NotFound();
    }
}
