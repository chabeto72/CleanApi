using Domain.Entities.Task;
using Domain.Entities.User;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    public class TaskConfiguration
    {
        public TaskConfiguration(EntityTypeBuilder<TaskEntity> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(x => x.TaskID);
            entityTypeBuilder.Property(x => x.Name).IsRequired();
            entityTypeBuilder.Property(x => x.State);
            entityTypeBuilder.Property(x => x.DateTask);
            entityTypeBuilder.Property(x => x.Detail);            
            
            entityTypeBuilder.HasOne(x => x.User).WithMany(x => x.Tasks).HasForeignKey(x => x.UserTask);
        }
    }
}
