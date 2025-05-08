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
                EmployeeCode = employee.EmployeeCode,
                Name = employee.Name,
                DateOfBirth = employee.DateOfBirth,
            }
        );
        return await queryable.ToListAsync();
    }

    public async Task<Employee?> GetEmployeeByIdAsync(int id)
    {
        Models.Employee? employee = await _context.Employees.FindAsync(id);
        return employee == null
            ? null
            : new Employee
            {
                EmployeeId = employee.EmployeeId,
                EmployeeCode = employee.EmployeeCode,
                Name = employee.Name,
                DateOfBirth = employee.DateOfBirth,
            };
    }

    public async Task<Employee> CreateEmployeeAsync(Employee emp)
    {
        Models.Employee employee = new()
        {
            EmployeeCode = emp.EmployeeCode,
            Name = emp.Name,
            DateOfBirth = emp.DateOfBirth,
        };
        _context.Employees.Add(employee);
        await _context.SaveChangesAsync();

        return new Employee
        {
            EmployeeId = employee.EmployeeId,
            EmployeeCode = employee.EmployeeCode,
            Name = employee.Name,
            DateOfBirth = employee.DateOfBirth,
        };
    }

    public async Task UpdateEmployeeAsync(Employee emp)
    {
        Models.Employee? employee = await _context.Employees.FindAsync(
            emp.EmployeeId
        );
        if (employee == null)
        {
            return;
        }

        employee.EmployeeCode = emp.EmployeeCode;
        employee.Name = emp.Name;
        employee.DateOfBirth = emp.DateOfBirth;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteEmployeeAsync(Employee emp)
    {
        Models.Employee? employee = await _context.Employees.FindAsync(
            emp.EmployeeId
        );
        if (employee == null)
        {
            return;
        }

        _context.Employees.Remove(employee);
        await _context.SaveChangesAsync();
    }
}
