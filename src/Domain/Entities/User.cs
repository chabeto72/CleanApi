using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class User
{
    public int UserID { get; set; }

    public int? RolUser { get; set; }

    public string? Address { get; set; }

    public string FirtsName { get; set; } = null!;

    public string? Email { get; set; }

    public string? NumberDocument { get; set; }

    public bool? Active { get; set; }

    public string? Password { get; set; }

    public virtual Rol? RolUserNavigation { get; set; }

    public virtual ICollection<TaskUser> TaskUser { get; set; } = new List<TaskUser>();
}
