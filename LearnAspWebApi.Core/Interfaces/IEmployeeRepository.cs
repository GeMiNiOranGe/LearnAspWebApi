using LearnAspWebApi.Core.Entities;

namespace LearnAspWebApi.Core.Interfaces;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetEmployeesAsync();

    Task<Employee?> GetEmployeeByIdAsync(int id);

    Task<Employee> CreateEmployeeAsync(Employee emp);

    Task UpdateEmployeeAsync(Employee emp);

    Task DeleteEmployeeAsync(Employee emp);
}
