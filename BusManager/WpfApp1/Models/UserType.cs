using System;
using System.Collections.Generic;

namespace WpfApp1.Models;

public partial class UserType
{
    public int UserTypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public decimal Discount { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
