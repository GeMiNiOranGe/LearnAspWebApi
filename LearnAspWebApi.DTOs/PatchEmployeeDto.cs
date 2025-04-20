namespace LearnAspWebApi.DTOs;

public class PatchEmployeeDto
{
    public string? EmployeeId { get; set; }

    public string? Name { get; set; }

    public DateOnly? DateOfBirth { get; set; }
}
