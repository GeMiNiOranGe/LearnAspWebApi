using LearnAspWebApi.Core.Entities;
using LearnAspWebApi.Core.Interfaces;

namespace LearnAspWebApi.UseCases;

public class EmployeeUseCase(IEmployeeRepository repository) : IEmployeeUseCase
{
    private readonly IEmployeeRepository _repository = repository;

    public async Task<IEnumerable<Employee>> GetEmployeesAsync()
    {
        return await _repository.GetEmployeesAsync();
    }
}
