using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Permission
{
    public Guid ID { get; set; }

    public string Name { get; set; } = null!;

    public string Code { get; set; } = null!;

    public virtual ICollection<RolePermissions> RolePermissions { get; set; } = new List<RolePermissions>();
}
