using AutoMapper;
using LearnAspWebApi.Core.Entities;
using LearnAspWebApi.Core.Interfaces;
using LearnAspWebApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LearnAspWebApi.Infrastructure.Repositories;

public class EmployeeRepository(LearnAspWebApiContext context, IMapper mapper)
    : IEmployeeRepository
{
    private readonly LearnAspWebApiContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<Employee>> GetEmployeesAsync()
    {
        IQueryable<Employee> queryable = _context.Employees.Select(employee =>
            _mapper.Map<Employee>(employee)
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
            : _mapper.Map<Employee>(existingEmployee);
    }

    public async Task<Employee> CreateEmployeeAsync(Employee employee)
    {
        Models.Employee newEmployee = _mapper.Map<Models.Employee>(employee);
        _context.Employees.Add(newEmployee);
        await _context.SaveChangesAsync();

        return _mapper.Map<Employee>(newEmployee);
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

        _mapper.Map(employee, existingEmployee);

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
