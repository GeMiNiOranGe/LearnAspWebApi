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

    public async Task<bool> UpdateEmployeeAsync(string id, EmployeeDto dto)
    {
        Employee? employee = await _repository.GetEmployeeByIdAsync(id);
        if (employee == null)
        {
            return false;
        }

        employee.EmployeeId = dto.EmployeeId;
        employee.Name = dto.Name;
        employee.DateOfBirth = dto.DateOfBirth;

        await _repository.UpdateEmployeeAsync(employee);
        return true;
    }

    public async Task<bool> DeleteEmployeeAsync(string id)
    {
        Employee? employee = await _repository.GetEmployeeByIdAsync(id);
        if (employee == null)
        {
            return false;
        }

        await _repository.DeleteEmployeeAsync(employee);
        return true;
    }
}
