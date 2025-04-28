using LearnAspWebApi.Core.Entities;
using LearnAspWebApi.DTOs;

namespace LearnAspWebApi.Core.Interfaces;

public interface IEmployeeUseCase
{
    Task<IEnumerable<Employee>> GetEmployeesAsync();

    Task<Employee?> GetEmployeeByIdAsync(int id);

    Task<Employee> CreateEmployeeAsync(EmployeeDto dto);

    Task<bool> UpdateEmployeeAsync(int id, EmployeeDto dto);

    Task<bool> PatchEmployeeAsync(int id, PatchEmployeeDto dto);

    Task<bool> DeleteEmployeeAsync(int id);
}
