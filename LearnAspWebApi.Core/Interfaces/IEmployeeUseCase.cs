using LearnAspWebApi.Core.Entities;
using LearnAspWebApi.DTOs;

namespace LearnAspWebApi.Core.Interfaces;

public interface IEmployeeUseCase
{
    Task<IEnumerable<Employee>> GetEmployeesAsync();

    Task<Employee?> GetEmployeeByIdAsync(string id);

    Task<Employee> CreateEmployeeAsync(EmployeeDto dto);
}
