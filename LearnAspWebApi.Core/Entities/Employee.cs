namespace LearnAspWebApi.Core.Entities;

public class Employee
{
    public required string EmployeeId { get; set; }

    public required string Name { get; set; }

    public DateOnly DateOfBirth { get; set; }
}
