namespace LearnAspWebApi.Core.Entities;

public class Employee
{
    public required int EmployeeId { get; set; }

    public required string EmployeeCode { get; set; }

    public required string Name { get; set; }

    public DateOnly DateOfBirth { get; set; }
}
