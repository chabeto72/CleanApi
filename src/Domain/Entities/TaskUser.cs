using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class TaskUser
{
    public Guid TaskID { get; set; }

    public string Name { get; set; } = null!;

    public bool? State { get; set; }

    public DateTime? DateTask { get; set; }

    public string Detail { get; set; } = null!;

    public int? UserTask { get; set; }

    public virtual User? UserTaskNavigation { get; set; }
}
