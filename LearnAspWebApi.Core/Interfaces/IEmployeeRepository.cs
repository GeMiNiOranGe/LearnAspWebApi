using LearnAspWebApi.Core.Entities;

namespace LearnAspWebApi.Core.Interfaces;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetEmployeesAsync();
}
