using System;
using System.Collections.Generic;

namespace WpfApp1.bos;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Name { get; set; }

    public int? RoleId { get; set; }

    public int? UserTypeId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual Role? Role { get; set; }

    public virtual UserType? UserType { get; set; }
}
