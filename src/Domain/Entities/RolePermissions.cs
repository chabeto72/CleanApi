using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class RolePermissions
{
    public Guid ID { get; set; }

    public Guid Rol { get; set; }

    public Guid Permission { get; set; }

    public virtual Permission PermissionNavigation { get; set; } = null!;
}
