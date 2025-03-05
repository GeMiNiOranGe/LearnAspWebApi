using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string EmployeeId { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
