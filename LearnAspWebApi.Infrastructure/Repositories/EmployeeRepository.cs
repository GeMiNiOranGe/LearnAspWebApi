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
        Models.Employee? existingEmployee = await _context.Employees.FindAsync(
            id
        );
        return existingEmployee == null
            ? null
            : new Employee
            {
                EmployeeId = existingEmployee.EmployeeId,
                EmployeeCode = existingEmployee.EmployeeCode,
                Name = existingEmployee.Name,
                DateOfBirth = existingEmployee.DateOfBirth,
            };
    }

    public async Task<Employee> CreateEmployeeAsync(Employee employee)
    {
        Models.Employee newEmployee = new()
        {
            EmployeeCode = employee.EmployeeCode,
            Name = employee.Name,
            DateOfBirth = employee.DateOfBirth,
        };
        _context.Employees.Add(newEmployee);
        await _context.SaveChangesAsync();

        return new Employee
        {
            EmployeeId = newEmployee.EmployeeId,
            EmployeeCode = newEmployee.EmployeeCode,
            Name = newEmployee.Name,
            DateOfBirth = newEmployee.DateOfBirth,
        };
    }

    public async Task UpdateEmployeeAsync(Employee employee)
    {
        Models.Employee? existingEmployee = await _context.Employees.FindAsync(
            employee.EmployeeId
        );
        if (existingEmployee == null)
        {
            return;
        }

        existingEmployee.EmployeeCode = employee.EmployeeCode;
        existingEmployee.Name = employee.Name;
        existingEmployee.DateOfBirth = employee.DateOfBirth;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteEmployeeAsync(Employee employee)
    {
        Models.Employee? existingEmployee = await _context.Employees.FindAsync(
            employee.EmployeeId
        );
        if (existingEmployee == null)
        {
            return;
        }

        _context.Employees.Remove(existingEmployee);
        await _context.SaveChangesAsync();
    }
}
