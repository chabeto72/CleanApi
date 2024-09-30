using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Rol
{
    public int RolID { get; set; }

    public string RolName { get; set; } = null!;

    public string Code { get; set; } = null!;

    public virtual ICollection<User> User { get; set; } = new List<User>();
}
