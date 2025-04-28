namespace LearnAspWebApi.DTOs;

public class PatchEmployeeDto
{
    public string? EmployeeCode { get; set; }

    public string? Name { get; set; }

    public DateOnly? DateOfBirth { get; set; }
}
