using LearnAspWebApi.Core.Entities;
using LearnAspWebApi.Core.Interfaces;
using LearnAspWebApi.DTOs;

namespace LearnAspWebApi.UseCases;

public class EmployeeUseCase(IEmployeeRepository repository) : IEmployeeUseCase
{
    private readonly IEmployeeRepository _repository = repository;

    public async Task<IEnumerable<Employee>> GetEmployeesAsync()
    {
        return await _repository.GetEmployeesAsync();
    }

    public async Task<Employee?> GetEmployeeByIdAsync(string id)
    {
        return await _repository.GetEmployeeByIdAsync(id);
    }

    public async Task<Employee> CreateEmployeeAsync(EmployeeDto dto)
    {
        Employee employee = new()
        {
            EmployeeId = dto.EmployeeId,
            Name = dto.Name,
            DateOfBirth = dto.DateOfBirth,
        };
        await _repository.CreateEmployeeAsync(employee);
        return employee;
    }
}
