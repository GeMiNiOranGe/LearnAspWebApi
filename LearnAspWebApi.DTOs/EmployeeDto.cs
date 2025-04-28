using System.ComponentModel.DataAnnotations;

namespace LearnAspWebApi.DTOs;

public class EmployeeDto
{
    [Required(ErrorMessage = "Employee code is required.")]
    public required string EmployeeCode { get; set; }

    [Required(ErrorMessage = "Employee name is required.")]
    public required string Name { get; set; }

    public DateOnly DateOfBirth { get; set; }
}
