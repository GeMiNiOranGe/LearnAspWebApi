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
        IQueryable<Employee> queryable = _context.Employees.Select(
            employee => new Employee
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                DateOfBirth = employee.DateOfBirth,
            }
        );
        return await queryable.ToListAsync();
    }

    public async Task<Employee?> GetEmployeeByIdAsync(string id)
    {
        IQueryable<Employee> queryable = _context
            .Employees.Where(employee => employee.EmployeeId == id)
            .Select(employee => new Employee
            {
                EmployeeId = employee.EmployeeId,
                Name = employee.Name,
                DateOfBirth = employee.DateOfBirth,
            });
        return await queryable.FirstOrDefaultAsync();
    }

    public async Task CreateEmployeeAsync(Employee emp)
    {
        Models.Employee employee = new()
        {
            EmployeeId = emp.EmployeeId,
            Name = emp.Name,
            DateOfBirth = emp.DateOfBirth,
        };
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();
    }
}
