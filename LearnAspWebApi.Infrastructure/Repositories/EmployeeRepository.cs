using LearnAspWebApi.Core.Entities;
using LearnAspWebApi.Core.Interfaces;
using LearnAspWebApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LearnAspWebApi.Infrastructure.Repositories;

public class EmployeeRepository(LearnAspWebApiContext context)
    : IEmployeeRepository
{
    private readonly LearnAspWebApiContext _context = context;

    public async Task<IEnumerable<Employee>> GetEmployeesAsync()
    {
        return await (
            from employees in _context.Employees
            select new Employee
            {
                EmployeeId = employees.EmployeeId,
                Name = employees.Name,
                DateOfBirth = employees.DateOfBirth,
            }
        ).ToListAsync();
    }
}
