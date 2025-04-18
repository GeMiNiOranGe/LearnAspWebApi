using System.ComponentModel.DataAnnotations;

namespace LearnAspWebApi.DTOs;

public class EmployeeDto
{
    [Required(ErrorMessage = "Employee id is required.")]
    public required string EmployeeId { get; set; }

    [Required(ErrorMessage = "Employee name is required.")]
    public required string Name { get; set; }

    public DateOnly DateOfBirth { get; set; }
}
