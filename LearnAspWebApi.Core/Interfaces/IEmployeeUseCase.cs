using LearnAspWebApi.Core.Entities;

namespace LearnAspWebApi.Core.Interfaces;

public interface IEmployeeUseCase
{
    Task<IEnumerable<Employee>> GetEmployeesAsync();
}
