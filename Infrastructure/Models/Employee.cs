using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class Employee
{
    public string EmployeeId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public virtual Account? Account { get; set; }
}
