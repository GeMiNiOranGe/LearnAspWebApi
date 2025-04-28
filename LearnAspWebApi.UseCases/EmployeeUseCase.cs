using AutoMapper;
using LearnAspWebApi.Core.Entities;
using LearnAspWebApi.Core.Interfaces;
using LearnAspWebApi.DTOs;

namespace LearnAspWebApi.UseCases;

public class EmployeeUseCase(IEmployeeRepository repository, IMapper mapper)
    : IEmployeeUseCase
{
    private readonly IEmployeeRepository _repository = repository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<Employee>> GetEmployeesAsync()
    {
        return await _repository.GetEmployeesAsync();
    }

    public async Task<Employee?> GetEmployeeByIdAsync(int id)
    {
        return await _repository.GetEmployeeByIdAsync(id);
    }

    public async Task<Employee> CreateEmployeeAsync(EmployeeDto dto)
    {
        Employee employee = _mapper.Map<Employee>(dto);
        await _repository.CreateEmployeeAsync(employee);
        return employee;
    }

    public async Task<bool> UpdateEmployeeAsync(int id, EmployeeDto dto)
    {
        Employee? employee = await _repository.GetEmployeeByIdAsync(id);
        if (employee == null)
        {
            return false;
        }

        _mapper.Map(dto, employee);

        await _repository.UpdateEmployeeAsync(employee);
        return true;
    }

    public async Task<bool> PatchEmployeeAsync(int id, PatchEmployeeDto dto)
    {
        Employee? employee = await _repository.GetEmployeeByIdAsync(id);
        if (employee == null)
        {
            return false;
        }

        if (!string.IsNullOrWhiteSpace(dto.EmployeeCode))
        {
            employee.EmployeeCode = dto.EmployeeCode;
        }

        if (!string.IsNullOrWhiteSpace(dto.Name))
        {
            employee.Name = dto.Name;
        }

        if (dto.DateOfBirth.HasValue)
        {
            employee.DateOfBirth = dto.DateOfBirth.GetValueOrDefault();
        }

        await _repository.UpdateEmployeeAsync(employee);
        return true;
    }

    public async Task<bool> DeleteEmployeeAsync(int id)
    {
        Employee? employee = await _repository.GetEmployeeByIdAsync(id);
        if (employee == null)
        {
            return false;
        }

        await _repository.DeleteEmployeeAsync(employee);
        return true;
    }
}
